# Week 07


## Exercises:

1. Assume `L=[(0,1),0,-1,-2,1,2]`. A sequence of Python expressions is provided here. Determine the result of each expressions.
 ```python
result = []
result.append(L[0:-2])
result.append(L[::-2])
result.append(L[0])
result.append(L[0][1])
result.append(L+list('abcdef'[::-1]))
print(result)
 ```
2. Assume `s='Analysis'` and `t=(0,1,2)`. What will be result of the execution of the following expressions.
	- `s[1]='N'`
	- `t[1]=-1`
	- `s[::-1]`
	- `t[::-1]`
	- `s.replace('s','S')`
	- `t.replace(0,'0')`

3. Explore the following concepts:
	- What is a power set?
	- How many numbers can be generated using 4 bits? using n bits?
	- Assume a boolean expressions with 3 variables. How many rows does the truth table have?
	- Assume a set named `S` where `|S|=3`. What is the cardinality of the power set of `S`?
	- Assignment, shallow copy and deep copy in lists.

## Problems:

1. Assume we have a fair coin. We toss the coin. What is the probability of having a head?
	- How would you approach this problem to solve it using programming?
	- How would you model the parameters from the real world into the coding? 

2. 8-queens Classic Problem: We would like to have a code to check if queens are not attacking each other. 
	- How would you model the problem into the code?


