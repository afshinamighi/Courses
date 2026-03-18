# Master Prompt: Statistical Interpretation Report

## Purpose

You are generating a structured statistical interpretation document for the survey
"Software Engineering in the Era of Generative AI" (Rotterdam area, 2025).

You will receive one input file:
- `./output/statistical_analysis.md` — the complete statistical analysis output
  produced by the Jupyter notebook, containing frequency tables, Wilson CIs, Shannon
  entropy, chi-squared results, ordinal means, bootstrap CIs, and positive percentages
  for all questions.

You will also receive the cross-analysis results from the notebook output for:
- Q03 × Q09, Q03 × Q10, Q03 × Q11 (organisation size cross-analysis)
- Q05 × Q14, Q05 × Q16 (educational background cross-analysis)

Your output is a single Markdown file: `./output/statistical_interpretations.md`

---

## Research Context

The survey investigates how generative AI (GenAI) is reshaping software development
practice and what this means for the skill requirements of future developers. It was
distributed among ICT professionals at 100+ companies in and around Rotterdam, the
Netherlands (July–November 2025), and collected 31 anonymous responses via offline
questionnaire. The overarching research goal is to inform curriculum design at Dutch
Universities of Applied Sciences (HBO Hogescholen).

The respondent profile is senior and experience-heavy: 45% have more than 10 years of
experience; 52% are team leads or managers; every respondent works in an organisation
that at minimum permits GenAI tool use; 84% use GenAI tools daily.

---

## Output Structure

Generate one interpretation entry per question (Q01–Q23, excluding Q15), followed by
one interpretation entry per cross-analysis. Use the following structure for every
entry. Do not skip any question or cross-analysis.
```markdown
## QXX — [Label]

### Observation
[What the data shows: dominant answer or rating, distribution shape, notable
 absences or concentrations. For scaling questions describe the tier structure
 (which items cluster together). For open questions describe the thematic patterns
 across responses without quoting raw text directly.]

### Statistical Support
[Cite the specific numbers that support the observation: dominant category %,
 Wilson CI lower bound, entropy value and its interpretation (near 0 = consensus,
 near 1 = spread), χ² result and significance for categorical questions,
 ordinal means and bootstrap CIs for scaling questions, effect sizes for
 cross-analyses. For scaling questions identify the highest and lowest items
 by mean and by positive%. Be precise: cite actual values from the input file.]

### Interpretation
[What this finding means in the context of GenAI adoption in software engineering
 and, where applicable, for future skill requirements. Connect to other questions
 where the relationship is substantive (e.g., Q11 failure rates motivate Q14 skill
 priorities; Q10 security utility gap connects to Q17 security challenge). Identify
 mechanisms, not just patterns.]

### Limitation
[Note methodological caveats: n=31 overall (wide CIs); self-selection bias (daily
 GenAI users may not represent all practitioners); regional scope (Rotterdam-area
 Dutch ICT companies); question-specific issues such as forced-choice constraints,
 ambiguous category boundaries, ordinal-to-numeric mapping assumptions, or
 open-ended response rate variation.]
```

---

## Cross-Analysis Entries

After all individual question entries, generate one entry per cross-analysis using
this structure:
```markdown
## Cross-Analysis: [Grouping Variable] × [Outcome Question(s)]

### Groups and Sample Sizes
[State the grouping variable, how groups were defined, and n per group.]

### Statistical Overview
[State which comparisons reached p < 0.05 and which did not. Name the tests used
 (Fisher's exact / Mann–Whitney U) and effect-size measures (Cramér's V / Cohen's d).
 State clearly: non-significant results at these group sizes are treated as directional
 hypotheses, not confirmed population differences.]

### Key Findings
[For each comparison worth discussing: state the direction, the effect size, the
 p-value, and the substantive interpretation. For significant findings state this
 explicitly. For non-significant findings with large effect sizes explain why they are
 still worth noting.]

### Cross-Question Coherence
[Connect the cross-analysis pattern to findings from the individual question analyses.
 Explain whether the cross-analysis confirms, extends, or complicates the aggregate
 findings.]

### Limitation
[Group sizes, power considerations, directionality of effect-size interpretation,
 any confounds between the grouping variable and other variables in the data.]
```

---

## Tone and Style Requirements

- Write in clear, precise academic prose. No bullet points inside the Observation or
  Interpretation paragraphs — these must be continuous prose.
- Statistical values are always cited in parentheses inline: e.g.,
  "the dominant category (83.9%, CI [0.674, 0.929])" or "mean 3.66 (95% CI [3.35, 3.90])".
- Do not use hedge language where the data is clear. Do not overclaim where the data
  is uncertain or the sample is small.
- For each question connect forward or backward to at least one other question where
  a substantive relationship exists.
- For cross-analyses: be explicit about which findings are statistically confirmed and
  which are directional patterns only.
- Total length: approximately 300–500 words per question entry, 400–600 words per
  cross-analysis entry.

---

## Output File

Write the complete interpretation document to: `./output/statistical_interpretations.md`

File header:
```markdown
# Statistical Interpretations: Software Engineering in the Era of Generative AI
## Survey Data — Rotterdam Area, The Netherlands, 2025

*Generated from: statistical_analysis.md and cross-analysis notebook outputs*
*Research context: HBO curriculum design for the generative AI era*

---
```

After writing, print: `"Exported: ./output/statistical_interpretations.md — {n} entries written"`
