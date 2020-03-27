#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../../lib/console_read_line.h"

char* remove_letter_series(char* source) {
	int i;
	int source_len = strlen(source);
	if (source_len == 0) return NULL;
	char* dest = malloc(source_len * sizeof(char));
	int dest_len = 0;

	for (i = 0; i < source_len; ++i) {
		if (dest_len == 0) {
			dest[dest_len] = source[i];
			dest_len++;
		} else if (dest[dest_len - 1] != source[i]) {
			dest[dest_len] = source[i];
			dest_len++;
		}
	}

	dest[dest_len] = '\0';
	return dest;
}

int main() {
	char* line = console_read_line(100, 1000);
	char* removed_series = remove_letter_series(line);
	
	if (removed_series) printf("%s\n", removed_series);
	if (line) free(line);
	if (removed_series) free(removed_series);
	return 0;
}