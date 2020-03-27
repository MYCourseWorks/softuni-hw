#include <stdio.h>

int main() {
	double w, h;
	printf("width = ");
	scanf("%lf", &w);
	printf("height = ");
	scanf("%lf", &h);
	
	printf("p = %.1f\n", 2 * w + 2 * h);
	printf("a = %.1f\n", w * h);
	return 0;
}