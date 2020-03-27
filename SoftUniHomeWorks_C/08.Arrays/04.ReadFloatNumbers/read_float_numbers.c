#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include <math.h>

void arr_print(void* arr, int n, size_t type_size, void(print_fn)(void*)) {
	if (n < 1) {
		printf("[ ]");
		return;
	}

	printf("[");
	int i;
	for (i = 0; i < n - 1; ++i) {
		print_fn((char*)arr + i * type_size);
		printf(", ");
	}

	print_fn((char*)arr + i * type_size);
	printf("]");
}

float get_sum_f(float* arr, int n) {
	if (arr == NULL || n < 1)
		return 0;

	int i;
	float sum = 0;
	for (i = 0; i < n; ++i) {
		sum += arr[i];
	}

	return sum;
}

int get_sum(int* arr, int n) {
	if (arr == NULL || n < 1)
		return 0;

	int i;
	int sum = 0;
	for (i = 0; i < n; ++i) {
		sum += arr[i];
	}

	return sum;
}

float get_avg_f(float* arr, int n) {
	if (arr == NULL || n < 1)
		return 0;

	int i;
	float avg = 0;
	for (i = 0; i < n; ++i) {
		avg += arr[i];
	}

	return avg / n;
}

double get_avg(int* arr, int n) {
	if (arr == NULL || n < 1)
		return 0;

	int i;
	double avg = 0;
	for (i = 0; i < n; ++i) {
		avg += arr[i];
	}

	return avg / n;
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

void print_int(void* n) {
	printf("%d", *(int*)n);
}

void print_float(void* n) {
	printf("%.6g", *(float*)n);
}

int int_cmp(void* a, void* b) {
	return *(int*)a - *(int*)b;
}

int float_cmp(void* a, void* b) {
	float diff = *(float*)a - *(float*)b;
	if (diff < 0)
            return -1;
        else if (diff > 0)
            return 1;
        else 
            return 0;
}

int main() {
	int n, i;
	scanf("%d", &n);

	float* arr = malloc(n * sizeof(float));
	for (i = 0; i < n; ++i) {
		scanf("%f", &arr[i]);
	}

	size_t f_len = 2;
	int f_index = 0;
	float* floats = malloc(f_len * sizeof(float));
	int i_index = 0;
	size_t i_len = 2;
	int* ints = malloc(i_len * sizeof(int));

	for (i = 0; i < n; ++i) {
		bool is_integer = arr[i] == ceil(arr[i]);

		if (is_integer) {
			if (i_index == i_len) {
				i_len *= 2;
				ints = realloc(ints, sizeof(int) * i_len);
				if (ints == NULL)
					return 1;
			}

			ints[i_index] = arr[i];
			i_index++;
		}
		else {
			if (f_index == f_len) {
				f_len *= 2;
				floats = realloc(floats, sizeof(int) * f_len);
				if (floats == NULL)
					return 1;
			}

			floats[f_index] = arr[i];
			f_index++;
		}
	}

	free(arr);

	float f_min = 0, f_max = 0, f_sum = 0, f_avg = 0;
	get_min(floats, f_index, sizeof(float), &f_min, float_cmp);
	get_max(floats, f_index, sizeof(float), &f_max, float_cmp);
	f_sum = get_sum_f(floats, f_index);
	f_avg = get_avg_f(floats, f_index);

	arr_print(floats, f_index, sizeof(float), print_float);
	printf(" -> min = %.6g", f_min);
	printf(", max = %.6g", f_max);
	printf(", sum = %.6g", f_sum);
	printf(", avg = %.2f", f_avg);
	printf("\n");

	int i_min = 0, i_max = 0, i_sum = 0; 
	double i_avg = 0;
	get_min(ints, i_index, sizeof(float), &i_min, int_cmp);
	get_max(ints, i_index, sizeof(float), &i_max, int_cmp);
	i_sum = get_sum(ints, i_index);
	i_avg = get_avg(ints, i_index);

	arr_print(ints, i_index, sizeof(int), print_int);
	printf(" -> min = %d", i_min);
	printf(", max = %d", i_max);
	printf(", sum = %d", i_sum);
	printf(", avg = %.2f", i_avg);
	printf("\n");

	free(ints);
	free(floats);
	return 0;
}