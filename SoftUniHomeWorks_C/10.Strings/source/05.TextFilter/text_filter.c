#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../../lib/console_read_line.h"

int str_split(char** dest[], char* raw_str, char* delimiters) {
	int split_arr_len = 0;
	int dest_current_len = 10;
	*dest = malloc(dest_current_len * sizeof(char*));
	if (*dest == NULL) exit(1);

	char* current_split = strtok(raw_str, delimiters);
	while(current_split != NULL) {
		int current_split_len = strlen(current_split) * sizeof(char);
		(*dest)[split_arr_len] = malloc(current_split_len + 1);
		if ((*dest)[split_arr_len] == NULL) exit(1);

		strcpy((*dest)[split_arr_len], current_split);
		(*dest)[split_arr_len][current_split_len] = '\0';

		current_split = strtok(NULL, delimiters);
		split_arr_len++;

		if (split_arr_len >= dest_current_len) {
			dest_current_len *= 2;
			*dest = realloc(*dest, dest_current_len * sizeof(char*));
			if (*dest == NULL) exit(1);
		}
	}

	return split_arr_len;
}

void free_str_arr(char** str_arr, int len) {
	int i;
	for (i = 0; i < len; i++) {
		free(str_arr[i]);
	}

	free(str_arr);
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

int main() {
	char* words = console_read_line(100, 1000);
	char** words_split = NULL;
	int split_len = str_split(&words_split, words, ", ");
	char* text = console_read_line(100, 1000);
	text = filter_text(text, words_split, split_len, '*');

	printf("\n%s\n", text);

	if (words_split) free_str_arr(words_split, split_len);
	if (words) free(words);
	if (text) free(text);
	return 0;
}