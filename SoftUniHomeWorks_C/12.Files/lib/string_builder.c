#include "string_builder.h"

static void sb_resize(string_builder* sb)
{
	sb->_len *= 2;
	sb->_str_p = (char*)realloc(sb->_str_p, sb->_len);
	assert(sb->_str_p);
}

void sb_init(string_builder* sb)
{
	sb->_str_p = (char*)malloc(SB_DEFAULT_LEN);
	sb->_len = SB_DEFAULT_LEN;
	sb->count = 0;
}

void sb_free(string_builder* sb)
{
	sb->count = 0;
	sb->_len = 0;
	free(sb->_str_p);
}

void sb_clear(string_builder* sb)
{
	sb->count = 0;
}

void sb_append(string_builder* sb, const char* str)
{
	if (str == NULL)
		return;

	int str_len = strlen(str);
	if (sb->count + str_len >= sb->_len) {
		sb->_len += str_len;
		sb_resize(sb);
	}

	memcpy(sb->_str_p + sb->count, str, str_len);
	sb->count += str_len;
}

void sb_append_char(string_builder* sb, char c)
{
	if (sb->count + 1 >= sb->_len)
		sb_resize(sb);

	sb->_str_p[sb->count] = c;
	sb->count++;
}

char* sb_to_string(string_builder* sb)
{
	char* copy = malloc(sb->count + 1);
	memcpy(copy, sb->_str_p, sb->count);
	copy[sb->count] = '\0';
	return copy;
}

char* sb_substr(string_builder* sb, size_t start, size_t len)
{
	assert(start < sb->count);
	assert(start >= 0 && len > 0);
	if (start + len > sb->count)
		len = sb->count - start;

	char* sub_str = malloc(len + 1);
	memcpy(sub_str, sb->_str_p + start, len);
	sub_str[len] = '\0';
	return sub_str;
}

char* sb_give_control_of_str(string_builder* sb)
{
	char* str_p = sb->_str_p;
	str_p[sb->count] = '\0';
	sb_init(sb);
	return str_p;
}

char sb_get_char(string_builder* sb, size_t pos)
{
	assert(pos > 0 && pos < sb->count);
	return sb->_str_p[pos];
}

void sb_copy(string_builder* dest, string_builder* src)
{
	dest->_len = src->_len;
	dest->count = src->count;
	dest->_str_p = malloc(src->_len);
	memcpy(dest->_str_p, src->_str_p, src->count);
}

void sb_cut(string_builder* sb, size_t start, size_t end)
{
	assert(start >= 0 && start < end);
	assert(end > 0 && end <= sb->count);
	sb->count = end - start;
	memmove(sb->_str_p, sb->_str_p + start, sb->count);
}

bool sb_equals(string_builder* first, string_builder* second)
{
	return	first->count == second->count &&
		strncmp(first->_str_p, second->_str_p, first->count) == 0;
}

bool sb_equals_str(string_builder* sb, const char* str)
{
	return sb->count == strlen(str) &&
		strncmp(sb->_str_p, str, sb->count) == 0;
}

int sb_index_of(string_builder* sb, const char* str)
{
	if (str == NULL)
		return -1;

	int str_len = strlen(str);
	for (int i = 0; i <= (int)sb->count - str_len; i++) {
		if (strncmp(sb->_str_p + i, str, str_len) == 0)
			return i;
	}

	return -1;
}

int sb_last_index_of(string_builder* sb, const char* str)
{
	if (str == NULL)
		return -1;

	int str_len = strlen(str);
	int end_index = sb->count - str_len;
	while (end_index >= 0) {
		if (strncmp(sb->_str_p + end_index, str, str_len) == 0)
			return end_index;

		end_index--;
	}

	return -1;
}

void sb_reverse(string_builder* sb)
{
	for (int i = 0, j = sb->count - 1; i < j; i++, j--) {
		char tmp = sb->_str_p[i];
		sb->_str_p[i] = sb->_str_p[j];
		sb->_str_p[j] = tmp;
	}
}

void sb_trim_left(string_builder* sb)
{
	if (sb->count == 0)
		return;

	int trim_size = 0;
	while (isspace(sb->_str_p[trim_size])) {
		trim_size++;
	}

	if (trim_size == 0)
		return;

	sb->count -= trim_size;
	memmove(sb->_str_p, sb->_str_p + trim_size, sb->count);
}

void sb_trim_right(string_builder* sb)
{
	if (sb->count == 0)
		return;

	int trim_index = sb->count - 1;
	while (isspace(sb->_str_p[trim_index])) {
		trim_index--;
	}

	if (trim_index == sb->count - 1)
		return;

	sb->count = trim_index + 1;
}

void sb_trim_left_with(string_builder* sb, const char char_set[])
{
	if (sb->count == 0)
		return;

	int trim_size = 0;
	while (strchr(char_set, sb->_str_p[trim_size]) != NULL) {
		trim_size++;
	}

	if (trim_size == 0)
		return;

	sb->count -= trim_size;
	memmove(sb->_str_p, sb->_str_p + trim_size, sb->count);
}

void sb_trim_right_with(string_builder* sb, const char char_set[])
{
	if (sb->count == 0)
		return;

	int trim_index = sb->count - 1;
	while (strchr(char_set, sb->_str_p[trim_index]) != NULL) {
		trim_index--;
	}

	if (trim_index == sb->count - 1)
		return;

	sb->count = trim_index + 1;
}

void sb_remove(string_builder *sb, const char* str)
{
	if (str == NULL || sb->count == 0)
		return;

	char* filtered_str = malloc(sb->_len);
	int remove_size = 0;
	int str_len = strlen(str);

	for (size_t i = 0; i < sb->count; ++i) {
		if (strncmp(sb->_str_p + i, str, str_len) == 0 &&
			i <= sb->count - str_len) {
			i += str_len - 1;
		} else {
			filtered_str[remove_size] = sb->_str_p[i];
			remove_size++;
		}
	}

	free(sb->_str_p);
	sb->_str_p = filtered_str;
	sb->count = remove_size;
}

void sb_remove_all(string_builder *sb, const char char_set[])
{
	if (char_set == NULL || sb->count == 0)
		return;

	char* filtered_str = malloc(sb->_len);
	int filter_index = 0;

	for (size_t i = 0; i < sb->count; i++) {
		if (strchr(char_set, sb->_str_p[i]) == NULL) {
			filtered_str[filter_index] = sb->_str_p[i];
			filter_index++;
		}
	}

	free(sb->_str_p);
	sb->_str_p = filtered_str;
	sb->count = filter_index;
}

void sb_replace(string_builder *sb, const char* old_val, const char* new_val)
{
	if (old_val == NULL || sb->count == 0)
		return;

	string_builder new_sb;
	sb_init(&new_sb);
	int old_val_len = strlen(old_val);

	for (size_t i = 0; i < sb->count; i++) {
		if (strncmp(sb->_str_p + i, old_val, old_val_len) == 0 &&
				i <= sb->count - old_val_len) {
			sb_append(&new_sb, new_val);
			i += old_val_len - 1;
		}
		else {
			sb_append_char(&new_sb, sb->_str_p[i]);
		}
	}

	sb_free(sb);
	*sb = new_sb;
}

static void sb_get_splits(string_builder* sb, char** dest[], int* splits_count)
{
	int dest_curr_size = 10;
	int split_n = 0;
	*dest = malloc(dest_curr_size * sizeof(char*));
	if(*dest == NULL)
		return;

	int curr_split_len = 0;
	int curr_split_i = 0;

	for (size_t i = 0; i < sb->count; i++) {
		if (sb->_str_p[i] == '\0') {
			if (split_n + 1 > dest_curr_size) {
				dest_curr_size *= 2;
				*dest = realloc(*dest, dest_curr_size * sizeof(char*));
				if (*dest == NULL)
					return;
			}

			char* curr_sub_str = sb_substr(sb, curr_split_i, curr_split_len);
			(*dest)[split_n] = curr_sub_str;
			split_n++;
			curr_split_len = 0;
			curr_split_i = i + 1;
		}

		curr_split_len++;
	}

	*splits_count = split_n;
}

void sb_debug_print(string_builder* sb)
{
	for (size_t i = 0; i < sb->count; i++) {
		printf("[%lu] = %d %c\n", i, sb->_str_p[i], sb->_str_p[i]);
	}
}

char** sb_split(int* splits_count, const char* raw_str, const char* delimiters)
{
	string_builder sb;
	sb_init(&sb);
	sb_append(&sb, raw_str);
	char* raw_str_copy = sb_give_control_of_str(&sb);

	char* curr_split = strtok(raw_str_copy, delimiters);
	while (curr_split) {
		sb_append(&sb, curr_split);
		sb_append_char(&sb, '\0');
		curr_split = strtok(NULL, delimiters);
	}

	char** split_str_arr = NULL;
	sb_get_splits(&sb, &split_str_arr, splits_count);
	free(raw_str_copy);
	sb_free(&sb);
	return split_str_arr;
}