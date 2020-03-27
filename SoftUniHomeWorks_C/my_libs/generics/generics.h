#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

#ifndef GENERICS_H_
#define GENERICS_H_ 1

bool contains(void* arr, void* key, int len, 
	size_t type_size, int(*cmp_fn)(void* a, void* b));

int linear_search(void* arr, void* key, int len, 
	size_t type_size, int (*cmp_fn)(void*, void*));

int binary_search(void* sorted_arr, void* key, int len, 
	int type_size, int(*cmp_fn)(void* a, void* b));

void selection_sort(void* arr, int len,
	size_t elem_size, int(cmp_fn)(void*, void*));

void swap(void* a, void* b, size_t elem_size);

void get_max(void* arr, int len, int type_size,
	void* max, int(*cmp_fn)(void* a, void* b));

void get_min(void* arr, int len, int type_size, 
	void* min, int(*cmp_fn)(void* a, void* b));

void arr_print(void* arr, int len, int type_size,
	void(*print_fn)(void* a)); 

#endif