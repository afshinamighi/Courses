# Python 11: Structured Data Files

**Introduction**: This document presents learning activities for Python 11. In Python 10, you have learned how to manipulate plain text files, i.e. files containing unstructured contents. But, often in software projects we face data values with a specific structure, like csv file. In Python 11, you will get introduced with files that contains more structured data values. 

**Note**: In this phase, it is expected the learner can divide the program into smaller learning steps. The goal and direction of the topics will be provided. The student must take smaller steps towards the goals such that can implement solutions to the given problems and product(s).


## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **ORef-02**: Online Tutorial; Lucas Lofaro; "Working With JSON Data in Python"; [Available here](https://realpython.com/python-json/)
- **ORef-03**: Online Tutorial; Jon Fincher; "Reading and Writing CSV Files in Python"; [Available here](https://realpython.com/python-csv/)


## Path:

### Step: Tabular Text Files.

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs using structured data files: reading / writing content from / to CSV / JSON files, processing / modifying content of CSV / JSON files.
```
#### What ro learn?

1. Using **BRef-01: Chapter 16**, **ORef-02** and **ORef-03** answer and experiment the following questions:
   1. What is a csv file? How can one read the content of a csv file?
   2. What is a JSON file? How can one read the content of a JSON file?
   3. Given a csv file, how can we process the records? Experiment with an example where:
	   - a specific term is being searched
	   - the values of specific attributes for some records are extracted.
	   - the values of specific attributes for some records are modified.
   4. Given a JSON file, how can we process the objects? Experiment with an example where:
	   - the values of specific attributes for some objects are extracted.
	   - the values of specific attributes for some objects are modified.
   
#### Exercises:

1. Design at least ten different exercises of your own. They should improve understanding topics of this step. Share your exercises with your learning group and practice.


## Problems:

1. For the following problems we need the `movies.json` file which can be found in **./problems_data/movies.json** ([here](./problems_data/movies.json)). It contains information of some movies. 
	
	*Step 1*. Implement a program that using the data from `movies.json`, shows the following information:
		- The number of movies released in 2004.
		- The number of movies in which the genre is Science Fiction.
		- All movies with actor `Keanu Reeves`.
		- All movies with actor `Sylvester Stallone` released between `1995` and `2005`.
	
	*Step 2*. Using data from `movies.json`, make the following adjustments and write it back to the file:
		- Change the release year from the movie `Gladiator` from `2000` to `2001`.
		- Set the release year from the oldest movie to one year earlier.
		- Actor `Natalie Portman` changed her name to `Nat Portman`. Adjust this at all movies she is in.
		- Actor `Kevin Spacey` got cancelled. Remove his name from all movies he is in. 
	
	*Step 3*. Using data from `movies.json`, implement a program with the following functionalities: 
		- The program will Create a menu with the input options shown below. 

	[I] Show all information about the movies found in a user friendly format (based on step 1). If there are multiple movies by the same name, show these with the release year to user and let them pick which movie they meant.

	[M] Make modification (based on step 2).
	
	[S] Searching a title (should not be case sensitive).
	
	[C] Extend your program by allowing the user to change the title and/or release year of the selected movie (after searching it). Implement this in a user friendly way.
	
	[Q] Quit Program

2. For the following problems we need the `bannedvideogames.csv` file which can be found [here](./problems_data/bannedvideogames.csv) 
	1. Implement a program that shows the following information:
		- How many games got banned in Israel?
		- Which country got the most games banned?
		- How many games within the `Assasins Creed` series got banned? Don't count duplicates banned in different countries. 
		- Show all games (and the details) banned in `Germany`. 
		- Show all countries (and the details) the game `Red Dead Redemption` got banned in.

	2. Implement a program that makes the following adjustments and write it back to the file:
		- `Germany` got a new law that accepts all games as a form of art. Remove all records with `Germany` from the file.
		- The game `Silent Hill VI` got renamed to `Silent Hill Remastered`, rename this in all corresponding records. 
		- The ban on the game `Bully` in `Brazil` has been lifted. Change the `status` to `Ban Lifted`.
		- The game `Manhunt II` is by several countries. It is incorrectly listed as genre `Stealth`, change the genre to `Action` in all corresponding records.

	3. Implement a program that lets the user search the dataset by country. Show all details from banned video games in that country. 

	4. Create an application to add new a new record to the file. Ask the user to insert all needed information and write it to the file.


## Assignment:

**Car Parking: Extended with Structured Files** For this assignment you are going to expand your `CarParking` program to handle reading and writing of structured data files in JSON and CSV format. New functionalities need to be added to the existing program from week 10 which will be explained in depth below.

1. Retrieving and storing the car parking machine state with a JSON data file. In the previous assignment you created functionality to load the state (parked cars) of car parking machines from the log files. Now you will modify this functionality by using a JSON data file
to read/write the state of the car parking machines. Every car parking machine will save the state in its own JSON file! Provide a unique name or ID when instantiating a new car parking machine object. Use this name (or ID) to create a JSON file with this name (or ID), for example `parking-machine-north-001.json`.
If the JSON file already exists (for example this specific car parking machine
object has been created earlier) the exisitng file should be used and the previous state
should be read and loaded. The state should contain the parked cars from the car parking machine. See the following JSON format
to store parked cars in the file:
```json
[
    {
        "license_plate": "2-ABC-09",
        "check_in": "09-21-2022 16:20:04"
    },
    {
        "license_plate": "3-XYZ-10",
        "check_in": "09-21-2022 17:20:50"
    }
]
```
The following actions will result in data being read from or written to the JSON data file:
	- Check-in of a car (add car to json)
	- Check-out of a car (remove car from json)

2. Check-in validation: A car should only be able to check-in at a car parking machine if it does not have an open check-in (checked-in, but not checked-out yet) at another car parking machine within the same time frame. Modify the `CarParkingMachine` class `check_in` method to add this new functionality. To be able to check all currently parked cars in all car parking machines, you should keep track of created car parking machine instances and check their
car parking machine states. A possible solution would be to create a list in your main program and add the name (or ID) of created parking machine to that list. The `check-in` method of a car parking machine could use that list to know which JSON state files to check.

3. Creating data reports in CSV format: Create a program named `carparkingreports.py` with the following menu structure:

	`[P]` Report all parked cars during a parking period for a specific parking machine
	
	- Input: car parking machine identifier, from date, to date (date format: DD-MM-YYYY). Input is comma seperated.
	- Output: csv file example (semicolon seperated):

    ```csv
    license_plate;check-in;check-out;parking_fee
    2-ABC-09;09-21-2022 16:20:04;09-21-2022 17:20:30;5.00
    3-XYZ-10;09-21-2022 12:20:04;09-21-2022 18:45:11;18.00
    ```
	`[F]` Report total collected parking fee during a parking period for all parking machines.

	- Input: from date, to date (date format: DD-MM-YYYY). Input is comma seperated.
	- Output: csv file example (semicolon seperated):

	```csv
    car_parking_machine;total_parking_fee
    cpm_north;2,050
    cpm_south;180
    ```
    
	`[Q]` Quit program

*Note:* The information for the reports is based on the information in the log file.

## Extra Steps: 
