# Concurrency in C#: Practicum

This document class activities and exercises are described to be practised in practicums of Concurrency course of Hogeschool Rotterdam.

The exercises of each week coresponds to some of the source codes available here in Github:
https://github.com/afshinamighi/Courses

In each practical exercise, students are expected to read the specified source codes, read and analyze provided example codes, understand the structures, analyze the expected behaviour of the programs (guess and justify the output), and in some cases reproduce the concept in a different context.

**Note**: This document will be updated weekly. 



# Week 1: 
Main objectives of this week is to introduce the main concepts and prepare practical tools needed for upcoming weeks.
**Preparation**:
1. We will discuss about threads in week 3. Here, just think about a thread as a separate paths of execution that can be executed simultanously with the main program.
2. Refresh your C# programming environment: You are expected to be able to write simple console based programs. A set of possible concepts to be used later are: fundamentals (types, conditional statements, loops), defining attributes, methods, public / private / static, arrays, anonymous functions. Implement a simple program: like a counter class that counts until a given number and the main program instantiates an object from this class and prints the final result. The counter class has a state that keeps the latest counting value.



## Exercises:
1. Concurrency in your machine:
	i.	Make a list of parallel/concurrent programs in your computer: (recall that in mac the command [ps -ax] makes a list of currently running processes with PID and the location of the executable programs). Choose a running program (for example PyCharm) and see how many threads are running by the application.
	ii.	Open an internet browser with several tabs. Check how many threads are created. Make a list (at least five) of functionalities (tasks) that each thread of execution is responsible to execute. Share your list with the teacher.
2. **SocketClient, SocketServer**: 
	i.	These two projects implement a simple client and server programs in C#. Create a project in your local machine and run both client and server. Check how network communication is working in this simulation. 
	ii.	Assume you are asked to simulate multiple clients trying to communicate with the server simultaneously. How would you do that? What would you need? Explain the logic through the provided client code.Is current server implementation able to handle multiple simultaneous clients? If not, what would be your proposal to solve it? Explain the logic through the provided server code.
3. **MergeSort**: One of the challenges in designing a concurrent program is to recognise potential concurrent tasks. 
	i.	Among various sort algorithms one of the well-known ones is named **merge sort** algorithm. Read and understand how this algorithm works.
Resource: You can use resources here , or here (don't forget to choose right settings) 
Can you recognise tasks that can be done simultaneously? Discuss with your classmates and share your answers with the teacher. 
Note: In week three you will be asked to implement a concurrent version of this algorithm. Therefore, this exercise is crucial to understand and share your ideas. 
