"""
config/settings.py
------------------
Central configuration for the onto-agents project.
All examples import from here. Change values here to affect the whole project.
"""

import os
from dotenv import load_dotenv

load_dotenv()

# ── LLM ───────────────────────────────────────────────────────────────────────

# Model used for all agent calls.
# Change here to experiment with different models across the whole project.
MODEL = os.getenv("ONTO_MODEL", "claude-opus-4-5")

# Maximum tokens in the LLM response. 1024 is sufficient for structured JSON.
# Increase if agents produce truncated output.
MAX_TOKENS = int(os.getenv("ONTO_MAX_TOKENS", "1024"))

# Temperature for LLM calls. 0 = deterministic (recommended for structured output).
TEMPERATURE = float(os.getenv("ONTO_TEMPERATURE", "0"))

# How many times to retry a failed agent call before raising an error.
MAX_RETRIES = int(os.getenv("ONTO_MAX_RETRIES", "3"))

# ── Paths ─────────────────────────────────────────────────────────────────────

import pathlib

# Project root — the directory containing this config/ folder
PROJECT_ROOT = pathlib.Path(__file__).parent.parent

# ── Ontology defaults ──────────────────────────────────────────────────────────

# Base IRI for generated ontologies. Append the example name to make it unique.
# e.g. "http://onto-agents.example.org/animals.owl"
ONTOLOGY_BASE_IRI = "http://onto-agents.example.org/"

# Default serialization format for saved OWL files.
# Options: "rdfxml", "ntriples", "turtle" (owlready2 supports all three)
OWL_FORMAT = "rdfxml"
