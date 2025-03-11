# Python 06: Tutorial

## Todo

- add a section titled as "For Curious Minds": One of the topics that can be explained simply is the notion of efficiency and big-O notation to compare the efficient operations, like having a solution between sets and lists.

## Introduction



## Step 01: Dictionaries

As we have learned so far, in Python, we often use lists and tuples to store multiple values. These structures allow us to access elements using their position (index). However, in many real-world applications, we often need to retrieve a specific value associated with a meaningful key, rather than an arbitrary position. A dictionary in Python is a collection that stores key-value pairs. Instead of accessing values by index (like lists and tuples), we access them by a key. Imagine a school where each student has a unique student number. Instead of keeping a list of student names and searching through it every time, we can use a dictionary to quickly find a student’s name based on their student number. In this example, the keys are student numbers and the values are names.
Instead of searching through a list, we can instantly find a student’s name using their number. A dictionary in Python is very similar to a function because both take an input (parameter) and return an output (value).

A dictionary in Python is created using curly braces `{ }` and stores key-value pairs. Each key must be unique, and it maps to a specific value. You can create a dictionary with some known values at the start.

```python
students = {
    "0207099": "Alice",
    "0454183": "Bob",
    "0960749": "Charlie",
    "0531901": "David",
    "0863377": "Eve",
}

print(students) # {'0207099': 'Alice', '0454183': 'Bob', '0960749': 'Charlie', '0531901': 'David', '0863377': 'Eve'}
```

In Python, you can create an empty dictionary first and then add key-value pairs later. This is useful when the data is not available all at once and needs to be added dynamically.

```python
# Step 1: Create an empty dictionary
students = {}

# Step 2: Add key-value pairs (student numbers as keys, names as values)
students["0207099"] = "Alice"
students["0454183"] = "Bob"
students["0960749"] = "Charlie"
students["0531901"] = "David"
students["0863377"] = "Eve"

# Print the dictionary
print(students)
```

Instead of manually adding each student, we can store student numbers and names in separate lists and use a loop to add them to the dictionary dynamically.

```python
# List of student numbers (7-digit, starting with '0')
student_numbers = ["0207099", "0454183", "0960749", "0531901", "0863377"]

# List of student names
student_names = ["Alice", "Bob", "Charlie", "David", "Eve"]

# Step 1: Create an empty dictionary
students = {}

# Step 2: Use a for loop to add student numbers and names to the dictionary
for i in range(len(student_numbers)):
    students[student_numbers[i]] = student_names[i]. # See how the value of one list is used as the key

# Print the dictionary
print(students)
```

Once we have created a dictionary, we can perform various operations on it, such as looking up values, updating entries, retrieving all keys, and getting all values. Dictionaries allow us to store data efficiently and access it quickly using keys.

We can look up a student’s name using their student number. Before accessing a key, it’s good practice to check if the key exists to avoid errors. In this example, see how the `in` is used to check if the dictionary contains a certain key:

```python
student_id = "0960749"
if student_id in students:
    print(f"Student {student_id} is {students[student_id]}")
else:
    print("Student not found.")

```

Dictionaries allow us to update values easily. For example, if a student’s name needs correction, we can simply assign a new value to the existing key:

```python
students["0454183"] = "Bobby"  # Updating Bob to Bobby
print(f"Updated name for 0454183: {students['0454183']}")
```

To retrieve all student numbers, we use the `.keys()` method, which returns a collection of all the dictionary’s keys. In this example, see how the function `list()` is used to convert the collection to a list:

```python
all_student_numbers = students.keys()
print("All student numbers:", list(all_student_numbers))
```

Similarly, if we want to get all student names, we use the `.values()` method:

```python
all_student_names = students.values()
print("All student names:", list(all_student_names))
```

The `.items()` method in Python allows us to retrieve both the keys and values from a dictionary at the same time. Instead of accessing keys and values separately, `.items()` returns a collection of key-value pairs as tuples, making it easy to iterate over a dictionary.

```python
all_student_pairs = students.items() 
print(all_student_pairs)
# Output: [('0207099', 'Alice'), ('0454183', 'Bobby'), ('0960749', 'Charlie'), ('0531901', 'David'), ('0863377', 'Eve')]
```

Depending on what we need, we can iterate over a dictionary in different ways. If we want to iterate over only the keys (student numbers), we can use `.keys()`. Imagine, you need to update the name of the students with the first name and last name. Check this example: 

```python
students = {
    "0207099": "Alice",
    "0454183": "Bob",
    "0960749": "Charlie",
    "0531901": "David",
    "0863377": "Eve"
}

# Dictionary of last names corresponding to student numbers
last_names = {
    "0207099": "Johnson",
    "0454183": "Smith",
    "0960749": "Brown",
    "0531901": "Williams",
    "0863377": "Davis"
}

# Updating dictionary to include both first and last names
for student_id in students.keys():
    students[student_id] = students[student_id] + " " + last_names[student_id]

# Print the updated dictionary
print(students)
```

Sometimes we need to process only the values. The example below presents a case where we can find the longest name:

```python
# Initialize variables to track the longest name
longest_name = ""
max_length = 0

# Iterate over the values (student names) to find the longest one
for name in students.values():
    if len(name) > max_length:
        longest_name = name
        max_length = len(name)

# Print the result
print(f"The longest student name is: {longest_name}")
```

This example shows how to identify students (by student number) whose last names have more than 6 characters. This example iterates over both keys (student numbers) and values (full names) and extracts the last name dynamically.

```python
# Iterate over key-value pairs and check last name length
for student_id, full_name in students.items():
    first_name, last_name = full_name.split()  # Split full name into first and last name
    if len(last_name) > 6:
        print(f"Student {student_id} ({full_name}) has a long last name.")
```

Python provides multiple ways to remove elements from a dictionary, depending on whether you want to delete a specific key, retrieve and remove a key, or completely empty the dictionary.

The `del` statement removes a key-value pair from the dictionary. If the key does not exist, it raises a `KeyError`.

```python
# Remove a student by student number
del students["0454183"]
```

The `.pop()` method removes a key-value pair and returns the value. If the key does not exist, it raises a `KeyError`, unless a default value is provided.

```python
# Remove and get the removed value
removed_student = students.pop("0207099")

print(f"Removed student: {removed_student}")
```

Finally, the `.clear()` method removes all key-value pairs, leaving the dictionary empty. We recommend to try this in your example.

### Problem Solving

A small community library wants to digitally manage its book collection. Each book in the library has:

- A unique ISBN number (a 13-digit identifier).
- A title and an author.

The library staff should be able to:

1.	Add new books to the system.
2.	Look up a book using its ISBN and retrieve its details.
3.	Remove a book from the system when it is no longer available.
4.	Update book details (title or author) when necessary.
5.	List all available books in the library.

Your task is to develop a system that allows the library staff to perform these operations efficiently. The system should be easy to use and handle multiple books dynamically.

#### Strategy

To develop an efficient Library Book Management System, we need to carefully choose a data structure that allows for quick lookup, modification, and deletion of books. Instead of using lists or tuples, a dictionary is the best choice. Below is the step-by-step strategy for designing and implementing the solution.

1. Understanding the Problem and Requirements

The library needs a way to store, retrieve, update, and remove books based on a unique identifier (ISBN). The system should: Store books efficiently, Quickly find a book by ISBN, Easily update book details (title, author), Remove books when needed, List all books in the collection.

2. Choosing the Right Data Structure

- Why Not Use a List? If we used a list, we would have to store books as a list of tuples. 
	- Issues with Lists: 
		- Slow Lookup: Searching for a book requires checking each tuple one by one.
		- Inefficient Updates & Deletions: If a book is removed, the list needs to shift elements to fill the gap.
		- Harder to Access by ISBN: We need a loop every time we search for a book.
- Why Not Use Tuples? Tuples are immutable (cannot be changed after creation), so they cannot support updating books dynamically. Also, searching within a tuple still requires looping through all elements, which is slow.
- Why Use a Dictionary? A dictionary is the best choice for this problem because:
	- Fast Lookup: Directly retrieve a book using its ISBN as a key.
	- Efficient Updates: Modifying a book’s details is simple and does not require shifting elements.
	- Easy Deletion: Removing a book is straightforward without affecting other books.
	- Key-Value Pair Storage: Each book is uniquely stored by its ISBN, making it easy to manage.

3. Defining the Data Storage: We use a dictionary, where keys are ISBN and values are tuples containing `(Title, Author)`.

4. Breaking the Problem into Functions: To keep the code organized and reusable, we break the functionality into separate functions.

| Function                         | Purpose                                         |
|----------------------------------|-------------------------------------------------|
| `initialize_library()`           | Creates and returns an empty dictionary for book storage. |
| `add_book(library, isbn, title, author)` | Adds a new book using ISBN as the key. |
| `find_book(library, isbn)`       | Retrieves a book’s details by ISBN. |
| `remove_book(library, isbn)`     | Deletes a book by ISBN. |
| `update_book(library, isbn, new_title, new_author)` | Modifies the title or author of a book. |
| `list_books(library)`            | Displays all books in the system. |

5. Testing the Solution:
	- Adding multiple books to ensure correct storage.
	- Looking up a book by its ISBN and verifying the output.
	- Updating book details and confirming changes are reflected.
	- Removing a book and ensuring it no longer exists.
	- Listing all books to verify that everything is displayed correctly.

#### Solution

```python
# Function to initialize the book storage
def initialize_library():
    """Creates and returns an empty book storage system."""
    return {}

# Function to add a new book
def add_book(library, isbn, title, author):
    """Adds a new book to the library."""
    library[isbn] = (title, author)
    print(f"Book '{title}' added successfully.")

# Function to find a book by ISBN
def find_book(library, isbn):
    """Finds and returns a book's details by its ISBN."""
    return library.get(isbn, "Book not found.")

# Function to remove a book by ISBN
def remove_book(library, isbn):
    """Removes a book from the library."""
    removed_book = library.pop(isbn, None)
    if removed_book:
        print(f"Book '{removed_book[0]}' removed successfully.")
    else:
        print("Book not found.")

# Function to update book details
def update_book(library, isbn, new_title=None, new_author=None):
    """Updates a book's title and/or author."""
    if isbn in library:
        title, author = library[isbn]
        title = new_title if new_title else title # Keep old title if new_title is not provided
        author = new_author if new_author else author # Keep old author if new_author is not provided
        library[isbn] = (title, author)
        print(f"Book '{isbn}' updated successfully.")
    else:
        print("Book not found.")

# Function to list all books
def list_books(library):
    """Displays all books in the library."""
    if library:
        print("\nLibrary Collection:")
        for isbn, (title, author) in library.items():
            print(f"ISBN: {isbn}, Title: {title}, Author: {author}")
    else:
        print("No books in the library.")

# Main function to test the system
def main():
    # Initialize the library
    library = initialize_library()

    # Add books
    add_book(library, "9780143128540", "To Kill a Mockingbird", "Harper Lee")
    add_book(library, "9780307949486", "1984", "George Orwell")
    add_book(library, "9780439023528", "The Hunger Games", "Suzanne Collins")

    # Find a book
    print("\nFinding a book:")
    print(find_book(library, "9780307949486"))  # Should return book details

    # Remove a book
    remove_book(library, "9780439023528")  # Removing "The Hunger Games"

    # Update a book
    update_book(library, "9780143128540", new_author="Harper Lee (Updated)")  # Updating an author

    # List all books
    list_books(library)

# Run the program
if __name__ == "__main__":
    main()

```

#### Note

In the solution provided above, you may encounter some new structures that we have not explicitly discussed. However, at this stage, you are expected to feel confident in exploring and learning them independently.

- A Conditional Operator: It is used to choose a value based on a condition in a compact way. 

```python
value_if_true if condition else value_if_false
```
This means: If `condition` is `True`, return `value_if_true`, otherwise, return `value_if_false`.

- The `dictionary.get(key, default_value)` method:

If `key` exists in the dictionary, `.get()` returns the corresponding value. If `key` does NOT exist, `.get()` returns the `default_value` (instead of raising an error).

## Step 02: Sets

A set in Python is a collection of unique elements. Unlike lists or tuples, sets do not allow duplicate values and provide fast membership checks. This makes them useful in scenarios where we need to store distinct values and perform operations like removing duplicates, checking membership, or finding common elements between collections.

A set can be created using the `set()` function, which initializes an empty set. Elements can be added using the `.add()` method. Since sets do not allow duplicate elements, adding the same element multiple times has no effect on the set’s content.

```python
# Create an empty set
numbers = set()

# Add elements to the set
numbers.add(10)
numbers.add(20)
numbers.add(30)
numbers.add(10)

print(numbers)  # Output: {10, 20, 30}
```
A set can also be created with a collection of pre-existing elements.

```python
fruits = {"apple", "banana", "cherry"}
print(fruits)  # Output: {'apple', 'banana', 'cherry'}
```

You may have noticed that sets are represented using `{ }`. However, when creating an empty set, you should not use `{}` because it initializes a **dictionary** instead. To create an empty set, you must use the `set()` function.


For removing an elements you may use `.remove()` or `.discard()`. Use `.remove()` when you are sure the element exists.

```python
fruits.remove("banana")  # Removes "banana" (raises an error if not found)
print(fruits)  # Output: {'apple', 'cherry'}

fruits.discard("grape")  # No error if "grape" is not found
```

One of the key advantages of sets in Python is their fast membership checking. Unlike lists, where checking if an element exists requires searching through all elements, sets provide a very efficient technique to check if an element is within the set.

```python
fruits = {"apple", "banana", "cherry"}

# Check if "banana" is in the set
if "banana" in fruits:
    print("Banana is in the set!")  

# Check if "grape" is in the set
if "grape" not in fruits:
    print("Grape is not in the set!")  
```

Since sets are unordered collections, you can iterate through them using a `for` loop. The order of elements is **not guaranteed** because sets do not store items in a fixed sequence.

```
colors = {"red", "blue", "green"}

for color in colors:
    print(color) # Output: The elements might appear in a different order each time you run the code.
```

Sets in Python provide powerful operations that help in handling unique collections of data efficiently. Four key operations on sets are subset, union, intersection, and difference, which allow us to compare and manipulate sets easily.

A subset (`<=`) is when all elements of one set exist in another. For example, if `A = {1, 2}` and `B = {1, 2, 3, 4}`, then `A` is a subset of `B` because all elements of `A` are also in `B`.

A union (`|`) combines all unique elements from two sets. If `A = {1, 2}` and `B = {2, 3, 4}`, then `A | B = {1, 2, 3, 4}`, meaning all elements from both sets are included, without duplicates.

An intersection (`&`) finds common elements between two sets. If `A = {1, 2, 3}` and `B = {2, 3, 4}`, then `A & B = {2, 3}`, since these are the elements found in both sets.

A difference (`-`) finds elements that are in one set but not in the other. If `A = {1, 2, 3}` and `B = {2, 3, 4}`, then `A - B = {1}`, meaning `1` is in `A` but not in `B`.

```python
# Students enrolled in Math and Computer Science courses
math_students = {"Alice", "Bob", "Charlie", "David"}
cs_students = {"Charlie", "David", "Eve", "Frank"}

# Subset: Check if all Math students are also in CS
print(math_students <= cs_students)  # Output: False (not all Math students are in CS)

# Union: Get all students enrolled in at least one course
all_students = math_students | cs_students
print(all_students)  # Output: {'Alice', 'Bob', 'Charlie', 'David', 'Eve', 'Frank'}

# Intersection: Find students taking both Math and CS
common_students = math_students & cs_students
print(common_students)  # Output: {'Charlie', 'David'}

# Difference: Find students taking Math but not CS
only_math_students = math_students - cs_students
print(only_math_students)  # Output: {'Alice', 'Bob'}

# Difference: Find students taking CS but not Math
only_cs_students = cs_students - math_students
print(only_cs_students)  # Output: {'Eve', 'Frank'}
```

### Problem Solving

A teacher receives multiple student essays and wants to check for similar content between them. The program should:

1. Read multiple student submissions (entered as text).
2. Preprocess the text by:
- Breaking it into individual words.
- Ignoring punctuation and case differences.
3. Convert the processed text into sets to extract unique words.
4. Compare submissions using set operations:
- Intersection to find common words between documents.
- Difference to identify unique words from each submission.
5. Calculate a plagiarism score based on the proportion of shared words.
6. Display results, highlighting:
- Similarity percentages.
- Words that are only present in one submission.

#### Strategy

To efficiently compare student submissions, we will follow a structured approach:

1. Preprocessing the Text
- Convert text to lowercase to ensure case insensitivity.
- Remove punctuation to focus only on words.
- Split text into words and store them in a set (to automatically remove duplicates).

2. Set Operations for Comparison
- Use intersection to find common words between two submissions.
- Use difference to find words unique to each submission.
- Use union to get the total distinct words across both submissions.

3. Plagiarism Score Calculation
- The plagiarism score is based on the proportion of common words relative to the total words across both submissions. Formula:
`Plagiarism Score = (Number of common words/Total unique words in both texts) * 100`
- A higher percentage suggests a higher similarity.


#### Solution

```python
import string

### **Step 1: Preprocess Text (Remove Punctuation & Convert to Lowercase)**
def preprocess_text(text):
    """
    Cleans the input text by removing punctuation and converting to lowercase.
    Returns a set of unique words.
    """
    # Remove punctuation
    for char in string.punctuation:
        text = text.replace(char, "")
    
    # Convert to lowercase and split into words
    words = text.lower().split()
    
    # Return unique words as a set
    return set(words)

### **Step 2: Calculate Plagiarism Score**
def calculate_similarity(text1, text2):
    """
    Compares two texts and calculates a plagiarism score based on shared words.
    Returns:
        - Common words
        - Unique words for each submission
        - Plagiarism percentage
    """
    # Process both texts into sets of words
    words1 = preprocess_text(text1)
    words2 = preprocess_text(text2)
    
    # Set operations
    common_words = words1 & words2  # Intersection (common words)
    unique_words_text1 = words1 - words2  # Words unique to text1
    unique_words_text2 = words2 - words1  # Words unique to text2
    total_unique_words = words1 | words2  # Union (total distinct words)

    # Calculate plagiarism percentage
    if len(total_unique_words) == 0:
        plagiarism_score = 0  # Avoid division by zero
    else:
        plagiarism_score = (len(common_words) / len(total_unique_words)) * 100
    
    return common_words, unique_words_text1, unique_words_text2, plagiarism_score

### **Step 3: Display Results**
def display_results(text1, text2):
    """
    Displays plagiarism detection results between two texts.
    """
    common_words, unique_words_text1, unique_words_text2, plagiarism_score = calculate_similarity(text1, text2)

    print("\n **Plagiarism Detection Results**\n")
    
    print(f" **Plagiarism Score:** {plagiarism_score:.2f}%")
    
    print("\n **Common Words (Shared Content):**")
    print(common_words if common_words else "No common words.")

    print("\n **Unique Words in First Submission:**")
    print(unique_words_text1 if unique_words_text1 else "No unique words.")

    print("\n **Unique Words in Second Submission:**")
    print(unique_words_text2 if unique_words_text2 else "No unique words.")

### **Step 4: Main Function**
def main():
    """Main function to run the plagiarism detection program."""
    print(" **Plagiarism Detection Program** \n")
    
    # Get student submissions
    text1 = input("Enter first student submission:\n")
    text2 = input("Enter second student submission:\n")
    
    # Display results
    display_results(text1, text2)

### **Run the Program**
if __name__ == "__main__":
    main()
```

## Step 03: Functions (more)

In Python, functions are not just blocks of code; they are also objects (just like numbers, strings, and lists). This means we can assign a function to a variable and use it later.

Here, `say_hello` is just another name for `greet`, and it works exactly the same way.

```python
def greet(name):
    return f"Hello, {name}!"

# Assign the function to another variable
say_hello = greet

# Call the function using the new variable
print(say_hello("Alice"))  # Output: Hello, Alice!
```

What if we need a function just once and don’t want to name it? Python allows us to define a function on the spot using `lambda` functions (also called anonymous functions because they don’t have a name).


```python
double = lambda x: x * 2

print(double(5))  # Output: 10
```

In our example above, the anonymous function does the same thing as `def double(x): return x * 2`, but in a shorter way without a specific name.
This example illustrates how an anonymous function can be defined and assigned to a name. However, you might still wonder about the practical benefits of defining double in this way. To demonstrate its usefulness, we will first explain how a lambda function can be defined and applied on the spot, followed by a few examples showcasing scenarios where anonymous functions are particularly helpful.

An anonymous function can also be defined and used immediately without storing it in a variable. This can be confusing for beginners because the function is created on the spot and applied directly to an argument.
The general structure looks like this:

```python
(lambda parameters: expression)(arguments)
```

In this structure, `lambda parameters` defines the function, `expression` performs an operation on the parameters, and `(arguments)` calls the lambda function immediately with the provided values.

Let’s create a lambda function that squares a number and apply it on the spot.

```python
result = (lambda x: x ** 2)(4)
print(result)  # Output: 16
```
In this example `(lambda x: x ** 2)` defines a function that takes `x` and returns its squar without assigning a particular name to the function, `(4)` immediately calls the function with `4` as input, the result of applying lambda on `4` becomes `16` which is stored in `result` and printed.

Now, let’s create a lambda function that adds two numbers and apply it on the spot.

```python
result = (lambda a, b: a + b)(5, 3)
print(result)  # Output: 8
```
In the example above `(lambda a, b: a + b)` defines a function that takes `a` and `b`, then returns their sum, then `(5, 3)` calls the function with `5` and `3` as arguments, and finally the result `8` is stored in result and printed.

Lambda functions are very useful when sorting lists based on specific criteria without defining a separate function.
Imagine, you have a list of students with their names and ages, and you want to sort them. We can use the `sort()` function which is a built-in method for sorting lists in place (modifying the original list). But, we need to specify to the function what is our criteria of sorting. Let's assume we would like to sort our list based on their age.
Here is our first solution:

```python
students = [("Alice", 25), ("Bob", 20), ("Charlie", 23)]

def by_age(student):
    return student[1]  # Return the age

students.sort(key=by_age)  # Sorting using the function

print(students)
```
But we can improve our code. More likely the function `by_age()` will not be called (used) in other part of (our imaginary) bigger code. We can employ `lambda` functions on the spot where it is needed. Check our alternative solution here:

```python
students = [("Alice", 25), ("Bob", 20), ("Charlie", 23)]

students.sort(key=lambda student: student[1])  # Sorting directly with lambda

print(students)
```

In our alternative solution the code is cleaner and easier to read.

Here is another example where a list of names is processed using a `lambda` expression. In this example, pay close attention to how the anonymous function is defined and how the parameter is passed directly on the spot.
The `.title()` method in this example is used to convert a string to title case, meaning the first letter of each word is capitalized, and all other letters are converted to lowercase.

```python
names = ["aLICE johnson", "BOB sMITH", "charlie BROWN"]

# Initialize an empty list to store formatted names
formatted_names = []

# Using a loop and lambda to format names
for name in names:
    formatted_names.append((lambda n: n.title())(name))

print(formatted_names)
```

### Problem Solving

[todo: needs polishing, remove most common feature. Give an alternative solution where filter and list comprehension are used to make a cleaner and more packed code]

You are asked to develop a Python program that processes and analyzes customer reviews for an online store. The program will take a list of customer reviews containing: Customer Name (string), Review Text (string), Star Rating (1 to 5 as integer)

1.	Filter Reviews: Extract positive reviews (star rating 4 or 5) and negative reviews (1 or 2 stars).
2.	Sort Reviews:
- Sort reviews by rating (highest to lowest).
- Sort reviews alphabetically by customer name.
3.	Clean the Text:
- Remove unnecessary punctuation from reviews.
- Convert all text to lowercase for consistency.
4.	Summarize Reviews: Create a short version of each review by keeping only the first 5 words.
5.	Generate a Summary Report:
- Count the number of positive and negative reviews.
- Identify the most frequently used words across all reviews (excluding common words like `“the”`, `“and”`, etc.).

Students must structure their program into functions and apply `lambda` functions where appropriate to make the code concise and readable.

### Strategy

1. Define Data Structure: Each review will be stored as a tuple containing: Customer Name (string), Review Text (string), Star Rating (integer from 1 to 5)
- Multiple reviews will be stored in a list of tuples.

2. Implement Review Cleaning: Remove punctuation and convert to lowercase for consistency. Potential to use an anonymous function.

3. Filter Positive & Negative Reviews: Use `filter()` to extract positive reviews (ratings 4 or 5) and negative reviews (ratings 1 or 2). Potential to use an anonymous function. 

**Note**: Make some research about function `filter()`. 

4. Sort Reviews: Sort by rating (highest to lowest) and sort by customer name (alphabetically). Potential to use an anonymous function.

**Note**: Make some research about sorting function in Python. 

5. Summarize Reviews: Keep only the first 5 words of each review.

6. Generate a Summary Report: Count positive and negative reviews and find the most frequently used words (excluding common words like `“the”`, `“and”`, etc.).


#### Solution


```python
import string
from collections import Counter

# Sample data: List of customer reviews (name, review text, star rating)
reviews = [
    ("Alice", "This product is fantastic! I love it.", 5),
    ("Bob", "Terrible quality, broke after one use.", 1),
    ("Charlie", "Decent value for the price.", 3),
    ("David", "Absolutely wonderful, would buy again!", 5),
    ("Eve", "Not as described, very disappointed.", 2),
    ("Frank", "The best purchase I have made this year!", 5),
    ("Grace", "Horrible experience. Do not recommend.", 1),
    ("Hannah", "Pretty good but took too long to arrive.", 4),
    ("Ian", "Fairly average, nothing special.", 3),
    ("Jack", "Perfect, just what I needed!", 5),
]

### **Step 1: Clean Review Text (Remove Punctuation & Convert to Lowercase)**
def clean_text(text):
    """Removes punctuation manually using replace() and converts text to lowercase."""
    punctuation = string.punctuation
    for char in punctuation:
        text = text.replace(char, "")  # Remove punctuation by replacing it with an empty string
    return text.lower()  # Convert to lowercase

def clean_reviews(reviews):
    """Cleans the text of all reviews."""
    cleaned_reviews = []
    for name, text, rating in reviews:
        cleaned_reviews.append((name, clean_text(text), rating))
    return cleaned_reviews

### **Step 2: Filter Positive & Negative Reviews**
def filter_positive(reviews):
    """Filters reviews with a rating of 4 or 5 (Positive)."""
    positive_reviews = []
    for review in reviews:
        if review[2] >= 4:
            positive_reviews.append(review)
    return positive_reviews

def filter_negative(reviews):
    """Filters reviews with a rating of 1 or 2 (Negative)."""
    negative_reviews = []
    for review in reviews:
        if review[2] <= 2:
            negative_reviews.append(review)
    return negative_reviews

### **Step 3: Sorting Reviews**
def sort_reviews_by_rating(reviews):
    """Sorts reviews from highest to lowest rating."""
    return sorted(reviews, key=lambda r: r[2], reverse=True)

def sort_reviews_by_name(reviews):
    """Sorts reviews alphabetically by customer name."""
    return sorted(reviews, key=lambda r: r[0])

### **Step 4: Summarize Reviews (Keep First 5 Words)**
def summarize_review(text):
    """Keeps only the first 5 words of a review."""
    words = text.split()
    return " ".join(words[:5])

def summarize_reviews(reviews):
    """Creates a short version of each review (first 5 words)."""
    summarized_reviews = []
    for name, text, rating in reviews:
        summarized_reviews.append((name, summarize_review(text), rating))
    return summarized_reviews

### **Step 5: Generate Word Frequency Report**
def word_frequency(reviews):
    """Finds the most frequently used words in reviews, excluding common words."""
    stopwords = {"the", "is", "this", "a", "for", "to", "it", "i", "after", "on"}
    
    all_words = []
    for _, text, _ in reviews:
        words = text.split()
        for word in words:
            if word not in stopwords:
                all_words.append(word)
    
    word_counts = Counter(all_words)
    return word_counts.most_common(5)  # Get top 5 most common words

### **Main Function to Run the Program**
def main():
    """Main function that processes and analyzes customer reviews."""
    print("\n Cleaning Reviews...")
    cleaned_reviews = clean_reviews(reviews)

    print("\n Filtering Positive and Negative Reviews...")
    positive_reviews = filter_positive(cleaned_reviews)
    negative_reviews = filter_negative(cleaned_reviews)

    print("\n Sorting Reviews by Rating...")
    sorted_by_rating = sort_reviews_by_rating(cleaned_reviews)

    print("\n Summarizing Reviews (First 5 Words)...")
    summarized_reviews = summarize_reviews(cleaned_reviews)

    print("\n Generating Word Frequency Report...")
    common_words = word_frequency(cleaned_reviews)

    ### **Displaying Results**
    print("\n **Positive Reviews:**")
    for review in positive_reviews:
        print(f"- {review[0]}: {review[1]} ({review[2]} stars)")

    print("\n **Negative Reviews:**")
    for review in negative_reviews:
        print(f"- {review[0]}: {review[1]} ({review[2]} stars)")

    print("\n **Sorted Reviews by Rating (Highest First):**")
    for review in sorted_by_rating:
        print(f"- {review[0]}: {review[1]} ({review[2]} stars)")

    print("\n **Summarized Reviews:**")
    for review in summarized_reviews:
        print(f"- {review[0]}: {review[1]}... ({review[2]} stars)")

    print("\n **Most Common Words in Reviews:**")
    for word, count in common_words:
        print(f"- {word}: {count} times")

### **Run the program**
if __name__ == "__main__":
    main()
```

## Summary



## Assignment (Draft)

[todo: this is just an idea. Data set can be provided as a csv file where students must decide how to collect data values as a dictionary. Extend the features of the assignment to integrate more concepts of dictionaries, anonymous functions.]

You are given a dictionary where each key represents a user, and the corresponding value is a set of their friends. For example:

```python

social_network = {
    "Alice": {"Bob", "Charlie"},
    "Bob": {"Alice", "Charlie", "David"},
    "Charlie": {"Alice", "Bob"},
    "David": {"Bob", "Eve"},
    "Eve": {"David"}
}
```

Your task is to write a program that:

Takes a username as input.

Finds all the friends of the user.

Finds all the friends of those friends (excluding the user and their direct friends).

Recommends these friends as potential new connections.



### Implementation Guidelines

- Use sets for ....
- Use dictionaries for ....
- Use anonymous functions with ....
- ...
	