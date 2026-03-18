# Data Analysis Prompts


In this document the prompts used to analyse data is collected.

## Survey: Software Engineering in the era of AI


### Step 0: Preparation

I have attached a dataset which is the result of a survey about "software engineering in the era of generative ai".

Your task: Parse the excel file and extract values according to the following explanation.
My Goal: To see if the values are extracted correctly.

Context of the dataset:
- result of a survey from ict companies within The Netherland, mostly around Rotterdam.
- date: July - November 2025.
- topic: software engineering in the era of generative ai.
- purpose: understand skill sets required for the future software developers.
- survey is anonymous.
Structure:
- sheet 'complete': complete set of collected data values.
- sheet Q01 - Q23: responses to questions 1 until 23.
- sheet Q15: there is no response, empty. Ignore it.
- In all the sheets: first column id of the responder. 
- In sheets Q01 to Q09 ; Q11 to Q13, Q16 to Q23 : second column contains the question and responses. The first row is the question title and from the second row we have the responses to the questions. Sometimes the choices are separated with ; within one answer (For example Q11).
- In sheets Q10, Q14: The questions are scaling. The first row contains the question title. The second row (after column one) contains the options and the values of the scales (responses from the participants) are starting from third row (omit column 1 as it is the id of the participants.)
- empty cells within the scope of responses mean: there was no answer.
- There is a trailing semicolon in of the cells where answers are separated with ; .  This may produce an empty value after splitting. To clean properly, ignore empty strings when splitting.

### Step 1: Data Extraction and Validation

Your task: Load the values of the sheets based on the structure I explained above. 

My Goal: I want to validate if the data extraction is correct.

Validation:
- give me the answers for Q10: id=3 and id=24.
- give me the answers for Q08: id=2.
- give me the answers for Q23: id=6.

	Validate multi-choice parsing (semicolon-separated values):
- give me the answers for Q16: id=14.

### Step 2: Setting up analysis environment in Jupyter

My Goal: To set up and configure my jupyter notebook such that I can analyse this survey and visualize it.
Your task: Give me required commands and code based on the following requirements:
- I am using Mac and vs code.
- (Optional: only if you don’t have venv) give me command lines to build my virtual environment.
- Give me python code to import my required libraries.
- define global variables for path of the dataset file, a function to load the data in a global variable, a function that implements validation explained above.


### Step 3: Generating general code for visualizing single-choice categorical questions.

My Goal: To have general functions / code for visualisation single-choice categorial questions using pie-chart. 
Your task: Generate python code that is parametraised and general for visualising pie-chart for single-choice questions. Later for each question of this type I want to call this function with proper parameters. 

### Step 4: Generating general code for visualizing multiple-choice categorical questions.

My Goal: To have general functions / code for visualisation multiple-choice categorial questions. 
Your task: Generate python code that is parametraised and general for visualising multiple-choice questions. Later for each question of this type I want to call this function with proper parameters. 

### Step 5: Generating general code for visualizing scaling questions.

My Goal: To have general functions / code for visualisation scaling questions. 
Your task: Generate python code that is parametraised and general for visualising scaling questions. Later for each question of this type I want to call this function with proper parameters. 

### Step 6: Generating general code for statistical analysis

My Goal: To have general functions / code for statistical analysis of given question.
Your task: Generate python code that is parametraised and general for calculating and applying some statistical analysis for a given question. Later for each question I want to call this function with proper parameters. Maybe this function is implementing multiple internal smaller functions.

### Step 7: Generating general code for calling proper statistical analysis and visualization functions

My Goal: To have function that accepts the question (number or sheet name) and then based on the type of the question, extracts question title, choices, and calls proper analysis function and visualisation code.
Your Task: Generate python code that in a function accepts the question number and then calls proper analysis and visualization functions and shows the results.