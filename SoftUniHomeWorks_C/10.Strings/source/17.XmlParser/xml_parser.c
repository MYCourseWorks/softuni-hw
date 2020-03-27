#include <stdio.h>
#include <ctype.h>
#include <stdbool.h>

#include "../../lib/console_read_line.h"
#include "../../lib/string_builder/string_builder.h"

void free_str_arr(char** str_arr, int len) 
{
	for (int i = 0; i < len; ++i) {
		free(str_arr[i]);
	}

	free(str_arr);		
}

void read_to_empty_line(string_builder *sb) 
{
	bool empty_line = false;
	while(!empty_line) {
		char* line = console_read_line(100, 1000);
		sb_append(sb, line);
		sb_append_char(sb, '\n');
		empty_line = *line == '\0' ? true : false;
		free(line);
	}
}

bool is_valid_xml(char* tag_opening, char* tag_content, char* tag_closing)
{
	return tag_closing[0] == '/' &&
		strcmp(tag_opening, tag_closing + 1) == 0;
}

int main()
{
	string_builder sb;
	sb_init(&sb);
	read_to_empty_line(&sb);

	int split_size = 0;
	char* sb_as_str = sb_give_control_of_str(&sb);
	char** split_input = sb_split(&split_size, sb_as_str, "\n");

	for (int i = 0; i < split_size; ++i) {
		int curr_size = 0;
		char** current = sb_split(&curr_size, split_input[i], "<>");		
		bool valid = false;
		char* tag_opening; 
		char* tag_content; 
		char* tag_closing;

		if (curr_size == 3) {
			tag_opening = current[0];
			tag_content = current[1];
			tag_closing = current[2];
			if (is_valid_xml(tag_opening, tag_content, tag_closing))
				valid = true;
			else
				valid = false;
		} else {
			valid = false;
		}

		if (valid) {
			tag_opening[0] = toupper(tag_opening[0]);
			printf("%s : %s\n", tag_opening, tag_content);
		} else {
			printf("Invalid format\n");
		}

		free_str_arr(current, curr_size);
	}
	
	free(sb_as_str);
	free_str_arr(split_input, split_size);
	sb_free(&sb);
	return 0;
}