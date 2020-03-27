#include <stdio.h>

int main() {
	int n;
	printf("n = ");
	scanf("%d", &n);
	printf("%d\n", n % 7 == 0 && n % 5 == 0 && n != 0);	
	return 0;
}