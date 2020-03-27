#include <stdio.h>

int gcd(int a, int b) {
	int remainder = a % b;
	while(remainder > 0) {
		a = b;
		b = remainder;
		remainder = a % b;
	}

	return b;
}

int main() {
	int a, b;
	printf("a = ");
	scanf("%d", &a);
	printf("b = ");
	scanf("%d", &b);
	printf("%d\n", gcd(a, b));	
	return 0;
}