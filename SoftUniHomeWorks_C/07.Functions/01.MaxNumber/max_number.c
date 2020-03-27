#include <assert.h>
#include <stdio.h>

int get_max(int* arr, int n) {
	assert(arr != NULL);
	int max = arr[0];
	for (int i = 1; i < n; ++i) {
		if (max < arr[i]) {
			max = arr[i];
		}
	}

	return max;
}

int main() {
	int arr[2];
	printf("a = ");
	scanf("%d", &arr[0]);
	printf("b = ");
	scanf("%d", &arr[1]);
	printf("max = %d\n", get_max(arr, 2));
	return 0;
}