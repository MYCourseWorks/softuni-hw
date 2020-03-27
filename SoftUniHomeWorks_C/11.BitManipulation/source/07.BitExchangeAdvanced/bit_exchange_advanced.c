#include <stdio.h>
#include <stdlib.h>

#include "../../lib/bin_operations.h"

int main()
{
	unsigned int n;
	int p, q, k, i, smaller_i, bigger_i;
	scanf("%u %d %d %d", &n, &p, &q, &k);
	smaller_i = p > q ? q : p;
	bigger_i = p > q ? p : q;

	if (q + k > 32 || q < 0) {
		printf("out of range\n");
		exit(1);
	} else if (p + k > 32 || q < 0) {
		printf("out of range\n");
		exit(1);
	} else if (smaller_i + k > bigger_i) {
		printf("overlapping\n");
		exit(1);
	}

	for (i = 0; i < k; ++i) {
		n = exchange_bits(n, p + i, q + i);
	}

	printf("%u\n", n);
	return 0;
}