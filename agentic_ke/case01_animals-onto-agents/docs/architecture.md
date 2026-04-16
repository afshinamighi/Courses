# Architecture Patterns

This document describes the pipeline architectures used across examples,
and the principles for choosing between them.

---

## Pattern 1 — Linear pipeline (Example 01)

Each agent receives output from exactly one predecessor. No branching, no loops.

```
A → B → C → Output
```

**Use when:** The task can be decomposed into strictly sequential sub-tasks.
Each stage adds structure to the data without needing to reconsider earlier stages.

**Limitation:** No error recovery. If Agent B fails, the pipeline fails.

---

## Pattern 2 — Linear with feedback loop (Example 02, planned)

A validator agent reads the output of the last stage and decides whether to accept it
or send it back for revision.

```
A → B → C → Validator ──(pass)──► Output
                  │
                  └──(fail)──► B (retry with error context)
```

**Use when:** Output quality is measurable (e.g., OWL consistency) and the cost of
a retry is acceptable. This is the pattern for "self-healing" pipelines.

**Key design question:** What does the validator pass back? It should return a structured
error report, not free text — so the upstream agent can parse and act on it.

---

## Pattern 3 — Branching and merge (Example 03, planned)

One input is processed by multiple parallel agents. Their outputs are merged by a
dedicated merge agent.

```
          ┌── Domain Agent A ──┐
Input ────┤                    ├──► Merge Agent ──► Output
          └── Domain Agent B ──┘
```

**Use when:** Different aspects of the input require different expertise (e.g., one agent
handles taxonomic relations, another handles causal relations).

**Key design question:** What is the merge agent's contract? It must handle conflicts
between the two input streams (e.g., both agents found the same class under different names).

---

## Pattern 4 — Human checkpoint (Example 04, planned)

The pipeline pauses at a defined point and presents its intermediate output to a human
for review. The human can approve, reject, or edit before the pipeline continues.

```
A → B → [CHECKPOINT: human review] → C → Output
```

**Use when:** The cost of a downstream error is high and LLM confidence is low.
For example, before writing an ontology that will be loaded into a production system.

**Implementation:** The checkpoint saves state to disk and exits. A separate "resume"
command loads the saved state, incorporates human edits, and continues.

---

## Pattern 5 — Iterative refinement (Example 05, planned)

The final agent reads its own output and produces an improved version. This continues
until a quality threshold is reached or a maximum number of iterations is hit.

```
A → B → C ──► [quality check] ──(sufficient)──► Output
          ▲           │
          └───────────┘ (insufficient → re-run C with previous output as context)
```

**Use when:** Quality improves with iteration and you have a measurable quality signal.

---

## Agent design principles

### The single-responsibility rule
Each agent has one job. If you find yourself tempted to add a second task to an agent
("...and also check for duplicates"), create a new agent instead.

### The closed-world input rule
An agent only knows what is in its input JSON. It has no access to the original text
unless that text is explicitly passed to it. This prevents implicit context leakage.

### The grounding rule
When an agent produces names (class names, property names), those names must be
verifiable against a list provided in the input. If grounding is not enforced in the
prompt, agents will hallucinate plausible-sounding but unresolvable names.

### The retry budget
Every agent call should have a retry budget (default: 3 attempts). On retry, append
the previous error to the user message so the agent can self-correct.

### The separation of LLM and code
LLMs handle natural language → structured data. Code handles structured data → formal
output. Never ask an LLM to write RDF/XML or SPARQL directly — use owlready2 or
a SPARQL builder instead.
