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

int last_occurence_of_char(char* str, int len, char ch) {
	int i;
	int index_of_last_occurence = -1;
	for (i = len - 1; i >= 0; --i) {
		if (str[i] == ch) {
			index_of_last_occurence = i;
			break;
		}
	}

	return index_of_last_occurence;
}

int main() {
	char* line, ch;
	printf("text = ");
	line = console_read_line(50, 200);
	printf("ch = ");
	scanf("%c", &ch);

	int last_occurence = last_occurence_of_char(line, strlen(line), ch);
	printf("%d\n", last_occurence);

	free(line);
	return 0;
}