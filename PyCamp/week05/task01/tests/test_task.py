import unittest

from week05.task01 import task as target

# todo: replace this with an actual test
class TestCase(unittest.TestCase):
    def test_cw_validate_walk_path(self):
        fun = target.cw_validate_walk_path
        tcs = [
            ('snnnswwwseee', True),
            ('snnnswwwssee', False),
            ('ssssnnnnsn', True),
            ('wwwwwweeeeeew', False)
            ]
        for (tc , tcr) in tcs:
            result = fun(len(tc), tc)
            expected = tcr
            msg = 'in '+fun.__name__+' input '+tc+' expected '+str(tcr)
            self.assertEqual(result,expected ,msg)
