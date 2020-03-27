#include <stdio.h>

int main() {
	int n, i; 
	double sum, curr;
	printf("n = ");
	scanf("%d", &n);

	for (i = 1; i <= n; ++i) {
		printf("give me %d number = ", i);
		scanf("%lf", &curr);
		sum += curr;
	}

	printf("sum = %.1f\n", sum);
	return 0;
}