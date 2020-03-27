#include "generics.h"

bool contains(void* arr, 
			  void* key, 
			  int len, 
			  size_t type_size, 
			  int(*cmp_fn)(void* a, void* b)) 
{
	int i;
	for (i = 0; i < len; ++i) {
		if (cmp_fn(key, (char*)arr + i * type_size) == 0) {
			return true;
		}
	}

	return false;
}

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

int binary_search(void* sorted_arr, 
				  void* key, 
				  int len, 
				  int type_size,
				  int(*cmp_fn)(void* a, void* b)) 
{
	if (len < 0)
		return -1;

	int mid = len / 2;
	int low = 0;
	int high = len;
	int key_index = 0;
	bool done = false;

	while(!done) {
		void* curr_elem = (char*)sorted_arr + mid * type_size;

		if (cmp_fn(curr_elem, key) == 0) {
			key_index = mid;
			done = true;
		} else if (cmp_fn(curr_elem, key) < 0) {
			low = mid;
			if(low + 1 == high) {
				key_index = -1;
				done = true;
			}
		} else if (cmp_fn(curr_elem, key) > 0) {
			high = mid;
			if(high == low) {
				key_index = -1;
				done = true;
			}
		}

		mid = (high - low) / 2 + low;
	}

	return key_index;
}

void selection_sort(void* arr, 
					int len, 
					size_t elem_size, 
					int(*cmp_fn)(void*, void*)) 
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

void swap(void* a, 
	      void* b, 
	      size_t elem_size)
{
	char* buffer = malloc(elem_size);
	memcpy(buffer, a, elem_size);
	memcpy(a, b, elem_size);
	memcpy(b, buffer, elem_size);
	free(buffer);
}

void get_max(void* arr, 
			int len, 
			int type_size,
			void* max,
			int(*cmp_fn)(void* a, void* b)) 
{
	if (arr == NULL || len < 1) {
		return;
	}
	
	int i;
	memcpy(max, (char*)arr, type_size);
	for (i = 1; i < len; ++i) {
		void* current = (char*)arr + i * type_size;
		if (cmp_fn(max, current) < 0) {
			memcpy(max, current, type_size);
		}
	}
}

void get_min(void* arr,
			 int len,
			 int type_size,
			 void* min,
			 int(*cmp_fn)(void* a, void* b))
{
	if (arr == NULL || len < 1) {
		return;
	}

	int i;
	memcpy(min, (char*)arr, type_size);
	for (i = 1; i < len; ++i) {
		void* current = (char*)arr + i * type_size;
		if (cmp_fn(min, current) > 0) {
			memcpy(min, current, type_size);
		}
	}
}

void arr_print(void* arr, 
			   int len,
			   int type_size,
			   void(*print_fn)(void* a)) 
{
	if (arr == NULL || len < 1)
		return;

	int i;
	for (i = 0; i < len; ++i) {
		print_fn((char*)arr + i * type_size);
	}
}	