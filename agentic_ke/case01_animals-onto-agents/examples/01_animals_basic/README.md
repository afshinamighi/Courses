# Example 01 — Animals Basic

**Architecture:** Three-agent linear pipeline
**Concepts introduced:** Classes, individuals, subclass_of, ObjectProperty, owlready2 basics

---

## What this example teaches

This is the foundational example. It demonstrates:

1. The agent contract pattern (system prompt + JSON input/output)
2. How to pass data between agents (output of Agent N → input of Agent N+1)
3. The separation of LLM work (agents 1–2) from programmatic work (agent 3)
4. How `owlready2` creates classes, individuals, and properties at runtime
5. Basic OWL structural validation

## Run it

```bash
python examples/01_animals_basic/pipeline.py
```

Or with a custom input file:

```bash
python examples/01_animals_basic/pipeline.py my_text.txt
```

## Output

`output/animals.owl` — an RDF/XML file encoding:

```
owl:Thing
  └── Animal
        ├── Vertebrate
        │     └── Mammal
        │           ├── Dog  →  Rex (individual)
        │           └── Cat  →  Whiskers (individual)
        └── Invertebrate

ObjectProperty: hasTrait (Animal → Animal)
```

## What to try next

- Change `SOURCE_TEXT` in `pipeline.py` to a different domain (plants, vehicles, companies)
- Add a fourth class manually in `SOURCE_TEXT` and check that the agents find it
- Open `output/animals.owl` in [Protégé](https://protege.stanford.edu/) to browse visually
- Read [Example 02](../02_validation_loop/README.md) to see how to add a validation loop

## Files

```
01_animals_basic/
├── README.md               ← this file
├── pipeline.py             ← run this
├── agents/
│   ├── concept_extractor.py   ← Agent 1
│   ├── relation_definer.py    ← Agent 2
│   └── owl_builder.py         ← Agent 3 (no LLM)
└── output/
    └── animals.owl            ← generated ontology
```
