# Python 02: Python Programs Need to Decide and Get Organized

## Introduction

This document presents learning activities for Python 02. In Python 02, you will learn basics of Python structures to add decision points to your programs. A branching program is a flow of sequential instructions with branching statements. By the end this week, you will be able to implement a program where a user can enter simple input, the program can make choices based on some conditions and after calculation, results can be printed.

## Getting Started: The Core Building Blocks

### Step 1: Programs Decide

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement boolean expressions.
	2. implement Python programs with conditional statements.
```



You already know how an arithmetic expression works in Python. For example: `result = 5 + 3 * 2`. This does a math calculation and gives a number.

A boolean expression works the same way, but instead of giving a number, it gives either `True` or `False`. A boolean expression checks if something is true or not.
Just like mathematical operators, you can use the comparison operators, greater than `>` operator:

```python
is_greater = 5 > 3  # This is True
```

Or the not equal (!=) operator:

```python
is_not_equal = 5 != 3  # This is True
```

These small checks are the building blocks of a boolean expression. They help your program make decisions by asking simple yes/no questions.

Boolean expressions are very useful because they help your program make decisions. You use them with a conditional statement like `if`. Conditional statements allow you to execute different blocks of code based on certain conditions. The `if`-statement is used to check a condition and execute the block of code indented below it if the condition is true. If the condition is false, the block is skipped.

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
    
print("This statement always gets executed")
```

### Step 2: Organize your programs

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs with Python functions: function definition, calling functions, return of a function, functions with arguments.
```



When you write a program, you often have steps that repeat. Instead of writing the same steps again and again, you can put them in a function. A function is like a small box that holds some code. When you want to run that code, you just call the function’s name.

Here’s a tiny (maybe not very real world) example:

```python
def say_hello():
    print("Hello!")
    print("Welcome to my program.")
```

This creates a function called say_hello. The word def means “define a function.” Everything that is indented under it belongs to the function.

This function does not run by itself. To use it, you have to call it by name somewhere in your program:

```python
say_hello()
```

When you call say_hello(), Python runs the code inside it. You can call the same function as many times as you want. 

```python
say_hello()
say_hello() # This will print the same message two times.
```

Functions help you organize your program. They keep your code clean and easy to read. Instead of repeating yourself, you write it once and call it when you need it.

Functions can do even more when you give them arguments (information to use) and ask them to return a result. This makes your functions smarter — they don’t just do the same thing every time, they work with the data you give them.

Look at this tiny example and guess what it does:
```python
def add_numbers(a, b):
    return a + b
```

What do you think will happen if you write this?

```python
result = add_numbers(3, 4)
print(result)
```

Try to guess before you run it!

In the next steps, you’ll discover exactly how arguments and return work by answering simple questions and trying tiny experiments yourself.

## Dig Deeper: Explore and Discover

This section invites the reader to move beyond the basics and use guided exploration to discover each concept in greater depth.

### Essentials

   1. What is a comment? How can you specify a comment in Python?
   2. What are: boolean values, boolean expressions, comparison operators?
   3. What is a conditional statement in Python? What is correct syntax for a correct *if-else* statament? What is a *body* of a *if-else* statement?


   1. What is a function in Python?
   2. What are the main elements of a Python function? Define a simple function that does nothing.
   3. How can a function be used (called)? 
   4. How can one return the result of a function?
   5. What are the arguments and/or parameters?


### Bonus

### Go Beyond

## Exercises: Practice and Apply

### Step 1:

1. Create a variable with the value ```True```. Print it. Change the value to ```False```. Print it. 
2. Create a variable
	- named ```a``` with the value ```True```, another 
	- named ```b``` with the value ```False```. Use print to check the output of ```print(a == b)```.
	- Do the same for the other comparison operators, ```!=```, ```<```, ```>```, ```<=```, ```>=```.
4. Repeat the second exercise using an *if-statement*. Print ```yes``` or ```no```, for true false. 
	- Write a comment above the *if-statement* explaining with it does. 

5. Students numbers start with 0. Implement a program where the user enters her/his student number and your program must check if it starts with 0.

6. Ask the user to input a number. If it is lower than ```10``` print it, otherwise only print the first character.

7. Look up the Spanish alphabet and put it in a variable. Put the Dutch alphabet in a variable. Print ```yes``` if the letter k is at the same position at both, print ```no``` if not. Use an ```if``` statement. 

8. Implement a program in which the user is asked for input. Save the input of the user in a variable. Print ```yes``` if the input contains the character ```e```, ```no``` if not. 

9. Think of an useful situation where you need to check something with a if-statement within another if-statement (nested if-statements). Code it and write a comment to explain why it needs a nested if. 


### Step 2:

*Note*: In the following exercises you can decide yourself what should be the name of function in your solution. Check [PEP8 Function and Variable Names](https://peps.python.org/pep-0008/#function-and-variable-names) for guidelines.

1. Explain in your own words the difference between `arguments` and `parameters`.
2. Create a function that just prints the word `hello`. Call the function and run your program. Where the function is *defined*? Where is it *called*?
3. Create a function that takes a text as an argument. The function prints the text it receives. Call the function and run your program.
4. Create a function that takes two numbers as argument. The function adds the numbers together and returns the results. Call the function and run your program.
5. Create two functions, each takes a number as argument. The first one returns the number multiplied by 2 and returns it. The second multiplies it by 10 and returns it. Calling both functions add the two returned numbers together and print it. Run your program and check the results.
6. Create two functions. One that prints `hello`, the other prints `bye`. Ask the user to input a number, if the number is higher than 10, call the first function. If the number if lower or equal to 10, call the second function. Test your program.
7. Create two functions. One that prints `hello`, the other prints `bye`. The first functions calls the second one after printing. Call the first function.
8. Provide your solutions to the exercises of Python 05: Step-01. **ORef-01: Functions** can be used as extra learning reference.
9. Design two exercises of your own. They should improve understanding topics of this step.
10. Install *PyCharm* on your working machine. Implement and run a simple Python program of your choice. 
	- It is important to learn how to create a new Python program, how to configure interpreter and how to run the program. Where do you see the results?


## Problems:

**Note**: All your solutions must check invalid inputs from the user and print proper error messages.

1. Write a program that reads an integer from the user. Then your program should display a message indicating whether the integer is even or odd.
	- *Step-02*: Complete solution.
2. Most years have 365 days. However, the time required for the Earth to orbit the Sun is actually slightly more than that. As a result, an extra day, February 29, is included in some years to correct for this difference. Such years are referred to as leap years.
The rules for determining whether or not a year is a leap year follow:
	- Any year that is divisible by 400 is a leap year.
	- Of the remaining years, any year that is divisible by 100 is not a leap year.
	- Of the remaining years, any year that is divisible by 4 is a leap year.
	- All other years are not leap years.
Write a program that reads a year from the user and displays a message indicating whether or not it is a leap year.
	- *Step-02*: Complete solution.


3. Write a program that determines the name of a shape from its number of sides. Read the number of sides from the user and then report the appropriate name as part of a meaningful message. Your program should support shapes with anywhere from 3 up to (and including) 10 sides. If a number of sides outside of this range is entered then your program should display an appropriate error message.
	- *Step-02*: Complete solution.

4. A triangle can be classified based on the lengths of its sides as equilateral, isosceles or scalene. All 3 sides of an equilateral triangle have the same length. An isosceles triangle has two sides that are the same length, and a third side that is a different length. If all of the sides have different lengths then the triangle is scalene.
Write a program that reads the lengths of 3 sides of a triangle from the user.
Display a message indicating the type of the triangle.
	- *Step-02*: Complete solution. The user enters each side in a different line.
	- *Step-03*: Complete solution. The user enters all three sides in one line. Example Input: ```a=5 , b=6, c=5```.


5. Make a list of national holidays in The Netherlands (assume current year). Write a program that reads a month and day from the user. If the month and day match one of the holidays in the list then your program should display the holiday’s name. Otherwise your program should indicate that the entered month and day do not correspond to a fixed-date holiday.
	- *Step-02*: Complete solution. The user enters month and day in different lines.
	- *Step-03*: Complete solution. The user enters both month and day in one line. Example Input: ```Month : 5 , Day : 21```.

6. It is commonly said that one human year is equivalent to 7 dog years. However this simple conversion fails to recognize that dogs reach adulthood in approximately two years. As a result, some people believe that it is better to count each of the first two human years as 10.5 dog years, and then count each additional human year as 4 dog years.
Write a program that implements the conversion from human years to dog years described in the previous paragraph. Ensure that your program works correctly for conversions of less than two human years and for conversions of two or more human years. Your program should display an appropriate error message if the user enters a negative number.
	- *Step-03*: Complete solution. 

7. Positions on a chess board are identified by a letter and a number. Usually, the letter identifies the column, while the number identifies the row.
Write a program that reads a position from the user. The program should determine if the column begins with a black square or a white square. Then use modular arithmetic (check if you know this concept) to report the color of the square in that row. For example, if the user enters ```a1``` then your program should report that the square is black. If the user enters ```d5``` then your program should report that the square is white. Your program may assume that a valid position will always be entered. It should report proper error message in case on invalid input values.
	- *Step-03*: Complete solution. 


8. Consider a valid license plate in The Netherlands (consider only one valid pattern). 
Write a program that begins by reading a string of characters from the user. Then your program should display a message indicating whether the characters are representing a valid license plate. 
	- *Step-03*: Complete solution. 





<!--

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

-->
