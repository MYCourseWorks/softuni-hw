#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#include "../../lib/string_builder.h"

#define IO_BUFFER_SIZE 4096

static FILE* input_fp;
static FILE* out_fp;
static int line_counter = 1;
static int on_first_line = 1;

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

void read_file_to_end(FILE* fp, void(*callback)(char*))
{
	if (!fp) 
		die("Couldn't write to file");

	char buffer[100];
	while(!feof(fp)) {
		memset(buffer, 0, 100);
		fgets(buffer, 100, fp);
		callback(buffer);
	}
}

int digit_count(int n) {
	n = abs(n);
	int len = ceil(log(n + 1) / log(10));
	return len;
}

int int_to_str(char* buffer, int n)
{
	int i = 1;
	int d_count = digit_count(n);
	while(n > 0) {
		int curr_digit = n % 10;
		buffer[d_count - i] = curr_digit + '0';
		n /= 10;
		i++;
	}

	return d_count;
}

void put_line_numbers(char* dest, const char* src, int len)
{
	int dest_i = 0;
	int src_i = 0;
	
	if (on_first_line == 1) {
		dest[dest_i] = line_counter + '0';
		dest_i++;
		dest[dest_i] = ' ';
		dest_i++;
		line_counter++;
		on_first_line = 0;
	}

	for (src_i = 0; src_i < len; src_i++, dest_i++) {
		dest[dest_i] = src[src_i];
		if (src[src_i] == '\n') {
			char num_buffer[20];
			int n_b_size = int_to_str(num_buffer, line_counter);
			num_buffer[n_b_size] = '\0';
			dest = strcat(dest, num_buffer);
			dest_i += n_b_size + 1;
			dest[dest_i] = ' ';
			line_counter++;
		}

	}
}

void modify_file(char* buffer)
{
	int len = strlen(buffer);
	char* buff_with_line_numbers = calloc(len * 2, sizeof(char));
	if (!buff_with_line_numbers)
		die("Malloc fail");
	
	put_line_numbers(buff_with_line_numbers, buffer, len);
	int line_buff_len = strlen(buff_with_line_numbers);
	size_t bytes = fwrite(buff_with_line_numbers, sizeof(char), line_buff_len, out_fp);
	if (bytes != line_buff_len)
		die("Write failed");

	free(buff_with_line_numbers);
}

int main(int argc, char const *argv[])
{
	input_fp = file_open_relative("../file.c", "r", argv[0]);
	out_fp = file_open_relative("../modified.c", "w", argv[0]);

	read_file_to_end(input_fp, modify_file);

	if (fclose(input_fp) == EOF)
		die("Coun't colse file");
	if (fclose(out_fp) == EOF)
		die("Coun't colse file");
	return 0;
}