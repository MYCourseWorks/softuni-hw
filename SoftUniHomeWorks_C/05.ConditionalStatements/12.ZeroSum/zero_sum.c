#include <stdio.h>
#include <stdarg.h>

int zero_sum_exists = 0;

void print_if_zero(int n, int len, ...) {
	if (n == 0) {
		zero_sum_exists = 1;
		va_list args;
		va_start(args, len);

		int i;
		for (i = 0; i < len - 1; ++i) {
			printf("%d + ", va_arg(args, int));
		}

		printf("%d = 0", va_arg(args, int));
		printf("\n");
		va_end(args);
	}
}

int arr[5];

void zero_sub_set(int* arr, int len, int index, int sum) {
	if (index == len) {
		printf("%d\n", sum);
		return;
	} else {
		int i;
		for (i = index; i < len; ++i) {
			sum += arr[i];
			zero_sub_set(arr, len, index + 1, sum);
			sum -= arr[i];
		}
	}
}

int main() {
	int arr[] = {3, 1, -7, 35, 22};
	int n = 5;
	int i, j, k, m, l, sum = 0;

	// for (i = 0; i < n; ++i) {
	// 	sum += arr[i];
	// 	for (j = i + 1; j < n; ++j) {
	// 		sum += arr[j];
	// 		print_if_zero(sum, 2, arr[i], arr[j]);
	// 		for (k = j + 1; k < n; ++k) {
	// 			sum += arr[k];
	// 			print_if_zero(sum, 3, arr[i], arr[j], arr[k]);
	// 			for (m = k + 1; m < n; ++m) {
	// 				sum += arr[m];
	// 				print_if_zero(sum, 4, arr[i], arr[j], arr[k], arr[m]);
	// 				for (l = m + 1; l < n; ++l) {
	// 					sum += arr[l];
	// 					print_if_zero(sum, 5, arr[i], arr[j], arr[k], arr[m], arr[l]);
	// 					sum -= arr[l];
	// 				}

	// 				sum -= arr[m];
	// 			}

	// 			sum -= arr[k];
	// 		}

	// 		sum -= arr[j];
	// 	}

	// 	sum -= arr[i];
	// }

	if (zero_sum_exists == 0)
		printf("no zero subset\n");

	return 0;
}