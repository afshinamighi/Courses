import os, sys

valid_lines = []
corrupt_lines = []

'''
The validate_data function will check the students.csv line by line for corrupt data.

- Valid lines should be added to the valid_lines list.
- Invalid lines should be added to the corrupt_lines list.

Example input: 0896801,Kari,Wilmore,1970-06-18,INF
This data is valid and the line should be added to the valid_lines list unchanged.

Example input: 0773226,Junette,Gur_ry,1995-12-05,
This data is invalid and the line should be added to the corrupt_lines list in the following format:

0773226,Junette,Gur_ry,1995-12-05, => INVALID DATA: ['0773226', 'Gur_ry', '']

In the above example the studentnumber does not start with '08' or '09', 
the last name contains a special character and the student program is empty.

Don't forget to put the students.csv file in the same location as this file!
'''
def validate_data(line):
    # TYPE YOUR SOLUTION CODE HERE
    ...

def main(csv_file):
    with open(os.path.join(sys.path[0], csv_file), newline='') as csv_file:
        valid_lines, corrupt_lines = [], []

        # skip header line
        next(csv_file)

        for line in csv_file:
            validate_data(line.strip())

    print('### VALID LINES ###')
    print("\n".join(valid_lines))
    print('### CORRUPT LINES ###')
    print("\n".join(corrupt_lines))

if __name__ == "__main__":    
    main('students.csv')