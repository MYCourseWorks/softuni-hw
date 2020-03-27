#include <stdio.h>
#include <assert.h>
#include <stdlib.h>

int find_min(int* arr, int size) {
	assert(size > 0 || arr != NULL);
	int min = arr[0];
	int i;
	for (i = 0; i < size; ++i) {
		if (min > arr[i]) {
			min = arr[i];
		} 
	}

	return min;
}

int find_max(int* arr, int size) {
	assert(size > 0 || arr != NULL);
	int max = arr[0];
	int i;
	for (i = 0; i < size; ++i) {
		if (max < arr[i]) {
			max = arr[i];
		}
	}

	return max;
}

int calc_sum(int* arr, int size) {
	assert(size > 0 || arr != NULL);
	int sum = 0;
	int i;
	for (i = 0; i < size; ++i) {
		sum += arr[i];
	}

	return sum;
}

double calc_avg(int* arr, int size) {
	assert(size > 0 || arr != NULL);
	double avg = 0;
	int i;
	for (i = 0; i < size; ++i) {
		avg += arr[i];
	}

	return avg / size;
}

int main() {
	int n, i;
	printf("n = ");
	scanf("%d", &n);

	int* arr = malloc(sizeof(int) * n);
	for (i = 0; i < n; ++i) {
		printf("%d number = ", i);
		scanf("%d", &arr[i]);
	}

	printf("min = %.2f\n", (double)find_min(arr, n));
	printf("max = %.2f\n", (double)find_max(arr, n));
	printf("sum = %.2f\n", (double)calc_sum(arr, n));
	printf("avg = %.2f\n", calc_avg(arr, n));

	free(arr);
	return 0;
}