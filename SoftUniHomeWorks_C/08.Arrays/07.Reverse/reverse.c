#include <stdio.h>
#include <stdlib.h>

void arr_reverse(int* arr, int len) {
	int i, j;
	for (i = 0, j = len - 1; i < j; i++, j--) {
		int tmp = arr[i];
		arr[i] = arr[j];
		arr[j] = tmp;
	}
}

int main() {
	int n, i;
	scanf("%d", &n);

	int* arr = malloc(n * sizeof(int));
	for (i = 0; i < n; ++i) {
		scanf("%d", &arr[i]);
	}

	arr_reverse(arr, n);

	for (i = 0; i < n; ++i) {
		printf("%d ", arr[i]);
	}

	printf("\n");
	free(arr);
	return 0;
}