#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <strings.h>
#include <ctype.h>
#include <stdbool.h>

#ifndef STR_FUNCTIONS_H
#define STR_FUNCTIONS_H 1

/*
summary:
	this function tests if all chars before
	a '\0' contain only white space symbols.
uses:
	stdbool.h, stdlib.h and ctype.h
*/
bool is_str_empty(const char* str);
/*
summary:
	this function tests if all chars before
	a '\0' contain only digits.
uses:
	stdbool.h, stdlib.h and ctype.h
*/
bool is_str_int(const char* str);
/*
summary:
	this function tests if all chars before
	a '\0' contain only digits and/or exactly 1 '.' symbol.
uses:
	stdbool.h, stdlib.h and ctype.h
*/
bool is_str_num(const char* str);
/*
summary:
	this function reverses the char pointer with
	given length.
*/
void reverse_str(char* s, int len);
/*
summary:
	this function splits the contents of a char*
	into a char* array.
arguments:
	char** dest[] -> this is the address of the
		char* array in which the raw string will
		be split.
	char* raw_str -> this string will be passed to
		strtok, which means it will be changed in
		the process of splitting.
	const char* delimiters -> the symbols that we split on.
returns:
	the count of splits made, which is the number of rows
	in the dest array.
uses:
	stdlib.h and string.h
*/
int str_split(char** dest[], char* raw_str, const char* delimiters);
/*
summary:
	this function filters text by given char* array of words.
arguments:
	char* words[] -> the words to filter.
	int w_len -> the words count.
	char filter_symbol -> the symbol to filter with. 
returns:
	a pointer to the text variable.
uses:
	stdlib.h, string.h and strings.h !!
*/
char* filter_text(char* text, char* words[], int w_len, 
	char filter_symbol);

void str_arr_free(char** str_arr, int len);
void str_arr_print(char** str_arr, int len, char* delimiters);
/*
summary:
	copies the src from pos to len.
returns:
	the dynamically allocated substring.
uses:
	string.h and stdlib.h
*/
char* copy_sub_str(const char* src, int pos, int len);

#endif