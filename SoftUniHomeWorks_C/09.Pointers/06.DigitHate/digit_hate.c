#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* console_read_line(char* line, size_t start_len, size_t max_possible) {
	line = malloc(start_len);
	char* line_p = line;
	size_t len_max = start_len;
	size_t len = len_max - 1;
	int ch = 0;

	if (line == NULL) {
		return NULL;
	}

	while (ch != EOF) {
		ch = fgetc(stdin);
		if (ch == '\n') {
			break;
		} else if (len > max_possible) {
			break;
		}

		if (len == 0) {
			len = len_max;
			len_max *= 2;
			char* reallocated_line = (char*)realloc(line, len_max);

			if (reallocated_line == NULL) {
				free(line);
				return NULL;
			}

			line_p = reallocated_line + (line_p - line);
			line = reallocated_line;
		}

		*line_p = ch;
		line_p++;
		len--;
	}

	*line_p = '\0';
	return line;
}

char* digit_hate(char* dest, char* source) {
	int i;
	int str_len = strlen(source) + 1; // + 1 for '\0'
	dest = malloc(str_len + 1);
	dest = strcpy(dest, source);
	
	for (i = 0; i < str_len; ++i) {
		if (dest[i] >= '0' && dest[i] <= '9') {
			dest[i] = '/';
		}
	}

	return dest;
}

int main() {
	char* line;
	line = console_read_line(line, 100, 1000);	

	char* no_digits;
	no_digits = digit_hate(no_digits, line);
	printf("%s\n", no_digits);

	free(no_digits);
	free(line);
	return 0;
}