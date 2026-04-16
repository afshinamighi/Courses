# onto-agents

> An incremental research project for building OWL ontologies using AI agent pipelines.

---

## What this project is

`onto-agents` is a research sandbox for exploring how large language models can collaborate
as specialized agents to construct, validate, and extend formal OWL knowledge graphs —
starting from unstructured natural language text.

The project is designed to grow gradually. Each example introduces new concepts, a more
complex architecture, or a new domain. Nothing is thrown away: earlier examples remain
runnable and serve as conceptual anchors for later ones.

The central research question is:

> Can a pipeline of LLM agents, each with a narrow and well-defined role, produce
> ontologies that are formally valid, semantically coherent, and practically useful?

---

## Core ideas

### Ontology
A formal, machine-readable representation of knowledge about a domain. In OWL (Web
Ontology Language), knowledge is expressed as classes (categories), individuals (named
instances), and properties (relations between them). OWL is the W3C standard for the
Semantic Web and knowledge graphs.

### Agent
In this project, an agent is an LLM call with:
- a fixed system prompt defining its role
- a structured JSON input contract
- a structured JSON output contract

Each agent does one job. Agents do not improvise outside their contract.

### Pipeline
A directed chain of agents where the output of one becomes the input of the next.
The pipeline is the unit of architecture. Different examples explore different pipeline
topologies: linear, branching, with feedback loops, with human-in-the-loop checkpoints.

### Structured output discipline
Agents always return JSON, never free text. This is the single most important design
decision: it makes agent output composable, testable, and independent of prompt phrasing.

---

## Project structure

```
onto-agents/
│
├── README.md                    ← this file
├── requirements.txt             ← Python dependencies
├── .env.example                 ← environment variable template
│
├── core/                        ← shared utilities used by all examples
│   ├── __init__.py
│   ├── llm.py                   ← LLM call wrapper (structured output, retries)
│   ├── owl_writer.py            ← owlready2 helpers (create class, property, individual)
│   └── validator.py             ← OWL consistency checks
│
├── config/                      ← project-wide configuration
│   └── settings.py              ← model name, temperature, retry policy
│
├── docs/                        ← tutorials and conceptual documentation
│   ├── 00_concepts.md           ← OWL and agent fundamentals (start here)
│   ├── 01_tutorial_basic.md     ← walkthrough of Example 01
│   └── architecture.md          ← architectural patterns used across examples
│
├── prompts/                     ← MASTER PROMPT for project reconstruction
│   └── MASTER_PROMPT.md
│
└── examples/                    ← one subdirectory per example (growing over time)
    │
    └── 01_animals_basic/        ← Example 01: three-agent linear pipeline
        ├── README.md            ← what this example teaches
        ├── pipeline.py          ← the runnable pipeline
        ├── agents/
        │   ├── __init__.py
        │   ├── concept_extractor.py
        │   ├── relation_definer.py
        │   └── owl_builder.py
        └── output/
            └── animals.owl      ← generated ontology (committed for reference)
```

**Future examples (planned)**

| Example | Architecture | New concept introduced |
|---------|-------------|----------------------|
| `02_validation_loop` | Linear + feedback | Validator agent, retry on failure |
| `03_branching_domain` | Branching | Multiple domain agents merge results |
| `04_human_in_loop` | Linear + checkpoint | Human approval before OWL write |
| `05_iterative_refinement` | Cyclic | Agent reads its own output and improves |
| `06_biomedical` | Full pipeline | Domain-specific ontology (SNOMED-adjacent) |

---

## Architectural view

### Example 01 — Linear pipeline (three agents)

```
┌─────────────────────────────────────────────────────────────────┐
│                        INPUT: raw text                          │
└───────────────────────────────┬─────────────────────────────────┘
                                │
                    ┌───────────▼───────────┐
                    │   Agent 1             │
                    │   Concept Extractor   │
                    │                       │
                    │  in:  text            │
                    │  out: {classes,       │
                    │         individuals}  │
                    └───────────┬───────────┘
                                │ JSON
                    ┌───────────▼───────────┐
                    │   Agent 2             │
                    │   Relation Definer    │
                    │                       │
                    │  in:  text + concepts │
                    │  out: {subclass_of,   │
                    │        obj_properties}│
                    └───────────┬───────────┘
                                │ JSON
                    ┌───────────▼───────────┐
                    │   Agent 3             │
                    │   OWL Builder         │
                    │   (programmatic,      │
                    │    no LLM call)       │
                    │                       │
                    │  in:  concepts +      │
                    │       relations       │
                    │  out: .owl file       │
                    └───────────┬───────────┘
                                │
                    ┌───────────▼───────────┐
                    │   OUTPUT: animals.owl │
                    │   (RDF/XML)           │
                    └───────────────────────┘
```

### General pipeline pattern (all examples)

```
Text ──► [Extraction agents] ──► [Reasoning agents] ──► [Builder] ──► OWL
                                        ▲                   │
                                        │                   ▼
                                   [Validator] ◄──── [Consistency check]
```

---

## Getting started

See [docs/00_concepts.md](docs/00_concepts.md) to understand the conceptual foundation,
then [docs/01_tutorial_basic.md](docs/01_tutorial_basic.md) to run Example 01 step by step.

For installation and configuration: see the **Setup** section below.

---

## Setup

### 1. Clone or download the project

```bash
git clone https://github.com/yourname/onto-agents.git
cd onto-agents
```

### 2. Create a Python virtual environment

```bash
python3 -m venv .venv
source .venv/bin/activate        # Linux / macOS
.venv\Scripts\activate           # Windows
```

### 3. Install dependencies

```bash
pip install -r requirements.txt
```

### 4. Configure your API key

```bash
cp .env.example .env
# Edit .env and add your Anthropic API key
```

### 5. Run Example 01

```bash
python examples/01_animals_basic/pipeline.py
```

The generated ontology will be saved to `examples/01_animals_basic/output/animals.owl`.

---

## Design principles

- **One agent, one job.** Agents do not combine concerns. If you find an agent doing two
  things, split it.
- **JSON contracts are sacred.** Every agent input and output is a typed JSON schema.
  Prompt changes must not break the schema.
- **Programmatic when possible.** Once you have structured data, use code — not LLM calls
  — to write the OWL. LLMs handle language; code handles formalism.
- **Examples are additive.** Later examples build on earlier ones. No example is ever
  deleted or replaced.
- **Failures are data.** When an agent returns malformed output, log it. Bad outputs are
  research results, not bugs to hide.

---

## Dependencies

| Library | Purpose |
|---------|---------|
| `anthropic` | Anthropic API client |
| `owlready2` | OWL ontology creation and manipulation |
| `python-dotenv` | Environment variable loading |
| `pydantic` | JSON schema validation for agent contracts |

---

## License

MIT. Research use encouraged.
