import numpy as np


def vectorize(seq:str):
    # todo: validate the input, all rows only digits, rows same size
    assert(isinstance(seq,str))
    segments = seq.split(',')
    # Convert segments to integer arrays
    digit_arrays = [np.array(list(segment), dtype=int) for segment in segments]
    # Stack the digit arrays vertically
    arr = np.vstack(digit_arrays)
    return arr

class VBit: 
    def __init__(self) -> None:
        self.vec_value = np.array([[None],[None]])
        self.num_value = None
    def __getstate__(self) -> object:
        state = self.__dict__.copy()
        return state
    def get_vector(self) ->np.ndarray:
        return self.vec_value
    def str_vector(self) -> str:
        return np.array2string(self.vec_value)
    def dirac(self,nbits=0):
        return '|'+str(bin(self.num_value)).removeprefix('0b').zfill(nbits)+'>'


class VCBit(VBit):
    def __init__(self,value:object):
        super().__init__()
        if isinstance(value,np.ndarray):
            self.vec_value = value
            self.num_value = 0 if value[0]==1 and value[1]==0 else 1 if value[0]==0 and value[1]==1 else None
        elif isinstance(value,bool):
            self.vec_value = vectorize('0,1') if value else vectorize('1,0')
            self.num_value = int(value)
        else:
            raise Exception('Invalid type for VCBit initialization.')
    def __str__(self) -> str:
        return self.dirac()



class VCBitZero(VCBit):
    def __init__(self) -> None:
        super().__init__(False)

class VCBitOne(VCBit):
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
    def __init__(self) -> None:
        super().__init__(vectorize('01,10'))


class VCBitIdentity(VCBitUnaryOp):
    def __init__(self) -> None:
        super().__init__(vectorize('10,01'))

class VCBits(VBit):
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
    def __init__(self) -> None:
        operation_vector = vectorize('1000,0010,0100,0001')
        super().__init__(operation_vector)

class VCLCNot(VCTwoBitsOp):
    def __init__(self) -> None:
        operation_vector = vectorize('1000,0100,0001,0010')
        super().__init__(operation_vector)

class VCRCNot(VCTwoBitsOp):
    def __init__(self) -> None:
        operation_vector = vectorize('1000,0001,0010,0100')
        super().__init__(operation_vector)



def tests():
    print(f'negation of {VCBitZero()} is {VCBitNot().apply(VCBitZero())}')
    print(f'negation of {VCBitOne()} is {VCBitNot().apply(VCBitOne())}')
    print(f'Identity of {VCBitZero()} is {VCBitIdentity().apply(VCBitZero())}')
    print(f'Identity of {VCBitOne()} is {VCBitIdentity().apply(VCBitOne())}')
    print(f'Two bits of {VCBitOne()} and {VCBitZero()} is {VCBits(VCBitOne(),VCBitZero())}')
    print(f'Two bits of {VCBitOne()} and {VCBitOne()} is {VCBits(VCBitOne(),VCBitOne())}')
    print(f'Three bits of {VCBitOne()} and {VCBitOne()} and {VCBitZero()} is {VCBits(VCBitOne(),VCBitOne(),VCBitZero())}')
    print(f'Swap of {VCTwoBits(VCBitOne(),VCBitZero())} is {VCSwap().apply(VCTwoBits(VCBitOne(),VCBitZero()))}')
    print(f'Swap of {VCTwoBits(VCBitZero(),VCBitOne())} is {VCSwap().apply(VCTwoBits(VCBitZero(),VCBitOne()))}')
    print(f'Swap of {VCTwoBits(VCBitZero(),VCBitZero())} is {VCSwap().apply(VCTwoBits(VCBitZero(),VCBitZero()))}')
    print(f'Swap of {VCTwoBits(VCBitOne(),VCBitOne())} is {VCSwap().apply(VCTwoBits(VCBitOne(),VCBitOne()))}')
    print(f'Left cNot of {VCTwoBits(VCBitOne(),VCBitOne())} is {VCLCNot().apply(VCTwoBits(VCBitOne(),VCBitOne()))}')
    print(f'Left cNot of {VCTwoBits(VCBitOne(),VCBitZero())} is {VCLCNot().apply(VCTwoBits(VCBitOne(),VCBitZero()))}')
    print(f'Left cNot of {VCTwoBits(VCBitZero(),VCBitOne())} is {VCLCNot().apply(VCTwoBits(VCBitZero(),VCBitOne()))}')
    print(f'Left cNot of {VCTwoBits(VCBitZero(),VCBitZero())} is {VCLCNot().apply(VCTwoBits(VCBitZero(),VCBitZero()))}')
    print(f'Right cNot of {VCTwoBits(VCBitOne(),VCBitOne())} is {VCRCNot().apply(VCTwoBits(VCBitOne(),VCBitOne()))}')
    print(f'Right cNot of {VCTwoBits(VCBitOne(),VCBitZero())} is {VCRCNot().apply(VCTwoBits(VCBitOne(),VCBitZero()))}')
    print(f'Right cNot of {VCTwoBits(VCBitZero(),VCBitOne())} is {VCRCNot().apply(VCTwoBits(VCBitZero(),VCBitOne()))}')
    print(f'Right cNot of {VCTwoBits(VCBitZero(),VCBitZero())} is {VCRCNot().apply(VCTwoBits(VCBitZero(),VCBitZero()))}')








tests()