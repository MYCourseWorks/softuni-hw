#include <stdio.h>

void fib_print(int n) {
	int i, first = 0, second = 1;
	for (i = 0; i < n; ++i) {
		printf("%d ", first);
		int tmp = first;
		first = second;
		second = tmp + second;
	}

	printf("\n");
}

int main() {
	int n;
	printf("n = ");
	scanf("%d", &n);
	fib_print(n);
	return 0;
}