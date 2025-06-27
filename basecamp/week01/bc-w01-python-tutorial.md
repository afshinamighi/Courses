# Python 01: Getting Started with Computers and Python

## Introduction

Before you learn to write your own Python programs, it’s important to understand what makes a computer work. A computer is made up of hardware like the processor, memory (RAM), storage (hard disk), and input/output devices like the keyboard and screen. The operating system (OS) helps all these parts work together smoothly.

A computer program is simply a set of instructions that tells the computer what to do. Python is one of the most popular and beginner-friendly programming languages for writing these instructions.

Every program needs to accept some input, process it using logic and data types like numbers and text, and produce useful output. In this chapter, you will learn about the basic parts of a computer and how a simple Python program turns your ideas into actions that a computer can understand and execute.

## Getting Started: The Core Building Blocks

### Step 1: What is a Program?

#### Goals:

```
After taking this step, you will be able to:
	1. understand the general concepts of computer hardware: Hard disk, RAM, CPU, IO.
	2. understand the concept of (computer and non-computer) programs.
	3. experience your first taste of Python without knowing all the details.
```

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


### Step 2: Programs talk to you.

#### Goals:

```
After taking this step, you will be able to:
	1. understand value, variable, primitive data types (int, str, float, boolean).
	2. understand the concept of mutability (some data types are mutable and some are not).
	3. implement Python programs containing: variables, assigning values, print.
	4. interpret and implement basic operations of strings: concatenation (combining), duplicating, scanning and slicing.
```

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

### Step 3: How to process / calculate?

#### Goals:
```
After taking this step, you will be able to:
	1. understand the main arithmetic operations in Python.
	2. implement arithmetic expressions in Python.
	3. convert one primitive data type to another using functions: int(), float(), str(), bool().
	4. implement Python programs containing: input from the user, type conversion, calculation, printing.
```

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

## Dig Deeper: Explore and Discover

This section invites the reader to move beyond the basics and use guided exploration to discover each concept in greater depth.

### Essentials

1. What is a *type*? Provide five examples.
2. What are the rules in defining a variable name? Define some variables in Python that are not permitted in Python. Experiment with breaking various rules in defining variables. Analyse the error message.
3. We have learned that `=` is the operator that assigns a value to a variable. It does not mean *equals*. But, how can one check if two variables have equal values? 
4. Name basic built-in data types in Python. Use examples.
5. How can you identify the type of a value / variable?
6. How can you convert:
	- `int` to `str`
	- `float` to `str`
	- `str` to `float` 
7. What are the character and text string types in Python? Make examples. 
8. How can you combine several strings? Implement an example.
9. Can you multiply a number with a string? What is the result? Implement an example.
10. How can you get character 5 of a given string? How can you get the first character?
11. How can you get a substring from a given string? For example, the postcodes in The Netherlands consist of 4 digits followed by 2 letters. How can you extract the letters from a given postcode?
12. You have learned how to print something as an output of your program. How can you read something as input? What is the *function*? What is the type?
13. What are the basic arithmetic operations? Make a list with the meaning (semantics) of each operation.
14. Why *precedences* are important? Make examples.

### Bonus

### Go Beyond

## Exercises: Practice and Apply

### Step 01:

1. Take each of the given following Python programs and carry out these steps:
	- Write down sytactical elements that are understandable for you.
	- Specify statements that you know (or you can guess) the results of the their executions.
	- Share your lists within your learning group.
	- Discuss what will be the result of the program (without execution).

*Note*: Certainly there might be some lines that will be impossible to understand fully. The goal is to evaluate your first taste of Python programs and check how intutive they are. You will be learning all details in later stages. *Trust your intuition*.

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
	
```python
#Code 03
num = int(input("Enter a number"))
if num < 0:
   print("Enter a positive number")
else:
   sum = 0
   while(num > 0):
       sum += num
       num -= 1
   print("Result is", sum)
```
	
```python
#Code 04
import random
print(random.randint(0,9))
```
	
```python
#Code 05
my_str = input("Enter a string: ")
words = [word.lower() for word in my_str.split()]
words.sort()
print("The sorted words are:")
for word in words:
	print(word)
```


2. Using **OPyEditor** try to execute the given programs. Does output of the programs match with your expectations?


### Step 02:

1. Check the following program and write down what will be the result of the prints:

```python
x = 12
y = 15
z = 1
y = z
z = 12
y = 13
x = y 
y = x
z = 7
print(x)
print(y)
print(z)
```

2. A phone number is a number. Yet we would want to save it as a text. Can you think of a reason why?
3. The number in the address of your house, for example Kerkweg **8**, is a number. Yet we would want to save it as a text. Can you think of a reason why?
4. What is an example from a number we use in the real world that we do want to save as a number in Python, not as a text.
5. User input in Python is always considered a text, even if we just enter numbers, why would it act like this?
6. Define a variable called zipcode (postcode) and give it the value of your own zipcode. Print it using `print()`.
7. Define a variable called favorite food, give it the value `"Pizza"`. Print it. Change the value to `"Roti"`. Print it.  
8. Define a variable that stores your school email address. Extract your student number from this email address.
9. Write down the complete alphabet in a variable. Split it halfway over two different variables. Join them back together in the wrong order and print it. 
10. Explain in your own words with a ```f``` style string is?

### Step 03:

1. Create two variables with a number in it, you can decide which numbers, add them together and print the result.
2. Do the same for subtraction, devide and multiply.
3. Get input from the user. Save it as a number. Print it.
4. Try to divide something by zero. Describe the error you get.
5. Create two variables with a text in it. Print them togeter at once, using only print statement.
6. Python uses PEMDAS. What is that and is it different from the way you learned it?
7. Create one calculation using at least four parantheses, three multiplications and four subtractions. Print the result.
8. We can use a ```+``` or a ```,``` to combine two strings within a print. What's the difference?
9. Using a program ask the user for input. Print the first and last characters from the input.
Ask the user for a text input. Change both the first and last characters to uppercase and print it. 


## Problems:

*Note*: A systematic approach to transfer a solution in mind into a Python program can be challenging for novice programmers. 

- A check list ([accessible here](./misc/checklist_metacog.pdf)) can be used to guide beginners to solve the following problems. 
- A template and a couple of examples are provided [here](./misc/template.py). 
- Do you still need more detailed guideline for solving problems? Read and practice [here](./misc/inf_bc_w01_problem_solving.md).

Implement Python programs to solve the following problem statements:

1. Write a program that asks the user to enter his or her name. The program should respond with a message that says hello to the user, using his or her name.
	- *Step-02*: Complete solution.

2. Write a program that asks the user to enter the width and length of a room. Once the values have been read, your program should compute and display the area of the room. The length and the width will be entered as floating point numbers. Include units in your prompt and output message; either feet or meters, depending on which unit you are more comfortable working with.
	- *Step-02*: Partial solution, i.e. no calculation yet. The user enters the requested values the program prints only ```The Area of the Room: ```.
	- *Step-03*: Complete solution, i.e. add calculations. 

3. An online retailer sells two products: widgets and gizmos. Each widget weighs 75 grams. Each gizmo weighs 112 grams. Write a program that reads the number of widgets and the number of gizmos in an order from the user. Then your program should compute and display the total weight of the order.
	- *Step-02*: Partial solution, i.e. no calculation yet. The user enters the requested values the program prints only ```The Total Weight of the Order: ```.
	- *Step-03*: Complete solution, i.e. add calculations. 

4.  Develop a program that reads a four-digit integer from the user and displays the sum of the digits in the number. For example, if the user enters ```3141``` then your program should display ```3+1+4+1=9```.
	- *Step-02*: Partial solution, i.e. no calculation yet. The user enters a four-digit integer the program prints only ```Sum: ```.
	- *Step-03*: Complete solution. 

5. Implement a program that a user enters number of days as input, and the program prints number of hours, minutes and seconds separately as output.
	- *Step-02*: Partial solution, i.e. no calculation yet.
	- *Step-03*: Complete solution, i.e. add calculations. 

	
<!--

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
-->
