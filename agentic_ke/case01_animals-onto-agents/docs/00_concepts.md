# Concepts: OWL, Agents, and Knowledge Engineering

This document explains the foundational ideas behind the project.
No prior knowledge of the Semantic Web is assumed.

---

## Part 1 — What is an Ontology?

An ontology is a formal description of a domain of knowledge: what things exist,
what categories they belong to, and how they relate to each other.

The word comes from philosophy (ontology = the study of being), but in computer science
it has a precise technical meaning: a machine-readable model of a domain.

### The three building blocks of OWL

**1. Class** — a category. A class describes a set of things that share properties.

```
Animal
Mammal
Dog
Cat
```

Classes can have subclass relationships (taxonomies):

```
Dog  IS-A  Mammal
Mammal  IS-A  Animal
```

This means: every Dog is a Mammal, and every Mammal is an Animal.
Therefore, by inference, every Dog is also an Animal.

**2. Individual** — a named instance of a class. If `Dog` is the class,
then `Rex` (a specific dog) is an individual.

```
Rex    rdf:type    Dog
Whiskers    rdf:type    Cat
```

**3. Property** — a named relation between things. Properties come in two kinds:

- **ObjectProperty**: relates two individuals (or classes)
  ```
  hasTrait(Dog, Loyalty)     ← a Dog has the trait of Loyalty
  isPartOf(Paw, Dog)         ← a Paw is part of a Dog
  ```
- **DataProperty**: relates an individual to a literal value
  ```
  hasAge(Rex, 3)             ← Rex has age 3 (an integer)
  hasName(Rex, "Rex")        ← Rex has name "Rex" (a string)
  ```

### Why OWL and not just a database?

A database stores facts. An OWL ontology also stores *reasoning rules*. A DL reasoner
(like HermiT or Pellet) can read an ontology and automatically infer new facts:

- You assert: `Rex rdf:type Dog`
- You assert: `Dog subclassOf Mammal`
- The reasoner infers: `Rex rdf:type Mammal` (without you stating this explicitly)

This is the power of ontologies over flat data: **explicit knowledge + reasoning = implicit knowledge**.

---

## Part 2 — OWL in Practice

OWL files are serialized in RDF (Resource Description Framework). The most common
serialization formats are:

| Format | Extension | Readable? | Used for |
|--------|-----------|-----------|---------|
| RDF/XML | `.owl` | No | interchange, storage |
| Turtle | `.ttl` | Yes | authoring, reading |
| Manchester Syntax | `.omn` | Yes | human editing |
| JSON-LD | `.jsonld` | Somewhat | web APIs |

This project uses RDF/XML (the `owlready2` default) for output and Python objects
during construction.

### A minimal OWL file (RDF/XML)

```xml
<?xml version="1.0"?>
<rdf:RDF xmlns:owl="http://www.w3.org/2002/07/owl#"
         xmlns:rdf="http://www.w3.org/1999/02/22-rdf-syntax-ns#"
         xmlns:rdfs="http://www.w3.org/2000/01/rdf-schema#">

  <owl:Ontology rdf:about="http://example.org/animals.owl"/>

  <!-- A class -->
  <owl:Class rdf:about="#Animal"/>

  <!-- A subclass relation -->
  <owl:Class rdf:about="#Dog">
    <rdfs:subClassOf rdf:resource="#Animal"/>
  </owl:Class>

  <!-- An individual -->
  <owl:NamedIndividual rdf:about="#Rex">
    <rdf:type rdf:resource="#Dog"/>
  </owl:NamedIndividual>

</rdf:RDF>
```

---

## Part 3 — What is an Agent (in this project)?

The word "agent" is overloaded. In this project it has a specific, narrow definition:

> An agent is an LLM call with a fixed role, a JSON input contract, and a JSON output
> contract. It does one thing. It knows nothing outside its inputs.

This is intentionally minimal. We are not (yet) building autonomous agents with memory,
tool use, or self-direction. We are building **functional agents**: deterministic
transformations from structured input to structured output, powered by an LLM.

### Why this definition?

Because it makes agents:
- **Testable** — given the same input, we can measure whether the output is correct
- **Composable** — any agent's output can be the input of any other
- **Replaceable** — we can swap one LLM for another without changing the pipeline
- **Debuggable** — when something goes wrong, we know exactly which agent failed

### The agent contract

Every agent in this project has a contract defined by two JSON schemas:

```python
# Input contract (what the agent receives)
{
    "text": str,           # the source text
    "classes": list[str]   # class names from a previous agent
}

# Output contract (what the agent must return)
{
    "subclass_of": list[{"child": str, "parent": str}],
    "object_properties": list[{"name": str, "domain": str, "range": str}]
}
```

The system prompt enforces the output contract. Validation code checks it.
If an agent returns invalid JSON, it is retried (up to N times) before failing.

---

## Part 4 — The Pipeline Pattern

A pipeline is a directed graph of agents. In the simplest case (Example 01), it is
a linear chain:

```
Text → Agent A → Agent B → Agent C → Output
```

More complex pipelines (in later examples) add:

- **Branching**: one agent's output feeds two parallel agents, whose outputs are merged
- **Feedback loops**: a validator agent checks output and sends it back for revision
- **Conditional routing**: the pipeline takes different paths based on agent output
- **Human checkpoints**: the pipeline pauses and waits for human approval

### Data flow discipline

Every edge in the pipeline carries exactly one JSON object.
No agent reads from disk, no agent writes to disk, no agent calls another agent directly.
The orchestrator function is the only entity that moves data between agents.

This separation — agents as pure functions, orchestrator as coordinator — is what makes
the pipeline architecture testable and extensible.

---

## Part 5 — Knowledge Engineering with LLMs

Traditional knowledge engineering (KE) required human experts to manually author
ontologies. This was slow, expensive, and did not scale.

LLMs change the equation in several ways:

| KE task | Traditional approach | LLM agent approach |
|---------|---------------------|-------------------|
| Concept extraction | Manual reading + expert judgment | Concept Extractor agent |
| Taxonomy construction | Expert workshop + Delphi method | Relation Definer agent |
| Axiom authoring | Manchester Syntax by hand | OWL Builder agent |
| Consistency checking | Reasoner (HermiT, Pellet) | Validator agent + reasoner |
| Ontology merging | Manual mapping | Alignment agent (future) |

LLMs are not replacing the human expert — they are accelerating the first pass. The human
expert's role shifts from authoring to reviewing, correcting, and approving.

### The core tension

LLMs are probabilistic. OWL reasoning is deterministic. The pipeline must bridge this gap:
- Extract flexible, natural-language knowledge with LLMs
- Convert it to rigid, formal OWL with code
- Validate the formal output with a reasoner
- Loop back if validation fails

This is the architectural challenge that drives all the design decisions in this project.

---

## Further reading

- [OWL 2 Web Ontology Language Primer (W3C)](https://www.w3.org/TR/owl2-primer/)
- [owlready2 documentation](https://owlready2.readthedocs.io/)
- [Protégé ontology editor](https://protege.stanford.edu/) — visual OWL tool
- [HermiT reasoner](http://www.hermit-reasoner.com/)
