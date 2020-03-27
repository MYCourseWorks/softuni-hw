#include <stdio.h>
#include <stdlib.h>

int main() {
	int n, scalar, i;
	scanf("%d", &n);
	scanf("%d", &scalar);
	
	int* arr = malloc(n * sizeof(int));
	for (i = 0; i < n; ++i)	{
		scanf("%d", &arr[i]);
	}

	for (i = 0; i < n; ++i) {
		printf("%d ", arr[i] * scalar);
	}

	printf("\n");
	free(arr);
	return 0;
}