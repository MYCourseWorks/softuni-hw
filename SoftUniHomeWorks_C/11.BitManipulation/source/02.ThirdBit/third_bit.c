#include <stdio.h>

#include "../../lib/bin_operations.h"

int main()
{
	int n;
	scanf("%d", &n);
	printf("%d\n", get_bit(n, 3));
	return 0;
}