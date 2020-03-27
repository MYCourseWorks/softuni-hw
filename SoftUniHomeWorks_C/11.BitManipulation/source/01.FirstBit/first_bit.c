#include <stdio.h>

#include "../../lib/bin_operations.h"

int main()
{
	int n = 0;
	scanf("%d", &n);
	printf("%d\n", get_bit(n, 1));
	return 0;
}