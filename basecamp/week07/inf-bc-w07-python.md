# Python 07: Functions and Collective Structures.

**Introduction**: This document presents learning activities for Python 07. In Python 07, you will learn more in depth about tuples, lists, dictionaris and functions. 

**Note:** Exercises of this learning path must be done using:

1. IDE: Using **BRef-01: Chapter 19, Section: Integrated Development Environment** PyCharm can be installed in your local machine.


## Materials:

The activities are designed based on these following references:
Python
- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **ORef-01**: Online Tutorial; Charles Severance; "Python for Everybody"; [Available here](https://books.trinket.io/pfe/index.html)


## Path:

### Step-01: Functions (more).

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs with Python functions: [todo].
```

#### What to Learn?

1. Using **BRef-01: Chapter 09** answer and experiment the following questions:
   1. "Functions are first-class citizens": What does this sentence mean?
   2. What is an anonymous function and how can you define it in Python? Experiment with some examples.
   3. What are *namespace* and *scope*? What is the scope of a function? Use examples to justofy your answers. 

#### Exercises:

1. Analyse the given code below without executing it. What will be the result of the program?

```python
r = lambda a : a + 15
print(r(10))
r = lambda x, y : x * y
print(r(12, 4))
```

2. Complete the given code by creating a lambda that checks if a given number is even.

```python
even = #your lambda here
print(even(4))
print(even(13))
```

3. Create a code snippet that splits up a list into two new lists. Depending on if the number in the list is even or odd. Accomplish this with using a lambda and knowledge from the earlier weeks. 
- For example: Original list of integers:
`[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]`.
New list with only the even numbers:
`[2, 4, 6, 8, 10]`.
New list with the odd numbers:
`[1, 3, 5, 7, 9]`

4. Complete the function that checks if a given list is sorted or not, use at least one lambda within the function.

```python
def am_i_sorted(numberlist):
    #write the code
result = am_i_sorted([1,2,5,6,8,17])
print(result) #True
result = am_i_sorted([1,2,99,6,8,17])
print(result) #False
```

5. Create a lambda that takes two arguments and returns a Tuple containing those two values. 

6. Complete the function that checks if the items in a given list are `True` for the given lambda. Return a list containing all `True` values.

```python
def check_with_lambda(l, lam):
    #write the code

x = lambda a : a < 10
y = [1,6,19,22,7]
print(check_with_lambda(x, y)) #[1,6,7]
x = lambda a : a.index(1) == 'b'
y = ["abc", "bcd", "ube", "cur"]
print(check_with_lambda(x, y)) #["abc","ube"]
```

7. Design two exercises of your own. They should improve understanding topics of this step.

8. If you don't have PyCharm yet, install *PyCharm* on your working machine. Implement and run a simple Python program of your choice. 
	- It is important to learn how to create a new Python program, how to configure interpreter and how to run the program. Where do you see the results?

<hr>

### Step-02: Tuples and Lists (more).

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs with Python Tuples and Lists: [todo].
```

#### What to Learn?

1. Using **BRef-01: Chapter 07** answer and experiment the following questions:
   1. We have learned *join()* on a string. How does *join()* work in a list?
   2. How can we sort items of a list? Is this possible on a tuple?
   3. There are several ways to copy a list: *list(), clicing, copy()* and *deepcopy()*. Experiment different expamples for each technique.
   4. How can one build a list using *list comprehension*? Do we have *tuple comprehension*?

#### Exercises:
1. [todo]
2. Design two exercises of your own. They should improve understanding topics of this step.

<hr>

### Step-03: Dictionaries and Sets (more).

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs with Python Dictionaries and Sets: [todo].
```

#### What to Learn?

1. Using **BRef-01: Chapter 08** answer and experiment the following questions:
   1. How do *copy()* and *deepcopy()* behave on dictionaries? What about sets?
   2. How does *dictionary comprehension* work? What about sets?
   3. Try to build the following nested structures:
	   - List of lists.
	   - Tuple of lists.
	   - Tuple of tuples.
	   - List of tuples 

#### Exercises:
1. [todo]
2. Design two exercises of your own. They should improve understanding topics of this step.

<hr>

## Problems:
[todo]

## Products:
[todo]

## Extra Steps:
[todo]




