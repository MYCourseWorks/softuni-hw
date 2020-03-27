#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void free_str_arr(char** str_arr, int len) 
{
	int i;
	for (i = 0; i < len; ++i) {
		free(str_arr[i]);
	}

	free(str_arr);
}

int main()
{
	int n = 0, i = 0;
	scanf("%d", &n);
	char** str_arr = malloc(n * sizeof(char*));
	
	for (i = 0; i < n; ++i) {
		char buffer[100];
		scanf("%s", buffer);
		str_arr[i] = strdup(buffer);
	}

	int max_sequence_len = 1;
	int max_last_i = 0;
	int curr_sequence_len = 1;
	
	for (i = 1; i < n; ++i) {
		if (strcmp(str_arr[i - 1], str_arr[i]) == 0) {
			curr_sequence_len++;
		} else {
			curr_sequence_len = 1;
		}

		if (max_sequence_len < curr_sequence_len) {
			max_sequence_len = curr_sequence_len; 
			max_last_i = i;
		}
	}

	printf("\n%d\n", max_sequence_len);
	int max_start_i = max_last_i - max_sequence_len + 1;
	for (i = 0; i < max_sequence_len; ++i) {
		printf("%s\n", str_arr[i + max_start_i]);
	}

	free_str_arr(str_arr, n);
	return 0;
}