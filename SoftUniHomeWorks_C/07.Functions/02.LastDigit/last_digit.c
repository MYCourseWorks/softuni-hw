#include <stdio.h>

int last_digit(int n) {
	return n % 10;
}

int main() {
	int n;
	printf("n = ");
	scanf("%d", &n);
	printf("last digit = %d\n", last_digit(n));
	return 0;
}