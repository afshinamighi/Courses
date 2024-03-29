# Python 01: Tutorial

### Computer Hardware

Computer hardware refers to the physical components of a computer system. Here are some essential concepts to understand:

Hard Disk: It is a storage device that stores your files and programs permanently.
RAM (Random Access Memory): It is the computer's temporary memory that allows quick access to data during program execution.
CPU (Central Processing Unit): It is the brain of the computer that performs calculations and executes instructions.
I/O (Input/Output): It refers to the communication between the computer and external devices like keyboards, mice, monitors, and printers.
When you run a program on your computer, the program and its associated data are loaded from the hard disk into the computer's RAM. The CPU then 
executes the program instructions stored in RAM.

### Variables and Data Types

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

### Basic Calculations

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

In this example, the variables a and b store numeric values. The CPU performs the calculations defined by the arithmetic operators `(+, -, *, /)`, and the results are printed using the `print()` function.

### Data Types

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

### Input and Output in Python

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

