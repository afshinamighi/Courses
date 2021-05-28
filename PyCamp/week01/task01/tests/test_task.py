import unittest

from week01.task01 import task as target

class TestCase(unittest.TestCase):
    def test_add_binary(self):
        tcs = [
            ((3,5), str(bin(3+5))),
            ((6,10), str(bin(6+10)))]
        for ((a,b) , tcr) in tcs:
            self.assertEqual(target.add_binary(a,b), tcr,msg=str((a,b))+' Expected '+str(tcr))
    def test_add_hex(self):
        tcs = [
            ((3,5), str(hex(3+5))),
            ((6,10), str(hex(6+10)))]
        for ((a,b) , tcr) in tcs:
            self.assertEqual(target.add_hex(a,b), tcr,msg=str((a,b))+' Expected '+str(tcr))
