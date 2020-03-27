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
	strcpy(dest, path_to_dir);
	dest = strcat(dest, path_from_bin);
	
	free(path_to_dir);
	sb_free(&sb);
}

void die(char* msg)
{
	perror(msg);
	exit(1);
}

FILE* file_open_relative(const char* path, const char* mode, const char* zero_arg)
{
	char buffer[IO_BUFFER_SIZE];
	get_path_to_file(buffer, path, zero_arg);
	FILE* fp = fopen(buffer, mode);
	if (!fp)
		die("Coudn't open file");
	return fp;
}

void file_copy(FILE* dest_fp, FILE* src_fp)
{
	if (!src_fp) 
		die("Couldn't open file");

	char buffer[IO_BUFFER_SIZE];
	while(!feof(src_fp)) {
		size_t bytes_read = fread(buffer, 1, IO_BUFFER_SIZE, src_fp);
		if (bytes_read == 0)
			die("Invalid read");
		size_t byte_wrote = fwrite(buffer, 1, bytes_read, dest_fp);
		if (byte_wrote != bytes_read)
			die("Invalid write");
	}
}

int main(int argc, char const *argv[])
{
	FILE* input_fp = file_open_relative("../in.png", "r", argv[0]);
	FILE* out_fp = file_open_relative("../out.png", "w", argv[0]);
	file_copy(out_fp, input_fp);
	if(fclose(input_fp) == EOF)
		die("Invalid close");
	if(fclose(out_fp) == EOF)
		die("Invalid close");
	return 0;
}