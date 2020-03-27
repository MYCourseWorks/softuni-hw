#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../../lib/console_read_line.h"

int main() {
	printf("Give 5 numbers : ");
	char* line = console_read_line(50, 1000);
	if (line == NULL)
		return 1;

	double sum = 0;
	char* current_num = strtok(line, " \n\t");
	while (current_num != NULL) {
		sum += strtod(current_num, NULL);
		current_num = strtok(NULL, " \n\t");
	}

	printf("%.2f\n", sum);
	free(line);
	return 0;
}