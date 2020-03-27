#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int linear_search(void* arr, 
				  void* key, 
				  int len, 
				  size_t type_size, 
				  int (*cmp_fn)(void*, void*)) 
{
	for (int i = 0; i < len; ++i) {
		void* elem_addr = (char*)arr + i * type_size;
		if (cmp_fn(elem_addr, key) == 0) {
			return i;
		}
	}

	return -1;
}

int int_cmp(void* a, void* b) {
	return *((int*)a) - *((int*)b);
}

int main() {
	int n = 0, k = 0, i = 0;
	char line_buffer[100];
	printf("n = ");
	fgets(line_buffer, 10, stdin);
	if (sscanf(line_buffer, "%d", &n) == 0) {
		printf("Invalid input\n");
		return 1;
	}

	printf("line = ");
	fgets(line_buffer, 100, stdin);
	int* arr = malloc(n * sizeof(int));
	char* current_split = strtok(line_buffer, " ");
	
	while(current_split != NULL) {
		if (i >= n) {
			printf("Invalid input\n");
	 	}

	 	arr[i] = strtol(current_split, NULL, 10);		
	 	current_split = strtok(NULL, " ");
	 	i++;
	}

	printf("k = ");
	fgets(line_buffer, 10, stdin);
	if (sscanf(line_buffer, "%d", &k) == 0) {
		printf("Invalid input\n");
		return 1;
	}

	int index_of_k = linear_search(arr, &k, n, sizeof(int), int_cmp);
	printf("%s\n", index_of_k != -1 ? "yes" : "no");

	free(arr);
	return 0;
}