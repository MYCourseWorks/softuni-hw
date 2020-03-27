#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void swap(void* a, void* b, size_t type_size) {
	char* buffer = malloc(type_size);
	memcpy(buffer, a, type_size);
	memcpy(a, b, type_size);
	memcpy(b, buffer, type_size);
	free(buffer);
}

void example_1() {
	int a = 5;
	int b = 10;
	printf("a = %d, b = %d\n", a, b);
	swap(&a, &b, sizeof(int));
	printf("a = %d, b = %d\n", a, b);
}

void example_2() {
	char a = 'B';
	char b = '+';
	printf("a = %c, b = %c\n", a, b);
	swap(&a, &b, sizeof(char));
	printf("a = %c, b = %c\n", a, b);
}

void example_3() {
	double d = 3.14, f = 1.23567;
	printf("a = %.f2, b = %.f2", d, f);
	swap(&d, &f, sizeof(double);
	printf("a = %.f2, b = %.f2", d, f);
}

int main() {
	printf("Example 1: \n");
	example_1();
	printf("Example 2: \n");
	example_2();
	printf("Example 3: \n");
	example_3();
	return 0;
}



