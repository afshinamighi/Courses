"""
examples/01_animals_basic/agents/relation_definer.py
-----------------------------------------------------
Agent 2: Relation Definer

Role    : Identify subclass (IS-A) relations and object properties between classes.
Input   : Raw text + list of known classes from Agent 1.
Output  : {"subclass_of": [...], "object_properties": [...]}
LLM call: Yes (one call, with retry via core.llm.call_agent)
"""

from core.llm import call_agent
from core.validator import validate_relations


SYSTEM_PROMPT = """You are an ontology engineer. Your only task is to define relations between classes.

Return ONLY a JSON object with this exact structure — no explanation, no markdown fences:
{
  "subclass_of": [
    {"child": "ChildClass", "parent": "ParentClass"}
  ],
  "object_properties": [
    {"name": "propertyName", "domain": "ClassName", "range": "ClassName"}
  ]
}

Rules:
- subclass_of expresses IS-A hierarchies: "child IS-A parent"
  Example: Dog IS-A Mammal → {"child": "Dog", "parent": "Mammal"}
- object_properties are named relations between two classes (use camelCase for names)
  Example: Dog hasTrait Loyalty → {"name": "hasTrait", "domain": "Dog", "range": "Loyalty"}
- ONLY use class names from the list provided in the user message
- Do not invent new class names
- A class may have multiple parents (multiple subclass_of entries with the same child)
- If no object properties are found, return an empty list for "object_properties"
"""


def define_relations(text: str, concepts: dict) -> dict:
    """
    Run the Relation Definer agent on the given text and concept list.

    Parameters
    ----------
    text : str
        The original source text (passed again so the agent has full context).
    concepts : dict
        Output from Agent 1: {"classes": [...], "individuals": [...]}

    Returns
    -------
    dict
        Validated relations dict: {"subclass_of": [...], "object_properties": [...]}

    Raises
    ------
    core.llm.AgentOutputError
        If the agent fails to return valid JSON after MAX_RETRIES attempts.
    ValueError
        If the output fails schema validation.
    """
    known_classes = concepts["classes"]

    user_prompt = (
        f"Text:\n{text}\n\n"
        f"Known classes (use ONLY these names): {known_classes}\n\n"
        f"Define all subclass_of and object_property relations you can find in the text."
    )

    result = call_agent(
        system_prompt=SYSTEM_PROMPT,
        user_prompt=user_prompt,
        label="relation_definer",
    )

    # Validate that all class names in the output are from the known list
    validation = validate_relations(result, known_classes)
    if not validation.passed:
        raise ValueError(f"Relation definer output invalid:\n{validation}")

    for rel in result.get("subclass_of", []):
        print(f"  [relation_definer] subclass: {rel['child']} → {rel['parent']}")
    for prop in result.get("object_properties", []):
        print(f"  [relation_definer] property: {prop['domain']} --[{prop['name']}]--> {prop['range']}")

    return result
