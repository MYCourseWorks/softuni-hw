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

long hex_to_long(char* num_as_hex, int len) {
	long result, power = 1;
	int i = 0;

	for (i = len - 1; i >= 0; --i) {
		int current_digit = 0;
		switch (num_as_hex[i]) {
			case '0' : current_digit = 0; break;
			case '1' : current_digit = 1; break;
			case '2' : current_digit = 2; break;
			case '3' : current_digit = 3; break;
			case '4' : current_digit = 4; break;
			case '5' : current_digit = 5; break;
			case '6' : current_digit = 6; break;
			case '7' : current_digit = 7; break;
			case '8' : current_digit = 8; break;
			case '9' : current_digit = 9; break;
			case 'A' : current_digit = 10; break;
			case 'B' : current_digit = 11; break;
			case 'C' : current_digit = 12; break;
			case 'D' : current_digit = 13; break;
			case 'E' : current_digit = 14; break;
			case 'F' : current_digit = 15; break;
			default : exit(1);
		};

		result += current_digit * power;
		power *= 16;
	}

	return result;
} 

int main() {
	printf("number as hex = ");
	char* num_as_hex = console_read_line(30, 100);
	int num_as_hex_len = strlen(num_as_hex);
	long num = hex_to_long(num_as_hex, num_as_hex_len);
	
	printf("%ld\n", num);
	if (num_as_hex != NULL)
		free(num_as_hex);
	
	return 0;
}