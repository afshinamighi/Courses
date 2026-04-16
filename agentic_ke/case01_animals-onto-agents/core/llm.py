"""
core/llm.py
-----------
Shared LLM call wrapper used by all agents in all examples.

Every agent call goes through call_agent(). This ensures:
- Consistent retry logic
- JSON fence stripping (models sometimes wrap output in ```json ... ```)
- Token usage logging
- A single place to change the model or API client
"""

import json
import time
import anthropic
from config import settings


# ── Exceptions ────────────────────────────────────────────────────────────────

class AgentOutputError(Exception):
    """Raised when an agent fails to return valid JSON after all retries."""
    pass


# ── Helpers ───────────────────────────────────────────────────────────────────

def clean_json(text: str) -> str:
    """
    Strip markdown code fences from LLM output.

    Models often wrap JSON in ```json ... ``` or ``` ... ```.
    json.loads() cannot parse these fences.

    Example input:
        ```json
        {"classes": ["Dog", "Cat"]}
        ```
    Example output:
        {"classes": ["Dog", "Cat"]}
    """
    text = text.strip()
    if text.startswith("```"):
        lines = text.split("\n")
        # Remove the opening fence (```json or ```)
        lines = lines[1:]
        # Remove the closing fence (```)
        if lines and lines[-1].strip() == "```":
            lines = lines[:-1]
        text = "\n".join(lines).strip()
    return text


def to_identifier(name: str) -> str:
    """
    Convert an arbitrary string to a valid Python/OWL identifier.

    owlready2 uses class names as Python identifiers. Names with spaces,
    hyphens, or special characters must be sanitized.

    Example: "living organism" → "LivingOrganism"
    Example: "has-trait"       → "HasTrait"
    """
    import re
    # Replace non-alphanumeric characters with spaces, then title-case
    cleaned = re.sub(r"[^a-zA-Z0-9 ]", " ", name)
    return "".join(word.capitalize() for word in cleaned.split())


# ── Main wrapper ──────────────────────────────────────────────────────────────

_client = None

def get_client() -> anthropic.Anthropic:
    """Lazily initialize the Anthropic client (reads API key from environment)."""
    global _client
    if _client is None:
        _client = anthropic.Anthropic()
    return _client


def call_agent(
    system_prompt: str,
    user_prompt: str,
    label: str = "agent",
) -> dict:
    """
    Call an LLM agent and return its parsed JSON output.

    Parameters
    ----------
    system_prompt : str
        The agent's role and output contract. Must instruct the model to return
        only JSON with no explanation or markdown fences.
    user_prompt : str
        The data the agent should process (text, class list, etc.)
    label : str
        A human-readable name for this agent call (used in error messages and logs).

    Returns
    -------
    dict
        Parsed JSON output from the agent.

    Raises
    ------
    AgentOutputError
        If the agent fails to return valid JSON after MAX_RETRIES attempts.
    """
    client = get_client()
    last_error = None
    messages = [{"role": "user", "content": user_prompt}]

    for attempt in range(1, settings.MAX_RETRIES + 1):
        try:
            response = client.messages.create(
                model=settings.MODEL,
                max_tokens=settings.MAX_TOKENS,
                temperature=settings.TEMPERATURE,
                system=system_prompt,
                messages=messages,
            )

            raw = response.content[0].text
            cleaned = clean_json(raw)
            result = json.loads(cleaned)

            if attempt > 1:
                print(f"  [{label}] succeeded on attempt {attempt}")

            return result

        except json.JSONDecodeError as e:
            last_error = e
            error_msg = (
                f"Your previous response was not valid JSON. Error: {e}. "
                f"Raw response was:\n{raw}\n\n"
                f"Please try again and return ONLY a valid JSON object."
            )
            # Append the failed response and the error correction request to the
            # conversation, so the model can self-correct on the next attempt.
            messages = [
                {"role": "user",      "content": user_prompt},
                {"role": "assistant", "content": raw},
                {"role": "user",      "content": error_msg},
            ]
            print(f"  [{label}] attempt {attempt} failed: invalid JSON. Retrying...")
            time.sleep(1)  # brief pause before retry

        except anthropic.APIError as e:
            last_error = e
            print(f"  [{label}] attempt {attempt} API error: {e}. Retrying...")
            time.sleep(2 ** attempt)  # exponential backoff

    raise AgentOutputError(
        f"Agent '{label}' failed after {settings.MAX_RETRIES} attempts. "
        f"Last error: {last_error}"
    )
