#include <stdio.h>

int main() {
	double a, b, tmp;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);

	if (a > b) {
		tmp = a;
		a = b;
		b = tmp;
	}

	printf("a = %.1f b = %.1f\n", a, b);
	return 0;
}