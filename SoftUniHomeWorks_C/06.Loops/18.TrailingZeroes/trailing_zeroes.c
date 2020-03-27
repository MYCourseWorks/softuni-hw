#include <stdio.h>

int main() {
	long n;
	printf("n = ");
	scanf("%ld", &n);
	
	int trailing_zeroes = 0;
	int power_of_five = 1;
	while (n / power_of_five > 1) {
		trailing_zeroes += n / (power_of_five * 5);
		power_of_five *= 5;
	}

	printf("%d\n", trailing_zeroes);
	return 0;
}