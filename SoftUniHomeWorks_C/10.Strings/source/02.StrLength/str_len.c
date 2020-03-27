#include <stdio.h>
#include <string.h>

#include "../../lib/console_read_line.h"

void add_asterix(char* line) {
	int i = 0;
	int found_term = 0;
	while(i <= 20) {
		if (line[i] == '\0')
			found_term = 1;
		if (found_term == 1)
			line[i] = '*';

		i++;
	}

	line[i] = '\0';
}

int main() {
	char* line = console_read_line(21, 21);
	add_asterix(line);
	printf("%s\n", line);
	free(line);
	return 0;
}