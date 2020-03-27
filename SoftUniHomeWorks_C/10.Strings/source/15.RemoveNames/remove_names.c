#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../../lib/str_functions.h"
#include "../../lib/console_read_line.h"

char* remove_all(char* dest, const char* src, char* word) {
	int word_len = strlen(word);
	int dest_i = 0;
	int source_i = 0;

	while(src[dest_i] != '\0') {
		if (strncmp(src + dest_i, word, word_len) == 0)
			dest_i += word_len;
		else
			dest[source_i++] = src[dest_i];

		dest_i++;
	}

	dest[source_i] = '\0';
	return dest;
}

int main() {
	char* text = console_read_line(100, 1000);
	int text_len = strlen(text);
	char* filters_raw = console_read_line(100, 1000);

	char** filter_words = NULL;
	int split_len = str_split(&filter_words, filters_raw, " ");
	
	int i;
	for (i = 0; i < split_len; ++i) {
		char* filtered_text = calloc(1, text_len);
		if(!filtered_text) 
			exit(1);
		
		filtered_text = remove_all(filtered_text, text, filter_words[i]);
		free(text);
		text = filtered_text;
	}

	printf("%s\n", text);

	if(filter_words) str_arr_free(filter_words, split_len);
	if(text) free(text);
	if(filters_raw) free(filters_raw);
	return 0;
}