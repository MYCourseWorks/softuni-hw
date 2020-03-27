#include <stdio.h>
#include <stdlib.h>

int main() {
	int n, i;
	scanf("%d", &n);
	
	int* v1 = malloc(n * sizeof(int));
	int* v2 = malloc(n * sizeof(int));

	for (i = 0; i < n; ++i)	{
		scanf("%d", &v1[i]);
	}

	for (i = 0; i < n; ++i)	{
		scanf("%d", &v2[i]);
	}

	int dot_product = 0;
	for (i = 0; i < n; ++i) {
		dot_product += v1[i] * v2[i];
	}

	printf("%d\n", dot_product);
	free(v1);
	free(v2);
	return 0;
}