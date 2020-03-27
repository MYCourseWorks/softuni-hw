#include "str_functions.h"

bool is_str_empty(const char* str) {
	if (str == NULL)
		return false;

	int i = 0;
	while (str[i] != '\0') {
		if (isspace(str[i]) == 0)
			return false;

		i++;
	}

	return true;
}

bool is_str_int(const char* str) {
	if (str == NULL)
		return false;

	int i = 0;
	int new_line_code = 10;

	// skip white space:
	while(isspace(str[i])) {
		i++;
	}

	if (*str == '-')
		i++;

	do {
		if (str[i] != new_line_code && 
		   !isdigit((unsigned char)str[i])) {
			return false;
		}

		i++;
	} while (str[i] != 0);

	return true;
}

bool is_str_num(const char* str) {
	if (str == NULL)
		return false;

	int i = 0;
	int new_line_code = 10;
	bool num_has_dot = false;

	// skip white space:
	while(isspace(str[i])) {
		i++;
	}

	if (*str == '-')
		i++;

	do {
		if (str[i] == '.') {
			if (num_has_dot == true){
				return false;
			} else {
				num_has_dot = true;
			}
		} else if (str[i] != new_line_code &&
			!isdigit((unsigned char)str[i])) {
			return false;
		}

		i++;
	} while (str[i] != 0);

	return true;
}

void reverse_str(char* s, int len) {
	int i, j;

	for (i = 0, j = len - 1; i < j; i++, j--) {
		int tmp = s[i];
		s[i] = s[j];
		s[j] = tmp;
	}
}

int str_split(char** dest[], char* raw_str, const char* delimiters) {
	int split_arr_len = 0;
	int dest_current_len = 10;
	*dest = malloc(dest_current_len * sizeof(char*));
	if (*dest == NULL) exit(1);

	char* current_split = strtok(raw_str, delimiters);
	while(current_split != NULL) {
		int current_split_len = strlen(current_split) * sizeof(char);
		
		// malloc space for the current_split in the dest array :
		(*dest)[split_arr_len] = malloc(current_split_len + 1);
		if ((*dest)[split_arr_len] == NULL) exit(1);

		// copy the current split into the dest at split_arr_len :
		strcpy((*dest)[split_arr_len], current_split);
		// put a terminating char at the end of the string :
		(*dest)[split_arr_len][current_split_len] = '\0';

		current_split = strtok(NULL, delimiters);
		split_arr_len++;

		// if the dest buffer overflows resize it :
		if (split_arr_len >= dest_current_len) {
			dest_current_len *= 2;
			*dest = realloc(*dest, dest_current_len * sizeof(char*));
			if (*dest == NULL) exit(1);
		}
	}

	return split_arr_len;
}

char* filter_text(char* text, 
				  char* words[], 
				  int w_len, 
				  char filter_symbol) 
{
	int i;
	char* text_p = text;

	while (*text_p != '\0') {
		for (i = 0; i < w_len; ++i) {
			char* curr_word = words[i];
			int curr_word_len = strlen(curr_word);
			if (strncasecmp(text_p, curr_word, curr_word_len) == 0) {
				memset(text_p, filter_symbol, curr_word_len);
				text_p += curr_word_len - 1;
				break;
			}
		}

		text_p++;	
	}

	return text;
}

void str_arr_print(char** str_arr, int len, char* delimiters) {
	if (delimiters == NULL)
		delimiters = "";

	int i;
	for (i = 0; i < len; ++i) {
		if (i != len - 1)
			printf("%s%s", str_arr[i], delimiters);
		else
			printf("%s\n", str_arr[i]);
	}
}

void str_arr_free(char** str_arr, int len) {
	int i;
	for (i = 0; i < len; ++i) {
		free(str_arr[i]);
	}

	free(str_arr);
}

char* copy_sub_str(const char* src, int pos, int len) {
	int src_len = strlen(src);
	int substr_len = pos + len;
	
	if (src == NULL)
		return NULL;
	if (pos >= src_len)
		return NULL;
	if (substr_len > src_len) 
		substr_len = src_len;

	char* substring = malloc(substr_len + 1);
	if (!substring) 
		return NULL;

	memcpy(substring, src + pos, substr_len);
	substring[substr_len] = '\0';
	return substring;
}