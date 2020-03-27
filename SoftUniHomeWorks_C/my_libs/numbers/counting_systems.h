#include <stdlib.h>
#include <math.h>

#ifndef COUNTING_SYSTEM
#define COUNTING_SYSTEM 1

/*
summary:
	this function converts the integer type	
	to a char* binary representation.
	The recommend buffer size is the size
	of the int type.
uses:
	math.h and stdlib.h
*/
void int_to_bin(unsigned int n, char* buffer);
/*
summary:
	this function converts binary representation
	of a number from const char* and returns it as int.
arguments:
	char* num_as_bin -> The number as binary. 
		Should contain only '0' and '1' symbols.
	int len -> The size of the num_as_bin.
	int* error -> Pointer to and error variable.
		0 if it's all ok;
		1 if num_as_bin was null;
		2 if num_as_bin was in an incorrect format;
uses:
	stdlib.h
*/
int bin_to_int(const char* num_as_bin, int len, int* error);
/*
summary:
	this function converts an integer to a
	hexadecimal representation.
	The recommend buffer size is the size
	of the int type divided by 4.
uses:
	stdlib.h
*/
void int_to_hex(unsigned int n, char* buffer);
/*
summary:
	this function converts hex representation
	of a number from const char* and returns it as int.
arguments:
	char* num_as_hex -> The number as binary. 
		Should contain only [0..9A..F] symbols.
	int len -> The size of the num_as_hex.
	int* error -> Pointer to and error variable.
		0 if it's all ok;
		1 if num_as_hex was null;
		2 if num_as_hex was in an incorrect format;
uses:
	stdlib.h
*/
int hex_to_int(const char* num_as_hex, int len, int* error);

#endif