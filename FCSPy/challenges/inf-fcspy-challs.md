
# Challenges


We always hear about data, information and computers processing data. But what are those exactly? What are the main elements of a device to call it as a computer? How can data be represented in various format? Answering to these questions will help us take first steps in learning fundations of Computer Science.

## ISBN Check:

### Objectives
-	Evaluate the ability to apply concepts of numeral systems, boolean logic, strings, lists and tuples to solve problems.

### Problem Introduction
Recording data files are prone to mistakes. For example in long sequence of numbers a digit can be missed, duplicated, or removed. Processing given information relies on correctness of input values.
Fortunately, there are techniques at least minimize, such occurrences, and those are often used in computing for error detection. One of those is *checksum*, which is a calculated value used to determine the validity of data.

The International Standard Book Number (**ISBN**) is one such example. It is a numerical book identifier and is unique for each book. Currently there are ISBN-10 and ISBN-13 versions, each containing 10 or 13 digits respectively. In this assignment, we will focus on ISBN-10.
ISBN-10 became a world-wide standard in 1972. A 10-digit ISBN consists of 4 elements:
	
	- A group element (GE),
	- A publisher prefix (PP),
	- A title element (TE), and
	- A check digit (CD).

The format of an ISBN-10 number is: 

	ISBN [GE]-[PP]-[TE]-[CD]

Example: ISBN 1-85375-390-4. GE is 1, PP is 85375, CD is 390 and CD is 4. The elements of the code are separated by spaces or hyphens. The sizes of the first three parts are variable, but together they are always 9 characters long. The first 9 digits (here: 185375390x) are actually codes, while the last one (xxxxxxxxx4) is used for checking if the other digits are correct, hence its name – check digit.

The check digit is a value needed to be added to the control number so that it is divisible by 11. The control number is made of the first 9 digits (GE, PP and TE) and is the sum of the 1st digit multiplied by 10, plus the 2nd digit multiplied by 9, plus the 3rd digit multiplied by 8, … , plus the 9th digit multiplied by 2.

For our example in (1-85375-390-4): the control number will be:

	control number = 1*10+8*9+5*8+3*7+7*6+5*5+3*4+9*3+0*2 = 249.

Dividing control number by 11 (i.e. 249/11) we find 22 with the remaining 7. The correct check digit will be (11 - 7) which is 4 in our example.

	Test: (control number + check digit) / 11 = 
	(249 + 4) / 11	= 253 / 11	= 23 (R 0)

*Note*: Since ISBN-10 uses a modulo-11 checksum, there are cases when the check digit is actually 10. In that case, character X is used as check digit (X as Roman numeral for 10).

### Problem statement
A book store uses a scanner to scan the ISBN numbers of the books. Unfortunetly , the scanner was not functioning well and the output file contains some invalid isbn numbers. The owner of the book store found out that there are two groups of invalid isbn numbers: missing digits and wrong check digit. 
You are asked to implement a program that given an input file with the book names and isbn numbers, the program can make a list of invalid corrupted isbn numbers. The input file is a csv file in which each line has the following format:

	book_name,book_isbn_number
	
Your program is expected to process the input file and generate a list of books with invalid isbn number and corruption reason. This is an example output:

**[('Book1', 'ISBN 1-85375-390-5', 'Wrong Check Number'), ('Book3', 'ISBN -85375-390-4', 'Missing Digits'), ('Book4', 'ISBN 1-8537-390-4', 'Missing Digits')]**

### Implementation Criteria:
	- Read ISBN-10 from the given input csv file. 
	- Do not add any additional text to the user. 
	- Perform only validity checks explained above.

### Extended Features:

The scanner device has been improved and can put a dot in the position of missing digit. The check digit is guaranteed to be correct. Extend your program that can calculate the missing digit and replace the dot with a correct digit.
For example, an isbn code with value ISBN .-85375-390-4 can be fixed and corrected value will be ISBN 1-85375-390-4

<!--
Also, the input should contain only digits, character ‘X’ (capital) and character ‘.’ (dot). If any other character appears in the input, also print “INPUT ERROR” and exit the program.
You are guaranteed that the input will contain either no ‘.’ (dots) or a single ‘.’ (dot). If the input contains no ‘.’ (dots), then you should validate the given ISBN code using the rule explained in the paragraph above. If the code is valid, then print “VALID” (all capitals). If the code is not valid, then print “INVALID” (all capitals).
A single ‘.’ represents a missing ISBN character, and if given in the input, then you should use the same rule to determine what should be the correct character in that position. Output the correct character as string type.
Do not give any other output than what is described here.

Example input and output:
Input is given in BLUE. Required output is given in RED. 
-->

