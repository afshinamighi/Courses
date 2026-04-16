"""
core/owl_writer.py
------------------
Reusable helpers for building OWL ontologies with owlready2.

All examples import from here instead of calling owlready2 directly.
This centralizes the owlready2 API and makes it easy to adapt if the
library changes or if we switch to a different OWL library.
"""

from owlready2 import (
    get_ontology, Thing, ObjectProperty, DataProperty,
    FunctionalProperty, AllDisjoint
)
from config import settings
from core.llm import to_identifier


def create_ontology(name: str):
    """
    Create a new empty OWL ontology.

    Parameters
    ----------
    name : str
        Short name used to construct the ontology IRI.
        Example: "animals" → "http://onto-agents.example.org/animals.owl"

    Returns
    -------
    owlready2.Ontology
    """
    iri = f"{settings.ONTOLOGY_BASE_IRI}{name}.owl"
    return get_ontology(iri)


def add_classes(onto, class_names: list[str]) -> dict:
    """
    Create OWL classes in the ontology.

    Parameters
    ----------
    onto : owlready2.Ontology
        The ontology to add classes to. Must be used inside a `with onto:` block
        by the caller, OR this function opens its own context.
    class_names : list[str]
        List of class names (will be sanitized to valid identifiers).

    Returns
    -------
    dict[str, type]
        Maps original class name → owlready2 class object.

    Notes
    -----
    We use Python's type() to dynamically create classes:
        type(name, bases, dict)
    owlready2 overrides the metaclass so this also registers the class in the ontology.
    (Thing,) as the base means "subclass of OWL Thing", the root of all OWL classes.
    """
    owl_classes = {}
    with onto:
        for name in class_names:
            safe_name = to_identifier(name)
            owl_class = type(safe_name, (Thing,), {"namespace": onto})
            owl_classes[name] = owl_class  # keep original name as key for lookup
    return owl_classes


def add_subclass_relations(onto, owl_classes: dict, subclass_list: list[dict]):
    """
    Apply IS-A (subclass_of) relations between classes.

    Parameters
    ----------
    onto : owlready2.Ontology
    owl_classes : dict
        Maps class name → owlready2 class (from add_classes).
    subclass_list : list[dict]
        Each dict: {"child": str, "parent": str}

    Notes
    -----
    owl_class.is_a is a list of parent classes (and other axioms).
    Appending a class to is_a adds a subClassOf axiom in OWL.
    """
    applied = []
    with onto:
        for rel in subclass_list:
            child  = rel.get("child")
            parent = rel.get("parent")
            if child in owl_classes and parent in owl_classes:
                owl_classes[child].is_a.append(owl_classes[parent])
                applied.append((child, parent))
            else:
                print(f"  [owl_writer] skipped subclass {child} → {parent} (unknown class)")
    return applied


def add_object_properties(onto, owl_classes: dict, prop_list: list[dict]) -> dict:
    """
    Create OWL ObjectProperties (relations between individuals/classes).

    Parameters
    ----------
    onto : owlready2.Ontology
    owl_classes : dict
        Maps class name → owlready2 class.
    prop_list : list[dict]
        Each dict: {"name": str, "domain": str, "range": str}

    Returns
    -------
    dict[str, type]
        Maps property name → owlready2 property class.

    Notes
    -----
    domain restricts WHICH individuals can be the subject of the property.
    range  restricts WHICH individuals can be the object of the property.
    Both are optional in OWL but recommended for documentation.
    """
    owl_props = {}
    with onto:
        for prop in prop_list:
            pname  = to_identifier(prop.get("name", ""))
            domain = prop.get("domain")
            range_ = prop.get("range")
            attrs = {"namespace": onto}
            if domain and domain in owl_classes:
                attrs["domain"] = [owl_classes[domain]]
            if range_ and range_ in owl_classes:
                attrs["range"] = [owl_classes[range_]]
            owl_prop = type(pname, (ObjectProperty,), attrs)
            owl_props[prop.get("name")] = owl_prop
    return owl_props


def add_individuals(onto, owl_classes: dict, individual_list: list[dict]) -> list:
    """
    Create named individuals (instances of classes).

    Parameters
    ----------
    onto : owlready2.Ontology
    owl_classes : dict
        Maps class name → owlready2 class.
    individual_list : list[dict]
        Each dict: {"name": str, "type": str}

    Notes
    -----
    In owlready2, `MyClass("instance_name")` creates a named individual.
    The individual is automatically typed as an instance of MyClass.
    """
    created = []
    with onto:
        for ind in individual_list:
            iname = to_identifier(ind.get("name", ""))
            itype = ind.get("type")
            if itype in owl_classes:
                owl_classes[itype](iname)
                created.append(iname)
            else:
                print(f"  [owl_writer] skipped individual {iname}: unknown type '{itype}'")
    return created


def save_ontology(onto, output_path: str):
    """
    Serialize the ontology to disk in RDF/XML format.

    Parameters
    ----------
    onto : owlready2.Ontology
    output_path : str
        Absolute or relative path to the output .owl file.
    """
    onto.save(file=output_path, format=settings.OWL_FORMAT)
    print(f"  [owl_writer] saved → {output_path}")
