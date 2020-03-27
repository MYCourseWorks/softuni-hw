#include <stdio.h>

#include "arr_functions.h"

int main() {
	int arr[] = {1, 2, 3, 4, 5};
	int len = sizeof(arr) / sizeof(int);
	int max = get_max(arr, len);
	int min = get_min(arr, len);
	int sum = get_sum(arr, len);
	int avg = get_avg(arr, len);

	printf("int get_max(int* arr, int n), \n");
	printf("\t max test 1 %s\n", max == 5 ? "pass" : "fail");
	printf("int get_min(int* arr, int n), \n");
	printf("\t min test 1 %s\n", min == 1 ? "pass" : "fail");
	printf("int get_sum(int* arr, int n), \n");
	printf("\t sum test 1 %s\n", sum == 15 ? "pass" : "fail");
	printf("int get_avg(int* arr, int n), \n");
	printf("\t avg test 1 %s\n", avg == 3 ? "pass" : "fail");
	printf("bool arr_contains(int* arr, int n, int elem)\n");
	printf("\t contains test 1 %s\n", 
		arr_contains(arr, len, 2) == true ? "pass" : "fail");
	printf("\t contains test 2 %s\n", 
		arr_contains(arr, len, 7) == false ? "pass" : "fail");
	printf("void arr_clear(int* arr, int n)\n");
	arr_clear(arr, len);
	printf("\t clear test 1 %s\n", 
		arr[0] == 0 && arr[1] == 0 &&
		arr[2] == 0 && arr[3] == 0 &&
		arr[4] == 0 ? "pass" : "fail");

	int arr_1[] = {1, 2, 3};
	int arr_2[] = {4, 5};
	int* merge = arr_merge(arr_1, 3,  arr_2, 2);
	printf("int* arr_merge(int* arr_1, int n1, int* arr_2, int n2)\n");
	printf("\t merge test 1 %s\n", 
		merge[0] == 1 && merge[1] == 2 &&
		merge[2] == 3 && merge[3] == 4 &&
		merge[4] == 5  ? "pass" : "fail");
	free(merge);

	int* null_arr = NULL;
	merge = arr_merge(arr_1, 3, null_arr, 70);
	printf("\t merge test 2 %s\n", 
		merge[0] == 1 && merge[1] == 2 &&
		merge[2] == 3 ? "pass" : "fail");
	free(merge);

	return 0;
}