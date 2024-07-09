# How to transfer problem statement into the code? 


Usually, the problem is described as a text. The provided text is called a *problem statement* or *problem description*. The designer of the problem statement tries to be as accurate as possible. However, almost always, there are some points that might not be very clear. Due to the limitations of informal languages (like English, Dutch, Spanish, etc.), there are always some elements in the description that are subject to different interpretations.

One of the main responsibilities of a programmer (or software engineer) is to clarify the problem statement as precisely as possible. This is called *problem analysis*. In this stage, you will be experiencing analysis using small problem statements. Later in your studies, you will encounter problems and projects with a higher level of complexity.

Here we try to provide some general steps for the beginners to apply in order to analyze the given problems and provide the solution as a Python programs. Please note that you can only improve this skill only by practicing. 

## General Steps:

1. **Understand the Problem**:
   - Carefully read the problem description.
   - Identify the inputs and outputs.
   - Note any constraints or assumptions.

2. **Break Down the Problem**:
   - Divide the problem into smaller, manageable tasks.
   - Identify the main tasks needed to solve the problem.

3. **Analyze the Problem Description**:
   - Look for key information and clues in the problem description.
   - Determine the operations needed to process the input and generate the output.

4. **Plan the Solution**:
   - Outline the steps needed to solve the problem.
   - Consider the logic and algorithms required.

5. **Write Pseudocode**:
   - Draft a high-level version of the solution in plain language or pseudocode.
   - Focus on the logic and sequence of steps.

6. **Implement the Code**:
   - Translate the pseudocode into actual code.
   - Write the code step-by-step, following the plan.

7. **Test the Solution**:
   - Test the program with different inputs to ensure it works correctly.
   - Debug any errors and refine the code as needed.

8. **Optimize and Refactor**:
   - Refactor the code to improve readability and maintainability.

## Example 

**Problem Statement:** Implement a program that given number of years as input prints the number of months and days as output. 

Input example: ```Years: 5``` , 
Output example: ```Months: 60 , Days: 1825```.

*Expected Program Behaviour*: After running the program, the program will wait for the user input. The user will enter the full string ```Years: 5```. The program can provide a proper message to guide the user about the correct input format. The program must slice the input and extract the number to process and produce the result. 

### Steps Explained for the Student:

1. **Understand the Problem**:
   - **Input**: A string in the format "Years: X", where X is the number of years (e.g., "Years: 5").
   - **Output**: The number of months and days for the given years, formatted as "Months: Y, Days: Z".
   - **Constraints**: Each year has 365 days and 12 months, each month has 30 days.

2. **Break Down the Problem**:
   - Extract the number of years from the input string.
   - Calculate the number of months from the given years.
   - Calculate the number of days from the given years.
   - Format and print the output string.

3. **Analyze the Problem Description**:
   - Input: "Years: 5"
     - Extract "5" from the input string.
   - Calculations:
     - Months: 5 * 12 = 60
     - Days: 5 * 365 = 1825
   - Output format:
     - "Months: 60, Days: 1825"

4. **Plan the Solution**:
   - Read the input string.
   - Extract the number of years from the input string using the slicing operator.
   - Convert the extracted string to an integer.
   - Calculate the number of months and days.
   - Format the output string.
   - Print the output string.

5. **Write Pseudocode**:

```
1.	Read the input string.
2.	Extract the number of years from the input string using the slicing operator.
3.	Convert the extracted number to an integer.
4.	Calculate the number of months: years * 12.
5.	Calculate the number of days: years * 365.
6.	Format the output string: “Months: Y, Days: Z”.
7.	Print the output string.
```
6. **Implement the Code**:

```python
# Step-by-step implementation

# Step 1: Read the input string
input_string = input("Enter the number of years (format: 'Years: X'): ")

# Step 2: Extract the number of years from the input string using the slicing operator
prefix_length = len("Years: ")  # Length of the prefix "Years: "
years_string = input_string[prefix_length:]

# Step 3: Convert the extracted number to an integer
years = int(years_string)

# Step 4: Calculate the number of months
months = years * 12

# Step 5: Calculate the number of days
days = years * 365

# Step 6: Format the output string
output_string = "Months: " + str(months) + ", Days: " + str(days)

# Step 7: Print the output string
print(output_string)
```

7.	Test the Solution:
	- Test Case 1: Input: “Years: 5”
	- Expected Output: “Months: 60, Days: 1825”
	- Test Case 2: Input: “Years: 1”
	- Expected Output: “Months: 12, Days: 365”
	- Test Case 3: Input: “Years: 0”
	- Expected Output: “Months: 0, Days: 0”

8.	Optimize and Refactor:
	- Ensure the code is clear and concise.
	- Add comments for better readability if needed.
	- Verify the code handles unexpected inputs gracefully (e.g., non-numeric input).
