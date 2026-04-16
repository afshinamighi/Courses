"""
examples/01_animals_basic/agents/owl_builder.py
------------------------------------------------
Agent 3: OWL Builder

Role    : Convert structured concept and relation data into a valid OWL file.
Input   : concepts dict (from Agent 1) + relations dict (from Agent 2).
Output  : Path to the saved .owl file.
LLM call: NO — this agent is purely programmatic (owlready2).

Design note:
    Once data is structured, use code — not an LLM — to produce formal output.
    owlready2 is deterministic and validated. An LLM writing RDF/XML would not be.
"""

import pathlib
from core.owl_writer import (
    create_ontology, add_classes, add_subclass_relations,
    add_object_properties, add_individuals, save_ontology
)
from core.validator import validate_owl

# Output directory for this example
OUTPUT_DIR = pathlib.Path(__file__).parent.parent / "output"


def build_owl(concepts: dict, relations: dict, filename: str = "animals.owl") -> str:
    """
    Build and save an OWL ontology from structured concept and relation data.

    Parameters
    ----------
    concepts : dict
        Output from Agent 1: {"classes": [...], "individuals": [...]}
    relations : dict
        Output from Agent 2: {"subclass_of": [...], "object_properties": [...]}
    filename : str
        Name of the output .owl file (saved in the example's output/ directory).

    Returns
    -------
    str
        Absolute path to the saved .owl file.
    """
    OUTPUT_DIR.mkdir(parents=True, exist_ok=True)
    output_path = str(OUTPUT_DIR / filename)

    # Extract the ontology name from the filename (strip .owl)
    onto_name = filename.replace(".owl", "")
    onto = create_ontology(onto_name)

    # Step 1: Create all classes
    print(f"  [owl_builder] creating {len(concepts['classes'])} classes")
    owl_classes = add_classes(onto, concepts["classes"])

    # Step 2: Apply subclass relations
    applied = add_subclass_relations(onto, owl_classes, relations.get("subclass_of", []))
    print(f"  [owl_builder] applied {len(applied)} subclass relations")

    # Step 3: Create object properties
    props = add_object_properties(onto, owl_classes, relations.get("object_properties", []))
    print(f"  [owl_builder] created {len(props)} object properties")

    # Step 4: Create individuals
    created = add_individuals(onto, owl_classes, concepts.get("individuals", []))
    print(f"  [owl_builder] created {len(created)} individuals")

    # Step 5: Validate before saving
    result = validate_owl(onto)
    if not result.passed:
        print(f"  [owl_builder] WARNING: OWL validation issues:\n{result}")
    else:
        print(f"  [owl_builder] OWL validation passed")

    # Step 6: Save
    save_ontology(onto, output_path)

    return output_path
