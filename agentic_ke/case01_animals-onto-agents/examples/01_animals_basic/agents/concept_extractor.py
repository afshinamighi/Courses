"""
examples/01_animals_basic/agents/concept_extractor.py
------------------------------------------------------
Agent 1: Concept Extractor

Role    : Identify OWL classes and individuals from raw text.
Input   : Raw text string.
Output  : {"classes": [...], "individuals": [{"name": ..., "type": ...}]}
LLM call: Yes (one call, with retry via core.llm.call_agent)
"""

from core.llm import call_agent
from core.validator import validate_concepts


SYSTEM_PROMPT = """You are an ontology engineer. Your only task is to extract concepts from text.

Return ONLY a JSON object with this exact structure — no explanation, no markdown fences:
{
  "classes": ["ClassName1", "ClassName2"],
  "individuals": [
    {"name": "IndividualName", "type": "ClassName"}
  ]
}

Rules:
- Classes are general categories (use PascalCase, always singular noun — "Dog" not "Dogs")
- Individuals are specific named entities (e.g. "Rex", "Whiskers")
- Every individual's "type" must be one of the class names you listed in "classes"
- Do not invent class names not supported by the text
- If no individuals are mentioned, return an empty list for "individuals"
"""


def extract_concepts(text: str) -> dict:
    """
    Run the Concept Extractor agent on the given text.

    Parameters
    ----------
    text : str
        The source text to extract concepts from.

    Returns
    -------
    dict
        Validated concept dict: {"classes": [...], "individuals": [...]}

    Raises
    ------
    core.llm.AgentOutputError
        If the agent fails to return valid JSON after MAX_RETRIES attempts.
    ValueError
        If the output fails schema validation.
    """
    user_prompt = f"Extract ontology concepts from this text:\n\n{text}"

    result = call_agent(
        system_prompt=SYSTEM_PROMPT,
        user_prompt=user_prompt,
        label="concept_extractor",
    )

    # Validate the output against the expected schema
    validation = validate_concepts(result)
    if not validation.passed:
        raise ValueError(f"Concept extractor output invalid:\n{validation}")

    print(f"  [concept_extractor] classes: {result['classes']}")
    print(f"  [concept_extractor] individuals: {[i['name'] for i in result['individuals']]}")

    return result
