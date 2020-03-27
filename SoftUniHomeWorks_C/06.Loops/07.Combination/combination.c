#include <stdio.h>

int main() {
	int i, n, k; 
	printf("n = ");
	scanf("%d", &n);
	printf("k = ");
	scanf("%d", &k);

	// you don't need 2 loops !

	int nmkfs = 1; // n minus k in factorial sequence.
	unsigned long long sum = 1;
	for (i = k + 1; i <= n; ++i) {
		sum = (sum * i) / nmkfs;
		nmkfs++;
	}

	printf("%llu\n", sum);
	return 0;
}