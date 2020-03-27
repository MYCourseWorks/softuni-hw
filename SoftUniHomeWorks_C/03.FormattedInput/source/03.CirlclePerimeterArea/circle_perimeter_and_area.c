#include <stdio.h>
#include <math.h>

double calc_circle_p(double r) {
	return 2 * M_PI * r;
}

double calc_cirlce_area(double r) {
	return r * r * M_PI; 
}

int main() {
	double r;
	printf("r = ");
	scanf("%lf", &r);
	printf("Perimeter = %.2lf\n", calc_circle_p(r));
	printf("Area = %.2lf\n", calc_cirlce_area(r));

	return 0;
}