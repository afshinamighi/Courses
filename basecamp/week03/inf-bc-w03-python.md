# Python 03: Iterative Programs

**Introduction**: This document presents learning steps for Python 03. In Python 03, you will learn basics of strings in PythonPython and required structures to add repetition points to your programs. An iterative program is a flow of sequential instructions with repeating statements. By the end this Python, you will be able to implement a program where a user can have simple interactions: the user repeatedly enters simple input, the program calculats the results and prints the result in output.


**Note:** Exercises of this learning path can be done using:

1. Online Python Editor **OPyEditor**: The final program should be stored in local machine.
2. Local Python Package (see Step-00): Using **BRef-01: Appendix B** Python can be installed in your local machine.

## Materials:

The learning steps are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **OPyEditor**: Online Editor for Programming; "Online Python (with shell and file storing functionalities)"; [Available here](https://www.online-python.com/)
- **Exercises**: Available here [todo: finalise the link to the exercises file of week03].


## Path:

Follow these steps:

### Step-01: 
#### Strings

1. Using **BRef-01: Chapter 05** experiment and answer the following questions:
   1. What is string data type?
   2. Which Python built-in function can be used to convert a data type to string? Try some examples in Python shell.
   3. In Python (and some other programing langiages), special characters can mean differently in a string. How one can specify these special characters in a Python program? List some of these characters and try the examples in Python shell.
   4. How one can concatenate multiple strings? Make one string with your: First name, Last name, student number and group number.
   5. What would be the result of multiplying a number with a string? Try three examples. What if the number is zero?
   6. How can you extract specific character from a given string? How can you specify the first character? Last character? How can you get a slice if a string? Try with several examples in Python shell.
   7. What are the functionality of functions: *len()*, *split()*, *join()*, *replace()*. Try two examples for each function in Python shell.

#### Exercises:

1. [todo: choose / add the exercises suitable for this step]

<hr>

### Step-02: 
#### Looping with *while*

1. Using **BRef-01: Chapter 06** answer and experiment the following questions:
   1. A *while* loop consists of a condition and a body. Pick and example from **BRef-01: Chapter 06** and specify the condition and the body of the program.
   2. Using *while* loop implement a program that prints a message (like *Hello*) for 10 times.
   3. Using *while* loop implement a counter that counts down from 10 until 0. In each iteration, the program must print the value of the counter.
   4. What is *break* statement? 
   5. Implement a program that repeatedly asks the user to enter a character as input until the user enters *q*. If the user enters *q* the program will stop. 

#### Exercises:

1. [todo: choose / add the exercises suitable for this step]

<hr>

### Step-03: 
#### Looping with *for .. in*

1. Using **BRef-01: Chapter 06** answer and experiment the following questions:
   1. [todo: very similar to Step-02: design some activities.]
    
#### Exercises:

1. Practice the exercises listed in **BRef-01-Chapter 06: Things to Do**:
	- **6.1**, **6.2** and **6.3**.

2. [todo: choose / add the exercises suitable for this step]

<hr>

## Problems:

1. Write a program that draws “modular rectangles” like the ones below. The user specifies the width and height of the rectangle, and the entries start at 0 and increase typewriter fashion from left to right and top to bottom, but are all done mod 10. Example: Below are examples of a 3 x 5 rectangular: <br>0 1 2 3 4 <br> 5 6 7 8 9 <br> 0 1 2 3 4 <br>.
2. Write a program that displays a temperature conversion table for degrees Celsius and degrees Fahrenheit. The table should include rows for all temperatures between 0 and 100 degrees Celsius that are multiples of 10 degrees Celsius. Include appropriate headings on your columns. The formula for converting between degrees Celsius and degrees Fahrenheit can be found on the internet .
3. A string is a palindrome if it is identical forward and backward. For example “anna”, “civic”, “level” and “hannah” are all examples of palindromic words. Write a program that reads a string from the user and uses a loop to determines whether or not it is a palindrome. Display the result, including a meaningful output message.
4. There are numerous phrases that are palindromes when spacing is ignored. Examples include “go dog”, “flee to me remote elf” and “some men interpret nine memos”, among many others. Write a program that it ignores spacing while determining whether or not a string is a palindrome. For an additional challenge, extend your solution so that is also ignores punctuation marks and treats uppercase and lowercase letters as equivalent.
5. In this exercise you will create a program that displays a multiplication table that shows the products of all combinations of integers from 1 times 1 up to and including 10 times 10. Your multiplication table should include a row of labels across the top of it containing the numbers 1 through 10. It should also include labels down the left side consisting of the numbers 1 through 10.
6. Write a program that converts a binary (base 2) number to decimal (base 10). Your program should begin by reading the binary number from the user as a string. Then it should compute the equivalent decimal number by processing each digit in the binary number. Finally, your program should display the equivalent decimal number with an appropriate message.
7. [todo: add more exercises]
