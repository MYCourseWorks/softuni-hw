#include <stdio.h>

int main() {
	int n, i, j;
	printf("n = ");
	scanf("%d", &n);

	for (i = 0; i < n; ++i) {
		for (j = 0; j < n; ++j) {
			printf("%d ", j + i + 1);
		}

		printf("\n");
	}

	return 0;
}