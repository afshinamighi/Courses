## Primitive Data Types

In TypeScript, the primitive data types are the basic building blocks for defining variables and representing simple values. The primitive data types 
in TypeScript include the following:

- number: Represents numeric values, both integers and floating-point numbers. For example: let age: number = 25;

- string: Represents textual data enclosed in single quotes ('') or double quotes (""). For example: let name: string = "Alice";

- boolean: Represents a logical value that can be either true or false. For example: let isActive: boolean = true;

- null: Represents the absence of any object value. It is a distinct type that has only one possible value, which is null. For example: let person: null 
= null;

- undefined: Represents a variable that has been declared but has not been assigned a value. It is a distinct type with only one possible value, which 
is undefined. For example: let price: undefined = undefined;

- bigint: Represents integer values with arbitrary precision. It is a newer addition to JavaScript/TypeScript. For example: let bigNumber: bigint = 
9007199254740991n;

- symbol: Represents unique and immutable values that can be used as identifiers for object properties. It is often used for creating private object 
members. For example: const id: symbol = Symbol("id");

These primitive data types are the fundamental data types provided by TypeScript. They are used to store and manipulate simple values in your 
programs. It's worth noting that TypeScript also has other data types such as arrays, objects, and functions, which are derived from these primitive 
types or are more complex in nature.

Remember that TypeScript is a statically typed language, so it's generally recommended to explicitly annotate variables with their respective data 
types for better code clarity and type checking benefits.
