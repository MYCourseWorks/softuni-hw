#include "read_input.h"

char* console_read_line(size_t start_len, size_t max_possible)
{
	char* line = malloc(start_len);
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

bool read_int(int* n, FILE* stream)
{
	char buffer[20];
	fgets(buffer, 20, stream);
	int matches = sscanf(buffer, "%d", n);
	return matches != 0;
}

bool read_long(long* n, FILE* stream)
{
	char buffer[30];
	fgets(buffer, 30, stream);
	int matches = sscanf(buffer, "%ld", n);
	return matches != 0;
}

bool read_double(double* n, FILE* stream)
{
	char buffer[30];
	fgets(buffer, 30, stream);
	int matches = sscanf(buffer, "%lf", n);
	return matches != 0;
}