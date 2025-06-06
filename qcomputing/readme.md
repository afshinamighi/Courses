<h1 align="center">Quantum Computing</h1>
<h2 align="center">A Quick Introduction for Programmers</h2>

In this brief introductory course, a collection of self-contained learning materials has been prepared to facilitate the learning and practice of the fundamental concepts of quantum computing. This collection is designed for individuals interested in beginning quantum programming with minimal theoretical prerequisites.

### Content

1. [Reframing the Classical Bit: A Fresh Perspective](qc_lesson_01.ipynb)
2. [Beyond Binary: The Evolution from Classical Bits to Qubits](qc_lesson_02.ipynb)
3. [The Quantum Pair: The Dance of Two Entangled Qubits](qc_lesson_03.ipynb)
4. [From Classical Limits to Quantum Power: Deutsch’s Two-Qubit Solution](qc_lesson_04.ipynb)
   

### Required Background

In order to read and understand this collection it would be important to be confident in the following topics:

1. #### Basic algebraic terms:

$(x+y)(a+b)=xa+xb+ya+yb$ , $(x+y)(a-b)=xa-xb+ya-yb$ 

2. #### Basics of 2D Vector and Matrix:

$$ 
v = \begin{bmatrix} x \\
y \end{bmatrix} 
$$
and 
$$ 
M = \begin{bmatrix} a & b \\
c & d \end{bmatrix} 
$$

$$  
v_1 + v_2 = \begin{bmatrix} x_1 \\
y_1 \end{bmatrix} + \begin{bmatrix} x_2 \\
y_2 \end{bmatrix} = \begin{bmatrix} x_1 + x_2 \\
y_1 + y_2 \end{bmatrix} 
$$

$$  
s . v = s . \begin{bmatrix} x \\
y \end{bmatrix} = \begin{bmatrix} s . x \\
s . y \end{bmatrix} 
$$

3. #### Transformation

$$
M.v = \begin{bmatrix} a & b \\
c & d \end{bmatrix} . \begin{bmatrix} x \\
y \end{bmatrix} = \begin{bmatrix} ax+by \\
cx+dy \end{bmatrix}
$$

4. #### Functions
$f(x)$

5. #### Classical Bits
  - Each classical bit can have two states represented by $0$ and $1$, two classical bits can be represented as $b_1b_0$ which can provide $2^2$ possible states: $00$ , $01$ , $10$ , $11$
  - Given a classical bits $b_1b_0$: $\neg b_0$ is the negation of $b_0$, $$b_1 \land b_0$$ is the AND operation, $$b_1 \lor b_0$$ is the OR operation, $$b_1 \oplus b_0$$ is the XOR operation

6. #### Basic Symbols: $\psi$, $\phi$, $U_f$
7. #### Python
    - Basic Programming in Python