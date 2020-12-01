# Concurrency in C#: Practicum

This document class activities and exercises are described to be practised in practicums of Concurrency course of Hogeschool Rotterdam.

### Practical notes:
1. The exercises of each week coresponds to some of the source codes available here in Github: https://github.com/afshinamighi/Courses
2. Coresponding C# projects are represented with bold font at each exercise.
3. In each exercise, students are expected to evaluate specified source codes, understand the structures, analyze expected behaviours of the programs (guess and justify the output), and in some cases reproduce the concept in a different context.
4. In some of the exercises, students are asked to share / discuss / explain results of their evaluations. The teacher will determine how results will be shared with other students and/or the teacher.
5. This document will be updated weekly. 



# Week 1: 
Main objectives of this week is to introduce the main concepts and prepare practical tools needed for upcoming weeks.

## Preparation:
1.	 We will discuss about threads in week 3. Here, just think about a thread as a separate paths of execution that can be executed simultanously with the main program.
2.	 Refresh your C# programming environment: You are expected to be able to write simple console based programs. A set of possible concepts to be used later are: fundamentals (types, conditional statements, loops), defining attributes, methods, public / private / static, arrays, anonymous functions.
3.	 Implement a simple program: like a counter class that counts until a given number and the main program instantiates an object from this class and prints the final result. The counter class has a state that keeps the latest counting value.


## Exercises:
_note: just for today ignore the **#todo** inside the code that ask you to write code, we will focus on the understanding and not on producing code._
1. [~ 5 min ] Concurrency in your machine:
	1.	Make a list of parallel/concurrent programs in your computer. Choose a running program (for example PyCharm) and see how many threads are running by the application. You can check threads' count in your *task manager/activity monitor* (on Windows *task manager click* on the cloumns name to select colums and add threads if it is not already visible). You can also use in the Linux/MAC shell the command **"top"** (#TH --> total threads/running threads).
	2.	Open an internet browser with several tabs (*Chrome*) of the same domain website. Check how many threads are created per process (the threads are not directly named but they are listed as parts of the single process: they all have the same Process ID, but contains multiple lines). Make a list (at least five) of *functionalities* (tasks) that each thread of execution is responsible to execute.
	3. Share your list with the teacher.
2. [~ 30 min ] **SocketClient, SocketServer** (names of the projects/directories you can find in this repository):
	```diff
	+ Note: this code will be the base line for your assignment, read this document untill the end for more details.
	```
	1.	These two projects implement a simple client and server programs in C#. Create a project in your local machine and run both client and server. Check how network communication is working in this simulation.	*//hint:* run the client in a shell/terminal and the server in another. Start the server first and when it asks you the question, answer *"S"* (for Sequential).
	2.	Assume you are asked to simulate multiple clients trying to communicate with the server simultaneously.	
		1. In which method is the protocol implemented? Check for client and server.	*//hint:* at the top of the *Sequential.cs* file there is a high level view of the protocol.
		2. When is the server supposed to compute the votes?
		3. How does the client report to the server that the communication is ended?
		4. How are client and server configured?	*//hint:* multiple files are involved in this process.
		5. What is the role of the pending connection queue? Why do we need a queue?	*//hint:* the size is already defined from us, *"serverListeningQueue"*.
		6. Is the current server implementation able to handle multiple simultaneous clients? If not, what would be your proposal to solve it?	*//hint:* Which **functionality** of the server can be implemented **concurrently**?
	3. Share your answers with the teacher.
	
3. [~ 30 min ] **MergeSort**: One of the challenges in designing a concurrent program is to recognise potential concurrent tasks.
In Week 1, ignore the class named **ConcurrentMergeSort** and its todos.
	1.	Among various sort algorithms one of the well-known ones is named **merge sort** algorithm. Read and understand how this algorithm works. You can use the following sesources: [check here](https://www.hackerearth.com/practice/algorithms/sorting/merge-sort/visualize/) , or [here, just don't forget to choose right settings](https://visualgo.net/bn/sorting?slide=1).
	2.	**Note**: In week three you will be asked to implement a concurrent version of this algorithm. Therefore, this exercise is crucial to understand and share your ideas. 
		1. If you checked the visual algorithm displayed from the above links you should have noted that changes the order and rebuild the re-organised data, can you find these 2 methods in the code?
		2. How can we make it run faster if we had multiple processors available?
		3. Can you recognise sorting tasks that can be done *simultaneously*?
	3. Share your answers with the teacher.


# Week 2:

The main objectives are to understand and apply concepts of processes and inter-process communications in programming. In this week you will learn:
- how to obtain processes information from os.
- how to create and run a process through a program.
- how can two running processes communicate with each other.

## Preparation:
1. Use the online reference below and answer the questions:
Reference: [Process handling in C#](https://www.dotnetperls.com/process)
- Which namespace is needed?
- Which class and method are used to run a process?
- How can we modify properties of a process?
- How can we get a list of currently running processes?
2. Use the online reference below to find more information about **Process** component.
Reference: [System calls to make processes](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=netcore-3.1) 

## Exercises:

1. [~ 20 min ] **Processes**: The program will give a list of currently running processes. Names and Ids are printed. 
	1. Compare Ids and Names with your machine activity (task) manager program. Choose a process id from your computer that its termination is safe: like whatsapp, editors, browser. Check if the program terminates the given process completely.
	2. **[@home]** Add a method to the program that gets the name of a process and prints the related id.
2. [~ 20 min ] **ProcessCreation**: Implement a program, that executes a command, like **ls**/**dir**. Modify your program such that executes the **Processes** (previous exercise compiled version of the dll/exe, and check the references).

3. [~ 30 min ] **IPCNamedClient, IPCNamedServer**: Two projects are implemented to present how two programs can communicate using named pipes.
**Note**: Client and server naming is not following strict definition of client-server roles, it is just oriented to have a peer to peer communication.
	1. Read and analyse the programs for both client and server. What do you expect from the behaviour of these programs?
	2. Run the server, run the client. Check the behaviour.
	3. Run one server and two clients. Does the server communicate with both clients?
	4. What will happen if the name of the pipe in the server is different from the client? Change the name of the pipe in the server (or the client). Re-run both the client and server. Can they communicate? 
	5. Named pipes are meant for programs where two-way communication is needed. The current implementation provides only one-way communication (from the server to the client). Extend the programs such that the client sends the result of its processing (i.e. reversed message) back to the server. The server will print the result received from the client.
<!-- Solution: Is available. -->

4.  [~ 20 min ] **[@home]** Using named pipes implement a client / server program where the client sends the *name and the path* of an executable program to the server and the server starts the process given by the client.

<!-- (Optional) Read this tutorial and practice an example about AnonymousPipes: https://ingeno.io/2016/09/c-anonymous-pipes-for-interprocess-communication/  -->



# Week 3:

The main objectives are to understand and apply concepts of multithreading. This week we will focus on disjoint threads, i.e. threads that do not communicate with each other. In this week you will learn:

- how to create and start a thread.
- how to join to a running thread.
- how to separate a task from a given sequential program to be running concurrently.

## Preparation:

1. Use the online refernce provided here and answer the following questions:
   Reference: [Multi-threading in C#](http://www.albahari.com/threading/) (Read only *Introduction and Concepts* from Part 1).
   1. What namespaces are needed to use threads?
   2. How can you create a thread?
   3. How do you specify a task to be executed by a thread?
   4. How should you start a thread?
   5. What is a main thread? 
   6. What does happen when a main thread starts another thread? 
   7. How can a main thread (or in general any thread) join another thread?
   8. What may happen if a main thread terminates and does not wait for another thread to join?

## Exercises:

1. [~ 15 min] In Week 1, it is discussed how a statement like **C=A+B** is translated to assembly instructions. Answer the following questions and share them with your teacher.
   1. Check the slides and write down the sequence of assembly code for **C=A+B**
   2. Assume two threads running concurrently. Thread 1 is executing **X=A+B** and thread 2 is executing **Y=C+D**. 
      1. Write down three **possible** interleavings (assembly instructions). 
      2. Write down three **impossible** interleavings.
2. [~ 30 min] **Threads**: A simple example about threads: creating, starting and joining threads. Read the example. Follow todos, check how a thread is defined, started and joined. Check how a task can be given to the thread. Run the examples. Check the output. 
   1. How can we get information about running threads of a specific process?
   2. How can a main program create and start multiple threads? How can a main program join to multiple threads? Justify your answer by examples in the code. 
   3. Sometimes you need to pass parameters to a thread. How can you implement it? Justify your answer by examples in the code.
   4. Justify the output: why you get different output at each run?
3. [~ 30 min] **PrimeNumbers** : A sample sequential code for finding prime numbers is given. Your task is to write a method that implements the concurrent version of this algorithm.
   1. Understand how the sequential version works. Recognise which task can be divided between two (or more) threads.
   2. *Implementation*: Follow todo provided in the code to implement the exercise. For simplicity first implement **only for two threads**. 
   3. *Implementation (Optional)*:  Generalise your code for more threads.
4. [~ 30 min] **MergeSort**: A sample implementation of merge sort is given. It is implemented sequentially. Your task is to implement a multi-threaded MergeSort. *Note*: In order to practice with the concepts of merge sort, first, understand how the sequential version works. Check the exercises of Week 1. You can use online resources to observe its execution visually. 
   1. Recognise which task can be assigned to threads to be executed independently. For simplicity, assume only two threads.
   2. *Implementation*: Follow todos provided in the code to implement the exercise.



# Week 4:

The main objectives are to protect shared resources and to practice basic concepts of synchronisations... [in progress]

- How to ...
- How to ...
- ...

## Preparation:

1. In order to practice this set of exercises, you need to be confident with creating several threads, passing tasks to the threads, starting and joining to the threads. If you are not confident yet, first practice with exercises **Week 3: Exercises 2 and 3**.
2. Use the reference provided below to answer the following questions:
   Reference: [Synchronization Objects](http://www.albahari.com/threading/part2.aspx) 
   1. What are commonly used blocking methods in threads?
   2. What is the difference between spinning and bloking? Which one is not efficient?
   3. What is a lock? Why do we need a lock?
3. If you do not have experience with linked lists, read this tutorial to gain knowledge about linked list in C#:
   Tutorial: [Linked Lists in C#](https://www.dotnetperls.com/linkedlist) 



## Exercises:

1. [~ 20 min ] **Synchronization**: This program is a simple example of **data race**. Follow the comments and todos provided in the main method and run the examples. For each example, read the related code in detail and analyze the behaviour.
   1. Where is the shared memory here? 
   2. How do threads access to the shared memory? 
   3. Do you recognise a data race here? Justofy your answer?
   4. Do you recognise a critical section in the code? Where is it protected? 
   5. Which mechanism is used to protect the shared memory?
2. [~ 15 min ] **MergeSort** **[@home]** : Use the code and justify your answers for the following questions. 
   1. Do you recognise a shared memory? 
   2. Do you need to protect the shared memory?
3. [~ 30 min ] **ProducerConsumer**: This program is a simple simulation of (sequential) producer-consumer problem. There are a number of generated data (here just random numbers) produced by the producer, inserted in a shared buffer (list), and consumed by a consumer.
   1. Follow todos in the program and run the sequential version of producer-consumer. Check the order of data producing and consuming.
   2. Read the program carefully: 
      1. How are the producer and consumer generating / consuming data?
      2. How is the channel defined?
      3. How are the producer-consumer accessing the channel?
      4. Do we need to protect the channel in the sequential version? 
   3. Follow todos and run the **concurrentOneProducerOneConsumer** method. Check the order of the execution. 
      1. Re-run the program several times. Can the consumer consume all the generated data?
   4. **[@home]**: As you can recognise, usually, the shared buffer is left with some unused data items. Fix the program in a way that the consumer can use all the data available.
      Hint: First, instead of a fixed number of iterations, trigger producer and consumer in every *t* milliseconds. *t* can be a random number within an interval. Then, the consumer should consume all the items whenever it has a chance to execute.
4. [~ 30 min] **ProducerConsumer**:
   1. Implement a method that simulates multiple producers, one consumer.
   2. Implement a method that simulates multiple producers and multiple consumers.
5. **DataProcessor** (Optional): In a project, there are several sensors generating and sending data to a server. The server is responsible to collect all the data and visualize them.
   1. **Implementation**: Implement a program that provides the core for the above application. Data can be simply temperature of various locations that is measured every 10 milliseconds and being sent to the server together with the location data values. 
      *Hint*: The purpose of this exercise is not to implement a client server program. Focus on the model of data gathering and synchronisation with the visualizer. Visualization can simply be printing the data values in the output console. 







## Assignment: Practical steps
Description of the assignment and deliveries will be published by the teacher. Here we try to provide some steps that practically can lead students to implement a solution for the assignment. **Note**: These steps will be updated regularly during the course period.

During the course after Week ...
1. students can download and execute coresponding projects. They should spend enough time to understand details of the code and provided structure, modify and extend the code.
2. students can make a list of commands in the client side. They should modify server such that it can execute the command sent by the client. First step: all clients are sending only one command to be executed at the server.
3. students can extend client side such that it simulates a number of concurrent clients all trying to simultaneously communicating with the server.
4. students can extend the server that can handle multiple simultaneous clients.
5. students can extend the server with a proper shared structure such that stores received data from all the clients.
6. students can extend the server with a solution to make the server thread safe, i.e no data race.
7. students can execute and test their final results: ~ 500 simultenous clients.
Then, the solution is ready. Students should apply all the requested formats and deliver their solutions according given instructions.
