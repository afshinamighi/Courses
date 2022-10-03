# Week 05

So far we have practiced how to define single variables to store single values. But, more data demands programs that can handle a collection of values. In this week we introduce sets as a fundamental collection in computer science.


## Learning Outcomes

After this lesson each student will be able to:
1. understand sets and the main operations of sets: membership, union, intersection, subtractions. 
2. apply sets and set operations to solve problems in Python.

## Learning Activities

Using provided material, explore and discuss the following questions (both in Python and Math):

1. What is a set? How can you write down a set? How can you specify if an item is (or is not) a member of a set?
2. When are two sets are equal? When does a set become a subset of another set? What is an empty set?
3. Describe main operations between sets and provide an example for each: `union`, `intersection`, `difference`, `complement`.
4. What is a Venn Diagram? Use Venn Diagram to describe main operations of sets.
5. What is a cartesian product? Give an example.
6. How can we implement a code to iterate over a set?
7. Explore how the following operations can be done in Python:
	- Defining an empty set.
	- Defning a set with initialised values.
	- Adding new member(s) to a set.
	- Removing a member from a set.
	- Finding cardinality of a set.
	- Testing membership.
	- Intersection of S1 and S2.
	- Union of S1 and S2.
	- Difference S1 and S2.
	- Is S1 a subset of S2 (or vice-versa)? 

#### Exercises:

1. Create a set with and fill it with some values you can think of yourself. Print the length and the last value from the set.
2. Create a string with your defined value (preferably with some repeated characters). Convert it to a set. What is teh cardinality of the set? 
3. Create a `set` containing 5 letters `x,y,q,z,u`. Ask the user the input a letter. Check with `if` statement if the given letter is inside the `set`, print `yes` or `no`.
4. Analyse the given code below without executing it. What will be the result of the program?

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

5. Design two exercises of your own. They should improve understanding topics of this step.

<hr>

## Problems:

1. Implement a program that determines and displays the number of unique characters in a string entered by the user. For example, `Hello, World!` has 10 unique characters while `zzz` has only one unique character. 

2. Implement a Python program that collects book information. The program starts with three options: entering new book, searching a book, exit. 
	- Entering new book: The program will ask to enter: book title, book author, publisher, publication date.
	- Searching a book: The user enters a term and the program must search the term within titles, authors and publishers and report the existence of such a book with the requested term.
	- Exist: The program must print all the collected books before exiting.
	- What structure do you define to store the information? Disucss about your structure with your group mate and/or teacher.

3. In an application a valid password must be a combination of digits, uppercase and lowercase letters and only four symbols `* @ ! ?` . The length of the password must not be less than 8 characters and must not be more than 20 characters. In case the password is not valid, the user can try maximum three times until it is validated. Implement a Python program that asks the password of the user and checks if it is a valid password.
	- Use sets and set operations to solve this problem.

<!--
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
-->


