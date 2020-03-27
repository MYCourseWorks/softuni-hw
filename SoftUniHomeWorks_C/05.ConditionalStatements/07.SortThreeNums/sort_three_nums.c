#include <stdio.h>

int main() {
	double a, b, c;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);
	printf("c = ");
	scanf("%lf", &c);

	double first, second, third;
	if (a >= b && a >= c) {
		first = a;
		if (b >= c) {
			second = b;
			third = c;
		} else {
			second = c;
			third = b;
		}
	} else if (b >= a && b >= c) {
		first = b;
		if (a >= c) {
			second = a;
			third = c;
		} else {
			second = c;
			third = a;
		}
	} else if (c >= a && c >= b) {
		first = c;
		if (a >= b) {
			second = a;
			third = b;
		} else {
			second = b;
			third = a;
		}
	}

	printf("%.1f %.1f %.1f\n", first, second, third);
	return 0;
}