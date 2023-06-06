# Python 02

## Introduction

In Python 02, our focus lies on boolean expressions and their role in controlling the flow of execution. Boolean expressions, along with conditional statements and iterations, form the fundamental building blocks for making programmatic decisions

### Step 1: Boolean Expressions

Boolean expressions are statements that evaluate to either `True` or `False`. They are commonly used in conditional statements to control the flow of the program. In Python, the following comparison operators can be used to create boolean expressions:
```
`==` (equal to), `!=` (not equal to), 
`<` (less than), `>` (greater than), 
`<=` (less than or equal to), `>=` (greater than or equal to)
```

For example:

```python
x = 5
y = 10
is_greater = x > y # Check the explanation below
print(is_greater)  # False
```
In the statement `is_greater = x > y`, Python executes the comparison operation `x > y`. Here's a step-by-step explanation of how it is executed:

- Python evaluates the expression on the right-hand side of the assignment operator `x > y`.
- The values of x and y are substituted into the expression. Here `x = 5` and `y = 10`.
- Python compares the values of `x` and `y` using the `>` operator. In this case, it checks if 5 is greater than 10.
- The result of the comparison is a boolean value (`True` or `False`). If the comparison is true (in this case, if `x` is indeed greater than `y`), Python assigns `True` to the variable `is_greater`. Otherwise, it assigns `False`.
- The assignment operator `=` assigns the resulting boolean value (`True` or `False`) to the variable `is_greater`. Here, the variable `is_greater` will contain the boolean value `False` since 5 is not greater than 10.

Boolean expressions are not only valuable in calculations but also in verifying properties of text strings. For instance, the `len()` function can determine the length of a given text, while the `in` operator allows us to check whether a string includes a particular substring or character. Let's examine some examples:

```python
text = "Hello, world!"
length = len(text)
print(length)  # Output: 13
is_substr = "world" in text
print(is_substring) # Output: True
is_ended_qm = "?" in text
print(is_ended_qm) # Output: False
is_longer = len("Hello, Python!") > len(text)
print(is_longer) # Output: What will be the output here?
```

#### Exercises

1. What will be the result of the program? First, answer the question without executing the program. Then, copy the program and run it.

```python
# Boolean expressions
a = 10
b = 5
result1 = a > b
result2 = a == b * 2
print(result1)  # Output: ?
print(result2)  # Output: ?

# User input and checks
text = input("Enter a text that contains Hello: ")
print("Your text is:"+str("Hello" in text)) # # Output: ?
print("Length of your input is"+str(len(text))) # Output: ?

# Membership check in a simple list
fruits = ["apple", "banana", "orange"]
fruit = input("Enter a fruit: ")
print("Is your fruit in my list?"+str(fruit in fruits)) # Output: ?
```

### Step 2: Conditional Statements

Conditional statements allow you to execute different blocks of code based on certain conditions. The `if`-statement is used to check a condition and execute the block of code indented below it if the condition is true. If the condition is false, the block is skipped.

For example:

```python
x = 5
if x > 10:
    print("x is greater than 10")  # Pay attention to the indented block of if-statement
print("This statement always gets executed")
```

The `if-else` statement extends the `if` statement by providing an alternative block of code to execute when the condition is false.

For example:

```python
x = 5
if x > 10:
    print("x is greater than 10")
else:
    print("x is less than or equal to 10") # Pay attention to the indented block of else-statement
```

#### Exercises

1. What will be the result of the program? First, answer the question without executing the program. Then, copy the program and run it.

```
# List of colors
my_fav_colors = ["red", "green", "blue", "yellow"]

# User input
color = input("Enter your favorite color (lower case): ")

# Check membership in the list
if color in my_fav_colors:
    print("Color found in my list!")
else:
    print("Color not found in my list!")

# Print all colors in the list
print("List of my favorite colors:")
for color in my_fav_colors:  # Pay attention how in operator is used here
    print(color)
```

### Step 3: Conditional Iterations  

In addition to `for`-loops, there are situations where we need to repeat a set of statements until a specific condition is met. This is where `while`-loops come in handy. Unlike `for`-loops which require knowing the number of iterations in advance, `while`-loops allow us to iterate over a set of tasks until a certain condition becomes false. Once the condition evaluates to false, the program control exits the loop body.

A common scenario is when the program needs to repeatedly prompt the user for input until a specific character or text is entered, indicating the desire to stop. In such cases, we can use a `while`-loop to keep requesting input until the desired condition is met.

Here's an example illustrating the use of a `while`-loop to accept user input until the user decides to stop by entering a certain character or text:"

```python
# Initializing the list of the friends
friends = ""
sep = " - "

# Prompt the user for input until they enter 'stop'
inp_val = input("Enter the name of your friend (enter 'stop' to end): ")
while inp_val != "stop":
	friends = friends + inp_val + sep   # Analyze this statement carefully
	inp_val = input("Enter the name of your friend (enter 'stop' to end): ")

# Print the collected values entered by the user
print("Here is the list of your friends: "+friends)
```

#### Exercises

1. What will be the result of the program? First, answer the question without executing the program. Then, copy the program and run it.


```python
# Initializing the string to store the friends' names
friends = ""
sep = " - "

# Prompt the user for input until they enter 'stop'
while True:
    inp_val = input("Enter the name of your friend (enter 'stop' to end): ")
    if inp_val == "stop":
        break
    friends += inp_val + sep

# Print the collected values entered by the user
print("Here is the list of your friends: " + friends)
```


## Step 4: Problem Solving

### [todo]

Example: Write a Python program that takes a name as input and prints a greeting message based on the length of the name. If the name has more than 5 characters, it should print `"Hello, [name]!"`. Otherwise, it should print `"Hi, [name]!"`.

```python
name = input("Enter your name: ")
if len(name) > 5:
    print("Hello, " + name + "!")
else:
    print("Hi, " + name + "!")
```

### Problem: Grades Calculator

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

### Problems:

## Step 5: Assignment

