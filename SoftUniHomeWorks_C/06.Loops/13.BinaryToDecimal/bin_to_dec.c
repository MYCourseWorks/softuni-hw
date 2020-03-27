#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* console_read_line(size_t start_len, size_t max_possible) {
	char* line = malloc(start_len);
	char* line_p = line;
	size_t len_max = start_len;
	size_t len = len_max - 1;
	int ch;

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

long bin_to_long(char* num_as_bin, int len) {
	int i;
	long power = 1;
	long result = 0;

	for (i = len - 1; i >= 0; --i) {
		if (num_as_bin[i] == '0')
			result += 0;	
		else if (num_as_bin[i] == '1')
			result += power;
		else
			exit(1);

		power *= 2;
	}

	return result;
}

int main() {
	printf("binary number = ");
	char* num_as_bin = console_read_line(30, 100);
	if (num_as_bin == NULL)
		return 1;

	int num_len = strlen(num_as_bin);
	long num = bin_to_long(num_as_bin, num_len);

	printf("%ld\n", num);
	if (num_as_bin != NULL)
		free(num_as_bin);

	return 0;
}