#include <stdio.h>

#include "../../lib/bin_operations.h"

int main()
{
	int n = 0, p = 0;
	scanf("%d", &n);
	scanf("%d", &p);
	printf("%d\n", set_bit(n, p, 0));
	return 0;
}