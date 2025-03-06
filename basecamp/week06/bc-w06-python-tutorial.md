# Python 06: Tutorial

## Todo

- 

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
        title = new_title if new_title else title
        author = new_author if new_author else author
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

## Step 02: Lists



### Problem Solving



#### Strategy



#### Solution


## Step 03: Functions (more)?


#### Solution


## Summary



## Assignment (Draft)



### Implementation Guidelines

- Use sets for ....
- Use dictionaries for ....
- Use anonymous functions with ....
- ...
	