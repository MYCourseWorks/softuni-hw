#include <assert.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

#ifndef ARR_FUNCTIONS_H_
#define ARR_FUNCTIONS_H_ 1

int get_max(int* arr, int n);
int get_min(int* arr, int n);
int get_sum(int* arr, int n);
int get_avg(int* arr, int n);
void arr_clear(int* arr, int n);
bool arr_contains(int* arr, int n, int elem);
int* arr_merge(int* arr_1, int n1, int* arr_2, int n2);

#endif