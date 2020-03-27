#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

#include "../../lib/console_read_line.h"
#include "../../lib/str_functions.h"
#include "../../lib/generics.h"

bool is_palindrom(char* str) {
	int len = strlen(str);
	int i, j;

	for (i = 0, j = len - 1; i < j; ++i, --j) {
		if (str[i] != str[j]) {
			return false;
		}
	}

	return true;
}

int extract_palindroms(char** palindroms[], char* words[], int words_count) {
	int palindroms_count = 0;
	*palindroms = malloc(words_count * sizeof(char*));
	if (*palindroms == NULL) exit(1);

	int i;
	for (i = 0; i < words_count; ++i) {
		if (is_palindrom(words[i])) {
			int word_len = strlen(words[i]);
			(*palindroms)[palindroms_count] = malloc(word_len + 1);
			if ((*palindroms)[palindroms_count] == NULL) exit(1);
			strcpy((*palindroms)[palindroms_count], words[i]);
			palindroms_count++;
		}
	}

	return palindroms_count;
}

int string_comparator(void* a, void* b) {
	char* first = (char*)a;
	char* second = (char*)b;
	return strcmp(second, first);
}

int main() {
	char* text = console_read_line(100, 1000);
	char** words = NULL;
	int word_count = str_split(&words, text, "!?., \t");
	
	char** palindroms = NULL;
	int palindroms_count = extract_palindroms(&palindroms, words, word_count);

	selection_sort(palindroms, palindroms_count, 
		sizeof(char*), string_comparator);
	str_arr_print(palindroms, palindroms_count, ", ");

	str_arr_free(words, word_count);
	str_arr_free(palindroms, palindroms_count);
	free(text);
	return 0;
}