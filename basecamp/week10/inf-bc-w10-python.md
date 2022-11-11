# Python 10: (Plain) Data Files

**Introduction**: This document presents learning activities for Python 10. In Python 10, you will get introduced with plain data files in Python. 

**Note**: In this phase, it is expected the learner can divide the program into smaller learning steps. The goal and direction of the topics will be provided. The learning must take smaller steps towards the goals such that can implement solutions to the given problems and product(s).

## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **ORef-01**: Online Tutorial; Charles Severance; "Python for Everybody"; [Available here](https://books.trinket.io/pfe/index.html)


## Path:

### Step: Files and Content.

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs using plain data files: encoding / decoding, ascii and utf-8 encodings, binary vs text files, reading / modifying / wrting binary / text data files, searching content using regular expressions.
```

#### What to Learn?

1. Using **BRef-01: Chapter 12**, **BRef-01: Chapter 14**, **ORef-01: Chapter 7** and **ORef-01: Chapter 11** answer and experiment the following questions:
   1. What is encoding and decoding?
   2. How can we encode a string to bytes in Python? How can we decode some bytes to a string?
   3. What are text data and binary data? Experiment with some examples.
   4. Given an existing text file, how can we open and read the content in Python? What about a binary file?
   5. Given an existing text file, how can we open and add some new content? What about a binary file?
   6. Given an existing text file, how can we open and add search for an exact value? What about a binary file?
   7. Given an existing text file, how can we open and add search for a pattern using regular expression? 

#### Exercises:

1. Design at least ten different exercises of your own. They should improve understanding topics of this step. Share your exercises with your learning community and practice.


## Problems:
1. Unix-based operating systems usually include a tool named head. It displays the first 10 lines of a file whose name is provided as a command line parameter. Write a Python program that provides the same behavior. Display an appropriate error message if the file requested by the user does not exist or if the command line parameter is omitted.

2. Unix-based operating systems also typically include a tool named tail. It displays the last 10 lines of a file whose name is provided as a command line parameter. Write a Python program that provides the same behavior. Display an appropriate error message if the file requested by the user does not exist or if the command line
parameter is omitted.
*Note*: There are several different approaches that can be taken to solve this problem. Implement all three options and experiment with files with large content. Analyse the performance of each option (measure execution time of each solution).
	- Option One: is to load the entire contents of the file into a list and then display the last 10 elements.
	- Option Two: is to read the contents of the file twice, once to count the lines, and a second time to display the last 10 lines. 
	- Option Three: Options one and two are  not desirable when working with **large** files. Another solution exists that only requires you to read the file once, and only requires you to store 10 lines from the file at one time. 

3. **(Optional)** Create a program that adds line numbers to a file. The name of the input file will be read from the user, as will the name of the new file that your program will create. Each line in the output file should begin with the line number, followed by a colon and a space, followed by the line from the input file.

4. In this exercise you will create a Python program that identifies the longest word(s) in a file. Your program should output an appropriate message that includes the length of the longest word, along with all of the words of that length that occurred in the file. Treat any group of non-white space characters as a word, even if it includes numbers or punctuation marks.

5. Write a program that displays the word (or words) that occur **most** and **least** frequently in a file. Your program should begin by reading the name of the file from the user. Then it should find the word(s) by splitting each line in the file at each space. Finally, any leading or trailing punctuation marks should be removed from each word. In addition, your program should ignore capitalization. As a result, apple, apple!, Apple and ApPlE should all be treated as the same word.

6. Python uses the `#` character to mark the beginning of a comment. The comment ends at the end of the line containing the `#` character. In this exercise, you will create a program that removes all of the comments from a Python source file. Check each line in the file to determine if a `#` character is present. If it is then your program should remove all of the characters from the `#` character to the end of the line (we’ll ignore the situation where the comment character occurs inside of a string). Save the modified file using a new name that will be entered by the user. The user will also enter the name of the input file. Ensure that an appropriate error message is displayed if a problem is encountered while accessing the files.

7. **(Optional)** While generating a password by selecting random characters generally gives a relatively secure password, it also generally gives a password that is difficult to memorize. As an alternative, some systems construct a password by taking two English words and concatenating them. While this password isn’t as secure, it is much easier to
memorize.
Write a program that reads a file containing a list of words, randomly selects two
of them, and concatenates them to produce a new password. When producing the password ensure that the total length is between 8 and 10 characters, and that each word used is at least three letters long. Capitalize each word in the password so that the user can easily see where one word ends and the next one begins. Display the password for the user.

8. **(Optional)** Spelling mistakes are only one of many different kinds of errors that might appear in a written work. Another error that is common for some writers is a repeated word. For example, an author might inadvertently duplicate a word, as shown in the following sentence:
`At least one value must be entered
entered in order to compute the average.`
Some word processors will detect this error and identify it when a spelling or grammar check is performed. In this exercise you will write a program that detects repeated words in a text file. When a repeated word is found your program should display a message that contains the line number and the repeated word. Then the program must ask the user if the repeated word to be removed or find display next one. 
The name of the file to examine will be provided as the program’s only command line parameter. Display an appropriate error message if the user fails to provide a command line parameter, or if an error occurs while processing the file.

9. **(Optional)** Sensitive information is often removed, or redacted, from documents before they are released to the public. When the documents are released it is common for the redacted text to be replaced with black bars.
In this exercise you will write a program that redacts all occurrences of sensitive words in a text file by replacing them with asterisks. Your program should redact sensitive words wherever they occur, even if they occur in the middle of another word. The list of sensitive words will be provided in a separate text file. Save the redacted version of the original text in a new file. The names of the original text file, sensitive words file, and redacted file will all be provided by the user.

10. When one writes a function, it is generally a good idea to include a comment that outlines the function’s purpose, its parameters and its return value. However, sometimes comments are forgotten, or left out by well-intentioned programmers that plan to write them later but then never get around to it.
Create a python program that reads one or more Python source files and identifies functions that are not immediately preceded by a comment. For the purposes of this exercise, assume that any line that begins with `def`, followed by a space, is the beginning of a function definition. Assume that the comment character, `#`, will be the first character on the previous line when the function has a comment. Display the names of all of the functions that are missing comments, along with the file name and line number where the function definition is located.
The user will provide the names of one or more Python files as command line parameters. If your program encounters a file that doesn’t exist or can’t be opened then it should display an appropriate error message before moving on and processing the remaining files.
	- **Extended version**: Extend your program such that it generates a new python file where functions without comments will be commented with a `todo` note. For example, if in the input file there exist a function named `def sum(a,b):` without any comment, then in the output file it will be:

```python
# todo: add comment to this function.
def sum(a,b):
``` 

	
## Assignment:

For this assignment you are going to expand your carparking program to handle file reading and writing.
Two new additions need to be added to the existing program from week 09 which will be explained in depth below.

1. *Logging car check-in and check-out*
Create a new class named CarParkingLogger which contains (at least) a method to log a car check-in and a method to log a car check-out. Every check-in and check-out should write a line to a logfile named `carparklog.txt` which is shared by all car parking machines. The lines should be written in a specific format as shown in the following examples:
	- Car parking machine North with a parking fee rate of 2 euro per hour checks in a car with license_plate SG-123-B on September 9 at 14:33:54 (hours, minutes, seconds).

This should result in the following log line:
```
09-02-2022 14:33:54;cpm_name=North;license_plate=SG-123-B;action=check-in
```

- Car parking machine North checks the same car out at 16:50:02:
```
09-02-2022 16:50:02;cpm_name=North;license_plate=SG-123-B;action=check-out;parking_fee=6
```

2. *Reading the current car parking machine states*
When initializing a car parking machine you should load all non checked-out cars (checked-in but not checked-out) from the log file for this specific machine (example 'North'). Be sure to not check-in these cars again (as this will create new log lines), but only load them in the car parking machine instance/object.

3. *Calculate the total parking fee for a specific car parking machine on a specific day.* Add a new method to the CarParkingLogger which accepts two arguments:
	- car parking machine name (case insensitive)
	- search date (format: DD-MM-YYYY)
The total parking fee should be rounded up to two decimals.

4. *Calculate the total amount of parking fees for a specific license plate.* Add a new method to the CarParkingLogger which accepts one argument:
	- license plate

The total fee returned should be independent of the car parking machine used and should be rounded up to two decimals.

Hint: use the datetime module to modify your datetime to the correct format.

To test your code, use the test file from the assignment of week 09.

## Extra Steps: 



