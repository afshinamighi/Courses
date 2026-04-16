# MASTER PROMPT — onto-agents

> Use this prompt to reconstruct the entire project from scratch in a new session,
> or to brief a new collaborator (human or AI) on the full state of the project.
> This document is the single source of truth for project intent, architecture,
> and implementation decisions.

---

## 1. Project identity

**Name:** `onto-agents`
**Language:** Python 3.11+
**Purpose:** A research sandbox for constructing OWL ontologies using pipelines of
LLM agents. Each example in the project is a standalone, runnable pipeline that
introduces new architectural concepts. Examples accumulate — nothing is ever deleted.

**Core research question:**
> Can a pipeline of LLM agents, each with a narrow and well-defined role, produce
> OWL ontologies that are formally valid, semantically coherent, and practically useful?

---

## 2. Technology stack

| Component | Library / Tool | Version |
|-----------|---------------|---------|
| LLM API | `anthropic` | ≥ 0.25 |
| OWL construction | `owlready2` | ≥ 0.46 |
| Schema validation | `pydantic` | ≥ 2.0 |
| Env config | `python-dotenv` | ≥ 1.0 |
| Default model | `claude-opus-4-5` | (configurable) |
| OWL format | RDF/XML | (owlready2 default) |

---

## 3. Directory structure (complete)

```
onto-agents/
│
├── README.md                        ← project overview, architecture, setup
├── requirements.txt                 ← anthropic, owlready2, pydantic, python-dotenv
├── .env.example                     ← ANTHROPIC_API_KEY + optional overrides
│
├── config/
│   └── settings.py                  ← MODEL, MAX_TOKENS, TEMPERATURE, MAX_RETRIES,
│                                       ONTOLOGY_BASE_IRI, OWL_FORMAT, PROJECT_ROOT
│
├── core/
│   ├── __init__.py                  ← re-exports all public symbols
│   ├── llm.py                       ← call_agent(), clean_json(), to_identifier(),
│   │                                   AgentOutputError, get_client()
│   ├── owl_writer.py                ← create_ontology(), add_classes(),
│   │                                   add_subclass_relations(), add_object_properties(),
│   │                                   add_individuals(), save_ontology()
│   └── validator.py                 ← ValidationResult, validate_concepts(),
│                                       validate_relations(), validate_owl()
│
├── docs/
│   ├── 00_concepts.md               ← OWL fundamentals + agent pattern theory
│   ├── 01_tutorial_basic.md         ← line-by-line walkthrough of Example 01
│   └── architecture.md              ← pipeline patterns: linear, feedback, branching,
│                                       human checkpoint, iterative refinement
│
├── prompts/
│   └── MASTER_PROMPT.md             ← THIS FILE
│
└── examples/
    ├── __init__.py
    └── 01_animals_basic/
        ├── README.md                ← what the example teaches, how to run it
        ├── pipeline.py              ← orchestrator: run_pipeline(text) → owl_path
        ├── agents/
        │   ├── __init__.py
        │   ├── concept_extractor.py ← extract_concepts(text) → dict
        │   ├── relation_definer.py  ← define_relations(text, concepts) → dict
        │   └── owl_builder.py       ← build_owl(concepts, relations) → owl_path
        └── output/
            └── animals.owl          ← generated ontology (committed for reference)
```

---

## 4. Core design decisions (and why)

### 4.1 Agents return JSON, never free text
Every agent's system prompt ends with: `"Return ONLY a JSON object — no explanation,
no markdown fences."` This makes agent output composable and testable.
The `clean_json()` helper strips markdown fences if the model adds them anyway.

### 4.2 Retry with self-correction
`call_agent()` retries up to `MAX_RETRIES` times. On retry, the failed response and
the JSON parse error are appended to the conversation so the model can self-correct:
```
user:      [original prompt]
assistant: [malformed output]
user:      "Your response was not valid JSON. Error: ... Please try again."
```

### 4.3 LLM for language, code for formalism
Agents 1 and 2 use LLM calls. Agent 3 uses `owlready2` with no LLM call.
Principle: extract uncertain knowledge with LLMs, produce formal output with code.

### 4.4 Grounding constraint
Agent 2's prompt receives the explicit class list from Agent 1:
`"Known classes (use ONLY these names): [...]"`. This prevents the LLM from hallucinating
new class names that Agent 3 cannot resolve.

### 4.5 Orchestrator knows nothing about LLMs
The `pipeline.py` orchestrator only calls the agent functions and passes their outputs
forward. It has no knowledge of `anthropic`, `owlready2`, or JSON. This enforces
clean separation of concerns.

### 4.6 `to_identifier()` for safe OWL names
`owlready2` uses class names as Python identifiers. `to_identifier()` in `core/llm.py`
converts any LLM-returned string to a valid PascalCase identifier:
`"living organism"` → `"LivingOrganism"`.

### 4.7 Examples accumulate
Each example is a self-contained subdirectory with its own `pipeline.py`, `agents/`,
and `output/`. Later examples import from `core/` but not from earlier examples.
Example numbers are permanent — Example 01 always refers to the animals pipeline.

---

## 5. Agent contracts (Example 01)

### Agent 1 — Concept Extractor

```
Input:   text: str
Output:  {
           "classes":     ["ClassName", ...],
           "individuals": [{"name": "Name", "type": "ClassName"}, ...]
         }
```

Validation rules:
- `classes` is a non-empty list of strings
- every `individual.type` must appear in `classes`

### Agent 2 — Relation Definer

```
Input:   text: str  +  concepts: dict (from Agent 1)
Output:  {
           "subclass_of":       [{"child": str, "parent": str}, ...],
           "object_properties": [{"name": str, "domain": str, "range": str}, ...]
         }
```

Validation rules:
- all class names in output must appear in Agent 1's `classes` list
- no self-loops in `subclass_of`

### Agent 3 — OWL Builder (programmatic)

```
Input:   concepts: dict  +  relations: dict
Output:  path to .owl file (str)
```

No validation failures possible — owlready2 raises exceptions on bad input,
which propagate as Python errors.

---

## 6. Configuration variables

All in `config/settings.py`, all overridable via `.env`:

| Variable | Default | Meaning |
|----------|---------|---------|
| `ANTHROPIC_API_KEY` | (required) | Anthropic API key |
| `ONTO_MODEL` | `claude-opus-4-5` | LLM model for all agent calls |
| `ONTO_MAX_TOKENS` | `1024` | Max tokens in agent response |
| `ONTO_TEMPERATURE` | `0` | 0 = deterministic |
| `ONTO_MAX_RETRIES` | `3` | Retry budget per agent call |
| `ONTOLOGY_BASE_IRI` | `http://onto-agents.example.org/` | IRI prefix for ontologies |
| `OWL_FORMAT` | `rdfxml` | Serialization format |

---

## 7. Key functions reference

### `core/llm.py`

```python
call_agent(system_prompt, user_prompt, label) → dict
    # Call LLM, strip fences, parse JSON, retry on failure

clean_json(text) → str
    # Strip ```json ... ``` fences from LLM output

to_identifier(name) → str
    # "living organism" → "LivingOrganism"

class AgentOutputError(Exception)
    # Raised when agent fails after all retries
```

### `core/owl_writer.py`

```python
create_ontology(name) → owlready2.Ontology
    # IRI = ONTOLOGY_BASE_IRI + name + ".owl"

add_classes(onto, class_names) → dict[str, type]
    # Creates OWL classes; returns {original_name: owl_class}

add_subclass_relations(onto, owl_classes, subclass_list) → list
    # Applies IS-A relations: child.is_a.append(parent)

add_object_properties(onto, owl_classes, prop_list) → dict
    # Creates ObjectProperty with domain and range

add_individuals(onto, owl_classes, individual_list) → list
    # Creates named individuals: MyClass("name")

save_ontology(onto, output_path)
    # onto.save(file=path, format=OWL_FORMAT)
```

### `core/validator.py`

```python
@dataclass
class ValidationResult:
    passed: bool
    errors: list[str]

validate_concepts(data) → ValidationResult
validate_relations(data, known_classes) → ValidationResult
validate_owl(onto) → ValidationResult
```

---

## 8. Planned examples (roadmap)

### Example 02 — Validation Loop
**New concept:** Feedback loop. A Validator agent reads the generated OWL,
checks for structural problems, and sends the pipeline back to Agent 2 for revision
if issues are found. Maximum N retry cycles.

**New agent:** `validator_agent.py`
```
Input:   owl_path: str
Output:  {"valid": bool, "issues": [{"class": str, "problem": str}]}
```

**New architecture:**
```
Agent 1 → Agent 2 → Agent 3 → Validator ──(valid)──► done
                        ▲          │
                        └──(issues)┘  (re-run Agent 2 with error context)
```

### Example 03 — Branching Domain
**New concept:** Parallel agents, merge step.
Two domain-specific agents (e.g. Taxonomic Agent + Behavioral Agent) process the
same text independently. A Merge Agent reconciles their outputs before OWL construction.

### Example 04 — Human in the Loop
**New concept:** Pipeline checkpoint. After Agent 2 defines relations, the pipeline
pauses, saves state to disk, and prints a review request. A separate `resume.py`
command loads the saved state (with optional human edits) and completes the pipeline.

### Example 05 — Iterative Refinement
**New concept:** Self-improvement loop. Agent 3 writes the OWL, Agent 4 reads it
back and suggests improvements (e.g. missing inverse properties, underspecified ranges),
and Agent 3 revises. Continues until quality score ≥ threshold or max iterations.

### Example 06 — Biomedical Domain
**New concept:** Domain-specialized prompt engineering.
Adapts the pipeline for biomedical text, aligning extracted concepts with SNOMED CT
and Gene Ontology class names using a terminology lookup step.

---

## 9. How to reconstruct this project

Given this master prompt and a Python environment, reconstruct the project as follows:

1. Create the directory structure as shown in Section 3.
2. Install dependencies: `pip install anthropic owlready2 pydantic python-dotenv`
3. Set `ANTHROPIC_API_KEY` in `.env`
4. Implement `config/settings.py` exactly as described in Section 6.
5. Implement `core/llm.py` with `call_agent()`, `clean_json()`, `to_identifier()`,
   `AgentOutputError`. Key behaviors: fence stripping, JSON retry with self-correction,
   exponential backoff on API errors.
6. Implement `core/owl_writer.py` with the six functions in Section 7.
   Use `type(name, (Thing,), {"namespace": onto})` for dynamic class creation.
7. Implement `core/validator.py` with `ValidationResult` and the three validators.
8. Implement Example 01:
   - `concept_extractor.py`: system prompt enforces PascalCase, type-must-be-in-classes
   - `relation_definer.py`: system prompt receives explicit class list, enforces grounding
   - `owl_builder.py`: calls owl_writer helpers in sequence, validates, saves
   - `pipeline.py`: calls the three agents in sequence, returns owl_path
9. Run: `python examples/01_animals_basic/pipeline.py`
10. Verify output at `examples/01_animals_basic/output/animals.owl`

---

## 10. Session continuity notes

- This project was initiated in a conversation with Claude (Anthropic).
- The incremental prompt-building methodology used in this session is itself treated
  as a research artifact — see `docs/architecture.md` for the prompt chain reasoning.
- All design decisions in Section 4 emerged from the first working example and should
  be preserved across future sessions.
- When adding a new example, always: (a) assign the next sequential number,
  (b) create its own subdirectory with README, pipeline.py, agents/, output/,
  (c) update the roadmap table in this file and in README.md.
- The master prompt should be updated after each significant session.

---

*Last updated after: Example 01 complete, project structure established.*
*Next session: implement Example 02 (Validation Loop).*
