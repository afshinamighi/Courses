import numpy as np
import sympy as sym

class Bits:
    '''Represents one or multiple rows of sequence of bits as string '''
    def __init__(self,seq:str) -> None:
        assert(isinstance(seq,str))
        assert(all([(c.isdigit() or c in [',',' ','-']) for c in seq]))
        self.bits_value = seq
    def vectorize(self):
        segments = self.bits_value.split(',')
        #assert(all(len(s)==len(segments[0]) for s in segments))
        digit_arrays = [np.array([int(c) for c in segment.split(' ')], dtype=int) for segment in segments]
        # Stack the digit arrays vertically
        arr = np.vstack(digit_arrays)
        return arr

class VBit: 
    '''Vector representation of one bit'''
    def __init__(self) -> None:
        self.vec_value = np.array([[None],[None]])
    def get_vector(self) ->np.ndarray:
        return self.vec_value
    def __str__(self) -> str:
        return np.array2string(self.vec_value)


class VCBit(VBit):
    '''Vector representation of one classical bit (0 or 1)'''
    def __init__(self,value:object):
        super().__init__()
        if isinstance(value,np.ndarray):
            self.vec_value = value
            self.num_value = 0 if value[0]==1 and value[1]==0 else 1 if value[0]==0 and value[1]==1 else None
        elif isinstance(value,bool):
            self.vec_value = Bits('0,1').vectorize() if value else Bits('1,0').vectorize()
            self.num_value = int(value)
        else:
            raise Exception('Invalid type for VCBit initialization.')
    def dirac(self,nbits=0):
        return '|'+str(bin(self.num_value)).removeprefix('0b').zfill(nbits)+'>'
    def __str__(self) -> str:
        return self.dirac() if self.num_value is type(int) else super().__str__()

class VCBitZero(VCBit):
    '''Vector representation of one classical bit 0'''
    def __init__(self) -> None:
        super().__init__(False)

class VCBitOne(VCBit):
    '''Vector representation of one classical bit 1'''
    def __init__(self) -> None:
        super().__init__(True)

class VCBitException(Exception):
    pass

class InvalidVectorValue(VCBitException):
    pass

class VCBitUnaryOp:
    def __init__(self,operation_vector:np.ndarray) -> None:
        assert(operation_vector.shape == (2,2))
        self.op_vector = operation_vector
    def apply(self,operand:'VCBit'):
        return VCBit(np.dot(self.op_vector,operand.get_vector()))

class VCBitNot(VCBitUnaryOp):
    '''Not (Flip) operation'''
    def __init__(self) -> None:
        super().__init__(Bits('0 1,1 0').vectorize())

class VCBitIdentity(VCBitUnaryOp):
    '''Identity operation'''
    def __init__(self) -> None:
        super().__init__(Bits('1 0,0 1').vectorize())

class VCBits(VCBit):
    def __init__(self,*vcbits:VCBit) -> None:
        assert len(vcbits) > 1 # minimum two bits
        for b in vcbits:
            assert(isinstance(b,VCBitOne) or isinstance(b,VCBitZero))
        result = vcbits[0].get_vector()
        for b in vcbits[1:]:
            result = np.tensordot(result , b.get_vector() , axes = 0)
        self.vec_value = result.reshape(2**len(vcbits),1)
        is_valid = np.count_nonzero(self.vec_value) == 1 and np.sum(self.vec_value) == 1
        self.num_value = np.nonzero(self.vec_value)[0][0] if is_valid else None
        self.num_bits = len(vcbits)
    def __str__(self) -> str:
        return self.dirac(self.num_bits)

class VCTwoBits(VCBits):
    def __init__(self, *value) -> None:
        if len(value)==1 and isinstance(value[0],np.ndarray):
            is_valid = np.count_nonzero(value[0]) == 1 and np.sum(value[0]) == 1
            self.vec_value = value[0]
            (self.num_value , self.num_bits) = (np.nonzero(value[0])[0][0] , 2) if is_valid else (None , None)         
        elif len(value)==2 and isinstance(value[0],VCBit) and isinstance(value[1],VCBit):
            super().__init__(*value)
        else:
            raise Exception('Invalid type for VCBit initialization.')

class VCTwoBitsOp:
    def __init__(self,operation_vector:np.ndarray) -> None:
        assert(operation_vector.shape == (4,4))
        self.op_vector = operation_vector
    def apply(self,operand:VCTwoBits):
        dot_resul = np.dot(self.op_vector,operand.get_vector())
        result = VCTwoBits(dot_resul)
        return result

class VCSwap(VCTwoBitsOp):
    '''Swap (Exchange) operation'''
    def __init__(self) -> None:
        operation_vector = Bits('1 0 0 0,0 0 1 0,0 1 0 0,0 0 0 1').vectorize()
        super().__init__(operation_vector)

class VCLCNot(VCTwoBitsOp):
    '''left Control Not Operation'''
    def __init__(self) -> None:
        operation_vector = Bits('1 0 0 0,0 1 0 0,0 0 0 1,0 0 1 0').vectorize()
        super().__init__(operation_vector)

class VCRCNot(VCTwoBitsOp):
    '''right Control Not Operation'''
    def __init__(self) -> None:
        operation_vector = Bits('1 0 0 0,0 0 0 1,0 0 1 0,0 1 0 0').vectorize()
        super().__init__(operation_vector)

# Exercise: Prove / Experiment that Swap_ij = C_ij C_ji C_ij

class VCBitZ(VCBitUnaryOp):
    '''Z operation'''
    def __init__(self) -> None:
        super().__init__(Bits('1 0,0 -1').vectorize())

class VCBitH(VCBitUnaryOp):
    '''Hadamard operation'''
    def __init__(self) -> None:
        super().__init__(sym.sqrt(2)*Bits('1 1,1 -1').vectorize())

# Exercise: Prove / Show C_ji = (H_iH_j) C_ij (H_iH_j) , this means using H, one can change C_ij to C_ji, changing the control and target bits. 

def tests():
    print(f'Two bits of {VCBitOne()} and {VCBitZero()} is {VCBits(VCBitOne(),VCBitZero())}')
    print(f'Two bits of {VCBitOne()} and {VCBitOne()} is {VCBits(VCBitOne(),VCBitOne())}')
    print(f'Three bits of {VCBitOne()} and {VCBitOne()} and {VCBitZero()} is {VCBits(VCBitOne(),VCBitOne(),VCBitZero())}')

    vcbits = [VCBitZero(),VCBitOne()]
    def test_one_bit_ops():
        onebitops = [VCBitNot(),VCBitIdentity(),VCBitZ(),VCBitH()]
        for act in onebitops:
            for op in vcbits:
                print(f'{act.__doc__} of {op} is {act.apply(op)}' )

    def test_two_bits_ops():
        vctwobits = [VCTwoBits(b1,b2) for b1 in vcbits for b2 in vcbits]
        twobitsops = [VCSwap(),VCLCNot(),VCRCNot()]
        for act in twobitsops:
            for op in vctwobits:
                print(f'{act.__doc__} of {op} is {act.apply(op)}' )

    test_one_bit_ops()
    test_two_bits_ops()



tests()

def experiment():
    x = sym.sqrt(2)
    v = np.array([[1],[0]])
    print(x*v)

experiment()