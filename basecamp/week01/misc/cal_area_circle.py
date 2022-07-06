## SECTION 1 - ASSIGNING VALUES TO VARIABLES
pi = 3.14159
radius = 2.2
# area of circle equation <- this is a comment
area = pi*(radius**2)
print(area)

# change values of radius <- another comment
# use comments to help others understand what you are doing in code
radius = radius + 1
print(area)     # area doesn't change
area = pi*(radius**2)
print(area)

## SECTION 2 - COMMENTING LINES
# In Spyder: to comment MANY lines at a time,
# highlight all of them then CTRL+1
# do CTRL+1 again to uncomment them
#
# In Pyzo: higlight all of them then,
# from Edit --> choose Comment / Uncomment (or use shortcut)
#
# try it on the next few lines below!

#pi = 3.14159
#area = pi*(radius**2)
#print(area)
#radius = radius + 1
#area = pi*(radius**2)
#print(area)

## SECTION 3 - AUTOCOMPLETE
# Spyder / Pyzo can autocomplete names for you
# start typing a variable name defined in your program and hit tab
# before you finish typing -- try it below

# define a variable
a_very_long_variable_name_dont_name_them_this_long_pls = 0

# below, start typing a_ve then hit tab... cool, right!
# use autocomplete to change the value of that variable to 1


# use autocomplete to write a line that prints the value of that long variable
# notice that Spyder/Pyzo also automatically adds the closed parentheses for you
