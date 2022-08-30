# Week 02

True or False? The result of decisions can change the path of the executions in a program. What are the fundamental concepts to formulate decisions in computer programs? In how many ways a boolean expression can be specified? What is the theory behind it? In this week we will explore branching algorithms and rules to analyse truthness of an expression.

## Learning Outcomes

After this lesson each student will be able to:

1. Understand and evaluate boolean logic expressions.
2. Understand and apply De Morgan's Laws to simplify Python boolean expressions.
3. Understand and implement conditional statements in Python.

## Learning Activities:

Using provided material, explore and discuss the following questions:

1. What is a boolean data type in Python? What is a boolean expression in Python? 
2. Make a list of boolean *operators* in Python. Write down at least one example for each.
3. Make a list of (main) operators in *boolean logic*. Write down at least one examples for each.
4. What is a truth table? Construct truth tables for the following boolean operators: `AND` (conjunction $\wedge$), `OR` (disjunction $\vee$), `NOT` (negation $\neg$), `XOR`, `IMPL`(implication $\implies$).
5. How do two boolean expressions become *equivalent*? 
6. Make a list of comparison operators in Python and math. Write down at least one examples for each.
7. What is a conditional statement in Python and how it can be used to implement branching algorithms?
8. Construct a table of De Morgan's Laws. Write down one example for each. 
9. How De Morgan's Laws can be used to simplify boolean expressions in a Python program?



## Exercises:

1. Assume you are living in a house that has two doors, front and back, each with a button to ring a bell. You have a sensor connected to each button that detects two states: 1 (true) – button pressed; 0 (false) – button not pressed. You connected these buttons to the single bell in the house and you want the bell to ring when someone presses the button either at the front or at the rear door. Which logical variables and operators would you use to build doorbell system? Write Boolean expression and prove the correctness of your expression using truth tables.
2. You are building your home alarm system. This system is connected to two sensors. The first is the light sensor, that distinguishes between day and night (TRUE – day, FALSE – night). The second is connected to the window and has the following values: TRUE – window open, FALSE – window closed. Assume that you want to open windows during the day. You can treat the burglary in progress as a case when the window is opened during the night. Which logical variables and operators would you use to build your alarm system? Write Boolean expression and prove its correctness using truth tables.
3. Write a program that examines three variables — x, y, and z — and prints the largest odd number among them. If none of them are odd, it should print a message to that effect (i.e. that there is none).
4. A programmer has implemented the following Boolean expressions. Try to simplify (re-write) them.

``` Python
 - not( x == 0 and y > 0 )
 - not( x <= 0   or  y == 0 )
 - x==0 and not( x<0 or y%2==0 )
 - not( x!=0 or not( y%3==0 and z>0 and w==0 ) )
 - not( x%2 == 0 or ( y>=0 or z==0))
```

5. Finish all the exercises provided [here](https://github.com/afshinamighi/Courses/blob/main/basecamp/week02/inf-bc-w02-python.md).


## Problems:

1. quotient and remainder: Input values X and Y. Then, print numbers A, B and C, such that: A is the result(quotient) of float division of X and Y, B is the result of floor division of X and Y, and C is the remainder when you divide X by Y.
2. seconds to h : m : s : Ask the user to input one numerical value representing time measured in seconds. Then, print it out in a form that is showing hours : minutes : seconds.
3. area of a triangle: Write a program that will print and calculate the area of a triangle. User should give the base and the height of the triangle.
4. sum of the areas of two triangles: Write a program that will print and calculate the sum of the areas of two triangles. User should give the bases and the heights of both triangles.
5. exchange values without “helper” variable: Write a program that will ask the user to input two numeric values and store them in variables A and B. Then, exchange the values so that A gets the value of B and B gets the value of A, but without using helper variable. Print out values of variable A and variable B.
6. sum of the remainders: Write a program that will ask to input four numerical variables. Then calculate the sum of the remainders of the first two numbers and the last two of them. For example, if user enters A = 5 , B = 4 , C = 6 and D = 4 the program should output sum = 1 + 2 = 3 .
7. square of a number: Write a program that will ask to input one numerical variable. Then calculate and print the square of this number.
8. joint endeavour: The first student can complete the homework in F amount of hours (whole number). The second student can complete the same homework in S amount of hours. How long will it take both students to complete the homework if they work together? Input values F and S, then find and print the result.
9. time in school: Enter the number of lessons students have this day. If we know that each lesson lasts 50 minutes, write an algorithm and implement it in Python, that will print out how many hours and minutes students spent this day in school.
10. practice truth tables: Create truth tables for the following statements: 
	- $\neg P \wedge Q \wedge R$
	- $(Q \wedge \neg P) \implies R$
	- $\neg R \implies (Q \wedge \neg P)$
11. alien logic: An alien mothership has just crashed into your backyard. Upon a closer inspection, you found a circuit board with a logic gate. The logic gate appears to be a binary operator $\square$, which you never encountered before. Testing it with P and Q, you mapped the following truth table:

|P | Q | 	P $\square$ Q |
|--|--|--|
|TRUE	| TRUE| 	TRUE |
|TRUE	|FALSE	|TRUE|
|FALSE	|TRUE|FALSE|
|FALSE|FALSE|TRUE|

To enter the mothership, you must find all boolean values for the following expression: $\neg (P \square \neg Q)$
*Hint: make a truth table*.

10. Implement your Python solutions to the problems provided [here](https://github.com/afshinamighi/Courses/blob/main/basecamp/week02/inf-bc-w02-python.md).

1. [todo: idea for using XOR in solving problems: "Classic Problems in Python", Introduction, Using XOR in encryption, 1.3. Unbreakable encryption]


## Resources:
### Books:
1. Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; Chapters 1,2 and 3.

### Videos:
1. [Truth Tables](https://www.youtube.com/watch?v=VCEYeB3bRW0)
2. [Boolean Algebra](https://www.youtube.com/watch?v=Hby4mlpSNxo)
3. [Logical equivalence and De Morgan’s Laws](https://www.youtube.com/watch?v=93CxSLi89Ok)
4. [How do computers add numbers?](https://www.youtube.com/watch?v=VBDoT8o4q00)
3. 
