#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

#ifndef READ_INPUT_H_
#define READ_INPUT_H_ 1

/* 
summary:
	This function reads the stdin stream until a EOF or '\n' is reached. 
	Then returns a dynamic char* with a null terminator at the end.
	It's a bit slow for big files, but it has precision for reading 
	input from a user.
input:
	size_t start_len - initial size for the malloc function.
	size_t line_size - maximum bits that can be written.
uses: 
	malloc, realloc and fgetc.
returns:
	a char* dynamically allocated with size between [start_len..max_possible]; 
	Don't forget to free the memory when done !
*/
char* console_read_line(size_t start_len, size_t max_possible);
/*
summary:
	Tries to read a specific type from the stream.
returns:
	If the match was successful returns true.
important:
	Can't tell if the input overflows the type.
*/
bool read_int(int* n, FILE* stream);
bool read_long(long* n, FILE* stream);
bool read_double(double* n, FILE* stream);

#endif