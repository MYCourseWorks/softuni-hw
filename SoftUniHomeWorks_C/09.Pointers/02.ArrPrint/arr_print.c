#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() {
	int arr[] = {1, 2, 3, 4, 5};
	int size = sizeof(arr) / sizeof(int);
	int i = 0;

	for (i = 0; i < size; ++i) {
		printf("%d ", *(arr + i));
	}

	printf("\n");
	return 0;
}