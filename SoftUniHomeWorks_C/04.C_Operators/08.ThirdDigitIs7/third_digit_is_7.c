#include <stdio.h>

int get_digit_at(int num, int pos) {
	int curr_pos = 1;
	if (curr_pos > pos)
		return -1;

	while (num > 0) {
		if (curr_pos == pos)
			return num % 10;

		num /= 10;
		curr_pos++;
	}

	return -1;
}

int main() {
	int n;
	printf("n = ");
	scanf("%d", &n);
	printf("is third digit == 7 ? %s\n", 
		get_digit_at(n, 3) == 7 ? "true" : "false");
	return 0;
}