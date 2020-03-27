#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

bool contains(void* arr, 
			  void* key, 
			  int len, 
			  size_t type_size, 
			  bool(*eql_fun)(void* a, void* b)) 
{
	int i;
	for (i = 0; i < len; ++i) {
		if (eql_fun(key, (char*)arr + i * type_size)) {
			return true;
		}
	}

	return false;
}

void swap(void* a, void* b, size_t elem_size) {
	char* buffer = malloc(elem_size);
	memcpy(buffer, a, elem_size);
	memcpy(a, b, elem_size);
	memcpy(b, buffer, elem_size);
	free(buffer);
}

void selection_sort(void* arr, 
					int len, 
					size_t elem_size, 
					int(cmp_fn)(void*, void*)) 
{	
	int i, j;
	for (i = 0; i < len; i++) {
		int flag = i;
		void* smallest_addr = (char*)arr + i * elem_size;
		for (j = i; j < len; j++) {
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

int int_cmp(void* a, void* b) {
	return *(int*)a - *(int*)b;
}

bool int_eql(void* a, void* b) {
	return *(int*)a - *(int*)b == 0;
}

int main() {
	int n, k, i;
	scanf("%d", &n);
	scanf("%d", &k);
	int* first_arr = malloc(n * sizeof(int));
	int* second_arr = malloc(k * sizeof(int)); 

	for (i = 0; i < n + k; ++i) {
		if (i < n) {
			scanf("%d", &first_arr[i]);
		} else {
			scanf("%d", &second_arr[i - n]);
		}
	}

	int* unique_arr = malloc(n * k * sizeof(int));
	int unique_index = 0;

	for (i = 0; i < n; ++i) {
		int key = first_arr[i];
		bool already_stored = contains(unique_arr, &key, unique_index, 
			sizeof(int), int_eql) == false;

		if (already_stored) {
			unique_arr[unique_index] = key;
			unique_index++;
		}
	}

	for (i = 0; i < k; ++i) {
		int key = second_arr[i];
		bool already_stored = contains(unique_arr, &key, unique_index, 
			sizeof(int), int_eql) == false;

		if (already_stored) {
			unique_arr[unique_index] = key;
			unique_index++;
		}
	}

	selection_sort(unique_arr, unique_index, sizeof(int), int_cmp);
	
	printf("\n");	
	for (i = 0; i < unique_index; ++i) {
		printf("%d ", unique_arr[i]);
	}

	printf("\n");
	free(first_arr);
	free(second_arr);
	return 0;
}