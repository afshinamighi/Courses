'''
DESCRIPTION FOR GTIHUB:

Create a progam that can convert a name/string to the hashed representation of that value

The program that needs to be programmed for this assignment is described below.

create a function that given the input string converts it to the encoded/decoded equivalent based on the provided or already set key/hashmap
make sure to only convert values that are in the key/hashmap, if the value is not present, use its own value
- encode_string(data: str, key: str = None) -> str:
- decode_string(data: str, key: str = None) -> str:

create a function that given a list of inputs converts the complete list to the encoded/decoded equivalent based on the key/hashmap
you can use the already created encode/decode function when looping through the list
tip! make use of the map function within python with a lambda to call the internal function with all elements [element, key]
as a return value, you should return a list with the converted values
- encode_list(data: list, key: str = None) -> list:
- decode_list(data: list, key: str = None) -> list:

create a function that given a encoded value, decoded value and a key/hashmap (optional) checks if the values are correct
the return value should be a boolean value (True if values match, False if they don't match)
- validate_values(encoded: str, decoded: str, key: str = None) -> bool:

create a function that given a key, converts to a key_hashmap (Dict) to be used for converting
* each oneven character is the Key of the Dict, each even character is the coresponding Value
* you should validate if the given input is an even input, otherwise show the error: Invalid hashvalue input
* example: a@b.c>d#eA will become: {'a': '@', 'b': '.', 'c': '>', 'd', '#', 'e': 'A'}
- set_hashmap(conversion_string: str) -> None:

Main program [main():]
- Ask for key to use for convertion (make sure to validate against even string length)
- Build menu structure as following (the input can be case-insensitive (so E and e are valid inputs))
[E] Encode value to hashed value
[D] Decode hashed value to normal value
[P] Print all encoded/decoded values
[V] Validate 2 values against eachother
[Q] Quit program

* For ease of use, you can use the following string as a default key to use within your program:
a_b?c9d6e1f4g!h:i<j|k{l0m@n7o+p~q2r+s/t=u^v3w]x(y-z>A*B8C;D%E#F}G5H)I[J$

To test your functions, use the provided unit test file (for boilerplate) and complete the test functions with your own code.
'''

hashmap_key_value = {}
encoded_values = set()
decoded_values = set()

# create a function that given the input string converts it to the encoded equivalent based on the provided or already set key/hashmap
# make sure to only convert values that are in the key/hashmap, if the value is not present, use its own value
def encode_string(data: str, key: str = None) -> str:

# create a function that given the input string converts it to the decoded equivalent based on the provided or already set key/hashmap
# make sure to only decode values that are in the key/hashmap, if the value is not present, use its own value
def decode_string(data: str, key: str = None) -> str:

# create a function that given a list of inputs converts the complete list to the encoded equivalent based on the key/hashmap
# you can use the already created encode function when looping through the list
# tip! make use of the map function within python with a lambda to call the internal function with all elements
# as a return value, you should return a list with Tuples containing the decoded value as first value and the encode value as second value
def encode_list(data: list, key: str = None) -> list:

# create a function that given a list of inputs converts the complete list to the encoded equivalent based on the key/hashmap
# you can use the already created decode function when looping through the list
# tip! make use of the map function within python with a lambda to call the internal function with all elements
# as a return value, you should return a list with Tuples containing the decoded value as first value and the encode value as second value
def decode_list(data: list, key: str = None) -> list:

# create a function that given a encoded value, decoded value and a key/hashmap (optional) checks if the values are correct
# the return value should be a boolean value (True if values match, False if they don't match)
def validate_values(encoded: str, decoded: str, key: str = None) -> bool:

# give the option to input a hashvalue to be used/converted to a key/hashmap
# each oneven character is the Key of the Dict, each even character is the coresponding Value
# you should validate if the given input is an even input, otherwise show the error: Invalid hashvalue input
# example: a@b.c>d#eA will become: {'a': '@', 'b': '.', 'c': '>', 'd', '#', 'e': 'A'}
def set_hashmap(key: str) -> None:

# build menu structure as following
# the input can be case-insensitive (so E and e are valid inputs)
# [E] Encode value to hashed value
# [D] Decode hashed value to normal value
# [P] Print all encoded/decoded values
# [V] Validate 2 values against eachother
# [Q] Quit program
def main():

# Create a unittest for both the encode and decode function (see test_namehasher.py file for boilerplate)
if __name__ == "__main__":
    main()