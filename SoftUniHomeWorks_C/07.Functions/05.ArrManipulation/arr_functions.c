#include "arr_functions.h"

int get_max(int* arr, int n) {
	assert(arr != NULL);
	
	int i;
	int max = arr[0];
	for (i = 1; i < n; ++i) {
		if (max < arr[i]) {
			max = arr[i];
		}
	}

	return max;
}

int get_min(int* arr, int n) {
	assert(arr != NULL);
	
	int i;
	int min = arr[0];
	for (i = 1; i < n; ++i) {
		if (min > arr[i]) {
			min = arr[i];
		}
	}

	return min;	
}

int get_sum(int* arr, int n) {
	assert(arr != NULL);
	
	int i;
	int sum = 0;
	for (i = 0; i < n; ++i) {
		sum += arr[i];
	}

	return sum;	
}

int get_avg(int* arr, int n) {
	assert(arr != NULL);
	
	int i;
	int avg = 0;
	for (i = 0; i < n; ++i) {
		avg += arr[i];
	}

	return avg / n;	
}

void arr_clear(int* arr, int n) {
	int i;
	for (i = 0; i < n; ++i) {
		arr[i] = 0;
	}
}

bool arr_contains(int* arr, int n, int elem) {
	int i;
	bool contains = false;

	for (i = 0; i < n; ++i) {
		if (arr[i] == elem) {
			contains = true;
			break;
		}
	}

	return contains;
}

int* arr_merge(int* arr_1, int n1, int* arr_2, int n2) {
	int i, counter = 0;
	int* merged_arr = malloc(sizeof(int) * n1 * n2);

	if (arr_1 != NULL) {
		for (i = 0; i < n1; ++i) {
			merged_arr[counter] = arr_1[i];
			counter++;
		}
	}

	if (arr_2 != NULL) {
		for (i = 0; i < n2; ++i) {
			merged_arr[counter] = arr_2[i];
			counter++;
		}	
	}

	return merged_arr;
}