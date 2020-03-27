#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void swap(void* a, void* b, size_t elem_size) {
	char* buffer = malloc(elem_size);
	memcpy(buffer, a, elem_size);
	memcpy(a, b, elem_size);
	memcpy(b, buffer, elem_size);
	free(buffer);
}

int main() {
	int a = 3;
	int b = 2;
	printf("a = %d, b = %d\n", a, b);
	swap(&a, &b, sizeof(int));
	printf("a = %d, b = %d\n", a, b);
	return 0;
}