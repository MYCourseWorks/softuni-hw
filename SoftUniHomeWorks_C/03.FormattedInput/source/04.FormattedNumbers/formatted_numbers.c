#include <stdio.h>

#define FORMATTER "|%-10X|%s|%10.2lf|%-10.3lf|\n"

void int_to_bin(int n, char* buffer, int len) {
	int i = len - 1;
	buffer[i] = '\0';
	i--;

	while (n > 0) {
		int remainder = n % 2;
		buffer[i] = (remainder == 1 ? '1' : '0');
		n = n / 2;
		i--;
	}

	while (i >= 0) {
		buffer[i] = '0';
		i--;
	}
}

int main() {
	int a;
	float b, c;

	printf("a = ");
	scanf("%d", &a);
	printf("b = ");
	scanf("%f", &b);
	printf("c = ");
	scanf("%f", &c);

	char a_to_bin[11];
	int_to_bin(a, a_to_bin, sizeof(a_to_bin));
	
	printf(FORMATTER, a, a_to_bin, b, c);
	return 0;
}