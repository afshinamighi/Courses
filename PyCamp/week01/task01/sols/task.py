
# Implement a function that adds two numbers together
# and returns their sum in binary, hex.
# The conversion can be done before, or after the addition.
#
# The binary or hex number returned should be a string.
#
# Examples:
#
# add_binary(5, 9) == "1110" (5 + 9 = 14 in decimal or 1110 in binary)
# add_hex(5, 9) == "1110" (5 + 9 = 14 in decimal or 1110 in binary)


def add_binary(a:int,b:int)->str:
    bresult = bin(a+b)
    sresult = str(bresult)
    return sresult

def add_hex(a:int,b:int)->str:
    sresult = 'result'
    return sresult
