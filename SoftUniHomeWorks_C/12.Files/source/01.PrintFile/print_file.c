#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../../lib/string_builder.h"

#define IO_BUFFER_SIZE 4096

// Find the file in bin independent on where the 
// program was called from.
void get_path_to_file(char* dest,
					  const char* path_from_bin, 
					  const char* called_from)
{
	string_builder sb;
	sb_init(&sb);
	sb_append(&sb, called_from);

	int dash_i = sb_last_index_of(&sb, "/");
	sb_cut(&sb, 0, dash_i + 1);
	char* path_to_dir = sb_give_control_of_str(&sb);
	dest = strcat(dest, path_to_dir);
	dest = strcat(dest, path_from_bin);
	
	free(path_to_dir);
	sb_free(&sb);
}

int main(int argc, char *argv[])
{	
	char buffer[IO_BUFFER_SIZE];
	get_path_to_file(buffer, "file.txt", argv[0]);

	FILE* fp = fopen(buffer, "r");
	if (fp == NULL) {
		perror("Couldn't open file");
		return 1;
	}

	while(!feof(fp)) {
		fread(buffer, IO_BUFFER_SIZE, 1, fp);
		printf("%s", buffer);
	}

	fclose(fp);
	return 0;
}