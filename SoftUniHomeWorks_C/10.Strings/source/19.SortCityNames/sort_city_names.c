#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>
#include <strings.h>

#include "../../lib/generics.h"
#include "../../lib/console_read_line.h"
#include "../../lib/str_functions.h"

int string_coparator(void* a, void* b) 
{
	return strcasecmp(*(char**)a, *(char**)b);
}

bool read_int(int* n) 
{
	char buffer[20];
	fgets(buffer, 20, stdin);
	if (sscanf(buffer, "%d", n) == 0) {
		return false;
	}

	return true;
}

int main()
{
	int n;
	if (!read_int(&n))
		return 1;

	char** str_arr = malloc(n * sizeof(char*));
	for (int i = 0; i < n; ++i) {
		str_arr[i] = console_read_line(20, 200);
	}

	selection_sort(str_arr, n, sizeof(char*), string_coparator);

	printf("\n");
	for (int i = 0; i < n; ++i) {
		printf("%s\n", str_arr[i]);
	}

	str_arr_free(str_arr, n);
	return 0;
}