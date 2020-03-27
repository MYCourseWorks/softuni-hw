#include <stdio.h>

int main() {
	double a, b, c, d, e;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);
	printf("c = ");
	scanf("%lf", &c);
	printf("d = ");
	scanf("%lf", &d);
	printf("e = ");
	scanf("%lf", &e);

	double biggest = a;
	if (b > biggest)
		biggest = b;
	if (c > biggest)
		biggest = c;
	if (d > biggest)
		biggest = d;
	if (e > biggest)
		biggest = e;

	printf("%.1f\n", biggest);
	return 0;
}