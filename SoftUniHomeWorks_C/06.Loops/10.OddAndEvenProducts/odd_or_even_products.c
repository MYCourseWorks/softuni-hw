#include <stdio.h>
#include <string.h>
#include <stdlib.h>

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

int main() {
	char* line = console_read_line(20, 50);

	if (line == NULL)
		return 1;

	int product_odd = 1, product_even = 1, counter = 0;
	char* current_num = strtok(line, " \n\t");
	while (current_num != NULL) {
		if (counter % 2 == 0)
			product_odd *= strtol(current_num, NULL, 10);
		else 
			product_even *= strtol(current_num, NULL, 10);

		current_num = strtok(NULL, " \n\t");
		counter++;
	}

	if (product_odd - product_even == 0)
		printf("yes\nproduct = %d\n", product_odd);
	else 
		printf("no\nodd_product = %d\neven_product = %d\n", product_odd, product_even);
	
	if (line != NULL)
		free(line);

	return 0;
}