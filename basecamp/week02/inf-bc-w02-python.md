# Python 02: Branching Programs

**Introduction**: This document presents learning activities for Python 02. In Python 02, you will learn basics of Python structures to add decision points to your programs. A branching program is a flow of sequential instructions with branching statements. By the end this week, you will be able to implement a program where a user can enter simple input, the program can make choices based on some conditions and after calculation, results can be printed.

**Note:** Exercises of this learning path can be done using:

1. Online Python Editor **OPyEditor**: The final program should be stored in local machine.
2. Local Python Package (see Step-01): Using **BRef-01: Appendix B** Python can be installed in your local machine.

## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **OPyEditor**: Online Editor for Programming; "Online Python (with shell and file storing functionalities)"; [Available here](https://www.online-python.com/)

## Path:


Follow these steps:

### Step-01: Set Up
#### Goals:

```
After taking this step, you will be able to:
	1. implement and run your Python programs in your local machine.
```

#### What to Learn?

1. Using **BRef-01: Appendix B** perform the following tasks:
   1. Install Python on your machine.
   2. Open a terminal (command window) and check the version of your Python. Which command did you use?
   3. Using **OPyEditor** implement a program that prints a statement of a defined variable, like ```Hello Python!```. Save the file in your local machine within a folder created by you. Using your terminal (command line) execute your first Python program. Which command do you need to execute a Python program?

#### Exercises:

1. Create a file named ```print_input.py```. Open it using an editor of your own choice. Enter your code in it to ask the user to input a text. Print that text. Run the file using the command line.
2. Read **BRef-01: Chapter 01, Section Running Python** and run python shell. Excute ```quit()```. What do you observe?
3. Start python shell and execute ```num = input('Enter a number:')```. Enter a number and print the value of ```num```. There are two different ways to print the value of ```num```. Try both at shell. Which one works in **OPyEditor**? Do you recognise differences between programming using *python shell* and an *editor*? Read **BRef-01: Chapter 01, Section Running Python** including subsections.  

**Note**: After this step, you can try both *python shell* and *editor* to practice. It is recommended to use *python shell* for small experiments and use programming within *editor*s (local or online) for writing a full program.
 
<hr>

### Step-02: Programs need to decide.
#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement boolean expressions.
	2. implement Python programs with conditional statements.
```

#### What to Learn?

1. Using **BRef-01: Chapter 04** discuss and experiment the following questions:
   1. What is a comment? How can you specify a comment in Python?
   2. What are: boolean values, boolean expressions, comparison operators?
   3. What is a conditional statement in Python? What is correct syntax for a correct *if-else* statament? What is a *body* of a *if-else* statement?

#### Exercises:

1. Create a variable with the value ```True```. Print it. Change the value to ```False```. Print it. 
2. Create a variable
	- named ```a``` with the value ```True```, another 
	- named ```b``` with the value ```False```. Use print to check the output of ```print(a == b)```.
	- Do the same for the other comparison operators, ```!=```, ```<```, ```>```, ```<=```, ```>=```.
4. Repeat the second exercise using an *if-statement*. Print ```yes``` or ```no```, for true false. 
	- Write a comment above the *if-statement* explaining with it does. 
6. Implement a program in which the user is asked for input. Save the input of the user in a variable. Print ```yes``` if the input contains the character ```e```, ```no``` if not. 
7. Think of an useful situation where you need to check something with a if-statement within another if-statement (nested if-statements). Code it and write a comment to explain why it needs a nested if. 
8. Finish all the exercises listed in **BRef-01-Chapter 04: Things to Do**.

<hr> 
  
### Step-03: Strings are essential.
#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement basic operations of strings: concatenation (combining), duplicating, scanning and slicing.
```

#### What to Learn?

1. Using **BRef-01: Chapter 05** discuss and experiment the following questions:
   1. How can you combine several strings? Implement an example.
   2. Can you multiply a number with a string? What is the result? Implement an example.
   3. How can you get character 5 of a given string? How can you get the first character?
   4. How can you get a substring from a given string?

#### Exercises:

1. We can use a ```+``` or a ```,``` to combine two strings within a print. What's the difference?
2. Using a program ask the user for input. Print the first and last characters from the input.
3. Students numbers start with 0. Implement a program where the user enters her/his student number and your program must check if it starts with 0.
4. Ask the user to input a number. If it is lower than ```10``` print it, otherwise only print the first character.
5. Write down the complete alphabet in a variable. Split it halfway over two different variables. Join them back together in the wrong order and print it. 
6. Explain in your own words with a ```f``` style string is?
7. Look up the Spanish alphabet and put it in a variable. Put the Dutch alphabet in a variable. Print ```yes``` if the letter k is at the same position at both, print ```no``` if not. Use an ```if``` statement. 
8. Ask the user for a text input. Change both the first and last characters to uppercase and print it. 
9. Practice the exercises listed in **BRef-01-Chapter 05: Things to Do**.
 
 <hr>    


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


## Assignment:

1. Write a program that reads a date from the user and computes its immediate successor. For example, if the user enters values that represent 2013-11-18 then your program should display a message indicating that the day immediately after 2013-11-18 is 2013-11-19. If the user enters values that represent 2013-11-30 then the program should indicate that the next day is 2013-12-01. If the user enters values that represent 2013-12-31 then the program should indicate that the next day is 2014-01-01. 
	- The date will be entered in ```YYYY-MM-DD``` format. 
	- Assume there is no leap year and February is always 28 days.
	- The program must print ```Input format ERROR. Correct Format: YYYY-MM-DD``` in case the user enters an incorrect input. Some examples of incorrect input: ```2013/12/30```,```2013_12_30```, ```0213/12/30```, ```30-12-2013```.
	- Input example: ```Input Date: 2013-12-31``` , Output example: ```Next Date: 2014-01-01```.
	- **Optional**: Check if the given date is valid. For example: `2022-13-22` , `2022-11-35` , `0122-11-35` are not valid dates.
 



## Extra Steps:
