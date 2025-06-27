# Python 01: Getting Started with Computers and Python

## Introduction

Before you learn to write your own Python programs, it’s important to understand what makes a computer work. A computer is made up of hardware like the processor, memory (RAM), storage (hard disk), and input/output devices like the keyboard and screen. The operating system (OS) helps all these parts work together smoothly.

A computer program is simply a set of instructions that tells the computer what to do. Python is one of the most popular and beginner-friendly programming languages for writing these instructions.

Every program needs to accept some input, process it using logic and data types like numbers and text, and produce useful output. In this chapter, you will learn about the basic parts of a computer and how a simple Python program turns your ideas into actions that a computer can understand and execute.

## Step 1: What is a Program?

Understanding how a computer works is important for every programmer. Knowing the basics of hardware, operating systems, and how programs run will help you write better code and solve problems more easily. Even simple Python programs rely on these fundamentals to work correctly.

Computer hardware refers to the physical parts of a computer system. Here are some essential concepts to understand:

- Hard Disk: It is a storage device that keeps your files and programs permanently, even when the computer is turned off.
- RAM (Random Access Memory): This is the computer’s temporary memory. It allows quick access to data and instructions while a program is running.
- CPU (Central Processing Unit): Often called the brain of the computer, it performs calculations and carries out instructions given by programs.
- I/O (Input/Output): This is how the computer communicates with the outside world through devices like keyboards, mice, screens, and printers.

When you run a program on your computer, the program’s instructions and the data it needs are copied from the hard disk into the RAM. The CPU then executes the instructions step by step directly from the RAM.

The operating system (OS) is special software that manages all the hardware and allows different programs to run smoothly. It controls how memory is used, manages files, handles input and output, and lets you run many programs at the same time.

A file is simply a collection of data stored on your hard disk. Files can contain text, pictures, music, or even programs themselves. Each file has a type or kind, which is usually recognized by its file extension — the letters after the dot in the file name. For example, a document might end in `.txt`, an image in `.jpg`, and a Python program in `.py`.

When you write and save a Python program, you create a file with a .py extension. When you run this file, the Python interpreter reads your code, loads it into RAM, and tells the CPU what to do, step by step. The program may read input from the user, process some data, and produce output on the screen.

Knowing these basics will help you understand what’s really happening when you write and run your Python code — and prepare you for more advanced programming concepts ahead.

Let’s look at a tiny Python program to see how this works:

```python
# This program adds two numbers

# Get first number from user
num1 = input("Enter the first number: ")

# Get second number from user
num2 = input("Enter the second number: ")

# Convert input from text to numbers
num1 = float(num1)
num2 = float(num2)

# Add the two numbers
result = num1 + num2

# Show the result
print("The sum is:", result)
```

When you run this program, it asks you to type two numbers. It adds them together and prints the total.

Each part of this little program has a purpose:

- Lines starting with `#` are comments. They explain what the code does but don’t run as instructions.
- `input()` asks the user for something to type in.
- Variables like `num1`, `num2`, and result hold the data in RAM while the program runs.
- `float()` changes the input from text to numbers so Python can do math.
- The `+` sign tells Python to add the numbers.
- `print()` shows the answer on the screen.

To write correct Python code, you must follow syntax rules — the grammar of the Python language. For example, you need parentheses after print and input, and you use = to assign values. If you break the syntax, Python will show an error.

But it’s not enough for your code to be written correctly — it must also make sense. This is called semantics — the meaning of what you wrote. For example, if you forget to convert input to numbers, Python might join the numbers as text instead of adding them! So both syntax and semantics matter for your program to work as you expect.

And that’s it — your first look at how your computer, files, and Python come together to turn your ideas into real results!


## Step 2: Programs talk to you.

Now that you know what a computer and a Python program are, it’s time to learn the basic building blocks you’ll use in every Python program you write.

A **value** is simply a piece of information that your program works with. For example:  
- `5` is a value (a whole number).  
- `3.14` is a value (a number with decimals).  
- `"Hello"` is a value (a piece of text, called a *string*).  

To use a value, you usually store it in a **variable**. Think of a variable as a labeled box that holds some information. For example:

```python
age = 20
name = "Alice"
pi = 3.14
```

In these examples, `age`, `name`, and `pi` are *variables*. The values on the right (`20`, `"Alice"`, `3.14`) are assigned to them using the `=` sign. Here, `=` means “store this value in this variable” — not “equal” as in math.

These values have **primitive data types** — basic kinds of information in Python:

- `int` for whole numbers (`20`)
- `float` for decimal numbers (`3.14`)
- `str` for text (`"Alice"`)
- `bool` for `True` or `False`


Here’s a tiny program using variables and `print()`:

```python
first_name = "Alice"
last_name = "Smith"

print("Name:", first_name, last_name)
```

Almost every Python program follows the same basic pattern:

1. **Accept input** from the user.
2. **Store** that input in a variable.
3. **Do some calculation or processing** with it.
4. **Print the result** so the user can see what happened.

For example, here’s a small program that asks the user for their name, then greets them:

```python
# Ask the user for their name
name = input("What is your name? ")

# Process
greet_message = "Hello " + name

# Print the result
print(greet_message)
```

Let’s break it down:

- **comment**:

```python
# Ask the user for their name
```

This line is a comment. In Python, anything after a `#` is for humans only — Python ignores it when running the program. Comments help you and others understand what the code is doing. There’s no variable or value here, just helpful text.

- **Input** 

```python
name = input("What is your name? ")
```

The `input()` function shows a message to the user and waits for them to type something. The text inside the quotes, `"What is your name? "`, is a string — one of Python’s primitive data types. This text is printed when `input()` is executed to communicate with the user that what is expected here. The `=` sign means `“store this value in a variable.”` Here, when the user answers the question, the user’s answer (like `"Alice"`) is read by `input()` and then saved in a variable named name. What is the *semantics* of this statement? The program asks the user a question and remembers what they typed as name.

- **Process** 

```python
greet_message = "Hello " + name
```

Now the program processes the input: `"Hello "` is another string value; `+` is the concatenation operator for strings — it combines two strings into one; the result, like `"Hello Alice"`, is stored in a new variable called `greet_message`. What is the semantics of `+` here? In this statements, the operator`+` combines a fixed message with the user’s name to build a new string (a greet message).

- **Output:** Finally, `print()` shows the result in a friendly message. `print()` is a built-in function that shows whatever you give it. `greet_message` is the variable holding your final text.

**Summary** This tiny program shows the heart of programming:

- It uses values (strings like "Hello " and the user’s name).
- It stores them in variables (name and greet_message).
- It follows correct syntax so Python knows what you mean.
- Its semantics make sense — each step does something clear: ask, store, combine, display.

If you accidentally make a typo, like writing `print(great_message)`, the syntax is still correct (it looks like a valid variable name), but the semantics break — Python doesn’t know what `great_message` is, because you never created it. So good syntax and clear semantics always work together.


By understanding this simple flow: `input -> store -> process -> output`  you’re ready to write your own tiny programs that talk to people and turn their answers into something useful or fun.

## Step 3: How to process / calculate?

Python code is executed by the CPU (Central Processing Unit) of the computer. When you perform calculations in Python using arithmetic operators, such as addition, subtraction, multiplication, and division, these calculations are executed by the CPU.

The CPU retrieves the values stored in the memory (RAM), performs the calculations, and stores the results back in the memory if needed. This process happens at a very high speed, allowing for quick computation.

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

In the previous examples, you have learned about the distinction between numerical values and text, which are known as strings in Python. Python differentiates between these values based on their types. Each value in Python has a specific type associated with it, and you can determine the type of a data value using the `type()` function. For example:

```python
type_of_num = type(10)
print(type_of_num) # Output: <class 'int'> which means the type is integer
```

Sometimes, you may need to convert values from one type to another. This process is called type casting. Python provides various functions for type casting. For instance, you can convert an `int` to a `str` (string) using the `str()` function, or convert a str to an int using the `int()` function. Here's an example of converting a `str` to an `int`:

```python
# Ask the user for their name
name = input("What is your name? ")

# Ask the user for their age
age = input("How old are you? ")

# Convert the input age from text to a number
age = int(age)

# Add 1 to their age and prepare result message
next_year_age = age + 1
result_message = "Hello" + name + "." + " Next year you will be " + str(next_year_age) 

# Print a message with the result
print(result_message)
```

This simple Python program asks the user for their name and age, then tells them how old they will be next year. When the program uses `input()`, whatever the user types is always stored as text, called a string — even if the user enters a number like `20`, it’s actually stored as `"20"`. To do math with this input, the program converts the `age` from a string to an integer using `int(age)`. This makes it possible to add `1` to the age to find out how old the user will be next year. Then, when building the final message, the program combines pieces of text and the number for next year’s age. Because you can’t directly join a number to a string, it converts the number back to a string using `str(next_year_age)`. This shows how type conversion lets a program switch between text and numbers: input comes in as text, numbers are used for calculations, and results are turned back into text so they can be printed in a friendly message for the user.


---------------------

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




**Working with Strings**

Strings are pieces of text. You can do simple operations with strings:

- **Concatenation (combining strings):**
  ```python
  greeting = "Hello, " + "world!"
  print(greeting)  # Output: Hello, world!
  ```

- **Duplicating (repeating strings):**
  ```python
  laugh = "ha" * 3
  print(laugh)  # Output: hahaha
  ```

- **Scanning (checking if something is inside):**
  ```python
  message = "Python is fun"
  print("Python" in message)  # Output: True
  print("Java" in message)    # Output: False
  ```

- **Slicing (getting part of a string):**
  ```python
  text = "Hello, world!"
  print(text[0:5])   # Output: Hello
  print(text[7:12])  # Output: world
  ```

Slicing uses square brackets `[]` to pick part of the string. The first number is where to start, the second is where to stop (but not including the stop number).

By understanding values, variables, primitive data types, mutability, and basic string operations, you now have the tools to write simple Python programs!

