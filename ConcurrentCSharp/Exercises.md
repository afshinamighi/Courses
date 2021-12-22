# Concurrency in C#: Practicum

This document class activities and exercises are described to be practised in practicums of Concurrency course of Hogeschool Rotterdam.
### Practical notes:
1. The exercises of each week corresponds to some of the source codes available here in Github: https://github.com/afshinamighi/Courses
2. Corresponding C# projects are represented with bold font at each exercise.
3. In each exercise, students are expected to evaluate specified source codes, understand the structures, analyze expected behaviours of the programs (guess and justify the output), and in some cases reproduce the concept in a different context.
4. In some of the exercises, students are asked to share / discuss / explain results of their evaluations. The teacher will determine how results will be shared with other students and/or the teacher.
5. This document will be updated weekly. 



# Week 1: 
Main objectives of this week is to introduce the main concepts and prepare practical tools needed for upcoming weeks.

## Preparation:
1.	 We will discuss about threads in week 3. Here, just think about a thread as a separate paths of execution that can be executed simultaneously with the main program.
2.	 Refresh your C# programming environment: You are expected to be able to write simple console based programs. A set of possible concepts to be used later are: fundamentals (types, conditional statements, loops), defining attributes, methods, public / private / static, arrays, anonymous functions.
3.	 Implement a simple program: like a counter class that counts until a given number and the main program instantiates an object from this class and prints the final result. The counter class has a state that keeps the latest counting value.


## Exercises:
_note: just for today ignore the **#todo** inside the code that ask you to write code, we will focus on the understanding and not on producing code._
1. [~ 5 min ] Concurrency in your machine:
   1. Make a list of parallel/concurrent programs in your computer. Choose a running program (for example PyCharm) and see how many threads are running by the application. You can check threads' count in your *task manager/activity monitor* (on Windows *task manager click* on the columns name to select columns and add threads if it is not already visible). You can also use in the Linux/MAC shell the command **"top"** (#TH --> total threads/running threads).
   2. Open an internet browser with several tabs (*Chrome*) of the same domain website. Check how many threads are created per process (the threads are not directly named but they are listed as parts of the single process: they all have the same Process ID, but contains multiple lines). Make a list (at least five) of *functionalities* (tasks) that each thread of execution is responsible to execute.
   3. Share your list with the teacher.
2. [~ 30 min ] **MergeSort**: One of the challenges in designing a concurrent program is to recognise potential concurrent tasks.
    In Week 1, ignore the class named **ConcurrentMergeSort** and its todos.
    1. Among various sort algorithms one of the well-known ones is named **merge sort** algorithm. Read and understand how this algorithm works. You can use the following resources: [check here](https://www.hackerearth.com/practice/algorithms/sorting/merge-sort/visualize/) , or [here, just don't forget to choose right settings](https://visualgo.net/bn/sorting?slide=1).
    2. **Note**: In week three you will be asked to implement a concurrent version of this algorithm. Therefore, this exercise is crucial to understand and share your ideas. 
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
2. [~ 20 min ] **[Solution Available]** **ProcessCreation**: Implement a program, that executes a command, like **ls**/**dir**. Modify your program such that executes the **Processes** (previous exercise compiled version of the dll/exe, and check the references).

3. [~ 30 min ] **[Solution Available]** **IPCNamedClient, IPCNamedServer**: Two projects are implemented to present how two programs can communicate using named pipes.
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

1. [~ 5 min] In Week 1, it is discussed how a statement like **C=A+B** is translated to assembly instructions. Answer the following questions and share them with your teacher.
   1. Check the slides and write down the sequence of assembly code for **C=A+B**
   2. Assume two threads running concurrently. Thread 1 is executing **X=A+B** and thread 2 is executing **Y=C+D**. 
      1. Write down three **possible** interleavings (assembly instructions). 
      2. Write down three **impossible** interleavings.
2. [~ 30 min] **Threads**: A simple example about threads: creating, starting and joining threads.
   
   1. This example presents how to collect information about threads of a process.
   
      1. Follow todo #1 from class Examples. Run the code. 
      2. How information of threads are extracted? Which process is the owner of these threads? Check the code implemented in class ThreadsList.
   
   2. This example presents how to create and start multiple threads. Answer the questions below and justify your answers using the code.
   
      1. Follow todo #2 from class Examples. Run the code. In order to see the behaviour of the program you have to check todo #2.1 provided in method ThreadCreation::runExample().
      2. How can a main program create and start multiple threads? 
      3. How to define a task of a thread?
      4. How can a main program join to multiple threads?  
   
   3. This example presents a different scenario of defining tasks for the threads. 
   
      1. Follow todo #3 from class Examples. Run the code. Justify the behaviour of the program.
   
      2. Check details of the implementation in class ThreadsJoin. How is the task given to the threads? Compare it with class ThreadCreation. 
   
      3. What would be the behaviour of the program if we had the following scenario for joining (try and justify your answer):
         **t_A.Start();**
         **t_A.Join();**
         **t_B.Start();**
         **t_B.Join();**
   
3. [~ 30 min] **[Solution Available]** **PrimeNumbers**: A sample sequential code for finding prime numbers is given. Your task is to write a method that implements the concurrent version of this algorithm.
   
   1. Understand how the sequential version works. Run the code and check how much time does it take to finish the task. 
   2. Recognise which task can be divided between two (or more) threads.
   3. *Implementation*: Follow todo provided in the code to implement the exercise. For simplicity, implement **only for two threads**. 
   4. Check to see how the time for sequential version is implemented. Apply it to your concurrent solution. Run both sequential and concurrent versions. Is you concurrent version more efficient? 
4. [~ 30 min] **[Solution Available]** **[@home]**  **MergeSort**: A sample implementation of merge sort is given. It is implemented sequentially. Your task is to implement a multi-threaded MergeSort. *Note*: In order to practice with the concepts of merge sort, first, understand how the sequential version works. Check the exercises of Week 1. You can use online resources to observe its execution visually. 
   
   1. Recognise which task can be assigned to threads to be executed independently. For simplicity, assume only two threads.
   2. *Implementation*: Follow todos provided in the code to implement the exercise.



# Week 4:

The main objectives are to protect shared resources and to practice basic concepts of synchronisations. In this week we will practice:

- How to recognise critical section and possible data race.
- How to employ locks to avoid data race.

## Preparation:

1. In order to practice this set of exercises, you need to be confident with creating several threads, passing tasks to the threads, starting and joining threads. If you are not confident yet, first practice with exercises **Week 3: Exercises 2 and 3**.
2. Use the reference provided below to answer the following questions:
   Reference: [Synchronization Objects](http://www.albahari.com/threading/part2.aspx) 
   1. What are the most commonly used blocking methods in threads?
   2. What is the difference between spinning (busy waiting) and blocking? Which one is not efficient?
   3. What is a lock? Why do we need a lock?
3. If you do not have experience with linked lists, read this tutorial to gain knowledge about linked list in C#:
   Tutorial: [Linked Lists in C#](https://www.dotnetperls.com/linkedlist) 



## Exercises:

1. [~ 20 min ] **Synchronization**: This program is a simple example of **data race**. Follow the comments and todos provided in the main method and run the examples. For each example, read the related code in detail and analyze the behaviour.
   1. Where is the shared memory here? 
   2. How do threads access the shared memory? 
   3. Do you recognise a *critical section* in the code? Where is it protected? 
   4. Do you recognise a *data race* here? 
   5. Which mechanism is used to protect the shared memory?
2. [~ 15 min ] **[@home]** **MergeSort**: Use the code and justify your answers for the following questions. 
   
   1. Do you recognise a shared memory? 
   2. Do you need to protect the shared memory?
3. [~ 40 min ] **ProducerConsumer**: This program is a simple simulation of (sequential) producer-consumer problem. There are a number of generated data produced by the *producer*, inserted in a shared buffer (a list), and consumed by a *consumer*.
   
   1. Follow the todos in the program and run the sequential version of **ProducerConsumer**. Check the order of data producing and consuming (check the ordering of the printed value).
   2. Read the program carefully: 
      1. How are the producer and consumer generating / consuming data?
      2. How is the the communication achived?
      3. How are the producer-consumer accessing the shared buffer?
      4. Do we need to protect this shared buffer in the sequential version? 
   3. Follow todos and run the **concurrentOneProducerOneConsumer** method. Your task will be to update the program to be thread safe. 
      1. Re-run the program several times. How do you interpret the behaviour? 
      2. Read the related code carefully and explain which tasks are concurrent.
      3. Do you recognise a shared memory? Justify your answer.
      4. Is the shared memory protected?
      5. Make the program **thread safe** (protect your memory!).
   4. *(Optional)*: As you can recognise, usually, the shared buffer is left with some unused data items. Fix the program in a way that the consumer can use all the data available.
   
      Hint: First, instead of a fixed number of iterations, trigger producer and consumer in every *t* milliseconds. *t* can be a random number within an interval. Then, the consumer should consume all the items whenever it has a chance to execute.
4. [~ 30 min]**[@home]** **ProducerConsumer** :
   
   1. Implement a method that simulates multiple producers, one consumer.
   
   2. Implement a method that simulates multiple producers and multiple consumers.
   
      
   

<!-- DataProcessor** (Optional): In a project, there are several sensors generating and sending data to a server. The server is responsible to collect all the data and visualize them. **Implementation**: Implement a program that provides the core for the above application. Data can be simply temperature of various locations that is measured every 10 milliseconds and being sent to the server together with the location data values. *Hint*: The purpose of this exercise is not to implement a client server program. Focus on the model of data gathering and synchronisation with the visualizer. Visualization can simply be printing the data values in the output console. -->



# Week 5:

The main objectives are to practice synchronisations of threads using Semaphores and to understand deadlocks. In this week we will practice:

- How to employ semaphores to protect shared resources.
- How to recognise deadlocks.

## Preparation:

1. In order to practice this set of exercises, you need to be confident with creating several threads, passing tasks to the threads, starting and joining threads. If you are not confident yet, first practice with exercises **Week 3: Exercises 2 and 3, Week 4: Exercises 1 and 3**.
2. Use the reference provided below to answer the following questions:
   Reference: [Synchronization Objects](http://www.albahari.com/threading/part2.aspx) 
   1. What is a deadlock?
   2. What is a semaphore?
   3. What is a mutex?
3. Watch this video: [Dining Philosophers](https://www.youtube.com/watch?v=NbwbQQB7xNQ)

## Exercises:

1. [~ 40 min] **Semaphores**: This exercise is implementing Producer-Consumers signalling each other using Semaphores.
   1. From #todo 1: analyse *sequential*OneProducerOneConsumer() before moving to the concurrent one.
   2. Answer #todo 2. 
   3. From #todo 3: analyze the output of *concurrent*OneProducerOneConsumer().
   	Do producer and consumer threads work correctly? Justify your answer. 
   4. From #todo 4: fix the problem of producer and consumer.
   5. From #todo 5: check the code implemented in ProducerConsumerSimulator::concurrentMultiProducerMultiConsumer(). Run the method and analyze the output.
2. [~ 40 min] **DiningPhilosophers**: This is a simple implementation of dining philosopher problem. *Philosopher* implements two versions of eating: every philosopher needs only one (right) fork to eat the food; and, each philosopher needs two (left and right) forks. 
   1. Run the code implemented for both kind of eating. Check how resources are locked. Check how a parameterized method is passed to the threads.
   2. Discuss the problem of two forks eating.
   3. Follow the todo and fix the problem of two forks eating. 
   4. Run the code with your solution. Does a deadlock occur? 
   5. Discuss what would be a solution for the deadlock. 
3. **[@home]** In order to synchronize threads, different synchronization constructs are implemented. So far, you have practiced to provide mutual exclusion using **lock(obj){ ... }** statement. However, C# provides a synchronization primitive named **Mutex**. 
   1. Read the specification of class **Mutex** and check how a critical section can be protected with an instance of **Mutex**:
      Reference: read [Class Mutex](https://docs.microsoft.com/en-us/dotnet/api/system.threading.mutex?view=net-5.0) 
   2. As we have discussed in the lesson, a binary semaphore (a semaphore initialized with one) can also be employed to implement mutual exclusion. Again, C# has already implemented a synchronization primitive named Semaphore (see [here](https://docs.microsoft.com/en-us/dotnet/api/system.threading.semaphore?view=netcore-3.1)). 
      1. What are the main differences between class **Mutex** and class **Semaphore**? Can one replace the other?
      2. Is it possible to implement **Week 5: Exercise 1** using a **Mutex**? Justify your answer.



# Week 6:

The main objective is to learn the basics of asynchronous programming in C#. In this week we will practice:

- How to employ tasks to implement an asynchronous operation.

## Preparation:

Practising basics of asynchronous programming in C#, the following online resource can be conslted:

- async and await in C#: Read the basics more [here](https://www.dotnetperls.com/async)
- Asynchronous Programming with an example: How to prepare breakfast asynchronously? [click here](https://docs.microsoft.com/en-us/dotnet/csharp/async)
- For more in-depth about Task Parallelism  [click here](http://www.albahari.com/threading/part5.aspx#_Task_Parallelism)

## Exercises:

1. [~ 30 min] **Asynchronous**: In namespace **TaskExamples** have a look at the "*check*" comments to understand various ways of defining and using *Task*s and the use of *async methods*. From the *main* method, uncomment the coresponding statement and run the example. Compare and discuss the measured times.  
2. [~ 20 min] **PrimeNumbers**: Check the provided solution.
3. [~ 20 min] **ProcessCreation**: Check the provided solution.
4. [~ 20 min] **MergeSort**: Check the provided solution.
5. **[@home]**  **ICPNamedClient** , **ICPNamedServer**: Check the provided solution.



# Week 7:

This week is the review week. In this week some of the provided solutions will be reviewed.

## Preparation:

Make your solutions ready.

## Exercises:

1. [~ 20 min] **DiningPhilosophers**: Check the provided solution.
   1. In the solution a method (named *startEatingWithTwoForksSafe*) is added to prevent a deadlock. In this method, shared resources are protected using class *Mutex*. Check how instances of this class is used. First, try the code without timeout. You should see the deadlock. Then, pass timeout as a parameter to the methods *WaitOne*. Do you expect a deadlock? Justify your answer.
2. [~ 30 min] **Semaphores**: We have learned how producers consumers can be synchronized with semaphores. 
   1. Check the provided solution.
   2. Wtach this video to see how semaphores can be initialized to exploit full capacity of a shared buffer.
      Video: https://www.youtube.com/watch?v=LRiN3DJdskA
   3. Check the initialized values of *psem* and *csem* . 
      1. What is the size of the buffer? 
      2. Are initializations of the semaphores help to exploit full capacity of the buffer?
      3. Propose your solution.
      4. *(Optional)* Modify the code in a way that implements your solution.



## Assignment: Practical steps
Description of the assignment and deliveries will be published by the teacher. Here we try to provide some steps that practically can lead students to implement a solution for the assignment. **Note**: These steps will be updated regularly during the course period.

During the course after Week ...
1. [in progress]
