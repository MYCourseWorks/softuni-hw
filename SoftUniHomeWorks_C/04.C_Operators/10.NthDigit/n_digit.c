#include <stdio.h>

int get_digit_at(int num, int pos) {
	int curr_pos = 1;
	if (curr_pos > pos)
		return -1;
	if (num < 0)
		num = -num;

	while (num > 0) {
		if (curr_pos == pos)
			return num % 10;

		num /= 10;
		curr_pos++;
	}

	return -1;
}

int main() {
	int number, n, n_digit;
	printf("number = ");
	scanf("%d", &number);
	printf("n = ");
	scanf("%d", &n);

	n_digit = get_digit_at(number, n);
	if (n_digit == -1)
		printf("%d digit = -\n", n);
	else
		printf("%d digit = %d\n", n, n_digit);

	return 0;
}