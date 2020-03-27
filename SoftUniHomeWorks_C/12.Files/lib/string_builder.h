#include <assert.h>
#include <ctype.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

#ifndef STRING_BUILDER_H_
#define STRING_BUILDER_H_ 1

#define SB_DEFAULT_LEN 10

typedef struct {
	size_t count; // logical length.
	size_t _len;  // actual length of allocated memory.
	char* _str_p; // actual representation of the string.
} string_builder;

/*
summary:
	Uses malloc for the _str_p.
*/
void sb_init(string_builder* sb);
/*
summary:
	sets sb->count = 0;
	sets sb->_len = 0;
	frees sb->_str_p;
important:
	Always call after sb_init and sb_clone !
*/
void sb_free(string_builder* sb);
/*
summary:
	Sets sb->count = 0.
*/
void sb_clear(string_builder* sb);
/*
summary:
	Uses memcpy to copy the str pointer.
	Uses realloc if the buffer is full.
*/
void sb_append(string_builder* sb, const char* str);
/*
summary:
	Uses realloc if the buffer is full.
*/
void sb_append_char(string_builder* sb, char c);
/*
summary:
	Gets the char at pos.
	Asserts that the pos is not bigger
	than sb->count.
*/
char sb_get_char(string_builder* sb, size_t pos);
/*
summary:
	Creates a copy of the src sb in the dest sb.
*/
void sb_copy(string_builder* dest, string_builder* src);
/*
summary:
	Cuts the string builders content using memmove.
	Asserts that the start and end are valid.
*/
void sb_cut(string_builder* sb, size_t start, size_t end);
/*
summary:
	Returns true only for a dead match.
	Performs a case sensitive compare !
*/
bool sb_equals(string_builder* first, string_builder* second);
bool sb_equals_str(string_builder* sb, const char* str);
/*
summary:
	Returns the index of the first or last match.
*/
int sb_index_of(string_builder* sb, const char* str);
int sb_last_index_of(string_builder* sb, const char* str);
/*
summary:
	Simple reverse.
*/
void sb_reverse(string_builder* sb);
/*
summary:
	Trims leading white space.
	Uses memmove to shift memory 
	to the first non white space.
*/
void sb_trim_left(string_builder* sb);
/*
summary:
	Trims trailing white space.
	Just sets the count to the index of
	the last non white space character.
*/
void sb_trim_right(string_builder* sb);
/*
summary:
	Trims all leading or trailing symbols 
	that are in the given char_set.
arguments:
	char_set -> should contain only unique symbols!
*/
void sb_trim_left_with(string_builder* sb, const char char_set[]);
void sb_trim_right_with(string_builder* sb, const char char_set[]);
/*
summary:
	Creates a new copy of the sb->_str_p,
	which is filtered with the exact given string.
arguments:
	str -> the string to skip.
*/
void sb_remove(string_builder *sb, const char* str);
/*
summary:
	Creates a new copy of the sb->_str_p,
	skipping all chars in the char_set.
arguments:
	char_set -> should contain only unique symbols!
*/
void sb_remove_all(string_builder *sb, const char char_set[]);
/*
summary:
	Creates a new copy of the string_builder
	and appends every char from sb->_str_p,
	replacing all occurrences of old_val with
	new_val.
important:
	Calls sb_free on the given sb and 
	reassigns it to the newly created sb.
*/
void sb_replace(string_builder *sb, const char* old_val, const char* new_val);
/*
summary:
	Prints the string to sb->count in the format:
	[index] = [(int)char] '[char]'
*/
void sb_debug_print(string_builder* sb);

// #### RETURN DYNAMIC MEMORY #####

/*
summary:
	Allocates memory and copies the memory with 
	the logical length of sb.
returns:
	dynamic memory with size (sb->count + 1) and
	a '\0' symbol at the end.
*/
char* sb_to_string(string_builder* sb);
/*
summary:
	Same as sb_to_string.
returns:
	dynamic memory with size (sb->count + 1) and
	a '\0' symbol at the end.	
*/
char* sb_substr(string_builder* sb, size_t start, size_t len);
/*
summary:
	Gives control of the already allocated
	memory in the _str_p to the user.
	Calls sb_init for the sb after that
	and the sb can still be used.
advantage:
	No copies are created we waste no memory.
returns:
	Returns the _str_p + '\0' at the end.
important:
	The string_builder is no longer responsible 
	for clearing the allocated memory, but still needs
	a sb_free to be called !
*/
char* sb_give_control_of_str(string_builder* sb);
/*
summary:
	Splits the contents of raw_str, by given delimiters
	and copies them into a char** one at a time.
arguments:
	int* splits_count -> the address of an integer to
		save the row count of the returning char**.
	char* raw_str -> the string to split (works on a copy).
	char* delimiters -> this is passed to strtok function
		at some point.
important:
	The returned char** is dynamic memory
	with a malloc call per row !
*/
char** sb_split(int* splits_count, const char* raw_str, const char* delimiters);

#endif
