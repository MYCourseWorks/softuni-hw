#include <stdio.h>
#include <string.h>

void reverse_str(char* s) {
	int length = strlen(s);
	int i, j;

	for (i = 0, j = length - 1; i < j; i++, j--) {
		int tmp = s[i];
		s[i] = s[j];
		s[j] = tmp;
	}
}

void long_to_hex(long n, char* buffer) {
	if (n == 0) {
		buffer[0] = '0';
		buffer[1] = '\0';
		return;
	}

	char hex_values[] = "0123456789ABCDEF";
	long i = 0;
	while (n > 0) {
		buffer[i] = hex_values[n % 16];
		n = n / 16;
		i++;
	}

	buffer[i] = '\0';
	reverse_str(buffer);
}

int main() {
	long n;
	printf("n = ");
	scanf("%ld", &n);

	char long_as_hex[64];
	long_to_hex(n, long_as_hex);
	printf("%s\n", long_as_hex);
	return 0;
}