#include <stdio.h>
#include <string.h>

#include "../../lib/console_read_line.h"

void str_reverse(char* str) {
	int i, j;
	int len = strlen(str);

	for (i = 0, j = len - 1; i < j; i++, j--) {
		char tmp = str[i];
		str[i] = str[j];
		str[j] = tmp;
	}

	str[len] = '\0';
}

int main() {
	char* line = console_read_line(100, 1000);
	str_reverse(line);
	printf("%s\n", line);
	free(line);
	return 0;
}