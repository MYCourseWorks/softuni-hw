#include <stdio.h>
#include <math.h>

int digit_count(int n) {
	int num = abs(n);
	int len = ceil(log(n + 1) / log(10));
	return len;
}

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

int reverse_number (int num) {
	int negative = 0;
	if (num < 0) {
		negative = 1;
		num = abs(num);
	}

	int reversed = 0;
	while(num > 0) {
		reversed *= 10;
		reversed += num % 10;
		num /= 10;
	}

	return negative == 0 ? reversed : -reversed;
}

int shift_num_right (int num) {
	int first_digit = get_digit_at(num, 1);
	num /= 10;
	num += first_digit * pow(10, digit_count(num));
	return num;
}

void swap_digits_at(int* num, int first_pos, int second_pos) {
	int f_pos_digit = get_digit_at(*num, first_pos);
	int s_pos_digit = get_digit_at(*num, second_pos);
	
	if (f_pos_digit == -1)
		return;
	if (s_pos_digit == -1)
		return;

	int f_pos_power = pow(10, first_pos - 1);
	int s_pos_power = pow(10, second_pos - 1); 

	// put zero at first pos :
	*num = *num - f_pos_power * f_pos_digit;
	// put zero at second pos :
	*num = *num - s_pos_power * s_pos_digit;
	// at first pos put second digit : 
	*num += f_pos_power * s_pos_digit;
	// at second pos put first digit :
	*num += s_pos_power * f_pos_digit;
}

int main() {
	int n, i, n_digit_count, sum;
	printf("four digit number: ");
	scanf("%d", &n);

	sum = 0;
	n_digit_count = digit_count(n);
	for (i = 1; i <= n_digit_count; ++i) {
		sum += get_digit_at(n, i);
	}

	printf("sum = %d\n", sum);
	printf("reversed = %d\n", reverse_number(n));
	printf("last digit in front = %d\n", shift_num_right(n));
	swap_digits_at(&n, 2, 3);
	printf("swap digits at 2 and 3 = %d\n", n);
	return 0;
}