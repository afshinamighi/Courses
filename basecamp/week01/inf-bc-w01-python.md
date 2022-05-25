# Python 01: Linear Programs.

**Introduction**: This document presents learning activities for Python 01. In Python 01, you will learn first elements of Python to build your first interactive linear program. We define a linear program as a flow of sequential instructions without branching and loops. At the end of Python 01, you will be able to implement a program where a user can enter simple input(s), the program calculates and prints the results as its output.

**Note:** In Python 01, exercises and examples can be executed using:

1. Online Python Editor **OPyEditor**: The final program should be stored in local machine.
2. Local Python Package (see ExtraStep-01): Using **BRef-01: Appendix B** Python can be installed in your local machine.

## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **ORef-01**: Online Tutorial; Charles Severance; "Python for Everybody"; [Available here](https://books.trinket.io/pfe/index.html)
- **OPyEditor**: Online Editor for Programming; "Online Python (with shell and file storing functionalities)"; [Available here](https://www.online-python.com/)

## Path:

Follow the following steps:

### Step-01: What is a Program?

#### Goals:

```
After taking this step, you will be able to:
	1. understand the concept of (computer and non-computer) programs.
	2. experience your first taste of Python without knowing all the details.
```

#### What to Learn?

1. Use **BRef-01: Chapter 01** as a reference and discuss the following questions:
   1. What is a general definition of a program? Provide some (none-computer) examples.
   2. What are the main elements of a program?
   3. **First Taste of Python**: Read section *Little Programs* and analyse provided examples.
   4. Consider the following python program and try to guess what the program does. Analyse and discuss inputs, behaviour and expected outputs.
   
```python
#Code 01: 
words = []
num_str = input("How many words would you like to enter?")
num = int(num_str)
for _ in range(0,num):
	word = input("Next word:")
   words.append(word)
print("This is your list of words:",words)
```
   
#### Exercises:

1. Make a small research to understand the meaning of *syntax in programming*. Give three examples from the programs you have read in **BRef-01: Chapter 01**.
2. Take each of the given following Python programs and carry out these steps:
	- Write down sytactical elements that are understandable for you.
	- Specify statements that you know (or you can guess) the results of the their executions.
	- Share your lists within your learning group.
	- Discuss what will be the result of the program (without execution).

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


3. Using **OPyEditor** try to execute the given programs. Does output of the programs match with your expectations?


<hr>

### Step-02: Everything starts with Data.

#### Goals:

```
After taking this step, you will be able to:
	1. understand the general concepts of computer hardware: Hard disk, RAM, CPU, IO.
	2. understand value, variable, primitive data types (int, str, float, boolean).
	3. understand the concept of mutability (some data types are mutable and some are not).
	4. implement Python programs containing: variables, assigning values, print.
```

#### What to Learn?

1. Perform a free (re-)search and explore the following answers:
   1. What are the main hardware elements of a computer?
   2. What is an Operating System and why do we need it?
   3. How data (values) are stored / extracted / computed in a computer? *Hint: explore concepts of bytes, bits, ram memory, hard disks, cpu registers.*
2. Using **BRef-01: Chapter 02** explore the answers for the following questions: 

*Note: There are some concepts (like objects, classes, references) that students may not be able to grasp completely. The main idea is to try as much as possible. They will be more clear later when they learn Object Oriented programming in Python.*

   1. What is a value? What is a variable?
   2. What is a *type*? Provide five examples.
   3. How can you define a variable in Python? 
   4. Define some variables in Python that are not permitted in Python. Experiment with breaking various rules in defining variables. Analyse the error message.
   5. How can you assign a value to a variable? How can we express that two items are equal?
   6. How can you identify the type of a value / variable?
3. Perform a free (re)-search and answer the following questions:
   1. What are the character and string types in Python? Make examples.
   2. You have learned how to print something as an output of your program. How can you read something as input? What is the function? What is the type?


#### Exercises:

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
6. Define a variable called zipcode (postcode) and give it the value of your own zipcode. Print it using print().
7. Define a variable called favorite food, give it the value "Pizza". Print it. Change the value to "Roti". Print it.  
8. Finish all the exercises listed in **BRef-01-Chapter 02: Things to Do**.

<hr>

### Step-03: How to Calculate?
#### Goals:
```
After taking this step, you will be able to:
	1. understand the main arithmetic operations in Python.
	2. implement arithmetic expressions in Python.
	3. convert one primitive data type to another using functions: int(), float(), str(), bool().
	4. implement Python programs containing: input from the user, type conversion, calculation, printing.
```
#### What to Learn?

1. Using **BRef-01: Chapter 03** answer the following questions:
   1. Name basic built-in data types in Python. Use examples.
   2. What are the basic arithmetic operations? Make a list with the meaning (semantics) of each operation.
   3. Why *precedences* are important? Make examples.
   4. How can you convert one data type to another? Name basic built-in functions.

#### Exercises:

1. Create two variables with a number in it, you can decide which numbers, add them together and print the result.
2. Do the same for subtraction, devide and multiply.
3. Get input from the user. Save it as a number. Print it.
4. Try to divide something by zero. Describe the error you get.
5. Create two variables with a text in it. Print them togeter at once, using only print statement.
6. Python uses PEMDAS. What is that and is it different from the way you learned it?
7. Create one calculation using at least four parantheses, three multiplications and four subtractions. Print the result.
8. Finish all the exercises listed in **BRef-01-Chapter 03: Things to Do**.

<hr>


## Problems:


Implement Python programs to solve the following problem statements:

1. Implement a program that given number of years as input prints the number of months and days as output. Input example: ```Years: 5``` , Output example: ```Months: 60 , Days: 1825```.
2. Write a program that asks the user to enter his or her name. The program should respond with a message that says hello to the user, using his or her name.
3. Write a program that asks the user to enter the width and length of a room. Once the values have been read, your program should compute and display the area of the room. The length and the width will be entered as floating point numbers. Include units in your prompt and output message; either feet or meters, depending on which unit you are more comfortable working with.
4. An online retailer sells two products: widgets and gizmos. Each widget weighs 75 grams. Each gizmo weighs 112 grams. Write a program that reads the number of widgets and the number of gizmos in an order from the user. Then your program should compute and display the total weight of the order.
5.  Develop a program that reads a four-digit integer from the user and displays the sum of the digits in the number. For example, if the user enters ```3141``` then your program should display ```3+1+4+1=9```.
6. Implement a program that a user enters number of days as input, and the program prints number of hours, minutes and seconds separately as output.

## Products:
1. Implement a program that given number of years as input prints the number of months and days as output. Input example: ```Years: 5``` , Output example: ```Months: 60 , Days: 1825```.

2. The program that you create for this exercise will begin by reading the cost of a meal ordered at a restaurant from the user. Then your program will compute the tax and tip for the meal. Use your local tax rate when computing the amount of tax owing. Compute the tip as 15 percent of the meal amount (without the tax). The output from your program should include the tax amount, the tip amount, and the grand total for the meal including both the tax and the tip.


## Extra Steps:

### ExtraStep-01: Set Up Python
1. Using **BRef-01: Appendix B** perform the following tasks:
   1. Install Python on your machine.
   2. Open a terminal (command window) and check the version of your Python. What is the command?
   3. Create a file and name it: hello.py (make sure the extension of the file is py). Open the file and use print statement to print a given text, like Hello Python. Save the file and using your terminal execute your first python program.
   4. Finish all the exercises listed in **BRef-01-Chapter 01: Things to Do**.
<!--
### Exercises:
### Problems:
-->









