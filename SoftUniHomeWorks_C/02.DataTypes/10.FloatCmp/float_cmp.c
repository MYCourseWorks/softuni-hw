#include <stdio.h>
#include <math.h>

int main() {
	double a, b, eps = 0.000001;

	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);

	printf("are they equal? ");
	if (fabs(a - b) < eps) {
		printf("true\n");
	} else {
		printf("false\n");
	}

	return 0;
}