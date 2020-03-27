#include <stdio.h>

int main() {
	int n, i;
	printf("n = ");
	scanf("%d", &n);

	if (n > 30) {
		printf("To big for unsigned long long !\n");
		return 1;
	}

	int power_n_fact = 1;
	unsigned long long sum = 1;
	for (i = n + 1; i <= n * 2; ++i) {
		sum = (sum * i) / power_n_fact;
		power_n_fact++;
	}

	sum /= power_n_fact;
	printf("%llu\n", sum);
	return 0;
}