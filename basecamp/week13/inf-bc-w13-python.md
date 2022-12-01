# Python 13: Databases.

**Introduction**: This document presents learning activities for Python 13. In Python 13, you will basics of implementing Python programs that can interact with databases.

**Note**: In this phase, it is expected the learner can plan and run required learning process towards the goals of the week: making solutions to the given problems and product(s).

## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- Free research.

## Path:

### Step: Databases.

#### Goals:

```
After taking this step, you will be able to:
	1. understand the concept of databases.
	2. understand and implement Python programs making basic queries in SQLite: CREATE, INSERT , SELECT x,y,z FROM t WHERE c.
```
#### What to learn?

1. Using **BRef-01, Chapter 16: Relational Databases** make a plan for the week to learn basics of Python programs interacting with relational databases.
	- Make an overview of the provided problems and final product.
	- Plan what you need to learn in order to provide your solutions.
	- Read proposed book chapter and practice basic steps.

<hr>


## Problems:


Implement Python programs to solve the following problem statements:

1. In this problem you are going to create an application to organise students and their info by class. You can use the the provided code (see template) to connect with the database and create it if it does not exists. Create a menu with the following options:

```
[A] Add new student
    > should ask for: first_name, last_name, city, date_of_birth (DD-MM-YYYY), class (optional)
    > should return the assigned studentnumber (auto-created)
[C] Assign student to class
    > should ask for: studentnumber (primary_key), class
    > should give error if student was not found: Could not find student with number: {studentnumber}
[D] List all students
    > result should be sorted based on class in descending order
[L] List all students in class
    > should ask for class to search students in
    > result should be sorted based on studentnumber in ascending order
[S] Search student
    > should ask for searchterm and search in first_name, last_name or city
    > limit result to 1
[Q] Quit
```
Extend your code so all functionality from the menu above is working correctly.

2. In this problem you are going to create a application to borrow and return books from a store/library. An existing dataset in JSON will be provided. The program, at the start will check the content of JSON and compare it with the related table in the database. First missing elements must be inserted, file always has latest update. After synchronising the file with db, the program will have an interactive communication with the user:

```
[B] Borrow book
    > should ask for id or isbn and duration in days
    > should check if book is not borrowed at the moment
      * statusses can be: AVAILABLE or BORROWED
    > should return the date until this book can be borrowed
      * calculate return_date based on (current_date + duration in days to borrow)
[R] Return book
    > should ask for id or isbn
    > should return fine to pay if book is returned later then return date 
      * 0.50 EUR per day that book is returned later then return date 
      * example: you borrow a book @ 29-11-2022 for 14 days, return_date should be 13-12-2022 
        if you return it later (say 14-12-2022 you should have to pay 1 day * 0.50 EUR)
[S] Search book
    > should ask for searchterm
    > should search in title, isbn or author
    > should return book information + status_information
      * statusses can be: AVAILABLE or BORROWED
[Q] Quit
```
The status of the books are in the database but the list of the books will be provided by JSON file.

## Assignment:

For this assignment you are going to refactor/change the exisitng car parking program code from weeks 9, 10 and 11. 
Instead of reading/writing a log file and storing the car parking machine state in a JSON file, you will use a database to replace this functionality completely. 
The database will contain information about checked-in and checked-out cars for all parking machines.
The database system used for this assigment will be an SQLITE (version 3.x) database. 
Before starting, check if sqlite3 has already been installed on your system. 
If not, information on how to install sqlite3 can be found on the SQLITE website: https://www.sqlite.org/. 
The `import sqlite3` line will load the installed python sqlite3 module for use in your program.
To keep track of this information you are given a database structure with a single table. This table has the following colums: 
`id, car_parking_machine , license_plate, check_in, check_out, parking_fee`

You can use the following code in your `__init__` of `CarParkingMachine` class to connect with the database and create it if not exists:

```python

self.db_conn = sqlite3.connect(os.path.join(sys.path[0], 'carparkingmachine.db'))
self.db_conn.execute(
    """CREATE TABLE IF NOT EXISTS parkings (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        car_parking_machine TEXT NOT NULL,
        license_plate TEXT NOT NULL,
        check_in TEXT NOT NULL,
        check_out TEXT DEFAULT NULL,
        parking_fee NUMERIC DEFAULT 0 
    );"""
)
```

Every row inserted in this PARKINGS table will represent a checked-in car at a specific car parking machine. 
When a car checks-out, the existing row has to be updated with the check-out date and the calculated parking fee. 
This way the PARKING table will function as a log history of all parked cars. 
It will also provide insight if a specific license plate is already checked-in at a specific car parking machine (to prevent duplicate check-ins).
The id (also called a primary key) of a row in the PARKINGS table will be automatically generated by the database using the built-in AUTOINCREMENT functionality (https://www.sqlite.org/autoinc.html). 
So no id needs to be provided while inserting a row into the PARKINGS table.

Add the following functionality to your existing car parking machine:
* ADD new method: `def find_by_id(self, id) -> ParkedCar:`
<br>This method will search for a parked_car in the database based on the row ID an return a ParkedCar object with the data
* ADD new method: `def find_last_checkin(self, license_plate) -> int:`
<br>This method will search for the last row for a given `license_plate` that has NOT checked-out yet (return row ID if found)
* ADD new method: `def insert(self, parked_car: ParkedCar) -> ParkedCar:`
<br>This method will insert details of a created ParkedCar object and put the new row ID (from database) on the object, return the object with this new row ID
* ADD new method: `def update(self, parked_car: ParkedCar) -> None:`
<br>This method will update details of a ParkedCar object inside the database (update based on ParkedCar.id <- Datbase Row ID)
The following funtionality in your existing car parking machine program will be changed:
* Removed the usage of a log file when checking-in and checking-out cars.
* Adjust ParkedCar class so it can store: `id: int, license_plate: str, check_in: datetime, check_out: datetime, parking_fee: float` 
* car parking init: restore the state of parked cars for a car parking machine by retrieving rows from the PARKINGS table  
* car parking check-in: insert a row into the PARKINGS to table instead of writing to the JSON state file.
* car parking check-out: update the row in the database with check_out time and parking_fee information.
* Adjust the carparkingreporter in such a way that it uses the database for the reports
* Add the following item to carparkingreport: [C] Report all complete parkings over all parking machines for a specific car
<br>input: license_plate
<br<output: csv file example (semicolon seperated):
<br>car_parking_machine;check_in;check_out;parking_fee 
<br>cpm_north;09-21-2022 16:20:04;09-21-2022 17:20:30;5.00
<br>cpm_south;09-22-2022 14:11:03;09-23-2022 19:00:10;15.00

## Extra Steps:
