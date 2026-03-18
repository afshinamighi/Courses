This file contains the detailed prompt for set up, configuration and code generation.

# Master Prompt: Code Generation
## Survey: Software Engineering in the Era of Generative AI

### Context

You are generating a complete, production-ready Jupyter notebook for analysing a survey
titled "Software Engineering in the Era of Generative AI", conducted among ICT
professionals at companies in the Rotterdam area, Netherlands (July–November 2025).
The purpose of the analysis is to understand skill requirements for future software
developers in the era of generative AI, with the goal of informing curriculum design
at Dutch Universities of Applied Sciences (HBO).

The dataset is an Excel file: `Survey_SoftwareDevelopmentInEraGenAI_polished.xlsx`
located at `./data/`.

---

### Output Format Requirements

Generate code as a Jupyter notebook. Each numbered step below maps to exactly one
notebook cell. Do not merge steps. Do not split a step across multiple cells. Each
cell must be independently runnable after all preceding cells have been executed.

**Code Architecture Rules (mandatory):**
- No duplicated logic. Every repeated operation must be extracted into its own small
  function and called wherever needed.
- Each function does one thing. Parsing functions must not render charts. Statistical
  functions must not print reports.
- Private helpers are prefixed with `_`. Functions not intended to be called directly
  from a notebook cell use a leading underscore.
- No hardcoded repetition. Values, colours, and labels appearing more than once are
  defined as constants.
- Parameters over copy-paste. Functions differing only in a parameter are unified into
  one parametrised function.

---

### Dataset Structure

| Element | Description |
|---|---|
| Sheet `complete` | Full dataset: all questions per respondent |
| Sheets `Q01`–`Q23` | One sheet per question (Q15 is empty — skip it) |
| First column (all sheets) | Respondent ID |
| Second column (Q01–Q09, Q11–Q13, Q16–Q23) | Row 1 = question title; rows 2+ = responses |
| Sheets Q10, Q14 | Scaling questions: row 1 = title; row 2 col 2+ = item labels; data from row 3 col 2+ |
| Empty cells | No answer — treat as missing |
| Semicolons in cells | Multiple selections separated by `;` with trailing `;` — split and discard empty strings |

---

### Question Registry

| QID | Type | Label | Notes |
|-----|------|-------|-------|
| Q01 | multi | Primary role in software development | |
| Q02 | single | Years of experience | Order: `< 1 year` → `1 - 3 years` → `4 - 6 years` → `7 - 10 years` → `> 10 years` |
| Q03 | single | Organisation size | Order: `Startup (1-10 employees)` → `Small (11-50 employees)` → `Medium Business (51-100 employees)` → `Large Enterprise (100+ employees)` |
| Q04 | multi | Primary programming languages | |
| Q05 | single | Highest education level (Dutch system) | |
| Q06 | single | Highest academic qualification | Order: `Associate degree` → `Bachelor's degree (BSc, BA, etc.)` → `Master's degree (MSc, MA, etc.)` → `PhD (Doctorate)` |
| Q07 | single | Organisation's stance on AI tools | |
| Q08 | single | Frequency of GenAI tool usage | Order: `Rarely (a few times a month)` → `Occasionally (a few times a week)` → `Regularly (daily or almost daily)` |
| Q09 | multi | Tasks where GenAI is used | |
| Q10 | scaling | Usefulness of GenAI per task | Scale: SCALE_USEFULNESS |
| Q11 | multi | Common issues experienced with GenAI | |
| Q12 | single | Estimated % of AI-assisted work (5 yrs) | Order: `21% - 40%` → `41 % - 60 %` → `61 % - 80 %` → `More than 80 %` |
| Q13 | multi | SDLC phases GenAI will take over | |
| Q14 | scaling | Expected change in skill importance | Scale: SCALE_IMPORTANCE_CHANGE |
| Q15 | — | Empty — skip entirely | |
| Q16 | multi | Most essential skills for future developers | |
| Q17 | multi | Main challenges in AI-assisted development | |
| Q18 | single | Trust in AI-generated code without review | Order: `Not at all` → `Somewhat` → `Mostly` |
| Q19 | single | Will AI replace traditional development roles? | |
| Q20 | single | AI impact on junior developer learning curve | |
| Q21 | open | Greatest risk of heavy reliance on AI-generated code | |
| Q22 | open | How hiring will change with mainstream AI tools | |
| Q23 | open | Additional comments on AI in software development | |

---

### Scale Definitions (define as constants)

**SCALE_USEFULNESS** (Q10):
- `order`: `["Not Useful", "Somewhat Useful", "Very Useful", "Essential"]`
- `na`: `"Not Applicable"` — exclude from % calculations, report as separate count
- `colors`: `["#C44E52", "#DD8452", "#4C72B0", "#2A6099"]`

**SCALE_IMPORTANCE_CHANGE** (Q14):
- `order`: `["Decreasing in Importance", "No Change", "Slightly Increasing", "Strongly Increasing"]`
- `na`: `None`
- `colors`: `["#C44E52", "#8C8C8C", "#55A868", "#2A6099"]`

---

### Visual Style Constants (define in Cell 2, reference everywhere — never duplicate)

| Constant | Value |
|---|---|
| `BG_COLOR` | `"#F7F9FC"` |
| `TITLE_COLOR` | `"#2C3E50"` |
| `FOOTNOTE_COLOR` | `"#7F8C8D"` |
| `GRID_COLOR` | `"#D5DCE8"` |
| `SPINE_COLOR` | `"#C0C8D4"` |
| `AXIS_LBL_COLOR` | `"#5A6475"` |
| `PALETTE` | 10-colour list: `["#4C72B0","#DD8452","#55A868","#C44E52","#8172B3","#937860","#DA8BC3","#8C8C8C","#CCB974","#64B5CD"]` |

---

### Cell Structure

#### Cell 1 — Imports
Import only. No application code.
Required: `pandas`, `numpy`, `matplotlib.pyplot`, `matplotlib.patches`,
`matplotlib.ticker`, `textwrap`, `collections.Counter`, `scipy.stats.chisquare`,
`scipy.stats.fisher_exact`, `scipy.stats.mannwhitneyu`.

#### Cell 2 — Configuration and Constants
All global constants only. No functions.
Define: `FILE_PATH`, `SHEETS` (empty dict), `BG_COLOR`, `TITLE_COLOR`,
`FOOTNOTE_COLOR`, `GRID_COLOR`, `SPINE_COLOR`, `AXIS_LBL_COLOR`, `PALETTE`,
`SCALE_USEFULNESS`, `SCALE_IMPORTANCE_CHANGE`, `QUESTION_REGISTRY`.

`QUESTION_REGISTRY` entry structure:
```python
"QXX": {
    "type":  "single" | "multi" | "scaling" | "open",
    "label": "Short human-readable label",
    "order": [...],    # optional: enforced display order
    "scale": {...},    # required for scaling type only
}
```
Include all 22 active questions (Q01–Q23 excluding Q15).

#### Cell 3 — Data Loading and Parsing Helpers
Define and immediately call `load_data(path) -> dict` at end of cell.
Functions:
- `load_data(path)` — reads Excel, updates `SHEETS` in-place (`.update()`), returns dict, prints sheet names
- `_split_choices(cell_value)` — splits semicolon-delimited cell into clean list, discards empty strings
- `_get_responses(qid)` — returns raw response Series (col 1, rows 2+), dropna, cast to str
- `get_standard_question(qid)` — returns DataFrame `[id, response]`
- `get_scaling_question(qid)` — returns DataFrame (id as index, items as columns), cleans `\xa0` from labels
- `get_multichoice(qid)` — extends `get_standard_question` with `choices` column (list of strings)
- `_flat_choices(qid)` — returns `(flat_choices_Series, n_respondents)` for multi-choice questions

#### Cell 4 — Validation
Define and immediately call `validate(sheets)`.
Check these expected values and print PASS / FAIL per check:

| Question | ID | Expected |
|---|---|---|
| Q10 (scaling) | id=3 | Brainstorming=Somewhat Useful, Code gen=Very Useful, Code Documentation=Very Useful, all others=Not Applicable |
| Q10 (scaling) | id=24 | Brainstorming=Very Useful, Code gen=Essential, all others blank |
| Q08 (single) | id=2 | Regularly (daily or almost daily) |
| Q23 (open) | id=6 | Cell contains "Low-Code is dead" and "Context Engineering" |
| Q16 (multi) | id=14 | Exactly 3 choices: Critical thinking and code review skills, Secure coding and ethical AI awareness, Data privacy and regulatory compliance awareness |

#### Cell 5 — Statistical Analysis Helpers (private)
Private functions only. No visualisation.
- `_wilson_ci(n_success, n_total, z=1.96)` — Wilson score 95% CI, returns `(lower, upper)`, handles n_total=0
- `_shannon_entropy(counts_array)` — returns `(entropy_bits, normalised_entropy)` where normalised ∈ [0,1]; 0=full consensus, 1=uniform; ignores zero counts
- `_chi2_uniform(counts_array)` — chi-squared goodness-of-fit vs uniform; returns `(None, None)` if <2 categories
- `_ordinal_stats(values_series, scale_map)` — maps labels to scores, returns dict with keys: `n`, `mean`, `std`, `median`, `mean_ci_95` (bootstrap, n_boot=2000, seed=42)

#### Cell 6 — Statistical Analysis: Public Function and Report Printers
- `_print_separator(width=74, char="─")` — shared by both report printers
- `_print_categorical_report(results)` — table: category | n | % | 95% CI; dominant, entropy, χ²
- `_print_scaling_report(results)` — per-item: distribution, ordinal stats, positive%, entropy, N/A count
- `analyse_question(sheets, qid, question_type, *, top_n, scale, na_label, print_report, return_results)`:
  - `'single'`/`'multi'`: counts, proportions, Wilson CI, dominant, Shannon entropy, χ² uniform
  - `'scaling'`: per item — counts, proportions, dominant, positive% (top-2 levels), Shannon entropy, ordinal stats, N/A count
  - Returns dict if `return_results=True`, else None

#### Cell 7 — Visualisation Helpers (private)
Private rendering helpers shared across all chart types. No public chart functions.
- `_fig_setup(figsize)` — creates figure and single axes with `BG_COLOR` background
- `_style_axes(ax)` — removes top/right/left spines, sets bottom spine, grid, tick params
- `_add_title(ax, qid, question, wrap_width=80)` — bold left-aligned title as `"{qid}  |  {wrapped question}"`
- `_add_footnote(fig, text)` — small grey footnote at bottom-left
- `_save_or_show(fig, save_path)` — saves or shows, always closes figure
- `_wrap_labels(labels, width)` — wraps list of strings, returns newline-joined list
- `_annotate_bar(ax, bar, value, pct, x_max, show_pct)` — annotates horizontal bar with `"  n  (x%)"`

#### Cell 8 — Visualisation: Pie Chart (single-choice)
`plot_pie(sheets, qid, *, order, colors, min_pct_label=3.0, figsize=(8,5), save_path)`
- Uses `_get_responses`
- Applies `order` if given; else sorts by descending frequency
- Pie with inline % labels (suppressed below `min_pct_label`)
- Legend panel on right: label, n=, %
- Calls `_add_title`, `_add_footnote`, `_save_or_show`

#### Cell 9 — Visualisation: Horizontal Bar Chart (multi-choice)
`plot_multichoice(sheets, qid, *, order, top_n, wrap_width=42, show_pct=True, color, figsize, save_path)`
- Uses `_flat_choices`
- Ascending sort (top of chart = most common)
- Annotates with `_annotate_bar`
- Footnote: `"n = {n} respondents  •  % = share of respondents  •  multiple selections allowed"`
- Calls `_fig_setup`, `_style_axes`, `_add_title`, `_add_footnote`, `_save_or_show`

#### Cell 10 — Visualisation: Stacked Bar Chart (scaling)
`plot_scaling(sheets, qid, scale, *, item_order, top_n, wrap_width=38, show_na_bar=True, show_counts=True, min_seg_pct=6.0, figsize, save_path)`
- Uses `get_scaling_question`
- 100% stacked horizontal bars; segments coloured by scale level
- Not Applicable excluded from stack; shown as `N/A=n` at right edge when `show_na_bar=True`
- Default item order: ascending by share of top-2 positive levels (most positive at top)
- Legend above chart using `bbox_to_anchor`
- Calls `_fig_setup`, `_style_axes`, `_add_title`, `_add_footnote`, `_save_or_show`

#### Cell 11 — Dispatcher
- `_display_open(sheets, qid, meta)` — prints question and all responses verbatim, numbered; handles semicolon-delimited open responses
- `show_question(sheets, qid, *, top_n, order, figsize, save_path, print_stats=True, return_results=False)`:
  - Normalises qid: accepts string `'Q08'` or integer `8`
  - Q15: prints notice, returns None
  - Looks up type, scale, default order from `QUESTION_REGISTRY`
  - Caller-supplied `order` overrides registry default
  - `'single'` → `analyse_question` (with `print_report=print_stats`) + `plot_pie`
  - `'multi'` → `analyse_question` + `plot_multichoice`
  - `'scaling'` → `analyse_question` + `plot_scaling`
  - `'open'` → `_display_open` only
  - Always calls `analyse_question` with `return_results=True`; `print_report` controlled by `print_stats`

#### Cell 12 — Cross-Analysis Statistical Helpers
Private helpers for cross-analyses. No visualisation.
- `_fisher_exact_2x2(a, b, c, d)` — Fisher's exact test on 2×2 table, returns `(odds_ratio, p)`
- `_mannwhitney(x, y)` — two-sided Mann–Whitney U, returns `(U, p)`; returns `(None, None)` if either group <2
- `_cohens_d(x, y)` — pooled Cohen's d effect size; returns None if insufficient data
- `_cramers_v(contingency_table)` — Cramér's V from 2D numpy array

#### Cell 13 — Cross-Analysis: Organisation Size (Q03) × Q09 / Q10 / Q11
Group mapping function and three cross-analysis functions:
- `_get_size_groups(sheets)` — returns `{id: 'Small' | 'Big'}`:
  - Small = `"Startup (1-10 employees)"` + `"Small (11-50 employees)"`
  - Big = `"Medium Business (51-100 employees)"` + `"Large Enterprise (100+ employees)"`
- `cross_q03_q09(sheets, size_groups, *, save_path)` — Fisher's exact + Cramér's V per task; grouped horizontal bar chart (Small vs Big); marks significant items with `*`
- `cross_q03_q10(sheets, size_groups, scale, *, save_path)` — Mann–Whitney U + Cohen's d per item; diverging dot plot (circle=Small, square=Big, connector line); marks significant items
- `cross_q03_q11(sheets, size_groups, *, save_path)` — Fisher's exact + Cramér's V per issue; grouped horizontal bar chart; excludes write-in single-count items from chart

Each function prints a formatted report table and saves/shows the chart.
End cell with:
```python
size_groups = _get_size_groups(SHEETS)
```

#### Cell 14 — Cross-Analysis: Educational Background (Q05) × Q14 / Q16
Group mapping function and two cross-analysis functions:
- `_get_edu_groups(sheets)` — returns `{id: 'HBO' | 'WO'}` from Q05 responses
- `cross_q05_q14(sheets, edu_groups, scale, *, save_path)` — Mann–Whitney U + Cohen's d per skill item; diverging dot plot (circle=HBO, diamond=WO, connector line); vertical reference lines at scale levels 1–4; marks significant items
- `cross_q05_q16(sheets, edu_groups, *, save_path)` — Fisher's exact + Cramér's V per skill; grouped horizontal bar chart (HBO vs WO); marks significant items

Each function prints a formatted report table and saves/shows the chart.
End cell with:
```python
edu_groups = _get_edu_groups(SHEETS)
```

#### Cell 15 — Export Statistical Analysis: Print, Visualise, and Export to Markdown

Define and call:
`export_stats_report(sheets, output_path="./output/statistical_analysis.md")`

This function must do **three things in sequence for every question**:

**Step 1 — Print the statistical report to the notebook output.**
Call `analyse_question` with `print_report=True` for all non-open questions.
For open questions print the question title and a note that responses are qualitative.

**Step 2 — Render the visualisation inline.**
Call `show_question` with `print_stats=False` (to avoid double-printing statistics)
so that only the chart is produced and displayed inline in the notebook output.
For open questions no chart is produced.

**Step 3 — Accumulate the formatted Markdown output.**
For each question build a Markdown section and append it to a running string.
Write the complete string to `output_path` at the end.

The Markdown section structure per question:
```markdown
## QXX — [Label]

**Type:** single | multi | scaling | open
**Question:** [Full question text]
**Respondents:** n

### Distribution

[For categorical (single/multi): frequency table with columns: Category | n | % | 95% CI (Wilson)]
[For scaling: per-item table with columns: Item | Mean | Median | Std | 95% CI | Positive% | Dominant | Entropy | N/A]
[For open: *Qualitative responses — see raw data output above.*]

### Key Statistics

[For categorical:]
- **Dominant category:** [value]
- **Shannon entropy:** [X.XXX bits] (normalised: [X.XXX] — 0 = full consensus, 1 = uniform)
- **χ² (uniform):** [X.XXX], p = [X.XXXX] — [✓ significant | ✗ not significant] at α = 0.05

[For scaling:]
- **Scale:** [level 1] → [level 2] → ... → [level n]
- **Highest-priority item:** [item name] (mean [X.XX], [XX]% positive)
- **Lowest-priority item:** [item name] (mean [X.XX], [XX]% positive)
- **Items with Strongly Increasing dominant:** [comma-separated list]
- **Items with Decreasing dominant:** [comma-separated list]
```

**Additional requirements:**
- Create `./output/` directory if it does not exist before writing.
- After writing, print: `"Exported: {output_path} — {n} questions processed"`.
- The function must process questions in registry order.
- For scaling questions include every item row in the table; do not truncate.
- All numeric values must be rounded consistently: means and CIs to 3 decimal places,
  percentages to 1 decimal place, entropy to 4 decimal places, χ² to 4 decimal places.## QXX — [Label]

**Type:** single | multi | scaling | open
**Question:** [Full question text]
**Respondents:** n

### Distribution
[frequency table or scaling table]

### Key Statistics
[dominant, entropy, χ² for categorical; scale order and top items for scaling]
```