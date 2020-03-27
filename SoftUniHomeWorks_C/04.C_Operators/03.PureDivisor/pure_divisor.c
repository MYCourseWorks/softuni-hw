#include <stdio.h>

int main() {
	int n;
	printf("n = ");
	scanf("%d", &n);
	int pure_divisor = n % 9 == 0 
		|| n % 11 == 0
		|| n % 13 == 0;

	printf("%d\n", pure_divisor);
	return 0;
}