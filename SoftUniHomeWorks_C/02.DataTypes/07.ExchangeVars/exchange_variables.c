#include <stdio.h>

//void swap (int * a, int * b);

void swap (int * a, int * b) {
	*a ^= *b;
	*b ^= *a;
	*a ^= *b;
}

int main() {
	int a = 2;
	int b = 3;

	printf("a = %d, b = %d\n", a, b);
	swap(&a, &b);
	printf("a = %d, b = %d\n", a, b);
	return 0;
}