#include <stdio.h>
#include <stdlib.h>

int main() {
	int n, i;
	scanf("%d", &n);
	
	int* arr = malloc(n * sizeof(int));
	for (i = 0; i < n; ++i) {
		int current;
		scanf("%d", &current);
		arr[i] = current;
	}

	for (i = n - 1; i >= 0; --i) {
		printf("%d ", arr[i]);
	}

	printf("\n");
	return 0;
}