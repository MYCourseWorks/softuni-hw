#include <stdio.h>
#include <stdbool.h>
#include <math.h>

bool is_prime(int n) {
	if (n <= 3) {
		if (n <= 1)
		    return false;
		else
		    return true;
	}

	if (n % 2 == 0 || n % 3 == 0)
		return false;

	int i;
	for (i = 5; i < sqrt(n) + 1; i += 6) {
		if (n % i == 0 || n % (i + 2) == 0)
		    return false;
	}

	return true;
}

int main() {
	int n;
	printf("n = ");
	scanf("%d", &n);
	printf("%s\n", is_prime(n) ? "true" : "false");
	return 0;
}