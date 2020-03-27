#include <stdio.h>

int main() {
	double n, x, sum = 1;
	int i;
	printf("n = ");
	scanf("%lf", &n);
	printf("x = ");
	scanf("%lf", &x);
	
	int fact = 1;
	double power = 1;
	for (i = 1; i <= n; ++i) {
        fact *= i;
        power *= x;
        sum += fact / power;
	}

	printf("%.5f\n", sum);
	return 0;
}