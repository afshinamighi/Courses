# Python 01

## Introduction

In Python 01, you will learn first elements of Python to build your first interactive linear program. We define a linear program as a flow of sequential instructions without branching and loops. At the end of Python 01, you will be able to implement a program where a user can enter simple input(s), the program calculates and prints the results as its output. 

### Step 1: Values and Variables

Computer hardware refers to the physical components of a computer system. Here are some essential concepts to understand:

Hard Disk: It is a storage device that stores your files and programs permanently.
RAM (Random Access Memory): It is the computer's temporary memory that allows quick access to data during program execution.
CPU (Central Processing Unit): It is the brain of the computer that performs calculations and executes instructions.
I/O (Input/Output): It refers to the communication between the computer and external devices like keyboards, mice, monitors, and printers.
When you run a program on your computer, the program and its associated data are loaded from the hard disk into the computer's RAM. The CPU then 
executes the program instructions stored in RAM.

In programming, variables are used to store and manipulate data. In Python, you can define variables by giving them a name and assigning a value to 
them. For example:

```python
# This is a comment statement. When we run a Python code, comments are ignored.
# An example of assigning a value to a variable. Note the difference between a number and text (string)
x = 10
name = "John"
```
Here, the variable `x` is assigned the value `10`, and the variable `name` is assigned the string `"John"`. Running a program, when you assign a value to a variable in Python, the value is stored in the computer's memory (RAM) at a specific memory address.

Usually we need to handle more values of the same concept. One solution would be to define several variables, but it will not be very efficient. We can collect more values in one place as a list. Then we can use lists. A list in Python is a collection of ordered elements enclosed in square brackets, and here's an example of initializing a list:

```python
fruits = ["apple", "banana", "orange"]
even_digits = [0,2,4,6,8]
```
#### Exercises:

1. [todo] Discuss what will be the result of the program (without execution).

*Note*: It is not expected that students understand all the elements of these programs. The main goal is to get a taste of Python programs and discuss about them. *Trust your intuition*.

```python
#Code 02
a = 16
b = 12
b = a
a = 22
print(a)
print(b)
# what will be printed here?
```

### Step 2: Basic Calculations

Python code is executed by the CPU (Central Processing Unit) of the computer. When you perform calculations in Python using arithmetic operators, such 
as addition, subtraction, multiplication, and division, these calculations are executed by the CPU.

The CPU retrieves the values stored in the memory (RAM), performs the calculations, and stores the results back in the memory if needed. This process 
happens at a very high speed, allowing for quick computation.

For example, let's perform some basic calculations in Python:

```python
a = 5
b = 3
c = a + b  # Addition
d = a - b  # Subtraction
e = a * b  # Multiplication
f = a / b  # Division

print(c)  # Output: 8
print(d)  # Output: 2
print(e)  # Output: 15
print(f)  # Output: 1.6666666666666667
```

In this example, the variables a and b store numeric values. The CPU performs the calculations defined by the arithmetic operators `(+, -, *, /)`, and 
the results are printed using the `print()` function.

In the previous examples, you have learned about the distinction between numerical values and text, which are known as strings in Python. Python differentiates between these values based on their types. Each value in Python has a specific type associated with it, and you can determine the type of a data value using the `type()` function. For example:

```python
type_of_num = type(10)
print(type_of_num) # Output: <class 'int'> which means the type is integer
```

Sometimes, you may need to convert values from one type to another. This process is called type casting. Python provides various functions for type casting. For instance, you can convert an `int` to a `str` (string) using the `str()` function, or convert a str to an int using the `int()` function. Similarly, you can convert a `str` or an `int` to a `float` using the `float()` function. Here's an example of converting a `str` to an `int`:

```python
age_str = "25"
age_int = int(age_str)
print(age_int)
```
#### Exercises:

[todo]

### Step 3: Input and Output

Input and output (I/O) in Python refer to the process of getting input from the user and displaying output to the user. Python provides built-in 
functions for this purpose.

The `input()` function allows interaction with the user by receiving input from the keyboard. It communicates with the computer's hardware I/O, which 
includes the keyboard, to get the input. The entered value is then made available to the program for further processing. The type of the value returned to the program is of type `str`.

The `print()` function is used to display output to the user. It communicates with the computer's hardware I/O, including the monitor or other output 
devices, to display the output. The output is visible to the user through the screen or other output mediums.

So, the `input()` and `print()` functions in Python serve as a bridge between the program and the computer's hardware I/O. They allow the program to 
interact with the user and exchange information through input and output operations facilitated by the computer's hardware components.

Here is an example:

```python
# Getting user input
name = input("Enter your name: ") # Note the text given to input()
age = int(input("Enter your age: ")) # Pay attention to the type casting

# Performing a calculation
birth_year = 2023 - age

# Displaying output
print("Hello, " + name + "! You were born in", birth_year)
```

In this example, the `input()` function is used to prompt the user to enter their name and age. The input for the age is type casted to an integer using the `int()` function to ensure it is treated as a numerical value.

A calculation is performed to determine the birth year by subtracting the age from the current year `2023`. The result is stored in the `birth_year` variable.

The `print()` function is then used to display a personalized message to the user, including their name and the calculated birth year. The string concatenation operator `+` is used to combine the strings and the variable value in the output.

#### Exercises:

[todo]

### Step 4: Repetitions

Sometimes you need to repeat a set of steps a specific number of times, and that's where the for loop in Python comes in handy. Using the `range()` function, you can easily define the number of iterations. For example, consider the following code:

```python
for i in range(5):
    print("Iteration", i)
    print("Hello, world!")
print("Iteration is finished"). # This is outside for-loop
```
In this example, the `for`-loop will iterate five times, with the variable `i` taking on the values 0, 1, 2, 3, and 4 in each iteration. The *indented* body of the loop, which consists of the two `print()` statements, will be executed for each iteration. It is crucial to note that the *indented code block* defines the actions to be repeated. You can perform any desired operations within this indented body, such as printing values, manipulating data, or executing specific algorithms. The for loop provides an efficient and concise way to repeat a block of code for a specified number of iterations.

#### Exercises:

[todo]

## Problems: Area of a rectangular

- Problem Statement: Calculate the area of some rectangles. The number of the calculations will be given by the user.

```python
# Ask for number of the calculations
num_calculations = int(input("How many calculations do you have?"))

# Define the repetitions
for i in range(num_calculations):
     # Define variables to store the dimensions of the rectangle
    length_str = input("Enter the length of the rectangle: ") # User input for length
    length = float(length_str)  # Converting the type
    width_str = input("Enter the width of the rectangle: ")   # User input for width
    width = float(width_str) # Converting the type

     #Perform the calculation
    area = length * width

     #Display the result
    print("The area of the rectangle is:", area)
print("All calculations are finished.")
```

In this example program, we calculate the area of a rectangle using the formula `length * width`.

Here's how the program works:

- First, we prompt the user to enter the number of calculations to be made. The entered value is then type-casted to an integer using the `int()` function and stored in the variable `num_calculations`. This determines the number of iterations for the loop.

- Next, a `for`-loop is implemented based on the number of iterations specified by `num_calculations`. Within the loop's body, we utilize the `input()` function to request the user's input for the length and width of a rectangle. The input values are captured in the variables length and width, respectively. To ensure proper numerical representation, we convert these input strings into floating-point numbers using the `float()` function.
The area is calculated by multiplying the length and width variables and storing the result in the variable `area`.

- Finally, we use the print() function to display the calculated area to the user.

- You can run this program and provide the `length` and `width` of the `rectangle` as inputs. The program will then calculate and display the area of the rectangle.

This example demonstrates the use of variables, user input, basic calculations, and output display with some repetitions, incorporating the concepts discussed in the tutorial.

## Problems:

*Note*: A systematic approach to transfer a solution in mind into a Python program can be challenging for novice programmers. A check list ([accessible here](./misc/checklist_metacog.pdf)) can be used to guide beginners to solve the following problems. Moreover, a template and a couple of examples are provided [here](./misc/template.py).

Implement Python programs to solve the following problem statements:

1. Write a program that asks the user to enter his or her name. The program should respond with a message that says hello to the user, using his or her name.
	- *Step-02*: Complete solution.

2. Implement a program that given number of years as input prints the number of months and days as output. Input example: ```Years: 5``` , Output example: ```Months: 60 , Days: 1825```.
	- *Step-02*: Partial solution, i.e. no calculation yet. The user enters the number of years and the program prints only ```Months: , Days: ```.
	- *Step-03*: Complete solution, i.e. add calculations. The user enters the number of years and the program prints the number of months and days as output.

3. Write a program that asks the user to enter the width and length of a room. Once the values have been read, your program should compute and display the area of the room. The length and the width will be entered as floating point numbers. Include units in your prompt and output message; either feet or meters, depending on which unit you are more comfortable working with.
	- *Step-02*: Partial solution, i.e. no calculation yet. The user enters the requested values the program prints only ```The Area of the Room: ```.
	- *Step-03*: Complete solution, i.e. add calculations. 

4. An online retailer sells two products: widgets and gizmos. Each widget weighs 75 grams. Each gizmo weighs 112 grams. Write a program that reads the number of widgets and the number of gizmos in an order from the user. Then your program should compute and display the total weight of the order.
	- *Step-02*: Partial solution, i.e. no calculation yet. The user enters the requested values the program prints only ```The Total Weight of the Order: ```.
	- *Step-03*: Complete solution, i.e. add calculations. 

5.  Develop a program that reads a four-digit integer from the user and displays the sum of the digits in the number. For example, if the user enters ```3141``` then your program should display ```3+1+4+1=9```.
	- *Step-02*: Partial solution, i.e. no calculation yet. The user enters a four-digit integer the program prints only ```Sum: ```.
	- *Step-03*: Complete solution. 

6. Implement a program that a user enters number of days as input, and the program prints number of hours, minutes and seconds separately as output.
	- *Step-02*: Partial solution, i.e. no calculation yet.
	- *Step-03*: Complete solution, i.e. add calculations. 

## Assignment:

1. The program that you create for this assignment will begin by reading the cost of a meal ordered at a restaurant from the user. Then your program will compute the tax and tip for the meal. Use your local tax rate when computing the amount of tax owing. Compute the tip as 15 percent of the meal amount (without the tax). The output from your program should include the tax amount, the tip amount, and the grand total for the meal including both the tax and the tip.
	- Assume local tax rate 21 percent.
	- After running your code, it should print the following to the standard output and wait for the user input: `Cost of the meal:`
	- The user enters the input (we assume the input is always valid and correct), let's say user entered `23.60`. 
	- Then the program should output the following: `Tax: 4.956 , Tip: 3.54 , Total: 32.096`.
