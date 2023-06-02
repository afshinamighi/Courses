# Tutorial: Python 02

## Boolean Expressions

Boolean expressions are statements that evaluate to either `True` or `False`. They are commonly used in conditional statements to control the flow of the program. In Python, the following comparison operators can be used to create boolean expressions:

`==` (equal to), `!=` (not equal to), `<` (less than), `>` (greater than), `<=` (less than or equal to), `>=` (greater than or equal to).

For example:

```python
x = 5
y = 10
is_greater = x > y # Check the explanation below
print(is_greater)  # False
```
In the statement `is_greater = x > y`, Python executes the comparison operation `x > y`. Here's a step-by-step explanation of how it is executed:

- Python evaluates the expression on the right-hand side of the assignment operator >: x > y.
- The values of x and y are substituted into the expression. Here `x = 5` and `y = 10`.
- Python compares the values of `x` and `y` using the `>` operator. In this case, it checks if 5 is greater than 10.
- The result of the comparison is a boolean value (`True` or `False`). If the comparison is true (in this case, if `x` is indeed greater than `y`), Python assigns `True` to the variable `is_greater`. Otherwise, it assigns `False`.
- The assignment operator `=` assigns the resulting boolean value (`True` or `False`) to the variable `is_greater`. Here, the variable `is_greater` will contain the boolean value `False` since 5 is not greater than 10.

## Conditional Statements

Conditional statements allow you to execute different blocks of code based on certain conditions. The `if`-statement is used to check a condition and execute the block of code indented below it if the condition is true. If the condition is false, the block is skipped.

For example:

```python
x = 5
if x > 10:
    print("x is greater than 10")
print("This statement always gets executed")
```

The `if-else` statement extends the `if` statement by providing an alternative block of code to execute when the condition is false.

For example:

```python
x = 5
if x > 10:
    print("x is greater than 10")
else:
    print("x is less than or equal to 10")
```
## Strings

Strings in Python are sequences of characters. Here are some basic string operations:

- Concatenation: Joining two or more strings together using the `+` operator.

```python
s1 = "Hello"
s2 = "World"
s3 = s1 + " " + s2
print(s3)  # "Hello World"
```

- Duplicating: Creating multiple copies of a string using the `*` operator.

```python
s = "Hello"
duplicated_s = s * 3
print(duplicated_s)  # "HelloHelloHello"
```
- Scanning: Accessing individual characters in a string using indexing.

```python
s = "Hello"
print(s[0])  # "H"
print(s[1])  # "e"
```

- Slicing: Extracting a portion of a string using the slice notation.

```python
s = "Hello World"
print(s[6:11])  # "World"
```

## Putting it All Together

Example: Write a Python program that takes a name as input and prints a greeting message based on the length of the name. If the name has more than 5 characters, it should print `"Hello, [name]!"`. Otherwise, it should print `"Hi, [name]!"`.

```python
name = input("Enter your name: ")
if len(name) > 5:
    print("Hello, " + name + "!")
else:
    print("Hi, " + name + "!")
```

## Problem: Grades Calculator

You are tasked with creating a program that calculates the average grade of a student and determines their final letter grade based on the following criteria:

- The program should take input from the user for five individual subject grades (ranging from 0 to 100).
- The program should calculate the average grade by summing up all the grades and dividing by 5.
- If the average grade is greater than or equal to `90`, the final grade should be `"A"`; between `80` and `89` (inclusive), the final grade should be `"B"`; between `70` and `79` (inclusive), the final grade should be `"C"`; between `60` and `69` (inclusive), the final grade should be `"D"`; below `60`, the final grade should be `"F"`.

```python
 # Step 1: Take input for five subject grades
grade1 = int(input("Enter grade for subject 1: "))
grade2 = int(input("Enter grade for subject 2: "))
grade3 = int(input("Enter grade for subject 3: "))
grade4 = int(input("Enter grade for subject 4: "))
grade5 = int(input("Enter grade for subject 5: "))

 # Step 2: Calculate average grade
average_grade = (grade1 + grade2 + grade3 + grade4 + grade5) / 5

 # Step 3: Determine final letter grade based on average grade
if average_grade >= 90:
    final_grade = "A"
elif average_grade >= 80:
    final_grade = "B"
elif average_grade >= 70:
    final_grade = "C"
elif average_grade >= 60:
    final_grade = "D"
else:
    final_grade = "F"

 # Step 4: Print the average grade and final letter grade
print("Average Grade:", average_grade)
print("Final Grade:", final_grade)
```

We start by taking input from the user for the five subject grades using the `input()` function. We convert the input to integers using the `int()` function and store them in separate variables (`grade1`, `grade2`, etc.).

Next, we calculate the average grade by summing up all the grades and dividing the sum by 5. We store the result in the variable `average_grade`.

Using conditional statements (`if`, `elif`, `else`), we determine the final letter grade based on the average grade. The first if statement checks if the average grade is greater than or equal to `90` and assigns the final grade as `"A"`. The subsequent `elif` statements check the average grade against the remaining ranges and assign the appropriate letter grades. The final else statement covers any average grade below `60` and assigns the final grade as `"F"`.

Finally, we print the average grade and the final letter grade using the `print()` function.

#### Tips for a beginner programmer:

- Begin by understanding the problem requirements and the input/output expectations.
- Break down the problem into smaller steps: taking input, calculating the average, determining the final grade, and printing the results.
- Start implementing the code step by step, testing each part along the way to ensure it works as expected.
- In each step be very clear what you need for your implementation. 
- Utilize the concepts covered in the tutorial: taking user input, conditional statements, and basic arithmetic operations. Sometimes you may need something that is not covered directly in the tutorial and you need to make a small research.
- Make use of meaningful variable names to enhance code readability.
- Run the program with sample inputs and check if the output is satisfying the requirements.
- Try to solve the same problem *differently*. Use alternative program structures. Solving the same problem with different solutions can be very helpful for beginners. Be creative and go beyond what you are asked in the requirements. 

