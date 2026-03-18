# Statistical Interpretations: Software Engineering in the Era of Generative AI
## Survey Data — Rotterdam Area, The Netherlands, 2025

*Generated from: statistical_analysis.md and cross-analysis notebook outputs*
*Research context: HBO curriculum design for the generative AI era*

---

## Q01 — Primary role in software development

### Observation
The sample is co-dominated by two roles that appear in exactly equal proportions: Team Lead / Manager and Software Engineer each account for 51.6% of respondents, meaning most participants hold both an engineering and a leadership function simultaneously. Software Architects form a secondary cluster at 22.6%, followed by Data Engineers (12.9%) and Data Scientists (9.7%) at lower representation. Highly specialised roles — AI Engineer, Product Owner, QA Engineer, DevOps Engineer — are sparsely represented, with AI Engineers present in only a single response. There is no clear unimodal professional identity in this sample: it is a practitioner-plus-manager population.

### Statistical Support
The co-dominance of Team Lead / Manager and Software Engineer (both 51.6%, CI [34.8%, 68.0%]) is striking; neither category's confidence interval excludes 34.8%, indicating substantial uncertainty at this sample size. The χ² test against a uniform distribution is strongly significant (χ² = 49.06, p < 0.001), confirming that the role distribution is non-random even with wide individual-category CIs. Shannon entropy is 2.57 bits (normalised: 0.81), reflecting high diversity in the role composition while stopping short of full uniformity.

### Interpretation
The prevalence of hybrid practitioner-manager profiles means that many respondents evaluate GenAI not only from the perspective of individual coding tasks but also through the lens of team productivity, code quality governance, and hiring. This dual vantage point likely elevates the salience of governance concerns in later questions — particularly Q17 (security and de-skilling risks) and Q18 (low trust in unreviewed AI code) — and reinforces why Q16 identifies critical thinking and code review skills as the paramount future competency. The low representation of specialised roles (QA, DevOps, AI Engineer) means findings about testing automation (Q13), CI/CD usefulness (Q10), and AI engineering futures should be interpreted cautiously.

### Limitation
Respondents could select up to three roles, making percentages non-exclusive and summing above 100%. The n=31 constraint means CIs for secondary roles span 20+ percentage points. Role categories are not exhaustive and several respondents may have chosen adjacent descriptions; the near-identical counts for Team Lead and Software Engineer may partly reflect a single phenomenon (senior developers who also manage) rather than genuinely distinct professional groups.

---

## Q02 — Years of experience

### Observation
The sample skews decisively towards senior practitioners. The single largest group comprises respondents with more than 10 years of experience (45.2%), and combining this with the 7–10 year group adds another 12.9%, meaning nearly 58% of the sample have at least seven years of professional experience. Entry-level representation is minimal: respondents with fewer than three years of experience total only 19.3%, and those with less than one year account for a single individual.

### Statistical Support
The dominance of the >10 years group (45.2%, CI [29.2%, 62.2%]) is statistically confirmed against a uniform distribution (χ² = 15.29, p = 0.004). Shannon entropy of 1.97 bits (normalised: 0.85) signals a fairly spread but asymmetrically skewed distribution with a clear senior-heavy tail. The next largest group, 4–6 years, registers 22.6% (CI [11.4%, 39.8%]), confirming a bimodal structure with a concentration at mid- to late-career.

### Interpretation
This experience profile has direct implications for interpreting GenAI adoption data throughout the survey. Senior practitioners who evaluate tools are doing so with a reference point of established workflows, known codebase architectures, and prior experience with failed automation promises. Their high daily usage rate (Q08) despite this experience base suggests GenAI has cleared a demanding credibility bar. Conversely, their strong concern about junior de-skilling (Q20) may reflect a pattern where experienced developers can leverage AI productively precisely because they have deep foundational knowledge — a prerequisite they fear juniors will lack.

### Limitation
The near-absence of respondents with fewer than three years of experience (19.3% combined, only one with <1 year) means the survey cannot represent how newcomers to the field experience or evaluate GenAI tools. Any interpretation about junior developers — particularly in Q20 — is entirely mediated through the perceptions of senior respondents rather than direct junior experience data.

---

## Q03 — Organisation size

### Observation
The organisation size distribution is bimodal, with the Small (11–50 employees) and Large Enterprise (100+ employees) categories both claiming 41.9% of respondents — statistically tied. Medium businesses (51–100 employees) account for 12.9%, and startups (1–10 employees) for a single respondent (3.2%). The Rotterdam-area ICT sector represented in this sample is therefore not dominated by either SMEs or large organisations but is evenly split between them, with minimal representation from the medium-size transitional range.

### Statistical Support
The bimodal pattern is statistically significant against a uniform distribution (χ² = 14.81, p = 0.002). Shannon entropy is 1.59 bits (normalised: 0.80), indicating meaningful concentration despite the two-category structure. Both dominant groups share identical 41.9% shares (CI [26.4%, 59.2%]), and their overlapping confidence intervals confirm that no size category can be treated as statistically dominant at this sample size.

### Interpretation
The even split between small-company and large-enterprise practitioners produces a sample that captures two quite different GenAI adoption contexts: small-company engineers typically operate with greater autonomy, less formal governance, and direct tool access, while large-enterprise practitioners face procurement barriers, security review cycles, and standardised tool stacks. This structural heterogeneity is the rationale for the Q03-based cross-analyses against Q09 (task usage), Q10 (usefulness ratings), and Q11 (experienced failures). Where cross-analysis reveals divergence by size, it identifies which GenAI value propositions are context-dependent.

### Limitation
The single startup respondent prevents any meaningful startup-specific analysis. The bimodal split, while analytically useful, means the cross-analysis groups (Small vs Big) each contain approximately 14–15 respondents, which substantially limits statistical power. The medium-business segment — arguably a distinct operating context from both small firms and large enterprises — is too sparsely represented for separate analysis.

---

## Q04 — Primary programming languages

### Observation
The language ecosystem represented in this sample is strongly oriented toward the Microsoft .NET stack and modern web development. C# dominates (58.1%), followed by TypeScript (45.2%) and JavaScript (35.5%), which together point to a web-and-enterprise application development focus. Python appears in 35.5% of responses, reflecting data engineering and AI-adjacent work. All other languages — Java, PHP, Go, Kotlin, Ruby, C/C++ — appear in single-digit or low double-digit percentages, suggesting they are minority presences in this regional ICT cluster.

### Statistical Support
C# is the clear dominant language (58.1%, CI [40.8%, 73.6%]), and the χ² test against uniform is highly significant (χ² = 86.09, p < 0.001). Shannon entropy of 2.87 bits (normalised: 0.77) reflects a multi-language environment with a recognisable hierarchy. TypeScript (CI [29.2%, 62.2%]) and JavaScript (CI [21.1%, 53.1%]) occupy a secondary tier with overlapping confidence intervals, reinforcing their co-presence in web development workflows.

### Interpretation
The .NET/TypeScript/JavaScript stack is particularly well-served by current GenAI coding assistants: GitHub Copilot, ChatGPT, and similar tools have received disproportionate training on C#, TypeScript, and JavaScript repositories, and commercial integrations (Visual Studio, VS Code) are tightly coupled to these ecosystems. This may inflate perceived usefulness ratings in Q10 and task adoption rates in Q09 relative to what practitioners using niche or lower-resource languages (Go, Kotlin, Ruby) would report. The relatively high Python representation is consistent with data engineering and AI-tool customisation roles, which connect to Q14's finding that "Understand Foundations of AI" is rated strongly increasing in importance.

### Limitation
Respondents could select all applicable languages, so percentages are non-additive. The C# dominance likely reflects the specific composition of Rotterdam-area ICT firms and may not generalise to other Dutch regions or to the broader European software market. The seven respondents listing Java — a major enterprise language globally — suggests underrepresentation of certain sectors (banking, logistics enterprise software) relative to their actual share of the Dutch ICT workforce.

---

## Q05 — Highest education level (Dutch system)

### Observation
The sample divides almost cleanly between HBO-educated practitioners (61.3%) and WO-educated (research university) practitioners (38.7%). This is a nearly 3:2 split in favour of applied-science graduates, which is broadly consistent with the expected composition of a Dutch regional ICT workforce where HBO institutions supply the majority of software professionals. Notably, the split is sufficiently balanced to support meaningful cross-analysis between the two groups.

### Statistical Support
Despite the 61.3%/38.7% split, the chi-squared test against a uniform two-category distribution does not reach significance (χ² = 1.58, p = 0.209), meaning the observed skew is consistent with chance at this sample size. Shannon entropy is 0.96 bits (normalised: 0.96) — essentially the maximum possible for a binary distribution — indicating near-equal representation. HBO dominates (CI [43.8%, 76.3%]) but the CI easily encompasses parity.

### Interpretation
The HBO plurality confirms that this survey sample is directly relevant to its stated purpose of informing HBO curriculum design. The substantial WO minority (38.7%) is important because it introduces a comparison group who may hold different baseline beliefs about the changing role of theoretical knowledge, algorithm design, and foundational CS concepts — all themes assessed in Q14. The cross-analysis of Q05 against Q14 (skill importance change) and Q16 (essential future skills) is designed to test whether educational background moderates which competencies practitioners prioritise. That the two groups are sufficiently balanced makes this comparison feasible despite the overall small sample.

### Limitation
The binary HBO/WO classification loses information about the field of study, the specific institution, and the year of graduation. An HBO graduate from 2005 in software engineering and one from 2023 in data science may hold substantially different views; both are classified identically. Additionally, 4 of the 31 respondents hold PhDs (Q06), meaning some WO respondents have postgraduate research backgrounds that may skew that group's mean responses on knowledge-intensive items.

---

## Q06 — Highest academic qualification

### Observation
Bachelor's degree holders strongly dominate the sample, accounting for 67.7% of respondents. This is a concentrated distribution: PhD holders (12.9%) and Master's degree holders (16.1%) form a combined 29% postgraduate cohort, while Associate degree holders represent a single respondent. The qualification profile confirms that this is a professionally rather than academically oriented sample, consistent with the applied-practice focus of the Dutch HBO system and with ICT sector norms in the Netherlands.

### Statistical Support
The Bachelor's degree dominance (67.7%, CI [50.1%, 81.4%]) is strongly confirmed against a uniform distribution (χ² = 31.32, p < 0.001). Shannon entropy of 1.35 bits (normalised: 0.67) reflects moderate concentration — lower normalised entropy than Q05, consistent with a less balanced distribution. The combined postgraduate tail (PhD + Master's, n=9) is too small to support reliable subgroup analysis on its own.

### Interpretation
The qualification distribution contextualises Q14's findings about the expected decline of syntax memorisation and manual documentation and the rise of security auditing and AI-collaboration skills. These skill shifts are being judged primarily by Bachelor's-level practitioners who likely learned software development through applied, tools-oriented programmes. Their intuitions about what becomes less valuable in an AI-assisted world may carry different systemic biases than would be found in a research-university sample. The presence of four PhD respondents is noteworthy: if these individuals are concentrated in particular response patterns on Q14 or Q16, they could exert disproportionate influence on those distributions given the small n.

### Limitation
The Q06 qualification variable partially overlaps with Q05's education system variable — nearly all HBO graduates will report Bachelor's degrees, while WO graduates may report Bachelor's, Master's, or PhD. Cross-referencing these two questions can distinguish educational pathways, but the small cell sizes in the Master's and PhD categories limit the reliability of any such analysis. The Associate degree respondent is an isolate and cannot be meaningfully compared to any other group.

---

## Q07 — Organisation's stance on AI tools

### Observation
Organisations represented in this sample fall into only two categories: those that actively encourage GenAI tool use (48.4%) and those that permit but do not actively promote it (51.6%). No respondent reported working in an organisation that restricts or prohibits GenAI tools. The distribution is strikingly symmetric, with the two categories nearly perfectly balanced and the slight plurality favouring passive permission over active encouragement.

### Statistical Support
The near-perfect split (48.4% vs 51.6%) produces near-maximum binary entropy (0.999 bits, normalised: 0.999), and the chi-squared test confirms the distribution is statistically indistinguishable from a coin flip (χ² = 0.03, p = 0.858). Neither category is dominant in any statistically meaningful sense. Both CIs ([32.0%, 65.2%] and [34.8%, 68.0%]) overlap extensively.

### Interpretation
The complete absence of restrictive or prohibitive organisational stances is one of the most analytically significant findings in the survey, and it is best interpreted in conjunction with Q08's finding that 83.9% of respondents use GenAI tools daily. This is not a random coincidence: participation in the survey was likely self-selecting among practitioners in organisations that have already normalised GenAI tool access. The sample therefore cannot speak to how practitioners in restrictive environments experience or evaluate GenAI. However, the even split between active encouragement and passive permission is meaningful within the enabling half of the organisational stance spectrum: it suggests that institutional enthusiasm is not yet the norm even where access is guaranteed, with practical tolerance outpacing formal promotion. This has implications for Q17's de-skilling concern — de-skilling risk may be higher in permissive-but-non-governing organisations than in actively managed ones.

### Limitation
The binary forced-choice format (only two options presented to respondents, given no one selected restrictive options) severely limits discrimination. The question was likely designed to capture a fuller range from prohibition to active promotion, but the response distribution collapsed to two adjacent options. This ceiling effect on the encouraging side means the question cannot reveal important gradations in AI governance quality — the difference between an organisation with a formal AI usage policy and one that merely tolerates tool use is collapsed into a single category.

---

## Q08 — Frequency of GenAI tool usage

### Observation
Generative AI tool usage among this sample is overwhelmingly habitual and daily. 83.9% of respondents report using GenAI tools regularly (daily or almost daily), with the remaining responses split between occasional (6.5%) and rare (9.7%) usage. This is a highly concentrated, right-skewed distribution with a near-absent lower tail. The distribution effectively truncates: almost no respondent in this sample is an infrequent user.

### Statistical Support
The dominant category (83.9%, CI [67.4%, 92.9%]) is the strongest point estimate in any categorical question in this survey. The chi-squared test is highly significant (χ² = 35.68, p < 0.001), and the Shannon entropy of 0.79 bits (normalised: 0.50) reflects a distribution that is far from uniform — one category holds the overwhelming plurality. The lower CI bound of 67.4% means that even conservatively, more than two-thirds of this sample are daily users.

### Interpretation
The 83.9% daily usage rate is the analytical anchor for interpreting the entire survey. Every assessment of GenAI usefulness (Q10), identified failure modes (Q11), skill importance changes (Q14), and future risks (Q17 and Q21) comes from a vantage point of intensive, habituated daily use. This is not a population evaluating a novel technology from the outside — it is a population of active, experienced practitioners reporting on tools they use constantly. This experience base validates the specificity and reliability of their assessments while simultaneously introducing survivorship bias: practitioners who found GenAI frustrating enough to abandon it are largely absent from this sample. The finding connects directly to Q12's expectation that over 60% of work will involve AI assistance within five years — expectations formed by people already at that usage level.

### Limitation
The extreme concentration in the "daily" category makes the survey functionally unable to compare frequent versus infrequent users in cross-analysis. This is the most significant sampling characteristic of the study: all subsequent analyses are within-daily-user variation. Any finding labelled as applying to "software practitioners" should be understood as applying specifically to senior, Dutch-ICT-sector, daily GenAI users.

---

## Q09 — Tasks where GenAI is used

### Observation
GenAI task adoption clusters into a high-use tier and a significantly lower-use tier. The top tier — Brainstorming (80.6%), Code generation/auto-completion (74.2%), and Debugging/Error Explanation (71.0%) — stands clearly above the rest, collectively identifying the three dominant use cases. A middle tier includes Test/Test case generation (48.4%), Self-development and Learning (45.2%), Code Documentation (45.2%), and Refactoring (41.9%). Code Review (35.5%) and Security Analysis (19.4%) form a lower tier, and niche or operational tasks — CI/CD Automation, Automating Workflows, Requirements Analysis, Code Translation/Migration — each register in single digits to low teens. There is no task achieving near-universal adoption.

### Statistical Support
Brainstorming is the nominal dominant task (80.6%, CI [63.7%, 90.8%]), effectively tied with Code generation at 74.2% (CI [56.8%, 86.3%]) given overlapping intervals. Debugging is close behind at 71.0% (CI [53.4%, 83.9%]). The distribution is significantly non-uniform (χ² = 90.15, p < 0.001), and the entropy of 3.31 bits (normalised: 0.87) confirms task adoption is spread across multiple categories, not concentrated in a single use case. Security Analysis at 19.4% (CI [9.2%, 36.3%]) represents the most notable underuse relative to its Q10 usefulness rating context.

### Interpretation
The preponderance of exploratory and iterative tasks (brainstorming, code generation, debugging) over review and governance tasks (code review, security analysis) points to a tool-use pattern oriented toward productivity acceleration rather than quality assurance. This pattern coheres with — and helps explain — Q18's finding that 55.2% do not trust AI-generated code without human review: practitioners generate code with AI but have not yet transferred the review function to it at scale. The relative underuse of Security Analysis (19.4%) against its consistently low usefulness rating in Q10 (mean 2.05, 31.6% positive) suggests a double gap: practitioners neither use GenAI for security tasks frequently nor find it useful when they do, which in turn substantiates Q17's designation of security risk as the top near-term challenge (72.4%).

### Limitation
The multi-select format means frequencies reflect concurrent multi-task adoption and cannot distinguish primary from secondary or experimental use. The long tail of write-in categories ("all kinds of general questions," "Requirements Analysis") suggests the fixed option list did not fully capture actual use patterns, potentially undercounting adoption in operational tasks. The Q09 options partially overlap with Q10's rated tasks, but the mapping is not one-to-one, creating interpretive friction when comparing adoption rates to usefulness ratings.

---

## Q10 — Usefulness of GenAI per task

### Observation
The usefulness ratings form a clear three-tier structure. The top tier — Code generation/auto-completion (mean 3.00), Test/Test case generation (mean 2.96), and Brainstorming (mean 2.81) — clusters between 2.81 and 3.00 on the four-point scale, with "Very Useful" as the dominant response across all three. A middle tier comprises Debugging/Error Explanation (mean 2.74), Code Translation/Migration (mean 2.79), Self-development and Learning (mean 2.61), Code Documentation (mean 2.65), and Code Review (mean 2.39), rated as useful but with more variability. The lower tier — Security Analysis (mean 2.05), CI/CD Automation (mean 2.00), and Maintenance Automation (mean 1.88) — consistently falls below the midpoint of the scale, with Maintenance Automation the only item for which "Not Useful" is the modal response. Notably, no task achieves "Essential" as its dominant rating.

### Statistical Support
The highest-rated item is Code generation/auto-completion (mean 3.00, 95% CI [2.742, 3.258], 74.2% positive). The lowest is Maintenance Automation (mean 1.88, 95% CI [1.50, 2.25], 25.0% positive). The gap between top and bottom items spans 1.12 mean-scale points, a substantively large range given the four-point scale. N/A counts are highest for Maintenance Automation (14 out of 31), CI/CD Automation (12), Code Translation/Migration (11), and Code Review (7), indicating these tasks are not part of many respondents' day-to-day work. For Security Analysis, 11 respondents rated it N/A, meaning the low usefulness score of 2.05 is based on only 19 active users, further limiting reliability for that item.

### Interpretation
The tier structure identifies where practitioners have genuinely absorbed GenAI into core workflow versus where uptake remains peripheral. The disconnect between Security Analysis's low usefulness rating (mean 2.05) and Q17's identification of security risk as the top near-future challenge (72.4%) is analytically important: practitioners simultaneously recognise security as the pressing concern and find GenAI unhelpful for addressing it. This motivates Q14's highest-rated future skill — Conducting security audit on AI-generated code — as a human competency that cannot currently be delegated to the tool. Conversely, the high usefulness of Code generation and Test generation coheres with Q13's anticipation that Code writing (50.0%) and Testing and QA (33.3%) are the SDLC phases most likely to be taken over by AI.

### Limitation
The ordinal-to-numeric mapping (Not Useful=1 through Essential=4) assumes equal intervals between scale levels, which may not hold perceptually. High N/A counts for operational tasks (CI/CD Automation, Maintenance Automation, Code Translation/Migration) mean those means are computed on substantially smaller subsamples — as few as 17 respondents for Maintenance Automation — reducing their reliability and making cross-question comparisons asymmetric.

---

## Q11 — Common issues experienced with GenAI

### Observation
Two issues dominate the experienced-problem landscape by a wide margin: AI-generated code failing to follow the provided specification (83.9% of respondents) and Logic/Algorithmic errors in AI-generated code (80.6%). These two fundamental correctness failures affect virtually the entire sample. A secondary cluster of significant problems includes Security vulnerabilities (54.8%) and Difficulty in debugging AI-generated code (45.2%). Legal or licensing concerns register in 35.5% of responses. A small number of write-in responses capture emerging anxieties — data sovereignty ("where does my data go"), hallucination recognition, and ethical/environmental concerns — not captured in the fixed option list.

### Statistical Support
The two dominant issues (specification non-compliance at 83.9%, CI [67.4%, 92.9%]; algorithmic errors at 80.6%, CI [63.7%, 90.8%]) share confidence intervals nearly identical to Q08's daily-use rate, suggesting that essentially everyone who uses GenAI daily has encountered both issues. The χ² test is highly significant (χ² = 113.56, p < 0.001), and entropy of 2.60 bits (normalised: 0.75) reflects a distribution concentrated at the top. Security vulnerabilities (54.8%, CI [37.8%, 70.8%]) are experienced by a majority of respondents.

### Interpretation
The near-universal rates of specification non-compliance and algorithmic errors reframe the meaning of GenAI usefulness ratings from Q10: practitioners find these tools "Very Useful" while simultaneously experiencing fundamental correctness failures in virtually every session. This is not a contradiction but a productivity calculus — the efficiency gains from code generation outweigh the overhead of catching and fixing errors, at least for experienced practitioners. This calculus has a direct curriculum implication: the skills required to detect algorithmic errors and specification drift in AI-generated code (connecting to Q16's top pick, "Critical thinking and code review skills," at 79.3%) are not optional competencies but essential daily-use capabilities. The security vulnerability finding (54.8%) directly substantiates both Q17's security challenge ranking and Q14's identification of security auditing as the fastest-rising skill.

### Limitation
The fixed-option list captures only pre-specified issue categories. The write-in responses suggest that hallucination recognition, data governance, and ethical concerns are not negligible but were not formally measured. The legal/licensing concern (35.5%) may be underreported given that it requires respondents to be aware of IP law nuances; actual exposure may be higher. The multi-select format cannot distinguish how frequently or severely each issue occurs — a respondent who experienced a security vulnerability once and one for whom it is a daily problem are counted identically.

---

## Q12 — Estimated % of AI-assisted work (5 yrs)

### Observation
The dominant expectation is that 41–60% of software development work will involve AI assistance within five years (32.3%), but the distribution is broad and nearly flat across the three highest brackets. The 61–80% bracket registers 29.0% and the >80% bracket 25.8%, meaning a majority of respondents (54.8%) expect AI assistance to comprise more than 60% of work within five years. Only 12.9% expect AI involvement to remain below 40%. There is no strong consensus: the distribution spans the entire scale, with the modal response only mildly dominant.

### Statistical Support
The modal category (41–60%) holds 32.3% (CI [18.6%, 49.9%]), and the chi-squared test against uniform fails to reach significance (χ² = 2.68, p = 0.444). Shannon entropy of 1.93 bits (normalised: 0.965) is the highest normalised entropy of any single-choice question in the survey, confirming that opinion is nearly uniformly distributed across the four options. The combined upper-two-bracket share (41.9% + 25.8% = over 60% of respondents expect ≥61% AI involvement) is the more analytically informative statistic.

### Interpretation
The lack of a consensus peak and the near-uniform distribution indicate genuine expert uncertainty about the pace of AI displacement — not indifference, but honest disagreement. This is a strategically important finding for curriculum design: given that practitioners cannot agree on whether AI will constitute 40% or 80% of the workflow in five years, curricula should be designed for resilience across a wide range of AI-involvement levels rather than optimised for any single scenario. The tendency toward high estimates (54.8% expecting >60%) connects to Q19's finding that a majority believe the field will remain human-centred but will shift substantially, and to Q13's identification of Documentation and Code writing as the phases most likely to be taken over by AI within the same timeframe.

### Limitation
The question asks for a point estimate within a percentage bracket, which conflates respondents' uncertainty about the rate of change with their beliefs about the eventual equilibrium state. A respondent who believes AI will constitute 41–60% in five years might also believe it will reach 80% in ten years; the five-year horizon may be capturing speed-of-adoption uncertainty more than total-impact beliefs. The non-significant chi-squared result, while correctly reported, also reflects the limited discriminating power of a four-category scale when opinion is genuinely spread.

---

## Q13 — SDLC phases GenAI will take over

### Observation
Documentation (56.7%) and Code writing (50.0%) are the phases respondents most expect GenAI to assume primary responsibility for within three to five years. Debugging and issue resolution (36.7%) and Testing and quality assurance (33.3%) form a distinct secondary tier with meaningful but lower expectations. Deployment/DevOps and UI/UX design both register at 10.0%, and Requirements analysis (16.7%) and Project management (13.3%) are expected to be partially automated by fewer than one in five respondents. System architecture and design is selected by a single respondent (3.3%), reflecting a near-consensus that strategic design remains a human domain.

### Statistical Support
Documentation is the clear statistical leader (56.7%, CI [39.2%, 72.6%]), and the χ² against uniform is highly significant (χ² = 61.00, p < 0.001). Shannon entropy of 3.00 bits (normalised: 0.84) reflects broad but structured spread across the SDLC. Code writing at 50.0% (CI [33.2%, 66.8%]) is within overlapping range of Documentation, and the two lead items cannot be ordered definitively at this sample size. The combined write-in responses ("ALL OF THE ABOVE" and "end responsibility should remain human") represent competing meta-views rather than specific phase selections.

### Interpretation
The pairing of Documentation and Code writing at the top is consistent with Q10's usefulness ratings — Code generation is the highest-rated GenAI task (mean 3.00) and Documentation is in the middle tier (mean 2.65) with a notably high "Very Useful" dominant — and coheres with Q14's finding that Manually commenting/documenting code is the skill expected to decrease most in importance (mean 1.55). The relatively modest 33.3% expectation for Testing and QA takeover sits in tension with Q10's high usefulness rating for Test/Test case generation (mean 2.96), suggesting that practitioners distinguish between GenAI as a test-writing accelerator and full autonomous responsibility for quality assurance. The near-absence of system architecture from anticipated AI takeover (3.3%) directly contextualises Q14's finding that fundamental and AI conceptual knowledge are expected to increase most strongly in importance: as lower-order tasks are automated, architectural and conceptual reasoning become the defining human contribution.

### Limitation
The question frames "taking over most human responsibilities" as a binary event within a three-to-five-year horizon, which may artificially suppress predictions for gradual partial automation (e.g., AI-assisted but not AI-owned testing). Some SDLC phases — like Requirements analysis — are highly context-dependent in their AI-amenability; the 16.7% estimate may underreflect heterogeneous views rather than true consensus. The write-in responses indicate that some respondents interpreted the question at a different level of abstraction (system-level vs. task-level) than intended.

---

## Q14 — Expected change in skill importance

### Observation
The Q14 responses reveal a clearly structured three-tier pattern in expected skill importance changes. The top tier of "Strongly Increasing" dominant skills clusters around AI governance and human-AI interface competencies: Conducting security audit on AI-generated code (mean 3.66), Collaborating with AI as a pair programmer (mean 3.52), Debugging and troubleshooting AI-generated code (mean 3.41), Reviewing and interpreting AI-generated code logic (mean 3.38), Understand Foundations of AI (mean 3.38), and Customizing and fine-tuning AI tools (mean 3.38). Fundamental Concepts scores 3.30 and also carries a "Strongly Increasing" dominant response. A middle tier — Integrating AI-generated code into CI/CD pipelines (mean 3.07) and Setting up CI/CD workflows (mean 2.93) — points to infrastructure and automation skills as moderately increasing. The bottom tier is unambiguous: Manually commenting/documenting code (mean 1.55), Memorizing syntax and APIs (mean 1.66), and Writing unit tests (mean 1.97) are all rated as "Decreasing in Importance," with the first two having the lowest mean scores of any item in the survey.

### Statistical Support
The highest-priority item, Conducting security audit on AI-generated code, scores mean 3.66 (95% CI [3.345, 3.897]), with 93.1% positive responses — the highest positive-percentage of any item in this question. Collaborating with AI as a pair programmer scores 3.52 (CI [3.31, 3.724]), with 96.6% positive — the highest positive-share alongside Customizing AI tools (also 96.6%). The lowest item, Manually commenting/documenting code, scores 1.55 (CI [1.241, 1.897]) with only 13.8% positive. The contrast between security auditing (mean 3.66) and code documentation (mean 1.55) represents a 2.11-point range on a four-point scale — the widest item-spread of any scaling question in the survey. Understand programming language structures (mean 2.52) is the only item with "No Change" as its dominant response, and its entropy of 1.89 bits is among the highest, indicating genuine disagreement about whether this foundational skill's importance changes.

### Interpretation
The Q14 findings constitute the central skill-priority signal of this survey and have the most direct implications for curriculum design. The "Strongly Increasing" cluster can be interpreted as describing a coherent new competency profile: security-first review, understanding AI foundations, debugging AI output, and treating AI as a collaborative agent rather than a code-generation tool. The decline of syntax memorisation and manual documentation is consistent with task automation findings from Q10 and Q13, and with the widely-held view in Q08 that practitioners are already daily users who have internalised these productivity gains. The ambiguity around "Understand programming language structures" (entropy 1.89, "No Change" dominant but wide spread) is analytically significant: there is genuine expert disagreement about whether language-structural knowledge — knowing how type systems, memory models, or concurrency primitives work — retains independent value in an AI-assisted world. This disagreement deserves explicit curriculum attention rather than a premature resolution in either direction.

### Limitation
The ordinal-to-numeric mapping assumes equal psychological intervals between the four scale points, which may not hold — practitioners may perceive the distance between "Slightly Increasing" and "Strongly Increasing" differently than between "No Change" and "Slightly Increasing." Bootstrap confidence intervals address sampling variability but not this measurement assumption. The item "Writing unit tests" receiving a "Decreasing in Importance" dominant rating (mean 1.97) should be interpreted cautiously: it may reflect an expectation that AI will write tests automatically (Q13 shows 33.3% expect AI to take over Testing and QA) rather than a belief that testing as a discipline is unimportant. The framing of individual skill items in isolation may also miss skills that are jointly important — security auditing and AI foundations, for instance, likely reinforce each other.

---

## Q16 — Most essential skills for future developers

### Observation
Critical thinking and code review skills dominates the response distribution decisively, selected by 79.3% of respondents — a margin that leaves all other items well behind. Understanding the limitations of AI-generated code (58.6%) is the clear second choice, and no other item reaches 35.0%. Effective prompt engineering (34.5%) and Secure coding and ethical AI awareness (27.6%) form a secondary tier. At the bottom, Collaboration and cross-functional teamwork registers a single selection (3.4%), the lowest of any option, suggesting the sampled practitioners did not perceive interpersonal collaboration skills as distinctively future-critical relative to the other options.

### Statistical Support
The dominant item (79.3%, CI [61.6%, 90.2%]) achieves a lower-bound CI of 61.6% — meaning even conservatively, more than three-fifths of the population this sample represents would select it. The second item (58.6%, CI [40.7%, 74.5%]) sits well below the lower-bound of Q16's top item, confirming a genuinely tiered ranking rather than a statistical tie. The χ² against uniform is highly significant (χ² = 44.61, p < 0.001), and entropy of 2.98 bits (normalised: 0.90) confirms that while critical thinking dominates, selection is spread across multiple items, reflecting a multi-skill view of future requirements.

### Interpretation
The alignment between Q16's top two items — critical thinking and code review (79.3%) plus understanding AI limitations (58.6%) — and Q14's highest-rated skill dimension — reviewing and interpreting AI-generated code logic (89.7% positive) — constitutes one of the strongest cross-question coherence signals in the survey. Both questions, asked in different framings (what skills will you prioritise vs. how will this specific skill change in importance), converge on the same answer: the future developer's primary value contribution is human oversight and interpretive judgment applied to AI-generated output. The relatively low selection rate for Effective prompt engineering (34.5%) is notable given the attention this skill receives in public discourse; practitioners in this sample consider it instrumentally useful but not the defining capability of future software work. Collaboration skills (3.4%) may be undervalued in this framework — the single-select-up-to-3 constraint may have displaced inherently social skills in favour of technical competencies.

### Limitation
The "select up to 3" constraint forces relative prioritisation but cannot reveal whether respondents believe items they did not select are unimportant. A practitioner who selected Critical thinking, Understanding AI limitations, and Prompt engineering may still regard Security awareness as highly important — merely the fourth priority. The low selection of Collaboration skills may therefore reflect ranking-constraint effects rather than a genuine devaluation of interpersonal competency.

---

## Q17 — Main challenges in AI-assisted development

### Observation
Security and data privacy risks (72.4%) and Developer de-skilling or over-reliance on AI assistance (69.0%) co-lead the challenge landscape, effectively tied at the top. Accumulation of technical debt from low-quality AI-generated code (62.1%) rounds out a leading triad, all exceeding 60%. Hallucinations or factual inaccuracies (51.7%) and Lack of trust in AI-generated code (37.9%) constitute a second tier. Legal and IP uncertainty (34.5%) and compliance concerns (24.1%) are moderate. Resistance to adoption (13.8%) and Governance gaps (17.2%) register at the low end, suggesting that organisational acceptance is less concerning to this sample than quality, security, and human-skill degradation.

### Statistical Support
The co-leaders Security (72.4%, CI [54.3%, 85.3%]) and De-skilling (69.0%, CI [50.8%, 82.7%]) both have lower-bound CIs exceeding 50%, meaning a majority concern is statistically defensible. Technical debt registers 62.1% (CI [44.0%, 77.3%]). The χ² against uniform is significant (χ² = 32.37, p < 0.001), and entropy of 3.27 bits (normalised: 0.95) — the highest in any multi-choice question in the survey — reflects a near-uniform spread across eleven options, indicating that practitioners perceive multiple simultaneous challenges rather than a single dominant threat.

### Interpretation
The security-de-skilling-technical-debt triad identifies three mutually reinforcing failure modes. Security vulnerabilities are produced by AI-generated code that practitioners do not fully understand (connecting to Q11's 54.8% security vulnerability experience rate); de-skilling reduces practitioners' capacity to detect and remediate those vulnerabilities (connecting to Q20's 72.4% belief that AI reduces junior learning opportunities); and technical debt accumulates when speed-to-generate outpaces comprehension-to-review (connecting to Q18's 55.2% expressing zero trust in unreviewed AI code). These three concerns form a coherent causal chain from adoption pressure to skill erosion to quality and security degradation. The high entropy of this question (0.95 normalised) means that the challenge landscape is perceived as comprehensively threatening rather than narrowly focused — a curriculum implication being that no single mitigation suffices, and future developers require a broad defensive competency set.

### Limitation
The multi-select format counts selection without severity weighting. A respondent who considers security risks existential and technical debt merely annoying contributes equally to both counts. High entropy may partly reflect a tendency to select many items in a multi-select format (endorsement bias) rather than genuinely uniform distribution of concern intensity. The near-absence of governance and resistance concerns may reflect the sample's composition — daily users in permissive organisations are less exposed to adoption friction.

---

## Q18 — Trust in AI-generated code without review

### Observation
Distrust of unreviewed AI-generated code is the dominant position in this sample. 55.2% of respondents report no trust at all in AI-generated code without human review, and an additional 37.9% report only partial trust ("Somewhat"). Only 6.9% — two respondents — report mostly trusting AI-generated code without review. The distribution is heavily left-shifted: the full credence end of the trust scale is essentially vacant.

### Statistical Support
The "Not at all" category dominates (55.2%, CI [37.5%, 71.6%]), confirmed against a uniform distribution (χ² = 10.41, p = 0.006). Shannon entropy of 1.27 bits (normalised: 0.80) reflects a concentration in the lower-trust categories while retaining a meaningful secondary presence for partial trust. The combined "Not at all" and "Somewhat" share accounts for 93.1% of responses. The two "Mostly" responses sit within a CI of [1.9%, 22.0%] — spanning a wide range due to low n.

### Interpretation
The low-trust finding is significant precisely because it coexists with 83.9% daily GenAI tool usage (Q08). These data are not contradictory: practitioners have adopted GenAI as a powerful productivity tool while simultaneously declining to trust its output autonomously. This is a mature, calibrated response to the error patterns documented in Q11 — where 83.9% have experienced specification non-compliance and 80.6% have encountered algorithmic errors. The finding directly validates Q14's top-rated skill of Conducting security audit on AI-generated code and supports Q16's co-emphasis on Critical thinking and code review skills (79.3%) alongside Understanding the limitations of AI-generated code (58.6%). For curriculum design, this finding suggests that the appropriate target is not blind trust or blind distrust but calibrated, skilled review — a competency requiring both technical depth and epistemological sophistication.

### Limitation
The three-option forced-choice scale (Not at all / Somewhat / Mostly) does not capture the task-specificity of trust. A practitioner who trusts GenAI entirely for boilerplate utility functions but not at all for security-critical code would need to compress this nuanced position into a single response, likely landing at "Somewhat." The resulting data conflates task-context variation with a single global trust disposition. The complete absence of a "fully trust" option may also have compressed the distribution downward relative to an open scale.

---

## Q19 — Will AI replace traditional development roles?

### Observation
The modal view — held by 51.7% of respondents — is that software development will remain fundamentally human-centred but will change substantially. The second most common position (37.9%) is that AI will create new roles and shift existing ones, a perspective compatible with significant transformation while denying wholesale replacement. These two views together account for 89.6% of responses. Only 6.9% believe traditional roles will be entirely unchanged, and a single respondent (3.4%) expects AI to significantly reduce the need for developers. Outright technological unemployment is essentially rejected by this sample.

### Statistical Support
The dominant category (51.7%, CI [34.4%, 68.6%]) is confirmed against a uniform four-category distribution (χ² = 19.41, p < 0.001). Shannon entropy of 1.46 bits (normalised: 0.73) reflects a clear but not extreme concentration. The second-place category (37.9%, CI [22.7%, 56.0%]) has substantial probability mass, and the two lead options' CIs overlap, preventing a definitive ranking by frequency. Together, however, the human-centred transformation narrative accounts for a dominant supermajority.

### Interpretation
The near-consensus rejection of radical replacement (96.6% ruling out major workforce reduction) is analytically important for a sample that simultaneously predicts >60% AI involvement in work within five years (Q12). The resolution of this apparent tension lies in how respondents interpret "AI involvement" versus "replacement": they anticipate deep workflow integration while maintaining that human judgment, creativity, and responsibility will remain central. This matches the skill priorities identified in Q14 and Q16 — both of which emphasise human-AI collaborative competencies over either pure technical skills or AI-independence. The 37.9% who emphasise role creation and shifting may be more alert to the macro-labour dynamics; their view is consistent with historical technological transitions in the software industry where automation created new categories of work.

### Limitation
The question offers categories that are not mutually exclusive at a conceptual level — "remains human-centred but will change" is compatible with "will create new roles." Respondents may have made different interpretive choices about which framing to select when both felt applicable. The very small counts in the "not replace" (n=2) and "significantly reduce" (n=1) categories make these positions statistically unreliable; the finding that displacement is nearly universally rejected may reflect genuine consensus or may simply reflect that respondents with more alarmist or more conservative views were not sampled.

---

## Q20 — AI impact on junior developer learning curve

### Observation
An overwhelming majority — 72.4% of respondents — believe that AI-assisted development reduces opportunities for junior developers to learn core problem-solving skills. This is the single most concentrated response on any categorical question in the second half of the survey. The remaining responses are distributed across minority positions including "accelerates learning" (6.9%) and "no significant effect" (6.9%), with three individual write-in responses articulating nuanced dual-effect positions. No response endorsed the view that AI unambiguously benefits junior learning without qualification.

### Statistical Support
The dominant category (72.4%, CI [54.3%, 85.3%]) is strongly confirmed against a uniform distribution (χ² = 80.34, p < 0.001). Shannon entropy of 1.54 bits (normalised: 0.55) is low for a categorical question with six effective categories, reflecting the pronounced concentration in the leading option. The lower-bound CI of 54.3% confirms that a majority position on skill-reduction harm is statistically defensible.

### Interpretation
The strength of the de-skilling concern (72.4%) among practitioners who are themselves daily GenAI users (83.9%) creates a specific pedagogical paradox: experienced practitioners benefit from AI augmentation but simultaneously believe that the learning path through which they acquired the foundational skills required to benefit from it is being truncated for the next generation. This connects directly to Q02's experience profile — senior practitioners who built core competencies through deep problem-solving are predicting that AI-mediated shortcuts will prevent juniors from building those same foundations. The three extended write-in responses further articulate a conditional hypothesis: junior developers who use AI as a learning scaffold may benefit, while those who use it as a replacement for reasoning will be harmed. This conditional formulation is not captured in the dominant response and represents an important nuance for curriculum design — the question is not whether AI is used, but how it is scaffolded pedagogically.

### Limitation
This question was answered entirely from the perspective of senior practitioners (median experience >10 years); no junior developer data exists in this survey for direct comparison. The concern about de-skilling is therefore a structural prediction rather than an observed outcome. Some of the write-in categories were substantively distinct enough to function as additional response options but were treated as idiosyncratic responses due to single-respondent occurrence; aggregating these thematically could yield a more informative distribution than the dominant-single-option reading suggests.

---

## Q21 — Greatest risk of heavy reliance on AI-generated code

### Observation
The open-ended responses to Q21 converge on several recurring thematic patterns. The most frequently expressed risk is erosion of fundamental coding competence — respondents articulate concern that developers who routinely accept AI-generated code without deep engagement will lose the ability to reason about code independently. A second prominent theme concerns security and correctness blindspots: the risk that unreviewed AI output introduces subtle bugs, security vulnerabilities, or specification mismatches that are harder to detect precisely because the code appears plausible and syntactically correct. A third theme addresses systemic brittleness — over-reliance on AI creates organisational dependency on tools whose failure modes (hallucination, model deprecation, pricing changes) are external to the team's control. Several respondents explicitly connect heavy reliance to declining professional standards and reduced accountability.

### Statistical Support
As an open-ended question, Q21 does not yield quantitative frequency distributions. The thematic patterns described above are derived from reading all responses in context; their relative prevalence cannot be precisely quantified from available data. The convergence of open-text themes with Q17's closed-category challenge rankings — which show security (72.4%), de-skilling (69.0%), and technical debt (62.1%) as the top three closed-choice concerns — provides cross-format validation that these themes are not artefacts of the forced-choice design in Q17.

### Interpretation
The Q21 open responses extend the structured survey findings by revealing the mechanisms respondents believe underlie the risks. The competence erosion risk connects to Q20's de-skilling concern but adds a professional-identity dimension: practitioners do not merely worry about individuals learning less but about the profession collectively losing the capacity for deep technical reasoning. The correctness blindspot theme provides a causal account for Q18's distrust of unreviewed AI code — the concern is not irrational technophobia but a well-founded assessment of AI failure modes experienced directly (Q11). For curriculum designers, Q21 suggests that resilience-oriented pedagogy — teaching students to work effectively with AI while maintaining independent reasoning capabilities — is the core curriculum design challenge.

### Limitation
Open-ended response rates and verbosity vary, meaning some respondents provided one-sentence answers and others multi-paragraph reflections; simple thematic counting weights these contributions equally. The thematic categorisation in this interpretation is interpretive, not algorithmically coded, and a different analyst might draw different thematic boundaries. The absence of a structured coding framework limits replicability.

---

## Q22 — How hiring will change with mainstream AI tools

### Observation
The open-ended responses to Q22 cluster around two complementary predictions. The first is a shift in the assessed competencies: respondents anticipate that rote coding ability and syntax recall will be devalued as explicit hiring criteria, displaced by judgment, problem-solving architecture, and the ability to critically evaluate AI-generated output. The second prediction concerns a rise in hybrid-profile demands — hiring will increasingly seek practitioners who understand both software engineering fundamentals and AI tool ecosystems, effectively expanding the definition of a software developer role. Several responses note that the volume of junior developer hiring may contract as AI tools extend the productivity of existing practitioners, while senior and specialist roles (security, architecture, AI integration) are expected to remain in demand or expand.

### Statistical Support
As an open-ended question, Q22 does not yield quantitative distributions. The thematic convergence with closed-question findings — specifically Q16's dominance of critical thinking and code review over syntax-level skills, Q14's deprecation of syntax memorisation, and Q19's prediction of role creation alongside role shift — provides cross-format coherence evidence.

### Interpretation
The hiring-change predictions in Q22 represent a practitioner-side translation of the skill priority findings into labour market terms. If critical thinking, security awareness, and AI-literacy become the primary assessed hiring criteria (as Q16 suggests future practitioners should develop), then hiring processes will need to move away from algorithmic coding challenges that reward syntax recall and toward evaluation formats that assess judgment, code review ability, and conceptual AI understanding. This has specific implications for HBO programmes whose graduates are entering the labour market: the graduating student's portfolio should demonstrate capacity for intelligent AI use and independent quality assessment, not merely code production volume.

### Limitation
Responses to Q22 reflect individual respondents' views on a highly speculative future state; many answers may be influenced by respondents' own current hiring responsibilities (52% are Team Leads or Managers, per Q01). This means Q22 thematic patterns are weighted toward managerial perspectives on hiring, potentially overrepresenting the preferences of decision-makers relative to the full range of employer stakeholders (HR professionals, non-managerial senior engineers, external recruiters).

---

## Q23 — Additional comments on AI in software development

### Observation
The Q23 open-ended responses are heterogeneous but cluster around three themes. A first group of responses reflects sceptical acceptance: practitioners acknowledge GenAI's transformative practical impact while expressing reservations about over-automation, hallucination risks, and the erosion of craft. A second group articulates a paradigm-shift framing — one response explicitly declares "Low-Code is dead; Development by Context Engineering is the new thing," positioning prompt-driven development not as a tool overlay but as a fundamental change in the nature of software development work. A third theme concerns professional and educational responsibility: several respondents call for formal training, updated curricula, and explicit guidance on how to integrate AI tools responsibly.

### Statistical Support
As an open-ended commentary question, Q23 does not yield formal frequency statistics. The paradigm-shift framing ("Context Engineering") is a minority view represented explicitly in a single response but implicitly consistent with the broader pattern in Q14 (AI collaboration and AI foundations as top rising skills) and Q22 (hiring shifting toward AI-competency assessment).

### Interpretation
Q23 functions as a validation and extension of the structured survey findings. The call for formal curricula and responsible integration training expressed in several responses directly mirrors the survey's stated purpose (HBO curriculum design), providing face-validity evidence that the research question resonates with practitioners. The "Context Engineering" framing is analytically provocative: if prompt engineering and context specification are the core design activities of the near-future developer, then the skill architecture implied by Q14 — AI foundations, specification review, debugging AI output — represents not a peripheral enhancement but a wholesale redefinition of the professional practice. For curriculum designers, Q23 closes the survey by confirming that practitioners themselves see a normative gap between current training and near-future requirements.

### Limitation
Q23 invites any additional comment, making it susceptible to recency and framing effects — respondents completing a survey about AI in software development may articulate views shaped by the survey instrument itself. The short length of most responses limits depth. Respondents who chose not to answer Q23 (which is optional) may hold systematically different views; the non-response rate is unknown from the data available.

---

## Cross-Analysis: Organisation Size (Q03) × Task Adoption (Q09), Usefulness Ratings (Q10), and Experienced Issues (Q11)

### Groups and Sample Sizes
Respondents were grouped by organisation size into Small (Startup 1–10 + Small 11–50 employees, n ≈ 14) and Big (Medium 51–100 + Large Enterprise 100+ employees, n ≈ 17) organisations. The grouping threshold was chosen to balance group sizes given the bimodal Q03 distribution (41.9% Small, 41.9% Large, 12.9% Medium, 3.2% Startup).

### Statistical Overview
Fisher's exact tests were applied to each binary task-adoption comparison (Q03×Q09 and Q03×Q11), producing odds ratios and p-values per item. Mann–Whitney U tests with Cohen's d effect sizes were applied to the ordinal usefulness ratings in Q10. Given the small group sizes (approximately 14 vs. 17), all analyses are substantially underpowered; at α = 0.05, reliable detection of a medium effect size (odds ratio ≈ 2.5 or Cohen's d ≈ 0.5) would require at least 30 respondents per group. Non-significant results throughout this cross-analysis are therefore treated as directional hypotheses only and not as evidence of population-level equivalence between size groups.

### Key Findings
For Q03×Q09, no task shows a statistically significant adoption rate difference between Small and Big organisations at p < 0.05. However, the directional pattern across task types is informative: Brainstorming, Code generation, and Debugging — the three highest-adoption tasks in the aggregate — show high adoption in both groups with minimal difference, suggesting these core use cases are size-invariant. Tasks in the operational and governance domain — CI/CD Automation, Security Analysis, Code Review — show somewhat higher adoption rates in Big organisations, consistent with the formalised workflows and compliance requirements typical of large enterprises. Small organisations show directionally higher rates for Self-development and Learning, which may reflect less access to formal training infrastructure.

For Q03×Q10, Mann–Whitney comparisons on usefulness ratings show no significant differences between Small and Big organisations across the twelve GenAI tasks. The directional pattern most worth noting concerns Security Analysis: Big organisation respondents tend to rate its usefulness somewhat higher, consistent with their higher formal security compliance requirements — but the small N/A counts in this item (11 of 31 respondents skipped it) further limit this comparison. CI/CD Automation and Maintenance Automation show similarly small directional differences with no statistical significance.

For Q03×Q11, Fisher's exact tests on experienced issue rates show no significant differences between size groups. The two dominant issues — specification non-compliance (83.9%) and algorithmic errors (80.6%) — are near-universal across both groups, confirming these are fundamental tool limitations not mediated by organisational context. Security vulnerability experience (54.8% overall) is directionally somewhat higher in Big organisations, consistent with larger attack surfaces and greater formal awareness of security failures, but this difference does not reach significance.

### Cross-Question Coherence
The absence of significant size-based differences in Q09 task adoption and Q11 experienced issues reinforces the aggregate picture from those questions: the core GenAI use pattern (brainstorming, code generation, debugging) and the core failure pattern (specification non-compliance, algorithmic errors) are consistent across organisational contexts in this sample. This convergence implies that the issues practitioners encounter are inherent to current GenAI tool architecture rather than artefacts of specific deployment contexts, which strengthens the case for skill-based interventions (Q14, Q16) over purely organisational or governance-level solutions.

### Limitation
The most fundamental limitation of these cross-analyses is statistical power: with approximately 14 and 17 respondents per group, the analyses can only reliably detect very large effects. The split definition (Small vs. Big) collapses meaningful heterogeneity within each group — a startup and a 50-person company may have very different GenAI governance maturity. Additionally, organisation size is correlated with other variables not controlled here, including respondent seniority, tech stack composition, and industry sector, any of which could mediate the patterns observed.

---

## Cross-Analysis: Educational Background (Q05) × Skill Importance Change (Q14) and Essential Future Skills (Q16)

### Groups and Sample Sizes
Respondents were grouped by highest level of education in the Dutch system: HBO (University of Applied Sciences, n ≈ 19) versus WO (Research University, n ≈ 12). This is the most analytically natural grouping given the survey's purpose (HBO curriculum design) and its near-equal representation of both groups (61.3% HBO, 38.7% WO).

### Statistical Overview
Mann–Whitney U tests with Cohen's d were applied to each item in Q14, comparing ordinal skill-importance ratings between HBO and WO respondents. Fisher's exact tests with Cramér's V were applied to each skill-selection comparison in Q16. Group sizes (n ≈ 19 vs. n ≈ 12) remain small, and the same power limitations that apply to the Q03 cross-analysis apply here. Significant results (p < 0.05) represent confirmed directional differences; non-significant results with moderate-to-large effect sizes are treated as exploratory hypotheses.

### Key Findings
For Q05×Q14, the majority of skill-importance items show no statistically significant difference between HBO and WO respondents, consistent with the overall pattern of broad agreement on the direction of skill change (security auditing increasing strongly; syntax memorisation decreasing). However, directional patterns emerge on several items that are conceptually meaningful. WO respondents tend to rate the importance of Fundamental Concepts and Understanding Foundations of AI somewhat higher than HBO respondents — consistent with research-university training that emphasises theoretical underpinning. HBO respondents show somewhat stronger rating of applied skills such as Integrating AI-generated code into CI/CD pipelines and Collaborating with AI as a pair programmer, consistent with applied-practice orientation. These directional differences, if replicated in larger samples, would imply that the two groups perceive the future skill landscape through subtly different frames — theoretical grounding versus operational deployment — even when their top-line rankings (security auditing first, documentation last) converge.

For Q05×Q16, Critical thinking and code review skills retains its overwhelming dominance (79.3% overall) across both educational groups, with no significant difference by education level. The Fisher's exact comparisons for Understanding the limitations of AI-generated code and Secure coding and ethical AI awareness show no significant divergence between groups. The direction of non-significant differences is small in all cases, confirming that the Q16 consensus — human oversight and AI-limitation awareness as the core future skills — is not an artefact of one educational subgroup's perspective but is shared across educational backgrounds.

### Cross-Question Coherence
The convergence of HBO and WO respondents on the core Q16 skill priorities (critical thinking, AI-limitation awareness) is one of the most important findings for curriculum design purposes: it implies that the competency requirements identified in this survey are not community-specific within the Dutch ICT sector but represent a shared professional judgment that crosses the applied-science/research-university divide. The subtle directional differences on Q14 items (theoretical vs. applied skill emphasis) suggest that HBO and WO programmes can legitimately emphasise different aspects of the shared competency framework — applied AI integration for HBO, AI foundations and conceptual security for WO — without contradicting each other.

### Limitation
The HBO group (n ≈ 19) and WO group (n ≈ 12) are too small to support reliable subgroup analysis of more than a few items simultaneously. The Q05 classification is based on the highest level of Dutch education completed, which does not fully capture international educational backgrounds, multidisciplinary degrees, or the field of study within each level. The HBO/WO distinction in the Dutch system carries connotations of vocational versus academic orientation that may be less meaningful for practitioners 10+ years into their careers, by which point on-the-job learning may have equalised formal educational differences.

---

*Exported: ./output/statistical_interpretations.md — 27 entries written*
*(22 individual questions Q01–Q23 excluding Q15, plus 5 cross-analysis sections)*
-----------------------

A few highlights from the interpretation document worth flagging:
Strongest convergence signals across questions:

Q11 (83.9% experienced specification non-compliance) + Q18 (55.2% zero trust in unreviewed code) + Q14 (security auditing as top rising skill, mean 3.66) form a tight causal chain that validates the Q16 top skill pick — critical thinking and code review — as a genuine operational necessity, not a theoretical preference.
Q08 (83.9% daily users) interpreted alongside Q14's declining skills (syntax memorisation, documentation) shows practitioners have already internalised those productivity gains; the skill shifts are descriptive of current practice, not just prediction.

Most analytically ambiguous finding:

Q12 (AI work percentage in 5 years) has the highest normalised entropy of any closed question (0.965) — genuine expert disagreement, not noise. This argues against designing curricula for a single AI-penetration scenario.

Most important curriculum design signal:

Q20's de-skilling concern (72.4%) from experienced practitioners who are themselves daily AI users produces the pedagogical paradox: the very experience base that lets seniors benefit from AI is what they fear juniors won't develop. The extended write-in responses articulate a conditional model — AI as scaffolding vs. AI as replacement — that deserves explicit treatment in curriculum design.