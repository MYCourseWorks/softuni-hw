#include <stdio.h>
#include <string.h>

#include "../../lib/console_read_line.h"

int count_substring(char* text, char* substring) {
	int counter = 0;
	char* text_p = text;
	int substring_len = strlen(substring);

	while(*text_p != '\0') {
		if (strncasecmp(text_p, substring, substring_len) == 0)
			counter++;

		text_p++;
	}

	return counter;
}

int main() {
	char* line = console_read_line(50, 1000);
	char* substring = console_read_line(10, 1000);

	int count = count_substring(line, substring);
	printf("%d\n", count);

	free(line);
	free(substring);
	return 0;
}