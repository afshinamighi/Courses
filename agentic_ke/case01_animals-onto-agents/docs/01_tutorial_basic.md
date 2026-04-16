# Tutorial: Example 01 — Animals Basic

This tutorial walks through every line of Example 01.
After reading this, you will understand not just what the code does,
but why each design decision was made.

---

## What Example 01 builds

A three-agent linear pipeline that reads this paragraph:

```
Animals can be classified into vertebrates and invertebrates.
Dogs and cats are vertebrates. Dogs are mammals. Cats are also mammals.
Rex is a dog. Whiskers is a cat.
Mammals breathe air. Vertebrates have a spine.
Dogs are loyal animals. Cats are independent animals.
```

And produces a valid OWL file encoding this knowledge graph:

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

---

## Step 1 — The shared LLM wrapper (`core/llm.py`)

All agent calls go through one function: `call_agent()`. This enforces the project
discipline that every agent call is identical in structure.

```python
def call_agent(system_prompt: str, user_prompt: str) -> dict:
    response = client.messages.create(
        model=settings.MODEL,
        max_tokens=settings.MAX_TOKENS,
        system=system_prompt,
        messages=[{"role": "user", "content": user_prompt}]
    )
    raw = response.content[0].text.strip()
    # strip ```json ... ``` fences if present
    return json.loads(clean_json(raw))
```

**Why a wrapper?** Because:
1. Every agent benefits from fence-stripping (models sometimes wrap JSON in markdown)
2. Retry logic lives here — agents don't need to know about retries
3. Logging and token counting happen in one place

**The fence-stripping problem**: LLMs often return JSON wrapped in markdown code fences
like ` ```json ... ``` `. This is stylistically correct for chat, but breaks `json.loads()`.
The `clean_json()` helper detects and removes these fences.

---

## Step 2 — Agent 1: Concept Extractor

**File:** `examples/01_animals_basic/agents/concept_extractor.py`

**What it does:** Reads raw text and identifies OWL classes and individuals.

**Input:** raw text string

**Output contract:**
```json
{
  "classes": ["Animal", "Vertebrate", "Mammal", "Dog", "Cat", "Invertebrate"],
  "individuals": [
    {"name": "Rex", "type": "Dog"},
    {"name": "Whiskers", "type": "Cat"}
  ]
}
```

**The system prompt strategy:**

The system prompt does three things:
1. Assigns a role (`"You are an ontology engineer"`)
2. Specifies the output schema exactly (as a JSON template in the prompt)
3. States the rules (PascalCase for classes, every individual must have a valid type)

```python
system = """You are an ontology engineer. Extract concepts from text.
Return ONLY a JSON object with this structure — no explanation, no markdown:
{
  "classes": ["ClassName1", ...],
  "individuals": [{"name": "Name", "type": "ClassName"}]
}
Rules:
- Classes are general categories (PascalCase, singular noun)
- Individuals are specific named entities
- Every individual's type must be one of the classes you listed
"""
```

**Why PascalCase?** Because `owlready2` uses the class name as a Python identifier.
`Dog` works; `the dog` does not.

**The type constraint** (`"Every individual's type must be one of the classes"`) is
critical. Without it, the LLM might return `{"name": "Rex", "type": "Canine"}` while
listing `Dog` as the class — a mismatch that would break Agent 3.

---

## Step 3 — Agent 2: Relation Definer

**File:** `examples/01_animals_basic/agents/relation_definer.py`

**What it does:** Reads the original text and the class list from Agent 1, and finds
two kinds of relations: IS-A hierarchies (subclass_of) and named object properties.

**Input:** text + `concepts` dict from Agent 1

**Output contract:**
```json
{
  "subclass_of": [
    {"child": "Dog", "parent": "Mammal"},
    {"child": "Mammal", "parent": "Vertebrate"},
    {"child": "Vertebrate", "parent": "Animal"},
    {"child": "Invertebrate", "parent": "Animal"}
  ],
  "object_properties": [
    {"name": "hasTrait", "domain": "Animal", "range": "Animal"}
  ]
}
```

**The two relation types:**

`subclass_of` encodes taxonomy. `Dog subclass_of Mammal` means:
every Dog IS a Mammal. This is the backbone of the ontology — it enables reasoning.

`object_properties` encode named relations between classes. `hasTrait(Animal, Animal)`
means some Animals have a trait relation to other Animals (imprecise in this example,
but it demonstrates the mechanism).

**The grounding constraint:** The system prompt says `"Only use class names from the
provided list"`. This prevents hallucination of new class names that Agent 3 cannot
resolve. The user message includes `Known classes: [...]` explicitly.

---

## Step 4 — Agent 3: OWL Builder (programmatic)

**File:** `examples/01_animals_basic/agents/owl_builder.py`

**What it does:** Takes the JSON output of Agents 1 and 2 and writes an OWL file
using `owlready2`. This agent makes no LLM call — it is pure Python.

**Why no LLM?** Once you have structured data, use code. An LLM writing RDF/XML
would be unreliable, verbose, and hard to validate. `owlready2` is deterministic.

**The four owlready2 operations:**

```python
# 1. Create the ontology container
onto = get_ontology("http://example.org/animals.owl")

with onto:
    # 2. Create a class (subclass of OWL Thing, the root of everything)
    Dog = type("Dog", (Thing,), {"namespace": onto})

    # 3. Apply a subclass relation
    Dog.is_a.append(Mammal)   # Dog IS-A Mammal

    # 4. Create an object property
    hasTrait = type("hasTrait", (ObjectProperty,), {
        "namespace": onto,
        "domain": [Animal],
        "range": [Animal]
    })

    # 5. Create an individual (named instance)
    Rex = Dog("Rex")   # Rex is an instance of Dog

# 6. Serialize to RDF/XML
onto.save(file="animals.owl", format="rdfxml")
```

**`type()` as a class factory:** Python's built-in `type(name, bases, dict)` creates
a new class at runtime. `owlready2` overrides the metaclass so that creating a class
this way also registers it in the ontology. This is why we can create OWL classes
dynamically from a list of strings.

---

## Step 5 — The pipeline orchestrator

**File:** `examples/01_animals_basic/pipeline.py`

The orchestrator is the simplest possible function: call the agents in sequence,
pass outputs as inputs.

```python
def run_pipeline(text: str) -> str:
    concepts  = agent_extract_concepts(text)         # Agent 1
    relations = agent_define_relations(text, concepts) # Agent 2
    owl_path  = agent_build_owl(concepts, relations)   # Agent 3
    return owl_path
```

**The orchestrator knows nothing about LLMs.** It only knows the sequence and the
data contracts. This is the correct separation of concerns.

---

## Step 6 — Reading the output

Open `output/animals.owl` in [Protégé](https://protege.stanford.edu/) (free, open source)
to browse the ontology visually. You will see:
- The class hierarchy in the left panel
- Individuals listed under their class
- Properties in the Object Properties tab

Or read the RDF/XML directly — the structure maps precisely to what the agents produced.

---

## Common issues and how to fix them

### Agent returns invalid JSON
The `call_agent()` wrapper retries up to `settings.MAX_RETRIES` times. If all retries
fail, it raises `AgentOutputError` with the raw text. Check the system prompt — the
output schema may be ambiguous.

### Individual type not in class list
Agent 1 returned an individual with a type that it did not also list as a class. Add
a validation step in the concept extractor that checks this constraint before returning.
(This is implemented as a post-processing check in `core/validator.py`.)

### owlready2 name collision
`owlready2` uses class names as Python identifiers. If the LLM returns a class name
with spaces or special characters, `owl_builder.py` sanitizes it with `to_identifier()`.

### The .owl file is empty
Most likely `onto.save()` was called outside the `with onto:` context. All class and
property creation must happen inside `with onto:`.
