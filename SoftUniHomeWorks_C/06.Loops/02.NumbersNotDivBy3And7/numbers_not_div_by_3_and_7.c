#include <stdio.h>

int main() {
	int n, i;
	printf("n = ");
	scanf("%d", &n);
	for (i = 0; i <= n; ++i) {
		if (i % 3 != 0 && i % 7 != 0) {
			printf("%d ", i);
		}
	}

	printf("\n");
	return 0;
}