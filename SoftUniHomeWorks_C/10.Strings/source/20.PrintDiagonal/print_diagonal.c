#include <stdio.h>

#include "../../lib/console_read_line.h"
#include "../../lib/string_builder/string_builder.h"
#include "../../lib/str_functions.h"

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

	string_builder sb;
	sb_init(&sb);

	for (int i = 0; i < n; ++i) {
		char* line = console_read_line(20, 200);
		int split_size = 0;
		char** line_split = sb_split(&split_size, line, " ");
		
		sb_append_char(&sb, '\n');
		sb_append(&sb, line_split[i]);

		str_arr_free(line_split, split_size);
		free(line);
	}

	char* str_content = sb_give_control_of_str(&sb);
	printf("%s\n", str_content);
	sb_free(&sb);
	return 0;
}