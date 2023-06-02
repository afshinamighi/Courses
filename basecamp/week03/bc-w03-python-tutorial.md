# Tutorial: Python 03

## Strings

- Splitting a String: The `split()` function is used to split a string into a *list of substrings* based on a delimiter. By default, the delimiter is a space.

```python
 # Splitting a string into substrings
sentence = "I enjoy exploring new places and trying different cuisines"
words = sentence.split()
print(words)
# Output: ['I', 'enjoy', 'exploring', 'new', 'places', 'and', 'trying', 'different', 'cuisines']
```

- Joining Strings: The `join()` function is used to concatenate a list of strings into a single string using a specified delimiter.

```python
# Joining a list of strings into a single string
words = ['I', 'enjoy', 'exploring', 'new', 'places', 'and', 'trying', 'different', 'cuisines']
sentence = ' '.join(words)
print(sentence)
# Output: I enjoy exploring new places and trying different cuisines
```
- Replacing Substrings: The `replace()` function is used to replace all occurrences of a substring with another substring within a string.

```python
# Replacing substrings in a string
sentence = "I like to have coffee in the morning"
new_sentence = sentence.replace('coffee', 'tea')
print(new_sentence)
# Output: I like to have tea in the morning
```
- Substrings and Slicing: Python provides various ways to extract substrings from a string using slicing. Slicing is done using the square bracket notation []. You can specify the start index, end index, and step size.

```python
# Extracting substrings using slicing
sentence = "Python programming is fun"
substring1 = sentence[7:18]  # Extracts characters from index 7 to 17
substring2 = sentence[0:6]   # Extracts characters from index 0 to 5
substring3 = sentence[::-1]  # Reverses the string
print(substring1)
print(substring2)
print(substring3)
# Output: programming
#         Python
#         nuf si gnimmargorp nohtyP
```
- f-Strings: f-strings provide a concise way to embed expressions inside string literals. They start with the `f` prefix and use curly braces `{}` to enclose the expressions.

```python
# f-Strings for embedding expressions in strings
name = "Alice"
age = 25
message = f"Hello, my name is {name} and I'm {age} years old."
print(message)
# Output: Hello, my name is Alice and I'm 25 years old.
```

### Example:

```python
# Example: Greeting based on the time of day
time = int(input("Enter the current time (in 24-hour format): "))

if time < 12:
    greeting = "Good morning"
elif time < 18:
    greeting = "Good afternoon"
else:
    greeting = "Good evening"

name = input("Enter your name: ")
message = f"{greeting}, {name}! How are you today?"
print(message)
```

In this example, the user is prompted to enter the current time in 24-hour format. Based on the time, the program uses conditional statements and an f-string to generate a personalized greeting message. If the time is before `12 PM`, it says `"Good morning."` If the time is between `12 PM` and `6 PM`, it says `"Good afternoon"` and etc.

## while-loop:

In programming, loops are essential control structures that allow us to repeat a block of code multiple times. They are used to automate repetitive tasks, iterate over collections of data, and control the flow of a program based on certain conditions. Without loops, we would need to write the same code over and over again, leading to redundant and inefficient programs.
Basic Structure:

```python
# Example of a basic while loop
count = 0
while count < 5:
    print("Count:", count)
    count += 1 # Increment count by one
```
In this example, the loop starts with count initialized to `0`. The code inside the loop is executed as long as the condition `count < 5` is *true*. The `print()` statement displays the current value of count, and count is incremented by 1 at the end of each iteration. The loop terminates when the condition becomes false.


```python
# Example of an infinite loop
while True:
    print("This is an infinite loop!")
```



```python
# Example: Finding the sum of numbers using a while loop
# Trace and analyze this code carefully. There are a lot to learn.
num_sum = 0
num = 1
while num != 0:
    num = int(input("Enter a number (enter 0 only to exit): "))
    num_sum += num
print("Sum of numbers:", num_sum)
```

In this example, the user is prompted to enter numbers continuously until they enter `0`. The while loop continues as long as num is not equal to `0`. The input numbers are added to `num_sum` in each iteration. The loop terminates when the user enters `0`, and the final sum is displayed.

Remember to use caution when working with while loops to avoid infinite loops and ensure that the loop condition will eventually become false.


## for-loop:

In Python, the `for-loop` is a versatile construct used to iterate over various types of sequences. It allows us to iterate over each item in the sequence and execute a block of code for each iteration.

Here is the general structure:

```python
for item in sequence:
    # Code to be executed
```

The item represents the current element in the sequence being iterated. It takes the value of each item successively as the loop progresses. The sequence can be any iterable object, such as a list or string.

```python
# Example of generating a shape with asterisks using for loops
rows = 5
for i in range(rows):
    print("*" * (i + 1))
```

In this example, the for loop iterates over the numbers from 0 to 4 (5 rows) using the `range()` function. The number of asterisks in each row is determined by `(i + 1)`. The `print()` statement displays the asterisks, with the number increasing by one in each iteration.

```
Output:

*
**
***
****
*****
```

```python
# Example of generating a hollow rectangle with asterisks using for loops
rows = 5
cols = 8
for i in range(rows):
    if i == 0 or i == rows - 1:
        print("*" * cols)
    else:
        print("*" + " " * (cols - 2) + "*")
```

In this example, the for loop iterates over the numbers from 0 to 4 (5 rows) using the `range()` function. The condition checks if it's the first or last row (`i == 0` or `i == rows - 1`) to print a full row of asterisks. For the other rows, a hollow section is created with an asterisk at the beginning and end, and spaces in between.

```Output:

********
*      *
*      *
*      *
********
```

```python
# Example: Counting the number of vowels in a string using a for loop
text = "Hello, World!"
vowels = "aeiou"
count = 0
for char in text.lower():
    if char in vowels:
        count += 1
print("Number of vowels:", count)
#Output:
#Number of vowels: 3
```
In this example, the for loop iterates over each character in the text string using `text.lower()` to handle uppercase letters as well. The condition checks if the current character is a vowel, and if so, increments the count variable. Finally, the total count of vowels is printed.


## Problem: Grades Calculator

You are tasked with creating a program that calculates the average grade of a student and determines their final letter grade based on the following criteria:

- The program should take input from the user for five individual subject grades (ranging from 0 to 100).
- The program should calculate the average grade by summing up all the grades and dividing by 5.
- If the average grade is greater than or equal to `90`, the final grade should be `"A"`; between `80` and `89` (inclusive), the final grade should be `"B"`; between `70` and `79` (inclusive), the final grade should be `"C"`; between `60` and `69` (inclusive), the final grade should be `"D"`; below `60`, the final grade should be `"F"`.
- The program must repeatedly calculate average grades and final letter grades until the user chooses to stop by entering `"no"` when prompted to continue.

```python
# Average and Final Grade Calculator

# A loop to interact with the user
while True:
    # Initialize variables
    total_grades = 0

    # Take input for five subject grades and calculate total grades
    for i in range(1, 6):
        grade = int(input("Enter grade for subject {}: ".format(i)))
        total_grades += grade

    # Calculate average grade
    average_grade = total_grades / 5

    # Determine final letter grade based on average grade
    if average_grade >= 90:
        final_grade = "A"
    elif average_grade >= 80:
        final_grade = "B"
    elif average_grade >= 70:
        final_grade = "C"
    elif average_grade >= 60:
        final_grade = "D"
    else:
        final_grade = "F"

    # Print the average grade and final letter grade
    print("Average Grade:", average_grade)
    print("Final Grade:", final_grade)

    # Ask the choice of the user
    choice = input("Do you want to continue? (yes/no): ")
    if choice != "yes":
        break  # Analyze this statement carefully.
```

#### Explanation:

- The entire code block is enclosed in a while loop with the condition True, allowing the code to repeat until the user chooses to stop.
- Inside the while loop, the user is prompted to enter grades for five subjects, and the total grades are calculated as before.
- The average grade and final letter grade are calculated based on the total grades, and the results are printed to the user.
- After each iteration, the user is prompted with the question "Do you want to continue?" and the answer is stored in the choice variable.
- If the user enters anything other than "yes" (case-insensitive), the break statement is executed, exiting the while loop and stopping the program. Otherwise, the loop continues, and the user is prompted to enter grades for another round.

This solution allows the user to repeatedly calculate average grades and final letter grades until they choose to stop by entering "no" when prompted to continue.

#### Tips for a beginner programmer:

- Understand the problem: Begin by understanding the problem statement and what is required. In this case, in addition to calculating the average of the grades, the program should also allow the user to choose whether to continue with another round or stop.

- Plan the program flow: Break down the problem into smaller steps and plan the flow of the program. In this case, you can start with a `while`-loop that repeats until the user chooses to stop. Test it carefully and make sure that the loop works correctly. You can use `print()` statements.

- Use a for loop for grade input: Inside the while loop, use a for loop to iterate five times and prompt the user to enter grades for each subject. Store each grade input in a variable, and update `total_grades` by adding the current grade to it.

- Calculate average and final grade: After the for loop, calculate the average grade by dividing `total_grades` by 5. Use conditional statements to determine the final letter grade based on the average grade. Update the `final_grade` variable accordingly.

- Keep practicing and seeking help: Programming skills improve with practice. Experiment with different scenarios, modify the code, and seek help from programming resources or communities when needed. Continuously learning and practicing will enhance your understanding and proficiency.

