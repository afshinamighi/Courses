# Python 05: Functions, Lists and Tuples.

**Introduction**: This document presents learning activities for Python 05. In Python 05, you will learn basics of functions to oraganise your large programs. A function is a fragment of code with a name to be reused in different places of the program. Moreover, in this Python you will learn how to build a sequence structure using basic data types.

## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **ORef-01**: Online Tutorial; Charles Severance; "Python for Everybody"; [Available here](https://books.trinket.io/pfe/index.html)

## Path:

### Step-01: 
#### What is a function?

1. Using **BRef-01: Chapter 09** answer and experiment the following questions:
   1. What is a function in Python?
   2. What are the main elements of a Python function? Define a simple function that does nothing.
   3. How can a function be used (called)? 
   4. How can one return the result of a function?
   5. What are the arguments and/or parameters?

#### Exercises:
1. Provide your solutions to the exercises of Python 05: Step-01. **ORef-01: Functions** can be used as extra learning reference.

[todo]

<hr>

### Step-02: 
#### Tuples.

1. Using **BRef-01: Chapter 07** answer and experiment the following questions:
   1. What is a tuple in Python and how is it defined?
   2. How can one combine and compare two (or more) tuples? 
   3. How can one iterate over the elements of a tuple?
   4. How is a tuple modified?

#### Exercises:
[todo]

<hr>

### Step-03: 
#### Lists.

1. Using **BRef-01: Chapter 07** answer and experiment the following questions:
   1. What is a tuple in Python and how is it defined?
   2. What is the result of *split()* on a string?
   3. There are two ways to get items from a list: offset and slice. What are the pros / cons of each. Experiment with some examples.
   4. How can you add new elements to a list?
   5. How can you modify elements of a list?
   6. *Mutability* is one of the main differences between a tuple and a list. Elaborate this with some example. 

#### Exercises:
[todo]

<hr>

## Problems:

1. A primary school teacher needs to automate basic arithmetic (summation, multiplication table, subtracton) exercises for her students. You are asked to implement a program that asks what type of the arithmetic the user needs to practice. Then, the program will generate exercises and the user should give the result. Consider the following features for the program:
	- For each arithmetic operation keep the total number of the exercises 10.
	- The program must be interactive: for example, if the chosen exercise is multiplication table, then the program generates two random numbers (check how python can generate random integers), like 3 and 5; the program prints 3 * 5 = and the user must give the result; the program will print if the answer was correct or wrong and then the program will generate next question.
	- Your program must be implemented with three functions, one for each arithmetic operation test and one main function that interacts with the user and call coresponding functions.
	- Numbers for summation and subtractions will be between 1 and 100.
	- For other aspects of the program feel free to decide your choice.
	- **Extented version**: Extend your program such that it collects all the mistakes from the user and prints them at the end.
	- **Extented version**: The teacher would like to know which questions are difficult for her students. Extend your program such that it measures the time that the students takes to answer each question. For each question collect the information in a tuple like **(question, correct or wrong,time)**. The program collects all the results in a list and prints them at the end.
	- **Extented version**: Sort the list of the results based on their time before printing it.

2. In a particular jurisdiction, taxi fares consist of a base fare of 4.00 eur, plus 0.25 eur for every 140 meters traveled. Write a function that takes the distance traveled (in kilometers) as its only parameter and returns the total fare as its only result. Write a main program that interacts with the user and calls the function to produce and print the final result.

4. If you have 3 straws, possibly of differing lengths, it may or may not be possible to lay them down so that they form a triangle when their ends are touching. For example, if all of the straws have a length of 6 inches. then one can easily construct an equilateral triangle using them. However, if one straw is 6 inches. long, while the other two are each only 2 inches. long, then a triangle cannot be formed. In general, if any one length is greater than or equal to the sum of the other two then the lengths cannot be used to form a triangle. Otherwise they can form a triangle.
Write a function that determines whether or not three lengths can form a triangle. The function will take 3 parameters and return a Boolean result. In addition, write a program that reads 3 lengths from the user and demonstrates the behaviour of this function.

5. In this exercise you will write a function named ```isInteger``` that determines whether or not the characters in a string represent a valid integer. When determining if a string represents an integer you should ignore any leading or trailing white space. Once this white space is ignored, a string represents an integer if its length is at least 1 and it only contains digits, or if its first character is either + or - and the first character is followed by one or more characters, all of which are digits.
Write a main program that reads a string from the user and reports whether or not it represents an integer. 
	- **Extended version**: Extend your program with a different function that if the given input string contains mixed digits and some alphabetic characters, it removes the alphabetic characters and prints the remaining integer. Example: given ```-12R0A89s``` the program will generate ```-12089```. The ersult of ```+012R0A89s``` will be ```12089```. 

6. Write a function that generates a random password. The password should have a random length of between 7 and 10 characters. Each character should be randomly selected from positions 33 to 126 in the ASCII table. Your function will not take any parameters. It will return the randomly generated password as its only result. Display the randomly generated password in your file’s main program. **Note**: Check how Python can choose random elements of a list or string.

3. The Twelve Days of Christmas is a repetitive song that describes an increasingly long list of gifts sent to one’s true love on each of 12 days. A single gift is sent on the first day. A new gift is added to the collection on each additional day, and then the complete collection is sent. The first three verses of the song are shown below.
The complete lyrics are available on the internet.

	*On the first day of Christmas my true love sent to me: 
	A partridge in a pear tree.*
	
	*On the second day of Christmas my true love sent to me: 
	Two turtle doves, And a partridge in a pear tree.*
	
	*On the third day of Christmas my true love sent to me: 
	Three French hens, Two turtle doves, And a partridge in a pear tree.*

	Your task is to write a program that displays the complete lyrics for The Twelve Days of Christmas. Write a function that takes the verse number as its only parameter and displays the specified verse of the song. Then call that function 12 times with integers that increase from 1 to 12.
Each item that is sent to the recipient in the song should only appear once in your program, with the possible exception of the partridge. It may appear twice if that helps you handle the difference between “A partridge in a pear tree” in the first verse and “And a partridge in a pear tree” in the subsequent verses. 

	 
## Extra Steps:

### ExtraStep-01:
1. [todo]






