#include <stdio.h>

int main() {
	double a, b, h;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);
	printf("h = ");
	scanf("%lf", &h);
	printf("%.2f\n", (a + b) * h / 2);	
	return 0;
}