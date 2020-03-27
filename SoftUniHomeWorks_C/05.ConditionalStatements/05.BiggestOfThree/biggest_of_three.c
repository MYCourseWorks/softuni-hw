#include <stdio.h>

int main() {
	double a, b, c;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);
	printf("c = ");
	scanf("%lf", &c);

	double biggest = a;
	if (b > biggest)
		biggest = b;
	if (c > biggest)
		biggest = c;

	printf("%.1f\n", biggest);
	return 0;
}