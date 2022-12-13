# Python 15: Recursive Functions.

**Introduction**: This document presents learning activities for Python 15. In Python 15, you will learn and practice recursive functions in Python. Recursive functions are the functions that call themselves. In majority of cases, you may implement a solution, non-recursively. There are cases that the definition is naturally recursive. In these cases, recursive functions can be easier to implement.

**Note**: In this phase, it is expected the learner can plan and run required learning process towards the goals of the week: making solutions to the given problems and product(s).

## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 

- Free research.


## Path:

#### Goals:

```
After taking this step, you will be able to:
	1. understand recursive functions.
```
#### What to learn?

**Note:** If this is the first time that you try recursion, it is very cruccial to start with small steps, small examples, seeing more samples and trying yourself. It will take time to feel confident in writing a solution recursively. Be patient.

1. Using **BRef-01, Chapter 9 (Section: Recursion)** make a plan for the week to learn basics of recursive functions in Python.
	- Make an overview of the provided problems and final product.
	- Plan what you need to learn in order to provide your solutions.
	- Read proposed book chapter and practice basic provided examples.
	- Read [this resource](https://www.pythontutorial.net/python-basics/python-recursive-functions/) and run provided examples.
	- Watch [this video](https://www.youtube.com/watch?v=m1Fjdnj_Mds). 

<hr>

## Exercises:

1. Play [Tower of Hanoi](https://webgamesonline.com/towers-of-hanoi/).
2. From elementary school we know $5^3=5 \times 5 \times 5$. But, we can also define it recursively: $5^3 = 5 \times 5^2$. Or in general we can define the concept of $m^n$ recursively: $m^n=m \times m^{(n-1)}$. Check the implementation below. Try the code. There is something missing which makes it incorrect. Fix the implementation.

```python
    def rec_power(m:int,n:int)->int:
        '''
        The function returns m to the power of n.
        '''
        return m*rec_power(m,n-1)
```  


## Problems:


1. You already know how to implement a Python program that prints positive numbers less than `n` (non-recursively). Implement a *recursive* function named `rec_print(n)` that given a positive integer `n` prints all the positive numbers less than `n`. 
2. Implement two functions, one for non-recursive and one recursive, that calculate the result of multiplication of positive numbers less that or equal given `n`. For example, given `n=5`, the result will be 120 (because `5*4*3*2*1=120`). Note: In mathematics this is called calculating *n-factorial*.
3. You are already familiar how to check if a list contains an item or not. Assume we would like implement such function ourselves. Implement a recursive function that given an element and a list, returns true if the list contains the element, false otherwise. It would be a good (and very simple) practice to implement a non-recursive one first. 

## Assignment:

In a program a function is implemented to tranverse the folders and files. It returns the result as a list. A list indicates a folder and an string item is a file. For example: `['file_1',[]]` is a folder that contains a file and an empty subfolder; `['file_1','file_2',['file_1']]` is a folder containing two files and a subfolder with a file.
Our task is to implement a Python function that:

- Given such a list as the root folder prints the contents. Indentation of the folder will be `>` and for a file will be `-`.
- Given such a list as the root folder prints the number of files. 

Use the following code template:

```python
def rec_print_folders(n:int,pref:str,root:list)->None:
    '''        
    This function prints the contents of a given root folder with indentations.
    '''
	# todo: implement the body of this function

def rec_count_files(root:list)->int:
	'''
	The functions counts number of files in a given folder (and all its sub-folders).
	:param root: A nested list: an element either is a file (name) or a list as a sub-folder.
	:return:
	'''
	# todo: implement the body of this function

test_cases =[
    ['file_1',[]] ,
    ['file_1','file_2',['file_1']] ,
    ['file_1','file_2',['file_3','file_4','file_5'],['file_6',['file_7','file_8'],['file_9'],'file_9',['file_10']],[]] ,
    ['file_1',['file_3',['file_2',['file_10',['file_9','file_8']]]],[] ],
    [[],[[],[[]]]] 
    ]
for case in test_cases:
    rec_print_folders(0,'',case)
    print('Number of files in case: ',case, ' is ',rec_count_files(case))
```
Below you will see the result of the execution for the first two cases:

```
Folder_0
 file_1
>Folder_1
Number of files in case:  ['file_1', []]  is  1
Folder_0
 file_1
 file_2
>Folder_1
- file_1
Number of files in case:  ['file_1', 'file_2', ['file_1']]  is  3
```
         


## Extra Steps:

[todo]