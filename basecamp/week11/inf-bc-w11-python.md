# Python 11: Structured Data Files

**Introduction**: This document presents learning activities for Python 11. In Python 11, you will get introduced with files that contains more structured data values. 

**Note**: In this phase, it is expected the learner can divide the program into smaller learning steps. The goal and direction of the topics will be provided. The learning must take smaller steps towards the goals such that can implement solutions to the given problems and product(s).


## Materials:

The activities are designed based on these following references:

- **BRef-01**: Book, Bill Lubanovic; "Introducing Python: Modern Computing in Simple Packages"; [Available here](https://www.oreilly.com/library/view/introducing-python-2nd/9781492051374/) 
- **ORef-01**: Online Tutorial; Charles Severance; "Python for Everybody"; [Available here](https://books.trinket.io/pfe/index.html)


## Path:

### Step: Tabular Text Files.

#### Goals:

```
After taking this step, you will be able to:
	1. interpret and implement Python programs using plain data files: reading / writing content from / to CSV / JSON files, processing / modifying content of CSV / JSON files.
```
#### What ro learn?

1. Using **BRef-01: Chapter 16** answer and experiment the following questions:
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

1. Design at least ten different exercises of your own. They should improve understanding topics of this step. Share your exercises with your learning community and practice.


## Problems:

1. For the following problems we need the `movies.json` file which can be found [here](./problems_data/movies.json). It contains information of some movies. 
	1. Implement a program that using the data from `movies.json`, shows the following information:
		- The number of movies released in 2004.
		- The number of movies in which the genre is Science Fiction.
		- All movies with actor `Keanu Reeves`.
		- All movies with actor `Sylvester Stallone` released between `1995` and `2005`.
	2. Using data from `movies.json`, make the following adjustments and write it back to the file:
		- Change the release year from the movie `Gladiator` from `2000` to `2001`.
		- Set the release year from the oldest movie to one year earlier.
		- Actor `Natalie Portman` changed her name to `Nat Portman`. Adjust this at all movies she is in.
		- Actor `Kevin Spacey` got cancelled. Remove his name from all movies he is in. 
	3. Using data from `movies.json`, implement a program that allows the user to search a movie based on the `title`. Show all information about the movies found in a user friendly format. If there are multiple movies by the same name, show these with the release year to user and let them pick which movie they meant. Searching a `title` should not be case sensitive. 
		- Extend your program by allowing the user to change the title and/or release year of the selected movie (after searching it). Implement this in a user friendly way.


2. For the following problesm we need the `bannedvideogames.csv` file which can be found [here](./problems_data/bannedvideogames.csv) 
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
[todo]

## Extra Steps: 
[todo]
