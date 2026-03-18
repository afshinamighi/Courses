# Master Prompt: Survey Analysis — Software Engineering in the Era of Generative AI

---

## Context

You are analysing the results of a survey titled **"Software Engineering in the Era of Generative AI"**,
conducted between July and November 2025 among ICT professionals working at companies in the Netherlands,
mostly in and around Rotterdam. The survey is anonymous and its purpose is to understand what skill sets
will be required for future software developers as generative AI becomes mainstream.

The dataset is an Excel file: `Survey_SoftwareDevelopmentInEraGenAI_polished.xlsx`

---

## Output Format Requirements

> **These requirements are mandatory and must be followed exactly.**

### One Step = One Notebook Cell

Generate the code as a Jupyter notebook. Each step below maps to exactly one notebook cell.
Do not merge steps into a single cell. Do not split a step across multiple cells.
Each cell must be independently runnable after all preceding cells have been executed.

### Code Architecture: Small, Reusable Functions

All code must follow these structural rules:

- **No duplicated logic.** Every repeated operation (parsing, counting, rendering a bar, printing a separator) must be extracted into its own small function and called wherever needed.
- **Each function does one thing.** Functions must be short and focused. A function that parses data must not also render a chart. A function that computes statistics must not also print a report.
- **Private helpers are prefixed with `_`.** Functions that are not part of the public API (i.e., not intended to be called directly from a notebook cell) must be named with a leading underscore.
- **No hardcoded repetition.** If the same value, color, label, or pattern appears more than once, define it as a constant or derive it from a shared source.
- **Parameters over copy-paste.** When two functions differ only in a parameter value, they must be unified into one parametrised function.

---

## Dataset Structure

| Element | Description |
|---|---|
| Sheet `complete` | Full dataset: all questions combined per respondent |
| Sheets `Q01`–`Q23` | One sheet per question (Q15 is empty — skip it) |
| First column (all sheets) | Respondent ID |
| Second column (Q01–Q09, Q11–Q13, Q16–Q23) | Question title in row 1; responses from row 2 onward |
| Sheets Q10, Q14 | Scaling / matrix questions: row 1 = question title; row 2 col 2+ = item labels; data starts row 3 col 2+ |
| Empty cells | No answer given — treat as missing, not as a value |
| Semicolons in cells | Some questions allow multiple selections; answers are semicolon-separated with a trailing semicolon — split on `;` and discard empty strings |

---

## Question Inventory

### Question Types

| QID | Type | Label |
|-----|------|-------|
| Q01 | multi | Primary role in software development |
| Q02 | single | Years of experience |
| Q03 | single | Organisation size |
| Q04 | multi | Primary programming languages |
| Q05 | single | Highest education (Dutch system) |
| Q06 | single | Highest academic qualification |
| Q07 | single | Organisation's stance on AI tools |
| Q08 | single | Frequency of GenAI tool usage |
| Q09 | multi | Tasks where GenAI is used |
| Q10 | scaling | Usefulness of GenAI per task |
| Q11 | multi | Common issues experienced with GenAI |
| Q12 | single | Estimated % of AI-assisted developer work (5 yrs) |
| Q13 | multi | SDLC phases where GenAI will have most impact |
| Q14 | scaling | Expected change in skill importance |
| Q15 | — | **Empty — skip entirely** |
| Q16 | multi | Most essential skills for future developers |
| Q17 | multi | Main challenges in AI-assisted development |
| Q18 | single | Trust in AI-generated code without review |
| Q19 | single | Will AI replace traditional development roles? |
| Q20 | single | AI impact on junior developer learning curve |
| Q21 | open | Greatest risk of heavy reliance on AI-generated code |
| Q22 | open | How hiring will change with mainstream AI tools |
| Q23 | open | Additional comments on AI in software development |

### Question Type Definitions

- **single**: One fixed answer per respondent. Analyse with frequency counts and pie chart.
- **multi**: Multiple selections per respondent, separated by semicolons. Analyse with frequency counts per choice and horizontal bar chart (% of respondents).
- **scaling**: Rating matrix — each respondent rates multiple items on the same scale. Analyse with stacked horizontal bar chart per item and ordinal statistics.
- **open**: Free-text responses. Display verbatim; no statistical analysis.

### Scale Definitions

**SCALE_USEFULNESS** (used for Q10)
- Ordered levels (low → high): `Not Useful` → `Somewhat Useful` → `Very Useful` → `Essential`
- Special value: `Not Applicable` — excluded from percentage calculations, reported as a separate count
- Colours (low → high): `#C44E52`, `#DD8452`, `#4C72B0`, `#2A6099`

**SCALE_IMPORTANCE_CHANGE** (used for Q14)
- Ordered levels (low → high): `Decreasing in Importance` → `No Change` → `Slightly Increasing` → `Strongly Increasing`
- No Not Applicable value
- Colours: `#C44E52`, `#8C8C8C`, `#55A868`, `#2A6099`

### Ordered Categories (for enforcing display order in charts)

| QID | Intended order (low → high or logical sequence) |
|-----|--------------------------------------------------|
| Q02 | `< 1 year` → `1 - 3 years` → `4 - 6 years` → `7 - 10 years` → `> 10 years` |
| Q03 | `Startup (1-10 employees)` → `Small (11-50 employees)` → `Medium Business (51-100 employees)` → `Large Enterprise (100+ employees)` |
| Q06 | `Associate degree` → `Bachelor's degree (BSc, BA, etc.)` → `Master's degree (MSc, MA, etc.)` → `PhD (Doctorate)` |
| Q08 | `Rarely (a few times a month)` → `Occasionally (a few times a week)` → `Regularly (daily or almost daily)` |
| Q12 | `21% - 40%` → `41 % - 60 %` → `61 % - 80 %` → `More than 80 %` |
| Q18 | `Not at all` → `Somewhat` → `Mostly` |

---

## Notebook Cell Structure

Generate exactly the following cells, in order. Each cell heading is its markdown title (use `## Step N` as the first line of a Markdown cell above each code cell).

---

### Cell 1 — Imports

Import all required third-party libraries. No application code here.

Required libraries: `pandas`, `numpy`, `matplotlib.pyplot`, `matplotlib.patches`,
`matplotlib.ticker`, `textwrap`, `collections.Counter`, `scipy.stats.chisquare`.

---

### Cell 2 — Configuration and Constants

Define all global constants. No functions here.
Path to the file is "./data/"

Must define:
- `FILE_PATH` — path to the Excel file
- `SHEETS` — empty dict, to be populated by `load_data()`
- `PALETTE` — list of 10 hex colour strings for categorical charts
- `SCALE_USEFULNESS` — dict with keys `order` (list), `na` (string), `colors` (list)
- `SCALE_IMPORTANCE_CHANGE` — dict with keys `order` (list), `na` (None), `colors` (list)
- `QUESTION_REGISTRY` — dict mapping each QID to its metadata (see structure below)

**`QUESTION_REGISTRY` entry structure:**
```python
"QXX": {
    "type":  "single" | "multi" | "scaling" | "open",
    "label": "Short human-readable label",
    "order": [...],    # optional: enforced display order for pie/bar charts
    "scale": {...},    # required for scaling type only; reference SCALE_* constants
}
```

Include all 22 active questions (Q01–Q23, excluding Q15).

---

### Cell 3 — Data Loading and Parsing Helpers

Define the data loading function and all low-level parsing helpers. No statistics or visualisation here.

Functions to define:

**`load_data(path) → dict`**
- Reads the Excel file with `pd.read_excel(..., sheet_name=None, header=None)`
- Updates the module-level `SHEETS` dict in-place (`.update()`) and also returns it
- Prints the list of loaded sheet names

**`_get_responses(qid) → pd.Series`**
- Returns the raw response column (column 1, rows 2 onward) as a Series, dropping NaN, cast to str
- Used as the shared base for all standard question parsers

**`get_standard_question(qid) → pd.DataFrame`**
- Returns a DataFrame with columns `[id, response]` for single / multi / open questions
- Row 1 is the header; responses start from row 2

**`get_scaling_question(qid) → pd.DataFrame`**
- Returns a DataFrame with respondent ID as index and item labels as columns for Q10 / Q14
- Cleans `\xa0` (non-breaking space) from item labels

**`get_multichoice(qid) → pd.DataFrame`**
- Extends `get_standard_question` by adding a `choices` column (list of strings per row)
- Splits on `;`, strips whitespace, discards empty strings

**`_split_choices(cell_value) → list[str]`**
- Private helper: splits a single semicolon-delimited cell value into a clean list
- Used by `get_multichoice` and by the analysis functions

**`_flat_choices(qid) → tuple[pd.Series, int]`**
- Private helper: returns `(flat_choices_series, n_respondents)` for a multi-choice question
- Flattens all selected choices across all respondents into one Series
- `n_respondents` is the count of rows with any response (used as denominator for %)

End the cell with a call to `load_data(FILE_PATH)` that stores the result in `SHEETS`.

---

### Cell 4 — Validation

Define and immediately call a `validate(sheets)` function.

The function must verify the following expected values and print PASS / FAIL per check:

| Question | Respondent ID | Expected value |
|----------|---------------|----------------|
| Q10 (scaling) | id=3 | Brainstorming=*Somewhat Useful*, Code gen / auto-completion=*Very Useful*, Code Documentation=*Very Useful*, all others=*Not Applicable* |
| Q10 (scaling) | id=24 | Brainstorming=*Very Useful*, Code generation / auto-completion=*Essential*, all others blank (no answer) |
| Q08 (single) | id=2 | *Regularly (daily or almost daily)* |
| Q23 (open) | id=6 | Raw cell value contains both *"Low-Code is dead"* and *"Context Engineering"* |
| Q16 (multi) | id=14 | Exactly 3 choices: *Critical thinking and code review skills*, *Secure coding and ethical AI awareness*, *Data privacy and regulatory compliance awareness* |

---

### Cell 5 — Statistical Analysis Helpers

Define all private statistical helper functions. No visualisation here.

**`_wilson_ci(n_success, n_total, z=1.96) → tuple[float, float]`**
- Returns the Wilson score 95 % confidence interval for a proportion
- Handles edge case: n_total = 0 → return (0.0, 0.0)

**`_shannon_entropy(counts_array) → tuple[float, float]`**
- Returns `(entropy_bits, normalised_entropy)`
- Normalised entropy ∈ [0, 1]: 0 = full consensus, 1 = uniform distribution
- Handles zero counts by ignoring them in the calculation

**`_chi2_uniform(counts_array) → tuple[float | None, float | None]`**
- Chi-squared goodness-of-fit against a uniform distribution
- Returns `(None, None)` when fewer than 2 categories

**`_ordinal_stats(values_series, scale_map) → dict`**
- Maps text labels → integer scores using `scale_map`
- Returns dict with keys: `n`, `mean`, `std`, `median`, `mean_ci_95`
- Uses non-parametric 95 % bootstrap CI on the mean (n_boot=2000, seed=42)

---

### Cell 6 — Statistical Analysis: Public Function and Report Printers

Define the public analysis function and its report-printing helpers.

**`_print_separator(width, char) → None`**
- Prints a horizontal rule; shared by both report printers

**`_print_categorical_report(results) → None`**
- Prints a formatted table: category | n | % | 95 % CI
- Prints dominant category, entropy, and χ² result
- Calls `_print_separator`

**`_print_scaling_report(results) → None`**
- Prints per-item block: distribution, ordinal stats, positive %, entropy, N/A count
- Calls `_print_separator`

**`analyse_question(sheets, qid, question_type, *, top_n, scale, na_label, print_report, return_results) → dict | None`**

For `question_type` = `'single'` or `'multi'`:
- Parse responses using `_get_responses` / `_flat_choices`
- Compute: counts, proportions, Wilson CI per category, dominant category, Shannon entropy, χ² uniform test
- Optionally print report via `_print_categorical_report`

For `question_type` = `'scaling'`:
- Parse using `get_scaling_question`
- Per item: counts, proportions, dominant level, positive % (top-2 levels), Shannon entropy, ordinal stats via `_ordinal_stats`, N/A count
- `Not Applicable` responses excluded from all calculations
- Optionally print report via `_print_scaling_report`

Returns dict if `return_results=True`, else None.

---

### Cell 7 — Visualisation Helpers

Define all private rendering helpers shared across the three chart types. No public chart functions here.

**`_fig_setup(figsize) → tuple[plt.Figure, plt.Axes]`**
- Creates a figure and single axes with background colour `#F7F9FC`

**`_style_axes(ax) → None`**
- Removes top, right, and left spines; sets bottom spine colour; configures tick parameters
- Called by all three chart functions to ensure consistent axis style

**`_add_title(ax, qid, question, wrap_width=80) → None`**
- Adds a bold, left-aligned title formatted as `"{qid}  |  {wrapped question}"`

**`_add_footnote(fig, text) → None`**
- Adds a small grey footnote at bottom-left of the figure

**`_save_or_show(fig, save_path) → None`**
- Saves to file if `save_path` is given, otherwise calls `plt.show()`; always closes the figure

**`_wrap_labels(labels, width) → list[str]`**
- Wraps a list of strings to a given character width using `textwrap.wrap`
- Returns list of newline-joined strings

**`_annotate_bar(ax, bar, value, pct, x_max, show_pct) → None`**
- Adds `"  n  (x%)"` annotation to the right edge of a horizontal bar
- Used by `plot_multichoice` and `plot_scaling`

---

### Cell 8 — Visualisation: Pie Chart (single-choice)

Define `plot_pie(sheets, qid, *, order, colors, min_pct_label, figsize, save_path) → None`

- Uses `_get_responses` to get response data
- Applies `order` if given; otherwise sorts by descending frequency
- Draws a pie chart with an inline `%` label (suppressed for slices below `min_pct_label`, default 3 %)
- Draws a legend panel on the right showing label, `n=`, and `%` per slice
- Calls `_add_title`, `_add_footnote`, `_save_or_show`
- Does **not** duplicate axis styling, title, or save logic — uses the shared helpers

---

### Cell 9 — Visualisation: Horizontal Bar Chart (multi-choice)

Define `plot_multichoice(sheets, qid, *, order, top_n, wrap_width, show_pct, color, figsize, save_path) → None`

- Uses `_flat_choices` to get flattened choices and respondent count
- Sorts bars ascending (so top of chart = most common after rendering)
- Applies `top_n` filter if given
- Annotates each bar with `_annotate_bar`
- Footnote states: `"n = {n_resp} respondents  •  % = share of respondents  •  multiple selections allowed"`
- Calls `_fig_setup`, `_style_axes`, `_add_title`, `_add_footnote`, `_save_or_show`

---

### Cell 10 — Visualisation: Stacked Bar Chart (scaling)

Define `plot_scaling(sheets, qid, scale, *, item_order, top_n, wrap_width, show_na_bar, show_counts, min_seg_pct, figsize, save_path) → None`

- Uses `get_scaling_question` to load the matrix
- Renders a 100 % stacked horizontal bar per item
- Each segment coloured by scale level (from `scale["colors"]`)
- `Not Applicable` responses excluded from the 100 % stack; shown as `N/A=n` text at right edge when `show_na_bar=True`
- Segment count annotations shown when `show_counts=True` and segment ≥ `min_seg_pct` %
- Default item order: ascending by share of top-2 positive levels (most positive item ends up at top)
- Legend placed above the chart (uses `bbox_to_anchor`)
- Calls `_fig_setup`, `_style_axes`, `_add_title`, `_add_footnote`, `_save_or_show`

---

### Cell 11 — Dispatcher

Define the open-ended display helper and the main dispatcher.

**`_display_open(sheets, qid, meta) → None`**
- Prints question text and all responses verbatim, numbered
- Handles both plain-text and semicolon-delimited open responses

**`show_question(sheets, qid, *, top_n, order, figsize, save_path, print_stats, return_results) → dict | None`**

- Normalises `qid`: accepts string (`'Q08'`) or integer (`8`)
- Handles Q15 edge case: prints notice and returns None
- Looks up `type`, `scale`, and default `order` from `QUESTION_REGISTRY`
- Caller-supplied `order` overrides the registry default
- Routing:
  - `'single'` → `analyse_question` (if `print_stats`) + `plot_pie`
  - `'multi'` → `analyse_question` (if `print_stats`) + `plot_multichoice`
  - `'scaling'` → `analyse_question` (if `print_stats`) + `plot_scaling`
  - `'open'` → `_display_open` only (no statistics, no chart)

---

## Shared Visual Style

All chart functions must use these values (defined as constants in Cell 2 and referenced — not duplicated):

| Property | Value |
|---|---|
| Figure background | `#F7F9FC` |
| Axes background | `#F7F9FC` |
| Title colour | `#2C3E50` |
| Footnote colour | `#7F8C8D` |
| Grid colour | `#D5DCE8` |
| Bottom spine colour | `#C0C8D4` |
| Axis label colour | `#5A6475` |
| Default categorical palette | `PALETTE` constant (10 colours) |

---

## Statistical Methods Reference

| Metric | Applies to | Interpretation |
|---|---|---|
| Counts + proportions | all categorical | Raw frequency and share of respondents |
| Wilson 95 % CI | categorical | Robust even for small n and extreme proportions |
| Dominant category / level | all | Most frequently chosen answer |
| Shannon entropy (bits + normalised) | all | 0 = full consensus, 1 = maximally split |
| χ² goodness-of-fit (uniform) | categorical | p < 0.05: distribution differs significantly from random |
| Ordinal mean / std / median | scaling | Numeric summary by mapping labels → 1…k scores |
| Bootstrap 95 % CI on mean | scaling | Non-parametric; safe for small n and skewed distributions |
| Positive % | scaling | Share of top-2 levels — one-number summary per item |

---

## Notes for Scientific Reporting

When writing a scientific interpretation for each question, structure it as follows:

1. **Observation** — what the data shows (dominant answer, distribution shape)
2. **Statistical support** — cite entropy, χ², CI, mean / median as appropriate
3. **Interpretation** — what this means in the context of GenAI adoption in software engineering
4. **Limitation** — note caveats (small n, self-selection bias, regional scope, single-country sample)
