# Python 07: Tutorial

## Todo

- 

## Introduction



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
    return (score * (1 + BONUS_PERCENTAGE / 100)) if score > BONUS_THRESHOLD else score

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
    print("🔍 **Employee Performance Analysis System** \n")
    employee_results = process_employees(employees)
    display_results(employee_results)

### **Run the Program**
if __name__ == "__main__":
    main()
```

#### Note


## Step 02: Sets


### Problem Solving


#### Strategy


#### Solution


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
This example simply demonstrates how an anonymous function can be defined. However, you might still wonder about the actual benefits of defining double this way. To clarify its usefulness, we will provide two examples where anonymous functions can be particularly helpful.

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
	