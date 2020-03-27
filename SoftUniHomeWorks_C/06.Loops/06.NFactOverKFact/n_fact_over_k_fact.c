#include <stdio.h>

int main() {
	int i;
	unsigned long long n, k, sum = 1; 
	printf("n = ");
	scanf("%llu", &n);
	printf("k = ");
	scanf("%llu", &k);

	for (i = k + 1; i <= n; ++i) {
		sum *= i;
	}

	printf("%llu\n", sum);
	return 0;
}