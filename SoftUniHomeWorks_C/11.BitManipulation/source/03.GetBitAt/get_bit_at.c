#include <stdio.h>

#include "../../lib/bin_operations.h"

int main()
{
	int n = 0, p = 0;
	scanf("%d", &n);
	scanf("%d", &p);
	printf("digit at %d in %d is %d\n", n, p, get_bit(n, p));
	return 0;
}