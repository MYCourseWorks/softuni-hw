#include <stdio.h>

#include "../../lib/bin_operations.h"

int main()
{
	unsigned int n = 1140867093;
	scanf("%u", &n);
	n = exchange_bits(n, 3, 24);
	n = exchange_bits(n, 4, 25);
	n = exchange_bits(n, 5, 26);
	printf("%u\n", n);
	return 0;
}