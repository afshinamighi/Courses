# Exercises (Relations, Functions, Combinatorics and Probability):

1. Provide solutions for the following problems:
    1. In a resturaunt you have a menue with three starters, five main dishes and four desserts. You want one item from each category. In how many ways you can order your dinner?
    2. You have five different books. In how many ways you can put them in your shelf?
    3. You have five books and there are only three empty positions left in your shelf. In how many ways you can put them in the empty positions of your shelf.
    4. You are in a team with 6 members. There are different tasks, one for each member. In how many ways you can divide tasks among each other? 

2. Assume these two sets: $A=\\{1,2,3,4,5\\}$ and $B=\\{a,b,c\\}$. 
    - Define three different relations.
    - How many relations can be defined? $(x,y): x \in A, y \in B$
    - Define three different functions: $f: A \rightarrow B$.
    - How many functions can be defined? $f: A \rightarrow B$.
3. Let $A = \\{ Cow, Chicken, Crocus \\}$ and $B = \\{ Plant, Animal, Bird, Mammal \\}$.  Let the relation R from A to B be defined as `is a`.
    - Express R in set-builder notation, in roster notation and in an arrow diagram.

4. Let $A = \\{ 2, 3, 4, 5, 6 \\}$, and let R be the relation on A (i.e. from A to A) defined as: `aRb iff a is a divisor of b`.  E.g. the divisors of 10 are 1, 2, 5, and 10.
    - Express R in set-builder notation, in roster notation and in an arrow diagram.

5. Let M be the set of months of the year 2020.
    - Let $f: M \rightarrow Z$ be the function that outputs the number of days in a given input month.  Represent $f$ using a table and using roster notation. 
    - *Python* Define a dictionary in Python that represents $f$.
    - *Python* Define a function that implements $f$. 

6. Let $R = \\{Chinese, Mexican, Pizza, Pasta, Fries\\}$ (set of dishes) and $D=\\{Fri,Sat, Sun\\}$ (set of days).
    - *Math* Define a function that specifies what should be prepared for a dinner in a given day.
    - *Python* Implement your function. How did you implement it?
    - *Math* How many possible mappings can you define for your function? 
    - *Python* Implement a code that generates all possible mappings (functions).
    - *Math* Suppose you are asked to serve a five course dinner for only one day, say Sunday. In how many possible orders you can server these dishes?
    - *Python* Impelement a code that generates all possible orders of dishes for one five-course dinner.
    - *Math* Suppose you are asked to serve only 3-course dinner. You can choose which three dishes can be served. How many possible options do you? After your selection, in how many possible ways you can serve?
    - *Python* Implement a code that generates all these possible options (3 dishes out of 5).


7. Given sets $A=\\{1,2,3,4,5\\}$ and $B=\\{a,b,c,d\\}$, determine  
    - *Python* Implement a program that generates all possible relations.
    - *Python* Implement a code that generates all possible functions.
    - the number of relations R from A to B and 
    - the number of functions from A to B.

8. Evaluate the following functions at x = 0, x = 1, x = -1, x = 2, x = -2, x = 5, and y = 10.
    - $f(x) = 5x - 7$
    - $g(x) = 5(x-7)$
    - $h(x) = {x^2} - x + 1$
    - $j(x) = 3(x+1) - 2$
    - $k(x,y) = {(x-1)^2} + {y^2}$
    - *Python* Implement these functions using anonymous functions (lambda expressions).

9. Which one is a function?
    - ${x^2}+{y^2}=4$
    - $\\{(2,4),(3,9),(4,1),(1,4)\\}$
    - $\\{(2,4),(3,9),(4,1),(2,5)\\}$
    - $y=\frac{(1-{x^2})}{(y-2)}$
    - $y^{2}+x^{2}=y^{3}+x^{3}+x^{4}+y^{4}$ (plot the equation [here](https://www.desmos.com/calculator))

10. Given the following equations:
    - $2n + 6p = 12$, express $p$ as a function of $n$, and also express $n$ as a function of $p$. 
    - $x + 4y = 3x - y$, express $x$ as a function of $y$, and express $y$ as a function of $x$.

11. Assume the word `ANALYSIS`. Using these letters we generate a random word (same length). what is the probability that `SIS` be part of the generated word (for example: `ASISYLIAN`). Propose your solution using simulation, itertools and theory.


12. Assume the word `COMPUTER`. 
    1. How many ways can the letters in the word be arranged in a row?
    2. We need the letters `CO` remains next to each other as a unit. In how many ways can the letters be arranged?
    3. Let's assume we randomly arrange the letters of the word. 
    - What is the probability that the letters `CO` remain next to each other?
    - What is the probability that the letters `CO` remain next to each other and at the beginning?
    4. From the letters of the word we select only three letters. In how many ways these letters can be arranged?

13. Assume there is a group with 7 members.  
    1. We would like to build a team with 4 members. In how many ways we can build the team?
    2. Implement a code that builds possible teams of 4 members.

14. Assume a *set* (or a *list*) with 8 (n) elements.
    1. In how many ways we can order the members? In how many ways we can make a *list* (the same size)? ... we can *build a word*?
    2. In how many ways we can order 4 (k) of them? In how many ways we can make a *list* with the size of 4 (k)? ... we can *build a word* of size 4 (k in general a shorter word).

15. Propose your solutions for the following concepts in Python:
    - Given sets $A$ and $B$, $R=\\{(a,b): a \in A, b \in B, a < b+2\\}$
    - 8 swimmers are racing for a medal (gold, silver, bronze). In how many different ways can the medals be distributed?
    - Using digits 0, 1, 3, 5, 7, 9, how many 4-digit numbers can be written, if we assume that no digit can be used more than once?
    - Let $S$ be a set of numbers 1-9: $S = \\{1,2,...,9\\}$. In how many ways can we pick two numbers if:
        - The order matters?
        - The order doesn’t matter?
    - You have the following ingredients in your refrigerator: bacon, cheese, eggs, salad, mustard, ketchup. How many different sandwiches can you make if you use 2 of the given ingredients?
    - A group of 10 employees (generate a set for 10 employees) has to elect 4 to a representative committee. In how many different ways can this committee be formed if one person is already elected?

     
## Tutorials:

In order to implement python code for the above exercises often special built-in functions and some important libraries can be useful. Here we list some learning resources:
- `map()`:[Reference](https://docs.python.org/3/library/functions.html?highlight=map#map), [Examples](https://www.programiz.com/python-programming/methods/built-in/map)
- `filter()`: [Reference](https://docs.python.org/3/library/functions.html?highlight=map#filter), [Examples](https://www.programiz.com/python-programming/methods/built-in/filter)
- `join()`: [Reference](https://docs.python.org/3/library/stdtypes.html#str.join) , [Examples](https://www.programiz.com/python-programming/methods/string/join)
- `zip()`:[Reference](https://docs.python.org/3/library/functions.html?highlight=zip#zip), [Examples](https://www.programiz.com/python-programming/methods/built-in/zip)
- `product()`:[Reference](https://docs.python.org/3/library/itertools.html?highlight=combination#itertools.product), [Examples](https://note.nkmk.me/en/python-itertools-product/)
- `permutations()`:[Reference](https://docs.python.org/3/library/itertools.html?highlight=permutation#itertools.permutations), [Examples](https://inventwithpython.com/blog/2021/07/03/combinations-and-permutations-in-python-with-itertools/)
- `combinations()`:[Reference](https://docs.python.org/3/library/itertools.html?highlight=combination#itertools.combinations) , [Examples](https://inventwithpython.com/blog/2021/07/03/combinations-and-permutations-in-python-with-itertools/)
