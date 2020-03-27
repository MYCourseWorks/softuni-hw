#include <stdio.h>

int new_integer() {
	int a = 5;
	return a;
}

// gives a warning when compiling.
int* new_integer_ptr() {
	int a = 5;
	return &a;
}

int main() {
	int a = new_integer();
	int* b = new_integer_ptr();

	printf("%d\n", a);
	printf("%d\n", *b);
	return 0;
}