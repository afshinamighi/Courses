# Short Tutorial: Python 01 

## Computer Hardware

Computer hardware refers to the physical components of a computer system. Here are some essential concepts to understand:

Hard Disk: It is a storage device that stores your files and programs permanently.
RAM (Random Access Memory): It is the computer's temporary memory that allows quick access to data during program execution.
CPU (Central Processing Unit): It is the brain of the computer that performs calculations and executes instructions.
I/O (Input/Output): It refers to the communication between the computer and external devices like keyboards, mice, monitors, and printers.
When you run a program on your computer, the program and its associated data are loaded from the hard disk into the computer's RAM. The CPU then 
executes the program instructions stored in RAM.

## Variables and Data Types
In programming, variables are used to store and manipulate data. In Python, you can define variables by giving them a name and assigning a value to 
them. For example:

```python
x = 10
name = "John"
```
Here, the variable `x` is assigned the value `10`, and the variable `name` is assigned the string `"John"`. When you assign a value to a variable in Python, 
the value is stored in the computer's memory (RAM) at a specific memory address.

## Basic Calculations

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

## Input and Output in Python

Input and output (I/O) in Python refer to the process of getting input from the user and displaying output to the user. Python provides built-in 
functions for this purpose.

The `input()` function allows interaction with the user by receiving input from the keyboard. It communicates with the computer's hardware I/O, which 
includes the keyboard, to get the input. The entered value is then made available to the program for further processing.

The `print()` function is used to display output to the user. It communicates with the computer's hardware I/O, including the monitor or other output 
devices, to display the output. The output is visible to the user through the screen or other output mediums.

So, the `input()` and `print()` functions in Python serve as a bridge between the program and the computer's hardware I/O. They allow the program to 
interact with the user and exchange information through input and output operations facilitated by the computer's hardware components.

By following this tutorial, you should now have a better understanding of computer hardware concepts, data types, variable definition, basic 
calculations, and the connection between hardware components and Python programs. This knowledge will help you comprehend how programs utilize 
computer hardware, perform calculations, and interact with the user through input and output operations.

## Example

```python
 # Problem Statement: Calculate the area of a rectangle

 # Step 1: Define variables to store the dimensions of the rectangle
length = float(input("Enter the length of the rectangle: "))  # User input for length
width = float(input("Enter the width of the rectangle: "))  # User input for width

 # Step 2: Perform the calculation
area = length * width

 # Step 3: Display the result
print("The area of the rectangle is:", area)
```

In this example program, we calculate the area of a rectangle using the formula `length * width`.

Here's how the program works:

We prompt the user to enter the length and width of the rectangle using the `input()` function. The input values are stored in the variables `length` and `width`, respectively. We use the `float()` function to convert the input strings into floating-point numbers.

The area is calculated by multiplying the length and width variables and storing the result in the variable `area`.

Finally, we use the print() function to display the calculated area to the user.

You can run this program and provide the `length` and `width` of the `rectangle` as inputs. The program will then calculate and display the area of the rectangle.

This example demonstrates the use of variables, user input, basic calculations, and output display, incorporating the concepts discussed in the tutorial.
