from carparking import *
from datetime import datetime, timedelta

'''
PyTest template file. Use asserts to test your class code.
Don't forget to put this file in the same location as your carparkingmachine.py

Hint: use the datetime module (datetime and timedelta objects) to test with a check-in time in the past.
Example: my_datetime = datetime.now() - timedelta(hours=2, minutes=10)
This statement creates a datetime object 2 hours and 10 minutes in the past.
'''

# Test check-in and car parking capacity.
def test_check_in_capacity():
    # check that multiple cars are checked-in and in the parked_cars dict
    # check that some cars are not checked-in when capacity has been reached

# Test correct calculation of parking fee.
def test_parking_fee():
    # check-in cars at multiple timestamps and check that the calculated fee is correct
    # check that the maximum fee is not exceeded when parking for more than 24 hours

# Test car parking check-out.
def test_check_out():
    # check that checked-out cars are removed from the parked_cars dict
    # check that a car checked-in and checked-out directly after has an 1 hour fee
