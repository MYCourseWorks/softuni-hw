#include <stdio.h>

int main() {
	int n;
	printf("n = ");
	scanf("%d", &n);
	printf("%d\n", n % 2 && n > 20);
	return 0;
}