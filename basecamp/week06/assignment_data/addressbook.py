'''
This program provides a partial solution for the assignment of week06. 
The student is expected to understand the code and complete the solution based on the given specification.
'''

import os, sys, json

addressbook = []

'''
print all contacts in the following format:
======================================
Position: <position>
First name: <firstname>
Last name: <lastname>
Emails: <email_1>, <email_2>
Phone numbers: <number_1>, <number_2>
'''
def display(list = []):
    ...

'''
return list of contacts sorted by first_name or last_name [if blank then unsorted], direction [ASC (default)/DESC])
'''
def list_contacts(...):
    # todo: implement this function
    ...

    return addressbook

'''
add new contact:
- first_name
- last_name
- emails = {}
- phone_numbers = {}
'''
def add_contact(...):
    # todo: implement this function
    ...

'''
remove contact by ID (integer)
'''
def remove_contact(...):
    # todo: implement this function
    ...

'''
merge duplicates (automated)
'''
def merge_contacts():
    # todo: implement this function
    ...

'''
read_from_json
Do NOT change this function
'''
def read_from_json(filename):
    # read file
    with open(os.path.join(sys.path[0], filename)) as outfile:
        data = json.load(outfile)
        # iterate over each line in data and call the add function
        for contact in data:
            addressbook.append(contact)

'''
write_to_json
Do NOT change this function
'''
def write_to_json(filename):
    json_object = json.dumps(addressbook, indent = 4)

    with open(os.path.join(sys.path[0], filename), "w") as outfile:
        outfile.write(json_object)

'''
main function: build menu structure as following and call the appropriate functions:
- the input can be case-insensitive (so E and e are valid inputs)
- [E] Encode value to hashed value
- [D] Decode hashed value to normal value
- [P] Print all encoded/decoded values
- [Q] Quit program

Don't forget to put the contacts.json file in the same location as this file!
'''
def main(json_file):
    read_from_json(json_file)

    # todo: implement this function.
    ...

'''
calling main function: 
Do NOT change it.
'''
main('contacts.json')
