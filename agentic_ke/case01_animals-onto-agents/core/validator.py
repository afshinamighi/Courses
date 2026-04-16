"""
core/validator.py
-----------------
Validation functions for agent output and OWL ontologies.

Two levels of validation:
1. Schema validation  — check that agent JSON output matches the expected contract
2. OWL validation     — check that the ontology is internally consistent

Both return a ValidationResult with a pass/fail flag and a list of error messages.
"""

from dataclasses import dataclass, field


# ── Result type ───────────────────────────────────────────────────────────────

@dataclass
class ValidationResult:
    passed: bool
    errors: list[str] = field(default_factory=list)

    def __str__(self):
        if self.passed:
            return "PASSED"
        return "FAILED:\n" + "\n".join(f"  - {e}" for e in self.errors)


# ── Schema validators (Agent output) ─────────────────────────────────────────

def validate_concepts(data: dict) -> ValidationResult:
    """
    Validate the output of Agent 1 (Concept Extractor).

    Checks:
    - 'classes' is a non-empty list of strings
    - 'individuals' is a list of dicts with 'name' and 'type' keys
    - Every individual's 'type' is present in 'classes'
    """
    errors = []

    classes = data.get("classes", [])
    if not isinstance(classes, list) or not classes:
        errors.append("'classes' must be a non-empty list")
    if not all(isinstance(c, str) for c in classes):
        errors.append("All entries in 'classes' must be strings")

    individuals = data.get("individuals", [])
    if not isinstance(individuals, list):
        errors.append("'individuals' must be a list")
    else:
        for i, ind in enumerate(individuals):
            if not isinstance(ind, dict):
                errors.append(f"individuals[{i}] must be a dict")
                continue
            if "name" not in ind:
                errors.append(f"individuals[{i}] missing 'name'")
            if "type" not in ind:
                errors.append(f"individuals[{i}] missing 'type'")
            elif ind["type"] not in classes:
                errors.append(
                    f"individuals[{i}] type '{ind['type']}' not found in classes. "
                    f"Known classes: {classes}"
                )

    return ValidationResult(passed=len(errors) == 0, errors=errors)


def validate_relations(data: dict, known_classes: list[str]) -> ValidationResult:
    """
    Validate the output of Agent 2 (Relation Definer).

    Checks:
    - 'subclass_of' entries reference known class names
    - 'object_properties' entries have name, domain, and range
    - No self-loops in subclass_of (Dog subclassOf Dog)
    """
    errors = []

    for i, rel in enumerate(data.get("subclass_of", [])):
        child  = rel.get("child")
        parent = rel.get("parent")
        if child not in known_classes:
            errors.append(f"subclass_of[{i}].child '{child}' not in known classes")
        if parent not in known_classes:
            errors.append(f"subclass_of[{i}].parent '{parent}' not in known classes")
        if child == parent:
            errors.append(f"subclass_of[{i}]: self-loop detected ({child} → {parent})")

    for i, prop in enumerate(data.get("object_properties", [])):
        if not prop.get("name"):
            errors.append(f"object_properties[{i}] missing 'name'")
        domain = prop.get("domain")
        range_ = prop.get("range")
        if domain and domain not in known_classes:
            errors.append(f"object_properties[{i}].domain '{domain}' not in known classes")
        if range_ and range_ not in known_classes:
            errors.append(f"object_properties[{i}].range '{range_}' not in known classes")

    return ValidationResult(passed=len(errors) == 0, errors=errors)


# ── OWL consistency check ─────────────────────────────────────────────────────

def validate_owl(onto) -> ValidationResult:
    """
    Run a basic consistency check on the generated OWL ontology.

    Note: Full DL reasoning (HermiT/Pellet) is not invoked here.
    This is a structural check using owlready2's built-in facilities.

    For full reasoning, use owlready2.sync_reasoner() — but that requires
    Java and a reasoner JAR to be installed separately.
    """
    errors = []

    try:
        classes = list(onto.classes())
        individuals = list(onto.individuals())
        properties = list(onto.object_properties())

        if not classes:
            errors.append("Ontology contains no classes")

        # Check for cycles in the class hierarchy (simple depth-limited check)
        for cls in classes:
            ancestors = set()
            queue = list(cls.is_a)
            depth = 0
            while queue and depth < 50:
                parent = queue.pop(0)
                if hasattr(parent, "name"):
                    if parent.name == cls.name:
                        errors.append(f"Cycle detected: {cls.name} is its own ancestor")
                        break
                    if parent.name not in ancestors:
                        ancestors.add(parent.name)
                        queue.extend(parent.is_a)
                depth += 1

        print(f"  [validator] {len(classes)} classes, {len(individuals)} individuals, "
              f"{len(properties)} object properties")

    except Exception as e:
        errors.append(f"OWL validation error: {e}")

    return ValidationResult(passed=len(errors) == 0, errors=errors)
