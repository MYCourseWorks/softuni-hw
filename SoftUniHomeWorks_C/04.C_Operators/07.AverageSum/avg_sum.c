#include <stdio.h>

int main() {
	double a, b, c;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);
	printf("c = ");
	scanf("%lf", &c);

	printf("%.5f\n", (a + b + c) / 3);
	return 0;
}