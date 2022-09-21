# Python 06: Functions, Dictionaries and Sets.

**Introduction**: This document presents learning activities for Python 06. In Python 06, you will learn dictionaries to collect keys and coresponding values. Moreover, you will learn more features of functions. 

**Note:** Exercises of this learning path should be done using:

1. IDE: Using **BRef-01: Chapter 19, Section: Integrated Development Environment** PyCharm can be installed in your local machine.

## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **ORef-01**: Online Tutorial; Charles Severance; "Python for Everybody"; [Available here](https://books.trinket.io/pfe/index.html)
- **ORef-02**: Book, Brian Heinold; "A Practical Introduction to Python Programming" [Available Online, Check here](https://www.brianheinold.net/python/python_book.html)


## Path:

### Step-01: Dictionaries.

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs with Python Dictionaries: creating, adding and modifying items,  extracting value(s), extracting key(s), deleting, pop and clear, iteration over dictionaries.
```

#### What to Learn?

1. Using **BRef-01: Chapter 08** answer and experiment the following questions:
   1. What is a dictionary in Python and how can you create a dictionary?
   2. How can items be added/changed to/in a dictionary?
   3. How can you get the value of a given key? 
   4. What are the behaviour of these functions: *keys()*, *values()*, *items()*?
   5. When can we use *del*, *pop()* and *clear()*? Experiment with some examples.
   6. How can one iterate over a dictionary?

#### Exercises:   

1. Describe in your own words the difference between a `dictionary` and a `tuple`.
2. Create a new dictionary containing a key named `FirstName` with the value `Larry`, a key named `LastName` with the value `Page`. Print the last value from the dictionary.
3. Create a dictionary with the following pairs `"brand": "Ford", "model": "Mustang", "year": 1964`. 
	- Print all the values from the distionary.
	- Print all the keys from the dictionary.
	- Print the length of the dictionary.
	- Add `"color": "Red"` and remove the pair with key = `"year"`. Print keys and values separately. 
4. Given the following code below. Explain in your own words what happens in this code. What are the keys in the dictionary?

 ```python
import random
rdic = {}
for i in range(0,10):
	rdic[i] = random.randint(0,100)
for item in rdic.values():
	print(item)
```

5. Modify the code from the previous exercise so each value becomes a `tuple` containing two random numbers.

6. Provide your solutions to the exercises of **ORef-01: Dictionary**.

7. Design two exercises of your own. They should improve understanding topics of this step.

8. If you don't have PyCharm yet, install *PyCharm* on your working machine. Implement and run a simple Python program of your choice. 
	- It is important to learn how to create a new Python program, how to configure interpreter and how to run the program. Where do you see the results?

9. **Extra:** Provide your solutions to the exercises f **ORef-01: Dictionaries** 


<hr>

### Step-02: Functions (more).

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs with Python functions: positional arguments, keyword arguments, parameters default values, docstrings.
```

#### What to Learn?

1. Using **BRef-01: Chapter 09** answer and experiment the following questions:
   1. What are the positional arguments in Python? What about keyword arguments?
   2. How can one define default values for function parameters? 
   3. What are Docstrings? How can they be helpful?

#### Exercises:

1. Describe in your own words what `*args` and `**kwargs` do.
2. Create a function that takes an `*args` of numbers as argument, which calculates the sum of all numbers and returns the result. Call the function and print the returned value.
3. Complete the given code below.

 ```python
def count_passes(**kwargs):
    count = 0
    #Complete this function to count the number of passes
    
    return count
#
result = count_passes(math="Fail", science="Fail", history="Pass", english="Pass")
print(result)
```

4. Analyse the given code below without executing it. What will be the result of the program?

 ```python
def do_something(*args, **kwargs):
    for i in args:
        for key, value in kwargs.items():
            if i == key:
                print(value)
#
#
do_something("a", "z", "d", "b", a=1, b=2, c=3, d=4)
```

5. Design two exercises of your own. They should improve understanding topics of this step.

6. **Extra:** Provide your solutions to the exercises f **ORef-01: Functions** 


<hr>

### Step-03: Sets.

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs with Python Sets: creating sets, difference between sets and lists and tuples, adding and removing elelemnts, membership operator, iteration over a set, basic operations between sets: intersection, union, difference and subset.
```

#### What to Learn?

1. Using **BRef-01: Chapter 08** answer and experiment the following questions:
   1. What is a set in Python and how is it defined?
   2. How can one add/remove elements to/from a set?
   3. How can one iterate over a set?
   4. Assume two sets S1 and S2. How can one specify the following operations on S1 and S2 in Python:
	   - Intersection of S1 and S2.
	   - Union of S1 and S2.
	   - Difference S1 and S2.
	   - Is S1 a subset of S2 (or vice-versa)? 

#### Exercises:

1. Describe in your own words the difference between a `set` and a `tuple`.
2. Describe in your own words the difference between a `set` and a `list`.
3. Create a set with and fill it with some values you can think of yourself. Print the length and the last value from the set.
3. Create a function which takes a `dictionary` as argument and returns a `set` created from the values of the given `dictionary`. Call the function and print all values from the returned set.
4. Create a `set` containing 5 letters `x,y,q,z,u`. Ask the user the input a letter. Check with `if` statement if the given letter is inside the `set`, print `yes` or `no`.
5. Analyse the given code below without executing it. What will be the result of the program?

 ```python
sfind = set('orihme')
schar = set('ichgo')
print("Step 1:")
for i in sfind:
    if i in schar:
        print(i)
#
print("Step 2:")
schar.update(sfind)
for i in schar:
    print(i)
```

9. Design two exercises of your own. They should improve understanding topics of this step.

<hr>

## Problems:

1. Implement a program that determines and displays the number of unique characters in a string entered by the user. For example, `Hello, World!` has 10 unique characters while `zzz` has only one unique character. 
	- Use only dictionaries to solve this problem. 
	- Use only sets to solve this problem.
	- Which solution would you prefer?

2. Implement a Python program that collects book information. The program starts with three options: entering new book, searching a book, exit. 
	- Entering new book: The program will ask to enter: book title, book author, publisher, publication date.
	- Searching a book: The user enters a term and the program must search the term within titles, authors and publishers and report the existence of such a book with the requested term.
	- Exist: The program must print all the collected books before exiting.
	- What structure do you define to store the information? Disucss about your structure with your group mate and/or teacher.

3. In an application a valid password must be a combination of digits, uppercase and lowercase letters and only four symbols `* @ ! ?` . The length of the password must not be less than 8 characters and must not be more than 20 characters. In case the password is not valid, the user can try maximum three times until it is validated. Implement a Python program that asks the password of the user and checks if it is a valid password.
	- Use sets and set operations to solve this problem.

4. The following data reprsents average tempratures of the third month for 1995, 2010, and 2020 recorded in Amsterdam (source is [available here](https://academic.udayton.edu/kissock/http/Weather/gsod95-current/NLAMSTDM.txt)).
Implement a program that given this data (copy the structures in your program) prints the answers for the following questions:
	- How many days have equal average tempratues in March 1995 and March 2010.
	- How many days have equal average tempratues in March 1995 and March 2020. 
	- Which year has a day with highest temprature in March?
	- Which year had the warmest March?

```python
('1995','3',['47.3', '40.0', '38.3', '36.3', '37.4', '40.3', '41.1', '40.5', '41.6', '43.2', '46.2', '45.8', '44.9', '39.4', '40.5', '42.0', '46.5', '46.2', '43.3', '41.7', '40.7', '39.6', '44.2', '47.8', '45.9', '47.3', '39.8', '35.2', '38.5', '40.5', '47.0'])

('2010','3',['39.2', '36.7', '35.5', '35.2', '35.8', '33.8', '30.7', '33.2', '32.3', '33.3', '37.3', '39.9', '40.8', '42.9', '42.7', '42.6', '44.8', '50.3', '52.2', '55.2', '47.2', '45.0', '48.6', '55.0', '57.4', '50.9', '48.6', '46.2', '49.6', '50.1', '43.6'])

('2020','3',['43.2', '41.1', '40.0', '43.6', '42.6', '44.0', '44.0', '47.9', '46.6', '50.5', '51.5', '47.7', '44.7', '44.0', '48.9', '45.3', '46.6', '49.7', '47.2', '44.8', '41.8', '40.9', '41.0', '42.7', '43.4', '44.0', '46.4', '45.5', '40.7', '39.5', '40.6'])

```

5. Morse Code Translator: Morse code is an encoding scheme that uses dashes and dots to represent numbers and letters. Implement a program that uses a dictionary to store the mapping from letters and numbers to Morse code. Your program should read a message from the user. Then it should translate each
character in the message to its mapping code. 
	- Put a space between translated character. Example: `Hello` is translated into ....&nbsp;.&nbsp;.-..&nbsp;.-..&nbsp;--- 
	- Put a 4 spaces when there is a space in the original message. Example: `Hello World` is translated into ....&nbsp;.&nbsp;.-..&nbsp;.-..&nbsp;---&nbsp;&nbsp;&nbsp;&nbsp;.--&nbsp;---&nbsp;.-.&nbsp;.-..&nbsp;-... 

	- Your program should print a proper error message if there is no mapping for specific characters. 
	- Extend your program with functionality of decoding a morse code.
	- Extend your program such that given a string it detects if it is a normal text or a morse code. Then based on the type of the message it translates to the other one. 


```python
MORSE_CODE_DICT = { 
	'A':'.-', 'B':'-...',
	'C':'-.-.', 'D':'-..', 'E':'.',
	'F':'..-.', 'G':'--.', 'H':'....',
	'I':'..', 'J':'.---', 'K':'-.-',
	'L':'.-..', 'M':'--', 'N':'-.',
	'O':'---', 'P':'.--.', 'Q':'--.-',
	'R':'.-.', 'S':'...', 'T':'-',
	'U':'..-', 'V':'...-', 'W':'.--',
	'X':'-..-', 'Y':'-.--', 'Z':'--..',
	'1':'.----', '2':'..---', '3':'...--',
	'4':'....-', '5':'.....', '6':'-....',
	'7':'--...', '8':'---..', '9':'----.',
	'0':'-----', ',':'--..--', '.':'.-.-.-',
	'?':'..--..'}
```
## Assignment:

1. Create an application that manages contacts in an addressbook. The following requirements should be implemented:
	- Add a contact with first name and last name (only alphabet), multiple (unique) e-mails (containing at least one '@'),
multiple (unique) phone numbers (only digits). Also, an ID should be generated which should be 1 higher 
than the highest current ID. 
	- Remove a contact by ID.
	- List all contacts with the option to sort by first_name or last_name (default first_name) with a sort_by parameter
and in ascending (ASC) or decending (DESC) direction (default ASC) witb a direction parameter.
	- Merge duplicate contacts (automatically). Contacts with the exact same full name (first and last name combined) should be merged.
The e-mails and phone numbers of the duplicate contacts should be added to the the first duplicate contact
(contact with the highest ID). The other duplicate contcts should be deleted from the addressbook.
	- Contacts are read from the provided JSON file and should be updated with new or removed contacts.
	- **Note**: A Python file and a dataset are provided. The Python file is an incomplete program with `todos comments` for the solution. The incomplete Python program can be found in **./week06/assignment_data/process_addbook.py** ([here](./assignment_data/process_addbook.py)) and the dataset is in **./week06/assignment_data/contacts.json** ([here](./assignment_data/contacts.json)). 


## Extra Steps




