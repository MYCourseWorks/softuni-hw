#include <stdio.h>
#include <stdlib.h>

int main() {
	int n = 3, i;
	int a[3], b[3], product[3];

	for (i = 0; i < n; ++i)	{
		scanf("%d", &a[i]);
	}

	for (i = 0; i < n; ++i)	{
		scanf("%d", &b[i]);
	}

	product[0] = a[1] * b[2] - a[2] * b[1];
	product[1] = a[2] * b[0] - a[0] * b[2];
	product[2] = a[0] * b[1] - a[1] * b[0];

	printf("[%d, %d, %d]\n", product[0], product[1], product[2]);
	return 0;
}