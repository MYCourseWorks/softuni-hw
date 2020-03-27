#include <stdio.h>
#include <stdlib.h>

#ifndef CONSOLE_READ_LINE_H_
#define CONSOLE_READ_LINE_H_

/* 
summary :
	This function reads a stream from the standard console input until
	a EOF or '\n' is reached. Then returns a dynamic char* with a null
	terminator at the end.
input :
	size_t start_len - initial size for the malloc function.
	size_t line_size - maximum bits that can be written.
uses : 
	malloc, realloc and fgetc.
returns :
	a char* dynamically allocated with size between [start_len..max_possible]; 
	Don't forget to free the memory when done !
*/
char* console_read_line(size_t start_len, size_t max_possible);

#endif