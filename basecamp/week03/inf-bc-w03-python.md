# Python 03: Iterative Programs

**Introduction**: This document presents learning steps for Python 03. In Python 03, you will learn basics of strings in Python and required programming structures to add repetition points to your programs. An iterative program is a flow of sequential instructions with repeating statements. By the end of Python 03, you will be able to implement a program where a user can have simple interactions: the user repeatedly enters simple input, the program calculats and prints the results.


**Note:** Exercises of this learning path can be done using:

- **Tutorial**: A short tutorial about this week can be found [here](./bc-w03-python-tutorial.md).
- Online Python Editor **OPyEditor**: The final program should be stored in local machine.
- Local Python Package: Using **BRef-01: Appendix B** Python can be installed in your local machine.

## Materials:

The learning steps are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **OPyEditor**: Online Editor for Programming; "Online Python (with shell and file storing functionalities)"; [Available here](https://www.online-python.com/)


## Path:

Follow these steps:

### Step-01: Strings

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs using string operations and functions: *, +, len(), split(), join(), replace(), subsrtings, slicing, f strings.
```

#### What to Learn?


1. Using **BRef-01: Chapter 05** experiment and answer the following questions:
   1. What is string data type?
   2. Which Python built-in function can be used to convert a data type to string? Try some examples in Python shell.
   3. In Python (and some other programing langiages), special characters can mean differently in a string. How one can specify these special characters in a Python program? List some of these characters and try the examples in Python shell.
   4. How one can concatenate multiple strings? Make one string with your: First name, Last name, student number and group number.
   5. What would be the result of multiplying a number with a string? Try three examples. What if the number is zero?
   6. How can you extract specific character from a given string? How can you specify the first character? Last character? How can you get a slice if a string? Try with several examples in Python shell.
   7. What are the functionality of functions: *len()*, *split()*, *join()*, *replace()*. Try two examples for each function in Python shell.

#### Exercises:

1. Ask the user to input a text. Print the length of the entered text.
2. Ask the user to input a text. Replace the first character with a ```k``` and print the result.
3. Make a variable with the text "this is a text". Remove all spaces from it. Print the result. 
4. Ask the user to input a text. Capitalize the complete input. Print the result. 
5. Ask the user to input a text. Remove all ```e``` characters from it. Print the result. Try to see what happens if the input doesn't contain an ```e```.
6. Ask the user to input a text. Count how many times the input contains the character ```i```. Print the result.
7. Ask the user to input two texts (two inputs). Print them together in one line using a ```f string```.
<hr>

### Step-02: Looping with *while*

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs using while-loops.
```

#### What to Learn?

1. Using **BRef-01: Chapter 06** answer and experiment the following questions:
   1. A *while* loop consists of a condition and a body. Pick and example from **BRef-01: Chapter 06** and specify the condition and the body of the program.
   2. Using *while* loop implement a program that prints a message (like *Hello*) for 10 times.
   3. Using *while* loop implement a counter that counts down from 10 until 0. In each iteration, the program must print the value of the counter.
   4. What is *break* statement? 
   5. Implement a program that repeatedly asks the user to enter a character as input until the user enters *q*. If the user enters *q* the program will stop. 

#### Exercises:

1. Print the numbers 1 to 42 using a ```while``` loop.
2. Print all odd numbers between 1 to 100 by using a ```while``` loop. 
3. Print the numbers from 10 to -10 using a ```while``` loop. 
4. Ask the user to input a text. Print each character of the input on a new line using a ```while``` loop. 
5. Ask the user to input a text. Print each character of the input that is the character ```e``` or ```a``` on a new line. 
6. What will be the output of the given code?
 
 ```python
i = 20
while i < 42:
	i = i *2 
	print(i-1)
```
7. What will be the output of the given code?
 
 ```python
i = -4
end = -33
while i > end:
	i = i -4 
	print(i*2)
```

8. If we swap the last two lines in the previous exercise we get a different output. Why is this?
 
 ```python
i = -4
end = -33
while i > end:
	print(i*2)
	i = i -4 
```

<hr>

### Step-03: Looping with *for .. in*

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs using for-loops.
```

#### What to Learn?

1. Using **BRef-01: Chapter 06** answer and experiment the following questions:
   1. What are the main elements of a *for* loop? 
   2. Using *for* loop implement a program that prints a message (like *Hello*) for 10 times.
   3. Using *for* loop implement a counter that counts down from 10 until 0. In each iteration, the program must print the value of the counter.
   4. Can you use a *break* statement within a *for* loop? Build a simple example. 
   5. Implement a *for* loop that prints characters of a given string. 
   6. Implement a *for* loop that given a string, prints characters positioned in odd indeces, i.e. ```1,3,5,7,...```. 
    
#### Exercises:

1. Print the numbers 1 to 42 using a ```for``` loop.
2. Print all uneven numbers between 1 to 100 by using a ```for``` loop. 
3. Ask the user to input a text. Print each character of the input on a new line using a ```for``` loop. 
4. The ```for``` and ```while``` are considered 'loops'. Explain in your own words what a loop is. 
5. Describe the difference between the ```for``` and ```while``` in your own words. 
6. What will be the output of the given code?

 ```python
i = 7
for number in range(1,i+i):
	print(number)
```
7. What will be the output of the given code?
 
 ```python
i = 1
j = 10
for number in range(i,j):
    if number > 5:
        print(number)
    else:
        print('Hello')
```
8. What will be the output of the given code?
 
 ```python
sentence = "I just came to say hello!"
count = 0
for letter in sentence:
    if letter == " ":
        count = count + 1
    elif letter == "a":
        count = count - 1
print(count)
```
9. What will be the output of the given code?
 
 ```python
 sentence="I just came to say hello!"
 for i in range(0,len(sentence)):
 	print(sentence[i])
```

10. What will be the output of the given code?
 
 ```python
 sentence="I just came to say hello!"
 for c in sentence:
 	print(c)
```

11. Practice the exercises listed in **BRef-01-Chapter 06: Things to Do**:
	- **6.1**, **6.2** and **6.3**.


<hr>

## Problems:

**Note**: All your solutions must check invalid inputs from the user and print proper error messages.

1. A string is a palindrome if it is identical forward and backward. For example “anna”, “civic”, “level” and “hannah” are all examples of palindromic words. Write a program that reads a string from the user and uses a loop to determines whether or not it is a palindrome. Display the result, including a meaningful output message.
	- *Step-01*: Complete solution, **without** loops.
	- *Step-02*: Complete solution, using *while* loop.
	- *Step-03*: Complete solution, using *for* loop.

2. There are numerous phrases that are palindromes when spacing is ignored. Examples include “go dog”, “flee to me remote elf” and “some men interpret nine memos”, among many others. Write a program that it ignores spacing while determining whether or not a string is a palindrome.
	- *Step-01*: Complete solution, **without** loops.
	- *Step-02*: Complete solution, using *while* loop.
	- *Step-03*: Complete solution, using *for* loop.
	- For an additional challenge, extend your solution so that is also ignores punctuation marks (like ```, . ? ! ;```) and treats uppercase and lowercase letters as equivalent.

3. Write a program that draws “modular rectangles” like the ones below. The user specifies the width and height of the rectangle, and the entries start at 0 and increase typewriter fashion from left to right and top to bottom, but are all done mod 10. Example: Below are examples of a 3 x 5 rectangular: <br>0 1 2 3 4 <br> 5 6 7 8 9 <br> 0 1 2 3 4 <br>.
	- *Step-02*: Complete solution, using *while* loop.
	- *Step-03*: Complete solution, using *for* loop.

4. Write a program that displays a temperature conversion table for degrees Celsius and degrees Fahrenheit. The table should include rows for all temperatures between 0 and 100 degrees Celsius that are multiples of 10 degrees Celsius. Include appropriate headings on your columns. The formula for converting between degrees Celsius and degrees Fahrenheit can be found on the internet .
	- *Step-02*: Complete solution, using *while* loop.
	- *Step-03*: Complete solution, using *for* loop.

5. In this exercise you will create a program that displays a multiplication table that shows the products of all combinations of integers from 1 times 1 up to and including 10 times 10. Your multiplication table should include a row of labels across the top of it containing the numbers 1 through 10. It should also include labels down the left side consisting of the numbers 1 through 10.
	- *Step-02*: Complete solution, using *while* loop.
	- *Step-03*: Complete solution, using *for* loop.

6. Write a program that converts a binary (base 2) number to decimal (base 10). Your program should begin by reading the binary number from the user as a string. Then it should compute the equivalent decimal number by processing each digit in the binary number. Finally, your program should display the equivalent decimal number with an appropriate message.
	- Make a research about binary and decimal numbers and how a binary can be converted to a decimal using pen-paper.
	- *Step-01*: Partial solution. The program reads a binary number in string format and converts its decimal using built-in functions.
	- *Step-02*: Complete solution, using *while* loop implement the steps of conversion.
	- *Step-03*: Complete solution, using *for* loop implement the steps of conversion.

7. Make a research about *truth tables*. Write down truth tables for ```and``` and ```or```. Implement a program that prints these two truth tables.
	- *Step-03*: Complete solution.



## Assignment:

1. Usually companies use a predefined templates in their emails. A company named XYZ would like to have a Python program that collects basic information and generates the content of the email. You are assigned to implement the program with the following criteria:
	- There are only two templates: ```Job Offer``` and ```Rejection```.
	- For the ```Job Offer``` email, the program asks: first name, last name, job title, annual salary, starting date.
	- For the ```Rejection``` email, the program asks: first name, last name, job title, with or without feedback, one feedback statement in case it is with feedback.
	- The program must check valid input formats.
	- First and last names: each minimum two characters and maximum ten characters; cotaining only alphabets, both starting with capital letters.
	- Job title: minimum 10 characters without numbers.
	- Salary: valid floating point number between (and including) 20.000,00 and 80.000,00.
	- Date: only in ```YYYY-MM-DD``` format, no negative numbers, days between 1 - 31, month between 1 - 12, year only 2021 and 2022.
	- Feedback: if the email contains a feedback there is an extra line in the text otherwise that line must be removed (check the example below).
	- The program will generate emails until the user answers ```No``` to the ```More Letters?``` question.
	- In case of invalid input from the user, the program must proper message and then repeats the question again.
	- A sample execution is presented below. Use this sample execution for the templates of the emails. Your program must have only **two** templates:

```
More Letters?(Yes or No)Yes
Job Offer or Rejection?Job Offer
First Name? John
Last Name? Hartman
Job Title? Junior Python Programmer
Annual Salary? 30.500,50
Start Date?(YYYY-MM-DD) 2021-01-01
Here is the final letter to send:
Dear John Hartman, 
 After careful evaluation of your application for the position of Junior Python Programmer, 
 we are glad to offer you the job. Your salary will be 30.500,50 euro annually. 
Your start date will be on 2021-01-01. Please do not hesitate to contact us with any questions. 
Sincerely, 
HR Department of XYZ 

More Letters?(Yes or No)Yes
Job Offer or Rejection?Rejection
First Name? David
Last Name? Johanson
Job Title? Junior C++ Programmer
Feedback? (Yes or No) No
Here is the final letter to send:
Dear David Johanson, 
After careful evaluation of your application for the position of Junior C++ Programmer, 
at this moment we have decided to proceed with another candidate. 
We wish you the best in finding your future desired career. Please do not hesitate to contact us with any questions. 
Sincerely, 
HR Department of XYZ 

More Letters?(Yes or No)Yes
Job Offer or Rejection?Rejection
First Name? David
Last Name? Chan
Job Title? Software Tester
Feedback? (Yes or No) Yes
Enter your Feedback (One Statement): You have sufficient testing knowledge but we expected to see more experience in web application testing techniques.
Here is the final letter to send:
Dear David Chan, 
After careful evaluation of your application for the position of Software Tester, 
at this moment we have decided to proceed with another candidate. 
Here we would like to provide you our feedback about the interview.
You have sufficient testing knowledge but we expected to see more experience in web application testing techniques. 
We wish you the best in finding your future desired career. Please do not hesitate to contact us with any questions. 
Sincerely, 
HR Department of XYZ 

More Letters?(Yes or No)No
```