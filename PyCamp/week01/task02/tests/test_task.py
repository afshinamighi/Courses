import unittest

from week01.task02 import task as target


# todo: replace this with an actual test
class TestCase(unittest.TestCase):
    def test_add(self):
        self.assertEqual(target.sum(1, 2), 3, msg="adds 1 + 2 to equal 3")
