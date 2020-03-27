#include <stdio.h>

#include "../../lib/bin_operations.h"

int main()
{
	int n = 0, p = 0, v = 0;
	scanf("%d %d %d", &n, &p, &v);
	printf("%d\n", set_bit(n, p, v));
	return 0;
}
