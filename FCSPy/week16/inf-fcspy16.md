# Week 06

A set builds a collection of well-defined items such that the order and repetition are not the main features. Often in our programming solutions we need different type of structures where *the order is important*. In this week we will learn how to build a sequence of ordered values.

## Resources:
### Books:

**BRef-01**: Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages";

## Learning Outcomes:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs using tuples and lists.
	2. interpret and implement Python programs manipulating lists: defining, offset, slicing, adding new element, modifying an element. 
```

## Learning Activities:

#### What to Learn?

1. Using **BRef-01: Chapter 07** answer and experiment the following questions:
   1. What is a tuple in Python and how is it defined?
   2. How can one combine and compare two (or more) tuples? 
   3. How can one iterate over the elements of a tuple?
   4. How is a tuple modified?
   5. What is a list in Python and how is it defined?
   6. What is the result of *split()* on a string?
   7. There are two ways to get items from a list: offset and slice. What are the pros / cons of each? Experiment with some examples.
   7. How can you add new elements to a list?
   8. How can you modify elements of a list?
   9. How can one iterate over the elements of a list?
   10. *Mutability* is one of the main differences between a tuple and a list. Elaborate this with some examples. 
   11. We have learned *join()* on a string. How does *join()* work in a list?
   12. How can we sort items of a list? Is this possible on a tuple?
   13. There are several ways to copy a list: *list(), slicing, copy()* and *deepcopy()*. Experiment different expamples for each technique.
   14. **(Optional)** How can one build a list using *list comprehension*? Do we have *tuple comprehension*?



#### Exercises:
1. You can create a tuple with mixed types in it, for example texts and numbers. Can you think of a advantage and a disadvantage of doing this? Implement your example.
2. Create a tuple with three numbers in it. Unpack the tuple into three different variables. Print the last one.
3. Create a tuple with two numbers in it, create a second tuple with two texts in it. Add them together into a new tuple. Print the new tuple.
4. Create a tuple with three numbers in it. Use a for loop to iterate over each value. Multiply each value by 2 and print each result.
5. Analyse the two given codes below without executing them. What will be the result of the programs?

 ```python
a_tuple = ('Never', 'gonna', 'give', 'you', 'up')
counter = 0
for x in a_tuple:
    if x[0] ==  'g':
        counter = counter + 1
    else:
        counter = counter + 2
print(counter)
```

6. Design two exercises of your own. They should improve understanding tuples.

7. Define a list of integers representing scores of a game. Write a program that prints out maximum and minimum of the `scores`.
8. Extend your program from the previous exercise such that it prints two largest and two smallest elements of the `scores`.
9. Write a program that asks the user to enter a list of integers. Do the following:
	- Print the total number of items in the list.
	- Print the last item in the list.
	- Print the list in reverse order.
	- Print Yes if the list contains a 5 and No otherwise.
	- Print the number of fives in the list.
	- Remove the first and last items from the list, sort the remaining items, and print the result.
	- Print how many integers in the list are less than 5.
10. Write a program that generates a list of 20 random numbers between 1 and 100.
 	- Print the list.
	- Print the average of the elements in the list.
	- Print the largest and smallest values in the list.
	- Print the second largest and second smallest entries in the list
	- Print how many even numbers are in the list.
11. Start with the list `[8,9,10]`. Do the following:
	- Set the second entry (index 1) to 17 
	- Add 4,5, and 6 to the end of the list 
	- Remove the first entry from the list
	- Sort the list
	- Double the list
	- Insert 25 at index 3
	- The final list should equal `[4,5,6,25,10,17,4,5,6,10,17]`
12. Create the following lists using a loop.
	- A list consisting of the integers 0 through 49
	- A list containing the squares of the integers 1 through 50.
	- The list `['a','bb','ccc','dddd', . . . ]` that ends with 26 copies of the letter z.

13. Create a list containing at least three `tuples` containing some numbers. Print the last item of each tuple by looping through the list. 

14. Write a program that takes any two lists L and M of the same size and adds their elements together to form a new list N whose elements are sums of the corresponding elements in L and M. For instance, if `L=[3,1,4]` and `M=[1,5,9]`, then N should equal `[4,6,13]`.

15. Design two exercises of your own. They should improve understanding topics of this step.

16. The method `list.sort()` sorts a list ascending. Look up how to sort descending and try it. 

20. Create a loop that creates a list containing tuples with the numbers 1 to 10 in pairs of 2. The result should be `[(1,2),(3,4),(5,6),(7,8),(9,10)]`.

21. Take the list from the previous exercise. Remove the tuples in which the first item is an odd number. 

22. Design two exercises of your own. They should improve understanding topics of this step.

## Problems:

1. A data set containing some information of Netflix is provided [here](./data/netflix_titles.csv) (for the reference [click here](https://www.kaggle.com/datasets/shivamb/netflix-shows)). The first row specifies the attributes, i.e. labels given for each column. For example, the first item of the first row indicates that in each row, the first item is the id. The third item of each row specifies the title. And so on.
	- Your task is to implement a program that after reading the content of the file, the program collects and prints the information as follows:
	- A list containing two lists.
	- Each list has two elements. The first element is either `TV Show` or `Movie`. The second element will be the list of `(title,director)` tuples that coresponds to the type specified in the first element.
	- Print the percentage of each type.
	- To read the content of the file, download the data file, copy it in the same folder as your program is implemented and use the following code at the beginning of your program:

```python
import csv
input_data_file = 'netflix_titles.csv'

def load_csv_file(file_name):
    file_content = []
    try:
        with open(file_name , 'r', encoding="UTF-8") as csv_file_object:
            csv_reader = csv.reader(csv_file_object)
            for row in csv_reader:
                file_content.append(row)
    except:
        print('Exception in opening file:',file_name)
    finally:
        csv_file_object.close()
    return file_content


file_content = load_csv_file(input_data_file)
print(file_content[:3])
```





