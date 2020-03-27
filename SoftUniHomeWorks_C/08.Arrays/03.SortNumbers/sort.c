#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void selection_sort(void* arr, int len, 
	size_t elem_size, int(cmp_fn)(void*, void*));
void swap(void* a, void* b, size_t elem_size);
int int_cmp(void* a, void* b);

void selection_sort(void* arr, 
					int len, 
					size_t elem_size, 
					int(cmp_fn)(void*, void*)) 
{
	for (int i = 0; i < len; i++) {
		int flag = i;
		void* smallest_addr = (char*)arr + i * elem_size;
		for (int j = i; j < len; j++) {
			void* curr_elem_addr = (char*)arr + j * elem_size;
			if (cmp_fn(smallest_addr, curr_elem_addr) > 0) {
				smallest_addr = (char*)arr + j * elem_size;
				flag = j;
			}
		}

		if (flag != i) {
			void* first_addr = (char*)arr + i * elem_size;
			void* second_addr = (char*)arr + flag * elem_size;
			swap(first_addr, second_addr, elem_size);
		}
	}
}

void swap(void* a, void* b, size_t elem_size) {
	char* buffer = malloc(elem_size);
	memcpy(buffer, a, elem_size);
	memcpy(a, b, elem_size);
	memcpy(b, buffer, elem_size);
	free(buffer);
}

int int_cmp(void* a, void* b) {
	return *(int*)a - *(int*)b;
}

int main() {
	int n = 0;
	printf("n = ");
	scanf("%d", &n);

	int* arr = malloc(sizeof(int) * n);
	for (int i = 0; i < n; ++i) {
		int current;
		scanf("%d", &current);
		arr[i] = current;
	}

	selection_sort(arr, n, sizeof(int), int_cmp);	
	
	for (int i = 0; i < n; ++i) {
		printf("%d ", arr[i]);
	}

	printf("\n");
	free(arr);
	return 0;
}