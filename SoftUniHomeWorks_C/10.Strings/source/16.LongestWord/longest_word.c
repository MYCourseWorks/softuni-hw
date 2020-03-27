#include <stdio.h>
#include <string.h>

#include "../../lib/console_read_line.h"
#include "../../lib/string_builder/string_builder.h"

void free_str_arr(char** str_arr, int len) 
{
	for (int i = 0; i < len; ++i) {
		free(str_arr[i]);
	}

	free(str_arr);
}

int main() 
{
	char* line = console_read_line(100, 1000);
	string_builder sb;
	sb_init(&sb);

	int count = 0;
	char** splits = sb_split(&count, line, " .,!?"); 

	int max_len = 0;
	char* max_str = NULL;
	for (int i = 0; i < count; ++i) {
		int curr_len = strlen(splits[i]);
		if (max_len < curr_len) {
			max_len = curr_len;
			max_str = splits[i];
		}
	}

	if (max_str) {
		printf("%s\n", max_str);
	}

	sb_free(&sb);
	free_str_arr(splits, count);
	free(line);
	return 0;
}