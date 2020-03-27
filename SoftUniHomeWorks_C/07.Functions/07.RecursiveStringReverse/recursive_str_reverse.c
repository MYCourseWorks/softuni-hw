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

void swap_char(char* a, char* b) {
    char tmp = *a;
    *a = *b;
    *b = tmp;	
}

char* r_reverse(char* str, int len, int i) {
    if (i >= len / 2)
        return str;

    swap_char(&str[i], &str[len - i - 1]);
    return r_reverse(str, len, i + 1);
}

int main() {
	printf("str = ");
    char* str = console_read_line(20, 100);
    printf("reverse = %s\n", r_reverse(str, strlen(str), 0));
	free(str);
	return 0;
}