#include <stdio.h>

void print_var_fn(int n) {
	printf("%p\n", &n);
}

int main() {
	int n = 5;
	printf("%p\n", &n);
	print_var_fn(n);
	return 0;
}