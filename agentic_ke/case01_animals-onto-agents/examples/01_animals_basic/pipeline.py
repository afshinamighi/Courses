"""
examples/01_animals_basic/pipeline.py
--------------------------------------
Example 01: Three-Agent Linear Pipeline

Architecture:
    Text → [Agent 1: Concept Extractor]
         → [Agent 2: Relation Definer]
         → [Agent 3: OWL Builder (programmatic)]
         → animals.owl

Run:
    python examples/01_animals_basic/pipeline.py

Output:
    examples/01_animals_basic/output/animals.owl
"""

import sys
import pathlib

# Make sure project root is on the path so we can import core/ and config/
sys.path.insert(0, str(pathlib.Path(__file__).parent.parent.parent))

import importlib.util, pathlib

def _load(rel_path):
    p = pathlib.Path(__file__).parent / rel_path
    spec = importlib.util.spec_from_file_location(p.stem, p)
    mod  = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(mod)
    return mod

_ce  = _load("agents/concept_extractor.py")
_rd  = _load("agents/relation_definer.py")
_ob  = _load("agents/owl_builder.py")

extract_concepts = _ce.extract_concepts
define_relations  = _rd.define_relations
build_owl         = _ob.build_owl


# ── Source text ───────────────────────────────────────────────────────────────

SOURCE_TEXT = """
Animals can be classified into vertebrates and invertebrates.
Dogs and cats are vertebrates. Dogs are mammals. Cats are also mammals.
Rex is a dog. Whiskers is a cat.
Mammals breathe air. Vertebrates have a spine.
Dogs are loyal animals. Cats are independent animals.
"""


# ── Pipeline ──────────────────────────────────────────────────────────────────

def run_pipeline(text: str = SOURCE_TEXT) -> str:
    """
    Run the three-agent ontology construction pipeline.

    Parameters
    ----------
    text : str
        The source text to extract knowledge from.

    Returns
    -------
    str
        Path to the generated .owl file.
    """
    print("=" * 60)
    print("  EXAMPLE 01 — Animals Basic")
    print("  Three-Agent Linear Pipeline")
    print("=" * 60)
    print(f"\nSource text:\n{text.strip()}\n")
    print("-" * 60)

    # ── Agent 1: Extract classes and individuals ──────────────────────────────
    print("\n[Step 1] Concept Extraction")
    concepts = extract_concepts(text)

    # ── Agent 2: Find relations between classes ───────────────────────────────
    print("\n[Step 2] Relation Definition")
    relations = define_relations(text, concepts)

    # ── Agent 3: Write the OWL file ───────────────────────────────────────────
    print("\n[Step 3] OWL Construction")
    owl_path = build_owl(concepts, relations, filename="animals.owl")

    print("\n" + "=" * 60)
    print(f"  DONE — ontology saved to:\n  {owl_path}")
    print("=" * 60)

    return owl_path


if __name__ == "__main__":
    # Allow passing custom text as a command-line argument
    if len(sys.argv) > 1:
        with open(sys.argv[1]) as f:
            text = f.read()
        run_pipeline(text)
    else:
        run_pipeline()
