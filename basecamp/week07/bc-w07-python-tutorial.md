# Python 07: Tutorial

## Todo

- 

## Introduction

As you continue exploring Python, understanding how data is stored, accessed, and manipulated at different levels becomes crucial for writing efficient and bug-free code. Imagine you’re working on a program that processes customer orders. You decide to use lambda functions to quickly filter high-value purchases, but soon realize that function behavior changes unexpectedly due to variable scope. Similarly, while copying order records, modifying one list unexpectedly alters another—revealing the difference between shallow and deep copies. These are common pitfalls that can lead to subtle bugs if not well understood. This tutorial dives deeper into lambda functions, name scope and variable scope, and copying techniques for lists, tuples, sets, and dictionaries. By mastering these concepts, you’ll gain greater control over how Python manages data, functions, and memory, helping you write more predictable and maintainable code.

## Step 01: Functions (more).

In the previous tutorial, we have learned that functions are not just blocks of code but also objects, meaning they can be assigned to variables and used later. This allows flexibility in function handling, such as renaming or passing functions as arguments.

For situations where a function is needed only once and does not require a name, Python provides lambda functions (anonymous functions). These are concise, single-expression functions that can be defined directly where they are used.
One of the major advantages of lambda functions is their ability to improve code readability when performing operations like sorting. Consider a list of students with their names and ages. The traditional way to sort them by age would involve defining a function:

```python
def by_age(student):
    return student[1]

students.sort(key=by_age)
```
However, if the sorting logic is needed only once, a lambda function makes the code cleaner:
```python
students.sort(key=lambda student: student[1])
```
This removes unnecessary function definitions and makes the sorting process more readable.

Lambda functions help make code cleaner and more concise by eliminating the need for separate function definitions, especially in cases where a function is used only once. However, because lambda expressions pack logic into a single line, they can be challenging for beginners to interpret and analyze at first. The compact syntax may make it harder to understand the flow of execution compared to traditional function definitions.

Like any other programming skill, understanding lambda functions improves with practice. By working on exercises, experimenting with different use cases, and gradually incorporating lambda expressions into coding tasks, beginners can become more comfortable using them effectively. With time, what once seemed complex will feel intuitive and natural. 

Here are couple of progressively challenging lambda function examples, starting from a simple one-parameter function and gradually increasing the complexity by adding more parameters and logic. Try to read them carefully, and analyze the execution order and predict the outcome. Then, copy the example in your IDE and after running check if your understanding was correct.

```python
# lambda function below uses conditional expressions
is_even = lambda x: "Even" if x % 2 == 0 else "Odd" 

print(is_even(10))  
print(is_even(7))  
```

```python
format_name = lambda title, first, last: f"{title}. {first.capitalize()} {last.capitalize()}"

print(format_name("Dr", "alice", "johnson"))
print(format_name("Mr", "bob", "smith"))  
```

```python
weighted_score = lambda hw, exam, project: (hw * 0.3) + (exam * 0.5) + (project * 0.2)

print(weighted_score(85, 90, 80)) 
print(weighted_score(70, 75, 80)) 
```

Lambda functions in Python are designed to be simple and concise, but they have limitations compared to regular functions. One important limitation is that lambda expressions cannot contain complex coding structures like loops (for, while) or multiple statements (if-elif-else, variable assignment, etc.). Check the examples below:

```python
# This will cause an error
set_value = lambda x: result = x  # Syntax Error
```

```python
# This will cause an error 
sum_list = lambda lst: for x in lst: total += x  # Syntax Error
```

Now that we have gained a solid understanding of functions, it is important to explore the scope of definitions—how and where variables exist and can be accessed in a program. In Python, namespace and scope play a crucial role in organizing variables, functions, and objects, ensuring that each name is uniquely identified and used correctly.

A namespace acts as a container that maps variable names to their values, preventing conflicts between different parts of the program. Meanwhile, scope determines the visibility and accessibility of these variables, ensuring that variables are only used within the correct context.

Understanding namespace and scope not only helps avoid errors like “variable not defined” or unintended modifications but also improves code organization, making programs more readable and maintainable. By mastering these concepts, you will be able to write cleaner, more efficient Python code while avoiding common pitfalls related to variable access and function definitions.

A namespace is like a container that holds names (variables, functions, objects) and their values. Think of it as a name tag system that helps Python find variables correctly. There are three main types of namespaces:

1.	Built-in Namespace: Contains functions and keywords that Python provides by default, like `print()`, `len()`, and `int()`.
2.	Global Namespace: Holds variables that are defined at the top level of a script and are accessible anywhere in the file.
3.	Local Namespace: Created when a function is called, containing variables defined inside the function. These variables exist only while the function runs.


Scope refers to where a variable can be accessed in a program. Python has four levels of scope, following the LEGB rule:

1.	Local (L): Variables defined inside a function. They can only be used inside that function.
2.	Enclosing (E): In a function inside another function, the inner function can use variables from the outer function.
3.	Global (G): Variables defined outside all functions. They can be used anywhere in the script.
4.	Built-in (B): Python’s built-in functions and keywords.


```python
x = 10  # Global variable

def show_number():
    y = 5  # Local variable (only exists inside this function)
    print("Inside function:", y)

show_number()

# Trying to access 'y' outside the function will cause an error
# print(y)  # This will give an error: NameError: name 'y' is not defined

print("Outside function:", x)  # Global variable can be accessed anywhere
```


By default, modifying a global variable inside a function creates a new local variable, unless we explicitly tell Python to use the global variable using the global keyword.

```python
count = 0  # Global variable

def increase_count():
    global count  # Allows modifying the global variable
    count += 1
    print("Inside function:", count)

increase_count()
print("Outside function:", count)  # Shows updated global value
```

In the example above, without `global`, Python treats count as a new local variable inside the function. Using `global count` allows the function to modify the global variable instead of creating a new one.

### Problem Solving

Develop a Python program to analyze employee performance based on multiple evaluation criteria. The program should compute performance scores, determine bonus eligibility, and rank employees accordingly.

Task Description

A company evaluates its employees based on three performance factors:

1.	Work Quality
2.	Punctuality
3.	Teamwork

Each of these factors has a different level of importance in the final performance score. The company wants a system that:

1.	Processes employee performance data and calculates a final score based on weighted criteria.
2.	Determines which employees qualify for a performance bonus based on a predefined threshold.
3.	Sorts employees in descending order of their performance scores.
4.	Generates a summary report displaying: Employee names, Their calculated performance scores, Whether they qualified for a bonus

#### Strategy

To efficiently solve this problem, we follow these steps:

1. Define how performance data will be stored and structured.
- Each employee has three scores that contribute to the final performance score.
- The scores should be weighted according to their importance.
- A dictionary is a good choice, where: The key is the employee’s name, The value is a tuple containing the three scores, This allows efficient lookups and storage while keeping the data organized.

2. Compute the final performance score using a weighted formula.
- Instead of treating all criteria equally, we assign different weights to each factor.
- The final performance score is calculated using a weighted formula:
`Score = (Work Quality * 0.4) + (Punctuality * 0.3) + (Teamwork * 0.3)`
- A lambda expression is ideal for this, as it performs calculations inline without defining a separate function.
- There’s no need to create a full function for a simple mathematical operation.

3. Determine bonus eligibility by setting a threshold score.
- If an employee’s final score exceeds this threshold, they qualify for a bonus.

4. Sort employees by performance score in descending order.
- The best-performing employees should appear at the top of the report.
- Sorting will be done using another lambda function as the key for sorting.

5. Display the final results in a clear and structured format.

#### Solution

```python
# Global variable for company-wide bonus threshold
BONUS_THRESHOLD = 85  # Employees scoring above this get a bonus
BONUS_PERCENTAGE = 10  # Bonus increases salary by this percentage

# Employee performance data (name as key, scores as tuple)
employees = {
    "Alice": (90, 85, 88),
    "Bob": (78, 80, 75),
    "Charlie": (95, 92, 90),
    "David": (60, 65, 70),
    "Eve": (88, 85, 87),
}

### **Step 1: Lambda Function to Calculate Performance Score**
calculate_score = lambda scores: (scores[0] * 0.4) + (scores[1] * 0.3) + (scores[2] * 0.3)

### **Step 2: Function to Determine Bonus Eligibility (Using Global Variables)**
def calculate_bonus(score):
    """Determines if an employee qualifies for a bonus."""
    global BONUS_THRESHOLD, BONUS_PERCENTAGE  # Using global scope
    
    if score > BONUS_THRESHOLD:
        return score * (1 + BONUS_PERCENTAGE / 100)  # Apply bonus
    else:
        return score  # No bonus applied
        
### **Step 3: Processing Employee Data**
def process_employees(employee_data):
    """Calculates scores, applies bonuses, and sorts employees."""
    results = []  # Local scope

    for name, scores in employee_data.items():
        performance_score = calculate_score(scores)  # Lambda function for score calculation
        final_score = calculate_bonus(performance_score)  # Applying bonus if applicable
        results.append((name, performance_score, final_score > performance_score))  # Store result

    # Sorting employees by performance score (Highest first)
    results.sort(key=lambda x: x[1], reverse=True)
    
    return results  # Returning results to keep local scope data separate

### **Step 4: Displaying Results**
def display_results(results):
    """Displays sorted employee rankings and bonus eligibility."""
    print("\n **Employee Performance Report**\n")
    print(f"{'Employee':<10} {'Score':<10} {'Bonus?':<10}")
    print("=" * 30)

    for name, score, bonus_eligible in results:
        print(f"{name:<10} {score:.2f} {'Yes' if bonus_eligible else 'No':<10}")

### **Main Function**
def main():
    """Main function to run the employee performance system."""
    print(" **Employee Performance Analysis System** \n")
    employee_results = process_employees(employees)
    display_results(employee_results)

### **Run the Program**
if __name__ == "__main__":
    main()
```


## Step 02: Tuples and Lists (more).

List comprehension is a concise way to create lists in Python by applying an operation to each item in an existing iterable (like a list, range, or tuple). It replaces traditional for loops when building lists, making the code shorter and more readable. The basic syntax is as follows:

```python
new_list = [expression for item in iterable]
```

where: `expression` is the operation to perform on each item, `item` is each element from the iterable, and iterable is the collection (list, tuple, etc.) we are looping through. Let's see couple of examples:

```python
numbers = [1, 2, 3, 4, 5]
squares = [num ** 2 for num in numbers]
print(squares)  # Output: [1, 4, 9, 16, 25]
```

```python
numbers = [1, 2, 3, 4, 5, 6]
evens = [num for num in numbers if num % 2 == 0] # Filtering Even Numbers
print(evens)  # Output: [2, 4, 6]
```

```python
numbers = [1, 2, 3, 4, 5]

# Convert each number to a string
string_numbers = [str(num) for num in numbers]

print(string_numbers)  # Output: ['1', '2', '3', '4', '5']
```

List comprehension works on any iterable, like tuples, but the output is a **list** by default. To keep the result as a different iterable, one needs to convert the type. See the example below:

```python
numbers = (1, 2, 3, 4, 5)  # A tuple

squared_numbers = [num ** 2 for num in numbers] # The result is a list [1, 4, 9, 16, 25]
squared_numbers_tuple = tuple(num ** 2 for num in numbers) # The result is a tuple (1, 4, 9, 16, 25)
```
As we learned in processing strings, the `.join()` method in Python is used to combine a list of strings into a single string, inserting a specified separator between elements.
We can use this method in a list. The `.join()` method combines **a list of strings** into a single string, inserting a specified separator between them.
If you’re working with non-string elements (like numbers), `.join()` **won’t work directly** because it requires all elements to be strings. Instead, we can use list comprehensions (or `map()`).

```python
words = ["Python", "is", "awesome"]
sentence = " ".join(words)
print(sentence) # Output: "Python is awesome"

numbers = [1, 2, 3, 4, 5]
joined_numbers = " - ".join(str(num) for num in numbers) # Convert numbers to strings before joining
print(joined_numbers) # Output: "1 - 2 - 3 - 4 - 5"
```

Sorting is a common operation in Python, and it works differently for lists and tuples.
Python provides two ways to sort a list: Using `.sort()` that **modifies the list in-place** and `sorted()` that returns a new sorted list.

```python
numbers = [5, 2, 9, 1, 5]
numbers.sort()  # Sorts the original list in-pace, no new list created
print(numbers)  # Output: [1, 2, 5, 5, 9]

numbers_2 = [5, 2, 9, 1, 5]
sorted_numbers = sorted(numbers_2)  # Creates a new sorted list
print(sorted_numbers)  # Output: [1, 2, 5, 5, 9]
print(numbers_2)  # Output: [5, 2, 9, 1, 5] (Original list remains unchanged)
```

Since tuples are **immutable**, they cannot be sorted in place like lists, but they can be sorted using `sorted()`, which returns a new sorted **list**. If you need the result as a tuple, convert it back using `tuple()`.

```python
numbers_tuple = (5, 2, 9, 1, 5)
sorted_items = sorted(numbers_tuple)
print(sorted_items)  # Output: [1, 2, 5, 5, 9]  (Note: Returns a list, not a tuple)

sorted_tuple = tuple(sorted(numbers_tuple))
print(sorted_tuple)  # Output: (1, 2, 5, 5, 9) returns a tuple
```

Often one needs to copy elements of a list. When copying a list in Python, it’s important to know whether the copy is completely separate or still connected to the original list. A shallow copy keeps links to some parts of the original list, while a deep copy makes a fully independent copy. Below are four common ways to copy a list and how they work.

1. Copying a List Using `list()`: Creates a new list with the same elements (Shallow Copy). Works for simple lists (no nested structures, i.e. list of lists).

```python
original = [1, 2, 3, 4]
copy_list = list(original)

print(copy_list)  # Output: [1, 2, 3, 4]

# Modifying the copy does NOT affect the original
copy_list.append(5)
print(original)   # Output: [1, 2, 3, 4]
print(copy_list)  # Output: [1, 2, 3, 4, 5]
```

2. Copying a List Using Slicing (`[:]`): Creates a new list with the same elements (Shallow Copy). This technique is faster than `list()` in most cases but
 it has the same limitations as `list()` (nested lists remain linked i.e. shallow copy).

```python
original = [1, 2, 3, 4]
copy_list = original[:]  # Slicing the whole list
print(copy_list)  # Output: [1, 2, 3, 4]
```

Check and analyze the following example very carefully. It presents the problem of shallow copying. The outer list is copied, but inner lists still reference the same objects.

```python
nested_list = [[1, 2], [3, 4]]
copy_nested = nested_list[:]  # Shallow copy

copy_nested[0][0] = 99  # Modify the first inner list
print(nested_list)  # Output: [[99, 2], [3, 4]] (Original list changed!)
```

3. Copying a List Using `.copy()`: It is similar to `list()` and `[:]`, but more readable. This technique still is a shallow copy, meaning nested lists are shared.

```python
original = [1, 2, 3, 4]
copy_list = original.copy()
print(copy_list)  # Output: [1, 2, 3, 4]
```

4. Copying a List Using `deepcopy()`: Creates a true independent copy of the entire list (Deep Copy). This method is needed for nested lists or lists containing other mutable objects. This technique is best choice when working with complex structures (nested lists). It is fully independent copy, i.e. modifications in the copy do not affect the original.

```python
import copy  # Import copy module

original = [[1, 2], [3, 4]]
deep_copy_list = copy.deepcopy(original)  # Deep Copy

# Modifying the copy does NOT affect the original
deep_copy_list[0][0] = 99
print(original)      # Output: [[1, 2], [3, 4]]  (Unchanged)
print(deep_copy_list) # Output: [[99, 2], [3, 4]] (Only the copy changed)
```


### Problem Solving


#### Strategy


#### Solution



## Step 03: Dictionaries and Sets (more).

When working with dictionaries in Python, sometimes we need to create a copy so that changes to one dictionary do not affect the other. However, similar to lists and tuples, Python handles copies in two ways: shallow copy and deep copy.

A shallow copy creates a new dictionary, but if the original dictionary contains lists or other dictionaries inside it, these are not fully copied. Instead, both the original and the copy share the same inner elements.

For example, using the `.copy()` method: 

```python
original = {'a': 1, 'b': [2, 3]}
shallow_copy = original.copy()

shallow_copy['b'].append(4)  # Adding an element to the list inside the copy

print(original)       # {'a': 1, 'b': [2, 3, 4]}
print(shallow_copy)   # {'a': 1, 'b': [2, 3, 4]}
```

Another way to make a shallow copy is by using the copy module:
```python
import copy

original = {'x': 10, 'y': [20, 30]}
shallow_copy = copy.copy(original)

shallow_copy['y'].append(40)  # Changing the list

print(original)       # {'x': 10, 'y': [20, 30, 40]}
print(shallow_copy)   # {'x': 10, 'y': [20, 30, 40]}
```

As shown in the example above, when we modify the list inside `shallow_copy`, the same change appears in original. This happens because both dictionaries still share the same list.

Dictionary comprehension can also create a shallow copy.

```python
original = {'a': 1, 'b': [2, 3]}
shallow_copy = {key: value for key, value in original.items()} # Dictionary comprehension

shallow_copy['b'].append(4)

print(original)       # {'a': 1, 'b': [2, 3, 4]}
print(shallow_copy)   # {'a': 1, 'b': [2, 3, 4]}
```

Dictionary comprehension is useful for modifying values while copying but does not create a deep copy.

A deep copy, on the other hand, creates a completely independent copy, including all lists and other dictionaries inside it. This means that changes made to the copy do not affect the original.

Dictionaries provide a `copy()` method for shallow copying, but **not** `deepcopy()` because deep copying is more complex. Since dictionaries can store various types of objects (including other dictionaries and lists), Python handles deep copying at a more general level with the copy module.

For example, using `copy.deepcopy()`:
```python
import copy

original = {'a': 1, 'b': [2, 3]}
deep_copy = copy.deepcopy(original)

deep_copy['b'].append(4)  # Modifying the copied dictionary

print(original)   # {'a': 1, 'b': [2, 3]}
print(deep_copy)  # {'a': 1, 'b': [2, 3, 4]}
```

Similar to other collective structures, sometimes we need to create a copy of a set. However, copying sets is different from copying lists or dictionaries because **sets cannot contain mutable objects** *like lists*. This makes copying simpler because we don’t need to worry about deep copying in most cases.

There are three common ways to copy a set in Python: shallow Copy using the method `copy()`, shallow Copy using the copy module, copying with set comprehension. Follow examples here:

```python
original = {1, 2, 3, 4}
shallow_copy = original.copy()

shallow_copy.add(5)  # Adding an element to the copied set

print(original)       # {1, 2, 3, 4}
print(shallow_copy)   # {1, 2, 3, 4, 5}
```

```python
import copy

original = {10, 20, 30}
shallow_copy = copy.copy(original)

shallow_copy.add(40)  # Adding an element to the copied set

print(original)       # {10, 20, 30}
print(shallow_copy)   # {10, 20, 30, 40}
```

```python
original = {100, 200, 300}
comprehension_copy = {item for item in original}

comprehension_copy.add(400)  # Adding an element to the copied set

print(original)            # {100, 200, 300}
print(comprehension_copy)  # {100, 200, 300, 400}
```

Unlike lists or dictionaries, sets do not support deep copying because sets cannot contain mutable elements like lists. This means:
- If you use `copy.deepcopy()`, it behaves the same as a shallow copy.
- There is no need for deep copying since sets only contain immutable values.

Let's try an example.  Tuples are immutable, which means their contents cannot be changed after they are created. Because of this, we can store tuples inside a set. This is allowed because sets only allow immutable (unchangeable) elements, and tuples meet this requirement.


Since sets are mutable, but tuples inside them are immutable, copying a set of tuples follows the same principles as copying a normal set.

```python
original = {(1, 2), (3, 4), (5, 6)}
shallow_copy = original.copy()

shallow_copy.add((7, 8))  # Adding a new tuple

print(original)       # {(1, 2), (3, 4), (5, 6)}
print(shallow_copy)   # {(1, 2), (3, 4), (5, 6), (7, 8)}
```

```python
import copy

original = {(1, 2), (3, 4)}
deep_copy = copy.deepcopy(original)

deep_copy.add((5, 6))  # Adding a new tuple

print(original)   # {(1, 2), (3, 4)}
print(deep_copy)  # {(1, 2), (3, 4), (5, 6)}
```

### Problem Solving

You are developing a student course registration system for a university. The system should allow students to modify their course registrations in a way that ensures the original records remain unchanged.

Write a `function modify_registration(student_data, student_id, new_course)` that:

- Takes the existing student data, a student ID, and a new course name.
- Creates a separate copy of the student data where changes can be made.
- Adds the new course to the copied student’s registration without modifying the original records.
- Returns both the original and the modified student data.

#### Strategy

1. Understand the Data Structure
- Identify how student data is stored (e.g., a dictionary of student records).
- Recognize that each student has a name and a list of courses.
2. Identify the Core Requirement
- The function must allow modifying a student’s courses without affecting the original records.
- The function should return both the original and the modified versions.
3.	Choose a Copying Method
- A simple assignment (=) won’t work since lists inside dictionaries are mutable.
- A shallow copy won’t fully solve the issue because nested lists remain shared.
- A deep copy is needed to ensure complete separation of data.
4.	Modify the Copied Data
- Locate the student in the copied dataset using the `student_id`.
- Append the new_course to the student’s course list in the copied version.
5.	Return Both Versions
- Return the original student data and the modified copy.
6.	Test with Different Cases
- Try adding a course for different students.
- Verify that the original data remains unchanged.
- Handle edge cases (e.g., adding a course to an empty list).

#### Solution

```python
import copy

def modify_registration(student_data, student_id, new_course):
    """
    Creates a deep copy of the student data and modifies the copied version
    by adding a new course to the given student.
    """
    # Ensure deep copy so the original data remains unchanged
    copied_data = copy.deepcopy(student_data)

    # Modify only the copied version
    if student_id in copied_data:
        copied_data[student_id]["courses"].append(new_course)
    
    return copied_data

def test_modify_registration():
    """
    Function to test the modify_registration function with sample data.
    """
    # Sample student data with 8-digit IDs
    students = {
        "01234567": {"name": "Alice", "courses": ["Math", "Physics"]},
        "02345678": {"name": "Bob", "courses": ["Chemistry", "Biology"]},
    }

    # Print original data before modification
    print("Original Student Data:")
    for student_id, details in students.items():
        print(f"{student_id}: {details}")

    # Test modifying registration
    modified_students = modify_registration(students, "01234567", "Computer Science")

    # Print data after modification
    print("\nModified Student Data:")
    for student_id, details in modified_students.items():
        print(f"{student_id}: {details}")

    # Validate that the original data remains unchanged
    print("\nVerifying Original Data is Unchanged:")
    print(f"Original Data for 01234567: {students['01234567']}")
    print(f"Modified Data for 01234567: {modified_students['01234567']}")

def main():
    """
    Main function to run the test cases.
    """
    test_modify_registration()

# Run the main function
if __name__ == "__main__":
    main()
```

## Summary

This tutorial provided an in-depth exploration of lambda functions, name scope, and variable scope, along with shallow and deep copying of lists, tuples, sets, and dictionaries in Python. It began by demonstrating how lambda functions simplified operations such as sorting and filtering, offering concise alternatives to traditional function definitions. The tutorial then delved into variable scope and namespace management, explaining how Python organized variables and controlled their accessibility across different parts of a program. Using practical examples, it illustrated the LEGB (Local, Enclosing, Global, Built-in) rule and the significance of the global keyword.

The tutorial further explored shallow and deep copying, emphasizing the differences in how Python handled mutable and immutable data structures. Through practical scenarios, it highlighted how shallow copies retained references to nested objects, leading to unintended modifications, whereas deep copies created fully independent duplicates. Various copying techniques across lists, tuples, sets, and dictionaries were demonstrated, showing real-world applications, such as modifying student course registrations without altering original records.

By the end of this tutorial, you gained a deeper understanding of Python’s memory management and data handling, enabling you to write more reliable and maintainable code.

## Assignment (Draft)

