# Python 05: Tutorial

## Introduction

So far, we have learned the fundamental structure of a Python program. We have practiced how to interact with the user using the `input()` and `print()` functions, employed conditional statements (`if`, `elif`, `else`) to make decisions in code execution, and experimented with loops (`for` and `while`) to iterate through sequences of instructions. We have also studied how to define and manipulate primitive data types, such as numbers and strings, and finally, we explored how functions can be used to break down long pieces of code into smaller, manageable components.

However, in many real-world scenarios, solving problems requires handling multiple values simultaneously, rather than working with just a few individual variables. To efficiently manage and organize data, Python provides collection structures that allow us to store, modify, and process multiple values within a single entity. Each of these structures serves a specific purpose and is optimized for different types of operations, making it easier for programmers to handle complex data efficiently.

In this tutorial, we will introduce two fundamental data structures in Python and explore how they can be utilized effectively. Additionally, we will further expand our understanding of functions and their advanced features to enhance the modularity and efficiency of Python programs.


## Step 01: Tuples

A tuple in Python is a way to store multiple values together in one variable. Imagine you want to keep a set of related items, like the names of the days in a week, the RGB values of a color, or the coordinates of a point in space. Instead of creating separate variables for each value, you can put them inside a tuple. A tuple keeps the order of the values exactly as you define them, and once you create it, you cannot change its contents. When we say that a tuple cannot be changed after creation, it means that it is **immutable**. This is an important property of tuples in Python. Once a tuple is created, you cannot add, remove, or modify its elements. The values inside the tuple will always remain the same throughout the program.

To define a tuple in Python, you write the values inside parentheses `()`, separated by commas. For example, a tuple that stores the names of three colors can be written as `colors = ("red", "green", "blue")`. You can also create a tuple without parentheses by simply writing the values with commas, like `numbers = 10, 20, 30`. If a tuple has only one value, you must add a comma after it, like `single = (5,)`, otherwise Python will not recognize it as a tuple.

```python
# Defining a tuple using parentheses
colors = ("red", "green", "blue")
print("Colors tuple:", colors)

# Defining a tuple without parentheses
numbers = 10, 20, 30
print("Numbers tuple:", numbers)

# Defining a single-element tuple (note the comma)
single = (5,)
print("Single-element tuple:", single)

# Without a comma, Python does not recognize it as a tuple
not_a_tuple = (5)
print("Not a tuple, just an integer:", not_a_tuple)
```

Once a tuple is created, you can access its values by using their positions, which are called **indexes**. Indexes in Python start from `0`, meaning the first item is at position `0`, the second at position `1`, and so on. For example, if you have `fruits = ("apple", "banana", "cherry")`, you can get the first fruit by writing `fruits[0]`, which will return `"apple"`. 

Sometimes, you may want to take a part of a tuple instead of a single item. This is called **slicing**. You can do this by writing the starting and ending positions inside square brackets. If you have `numbers = (1, 2, 3, 4, 5)`, then `numbers[1:4]` will give you `(2, 3, 4)`. The first number in the brackets tells Python where to start, and the second number tells Python where to stop (but it does not include that position).

```python
# Defining a tuple
fruits = ("apple", "banana", "cherry")

# Accessing elements using indexes
print("First fruit:", fruits[0])  # Output: apple
print("Second fruit:", fruits[1]) # Output: banana
print("Third fruit:", fruits[2])  # Output: cherry

# Defining another tuple for slicing
numbers = (1, 2, 3, 4, 5)

# Slicing the tuple (from index 1 to 4, but excluding 4)
sliced_numbers = numbers[1:4]  # This will include elements at indexes 1, 2, and 3
print("Sliced tuple:", sliced_numbers)  # Output: (2, 3, 4)
```

Another useful thing about tuples is that you can store different types of values together. A tuple can contain numbers, text, or even a mix of both. For example, `person = ("Alice", 25, "Engineer")` keeps a name, an age, and a profession in one place.

You can also unpack a tuple, which means taking its values and assigning them to separate variables in one step. If you have `point = (3, 7)`, you can write `x, y = point`, and now `x` will be `3` and `y` will be `7`.

```python
# Defining a tuple with different types of values
person = ("Alice", 25, "Engineer")

# Accessing elements in the tuple
print("Name:", person[0])       # Output: Alice
print("Age:", person[1])        # Output: 25
print("Profession:", person[2]) # Output: Engineer

# Tuple unpacking
point = (3, 7)

# Assigning tuple values to separate variables
x, y = point

print("X coordinate:", x)  # Output: 3
print("Y coordinate:", y)  # Output: 7
```

Although you cannot change the values inside a tuple after creating it, Python provides a few useful functions to work with tuples. If you have a tuple with repeated values, like `numbers = (1, 2, 3, 2, 4, 2)`, you can count how many times a value appears using `numbers.count(2)`, which will return `3` because `2` appears three times. You can also find the position of the first occurrence of a value by using `numbers.index(3)`, which will return `2`, meaning `3` is at index `2`.

Tuples are useful when you want to keep a group of values together and make sure they stay the same throughout the program. They help organize data in a structured way and make programs easier to read and understand.

```python
# Defining a tuple with repeated values
numbers = (1, 2, 3, 2, 4, 2)

# Counting how many times 2 appears in the tuple
count_of_twos = numbers.count(2)
print("Number of times 2 appears:", count_of_twos)  # Output: 3

# Finding the index of the first occurrence of 3
index_of_three = numbers.index(3)
print("Index of first occurrence of 3:", index_of_three)  # Output: 2
```

Even though tuples cannot be changed after they are created, Python provides ways to combine, compare, and work with them efficiently.

If you want to combine two or more tuples, you can use the `+` operator. This does not change the original tuples but creates a new one that contains the elements from both. For example, if you have `numbers1 = (1, 2, 3)` and `numbers2 = (4, 5, 6)`, you can create a new tuple by writing `combined = numbers1 + numbers2`, which results in `(1, 2, 3, 4, 5, 6)`. Similarly, you can repeat a tuple multiple times using the `*` operator. If you write `doubled = numbers1 * 2`, the result will be `(1, 2, 3, 1, 2, 3)`. This is useful when you need a repeated pattern of values.

```python
# Defining two tuples
numbers1 = (1, 2, 3)
numbers2 = (4, 5, 6)

# Combining two tuples using the + operator
combined = numbers1 + numbers2
print("Combined tuple:", combined)  # Output: (1, 2, 3, 4, 5, 6)

# Repeating a tuple using the * operator
doubled = numbers1 * 2
print("Repeated tuple:", doubled)  # Output: (1, 2, 3, 1, 2, 3)
```

Tuples can also be compared using comparison operators like `==`, `<`, and `>`. Python compares tuples element by element. This means `tuple1 = (1, 2, 3)` is considered smaller than `tuple2 = (1, 3, 2)` because `2` is smaller than `3` in their first differing position. This feature is useful when sorting a list of tuples or checking if two tuples have the same values.

Another useful operation with tuples is iterating over their elements. Since tuples are ordered collections, you can use a `for` loop to go through each value one by one. If you have `colors = ("red", "green", "blue")`, you can write:

```python
for color in colors:
    print(color)
```
This will print each color in order: `"red"`, `"green"`, and `"blue". This method is especially useful when processing a list of values stored in a tuple.

Even though tuples cannot be changed directly, you can still create a modified version by making a new tuple. If you want to change or update values in a tuple, you cannot do it directly because tuples are immutable. However, you can work around this limitation by converting the tuple into a list, modifying the list, and then converting it back into a tuple. For example:

```python
numbers = (1, 2, 3)
temp_list = list(numbers)  # Convert tuple to list
temp_list[1] = 10  # Modify the second element
numbers = tuple(temp_list)  # Convert back to tuple
print(numbers)  # Output: (1, 10, 3)
```

A nested tuple is a tuple that contains other tuples inside it. This is useful when storing structured data, where each item has multiple related values. Since tuples are immutable, using nested tuples helps keep data organized and prevents accidental modifications.

For example, imagine you need to store information about students, including their `name`, `age`, and `grade`. Instead of creating separate variables for each student, you can use a tuple of tuples, where each inner tuple represents a student’s record. You can access a full record using indexing or retrieve specific details by using two indexes—one for selecting the student and another for selecting a particular piece of information.

To work with nested tuples, you can use a `for` loop to iterate through each student and extract their details. This technique is useful when processing large amounts of structured data efficiently. 

Here is an example demonstrating how to handle nested tuples in Python:

```python
# Defining a nested tuple containing student records
students = (
    ("Alice", 20, "A"),
    ("Bob", 22, "B"),
    ("Charlie", 21, "A"),
)

# Accessing a specific student's full record
print(students[0])  # Output: ('Alice', 20, 'A')

# Accessing specific details
print(students[1][0])  # Output: Bob (name of second student)
print(students[2][2])  # Output: A (grade of third student)

# Iterating through nested tuples
for student in students:
    name, age, grade = student  # Tuple unpacking
    print(f"{name} is {age} years old and got grade {grade}.")
```

Tuples are powerful tools that allow you to organize data efficiently while keeping it safe from accidental changes. They provide a structured way to store values, combine different pieces of data, compare elements, and iterate through them in an easy and efficient manner.

### Problem Solving

You have two subgroups of delivery drones, each represented as a tuple of `(ID, location (x, y), battery level)`. Your tasks:
	1.	Use a function to combine the two subgroups into one tuple containing all drones.
	2.	Iterate through all drones and display their details.
	3.	Find the drone with the lowest battery (so it can be recharged).
	4.	Find the drone closest to a given target location for delivery using a manual distance formula.

#### Strategy

When solving a problem like coordinating drones using tuples, a structured approach helps break the problem into manageable steps. Here’s a simple problem-solving strategy you can use:

1.	Understand the Problem Clearly
	- Identify what information is given (e.g., drone ID, location, battery level).
	- Determine the required tasks (e.g., finding the lowest battery, nearest drone).
2.	Decide on a Data Structure
	- Since each drone has multiple attributes, a tuple is a good choice because it keeps related data together.
	- Use a tuple of tuples to store multiple drones.
3.	Break the Problem into Subtasks
	- Storing Data: Define tuples to represent individual drones and groups of drones.
	- Combining Data: Use functions to merge two drone groups.
	- Iterating Over Data: Use loops to go through each drone and analyze its attributes.
	- Knowing How to Calculate the Closest Distance Between Two Points: The distance between two points $(x_1, y_1)$ and $(x_2, y_2)$ can be found using the Euclidean distance formula: $d = \sqrt{(x_2 - x_1)^2 + (y_2 - y_1)^2}$
	- Comparing Values: Find the drone with the lowest battery and the closest drone.
4.	Write Modular Code
	- Use functions to keep code organized (e.g., a function for combining tuples, another for calculating distance).
	- This makes the solution reusable and easy to modify.
5.	Test with Sample Data
	- Run the program with different drone locations and battery levels to verify results.

#### Solution

```python
# Function to combine two tuples of drones
def combine_drones(group1, group2):
    """Combines two groups of drones into a single tuple."""
    return group1 + group2  # Uses the + operator to merge the tuples

# Function to calculate Euclidean distance manually
def calculate_distance(loc1, loc2):
    """Calculates the Euclidean distance between two points (x1, y1) and (x2, y2)."""
    x1, y1 = loc1
    x2, y2 = loc2
    return ((x2 - x1) ** 2 + (y2 - y1) ** 2) ** 0.5  # Square root of sum of squared differences

# Function to print all drones
def display_drones(drones):
    """Displays all drones with their location and battery level."""
    print("Drone Fleet:")
    for drone in drones:
        print(f"Drone {drone[0]} - Location: {drone[1]}, Battery: {drone[2]}%")

# Function to find the drone with the lowest battery
def find_lowest_battery_drone(drones):
    """Finds and returns the drone with the lowest battery."""
    lowest_battery_drone = drones[0]  # Assume the first drone has the lowest battery
    for drone in drones:
        if drone[2] < lowest_battery_drone[2]:  # Compare battery levels
            lowest_battery_drone = drone  # Update if a lower battery is found
    return lowest_battery_drone

# Function to find the closest drone to a given target location
def find_closest_drone(drones, target_location):
    """Finds and returns the drone closest to the target location."""
    closest_drone = drones[0]  # Assume the first drone is the closest
    closest_distance = calculate_distance(drones[0][1], target_location)

    for drone in drones:
        distance = calculate_distance(drone[1], target_location)
        if distance < closest_distance:  # If a drone is closer, update the best choice
            closest_drone = drone
            closest_distance = distance

    return closest_drone, closest_distance

# Main function to run the program
def main():
    """Main function to coordinate drones, find the lowest battery drone, and find the closest drone."""
    # Defining two groups of drones (each tuple contains: ID, location (x, y), battery level)
    drones_group1 = (
        ("D1", (10, 20), 80),
        ("D2", (5, 15), 60),
        ("D3", (12, 8), 90)
    )

    drones_group2 = (
        ("D4", (3, 5), 50),
        ("D5", (20, 10), 75),
        ("D6", (7, 7), 40)
    )

    # Combining the two drone groups using the function
    drones = combine_drones(drones_group1, drones_group2)

    # Display all drones
    display_drones(drones)

    # Find the drone with the lowest battery
    lowest_battery_drone = find_lowest_battery_drone(drones)
    print(f"\nDrone with the lowest battery: {lowest_battery_drone[0]} - Battery: {lowest_battery_drone[2]}%")

    # Define target location for delivery
    target_location = (10, 10)

    # Find the closest drone to the target location
    closest_drone, closest_distance = find_closest_drone(drones, target_location)
    print(f"\nBest drone for delivery to {target_location}: {closest_drone[0]} (Distance: {closest_distance:.2f})")

# Run the program
if __name__ == "__main__":
    main()
```

## Step 02: Lists

## Step 03: Functions (more)?



Here is an example:

```python
# Getting user input
name = input("Enter your name: ") # Note the text given to input()
age = int(input("Enter your age: ")) # Pay attention to the type casting

# Performing a calculation
birth_year = 2023 - age

# Displaying output
print("Hello, " + name + "! You were born in", birth_year)
```

In this example, the `input()` function is used to prompt the user to enter their name and age. The input for the age is type casted to an integer using the `int()` function to ensure it is treated as a numerical value.

A calculation is performed to determine the birth year by subtracting the age from the current year `2023`. The result is stored in the `birth_year` variable.

The `print()` function is then used to display a personalized message to the user, including their name and the calculated birth year. The string concatenation operator `+` is used to combine the strings and the variable value in the output.

