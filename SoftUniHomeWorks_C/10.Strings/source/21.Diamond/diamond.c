#include <stdio.h>

void print_char(char c, int times) 
{
	for (int i = 0; i < times; ++i) {
		printf("%c", c);
	}
}

int main()
{
	int n = 5;
	scanf("%d", &n);
	printf("\n");

	if (n < 3)
		return 1;

	print_char('.', n / 2);
	printf("%c", '*');
	print_char('.', n / 2);
	printf("\n");

	int dots = 1;
	int half = n / 2 - 1;
	for (int i = 0; i < n / 2 - 1; ++i) {
		print_char('.', half);
		printf("*");
		print_char('.', dots);
		printf("*");
		print_char('.', half);
		printf("\n");
		half--;
		dots += 2;
	}

	dots = 0;
	for (int i = 0; i < n / 2; ++i) {
		print_char('.', dots);
		printf("*");
		print_char('.', n - dots - 2 - i);
		printf("*");
		print_char('.', dots);
		printf("\n");
		dots++;
	}

	print_char('.', n / 2);
	printf("%c", '*');
	print_char('.', n / 2);
	printf("\n");

	return 0;
}