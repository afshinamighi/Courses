## TEMPLATE
# Start by writting the problem description.

# Inputs
# First, list all of the inputs, then convert it to Python code.

# Processing
# First, explain how will you solve the problem.
# Then, convert it to code.
# Do this section last.

# Outputs
# First, list all of the outputs, then convert it to Python code.



## EXERCISE 1 - RECTANGLE
# Calculate and print the area of a rectangle
# for width and length given by the user.

# Inputs
w = input("enter rectangle width: ")
w = int(w)
l = input("enter rectangle length: ")
l = int(l)

# Processing
area = w * l

# Outputs
print("The area of rectangle is:", area)



## EXERCISE 2 - PERIMETER
# Calculate and print the area and perimeter of a rectangle
# for width and length given by the user.

# Inputs
w = input("enter rectangle width: ")
w = int(w)
l = input("enter rectangle length: ")
l = int(l)

# Processing
area = w * l
perimeter = 2*l + 2*w

# Outputs
print("The area of rectangle is:", area)
print("The perimeter of rectangle is:", perimeter)



## EXERCISE 3 - PURCHASE
# Ask the user for the name of item X.
# Then ask the user for the price of item X.
# Finally, ask the user for desired quantity of item X.
# Based on input, calculate how much you have to pay.
# Write the message in the form:
#   "To purchase N units of X you must pay M euros."


# Inputs
name = input("Input the name of item X: ") # note: name is string -> no casting

print("What is the price of", name, "?") # we can also use print to ask user
price = input()
price = int(price)  # price is needed as integer, so we cast from string

# note: the line below would raise an error
# quantity = input("How many units of", name, "do you want to buy: ")
# If you want to print variable's value, you must use print command
print("How many units of", name, "do you want to buy?")
quantity = int(input()) # here we demonstare int and input in one line

# Processing
to_pay = price * quantity

# Outputs
print("To purchase", quantity, "units of", name, "you must pay", to_pay, "euros.")



## EXERCISE 4 - EXCHANGE VALUES
# Ask user to input two numeric variables A and B.
# Then exchange their values and print their results.

# Inputs
A = input("enter value A: ")
A = int(A)
B = input("enter value B: ")
B = int(B)

# Processing
T = A
A = B
B = T

# Outputs
print("A =", A)
print("B =", B)



## EXERCISE 5 - EXTRACT DIGIT
# Ask user to input some numeric value.
# Then, print the last digit for the number user had entered.

# Inputs
N = input("enter numerical value: ")
N = int(N)

# Processing
D = N % 10

# Outputs
print(D)



## EXERCISE 6 - MIDDLE DIGIT
# Ask user to input three digit number.
# Then, print out the digit in the middle.

# Note: This exercise is intended to be solved by students on their own.
# Only hints are given in comments.
# Replace lines marked by X with actual Python code

# Inputs
# X Ask user to input three digit number (you can call variable N or number)

# Processing
# X Using division and/or remainder and/or modulo extract the middle digit ...
#   ... and assign it to variable D or digit (or any other name of your choice)

# Outputs
# X Print digit (D).
