#include <stdio.h>
#include <math.h>

void long_to_bin(long n, char* buffer) {
	long i = log2(n) + 1;
	buffer[i] = '\0';
	i--;

	while (n > 0) {
		int remainder = n % 2;
		buffer[i] = (remainder == 1 ? '1' : '0');
		n = n / 2;
		i--;
	}
}

int main() {
	long n;
	printf("n = ");
	scanf("%ld", &n);

	char num_as_bin[64];
	long_to_bin(n, num_as_bin);
	printf("%s\n", num_as_bin);
	return 0;
}