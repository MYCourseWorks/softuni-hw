#include "operations_on_numbers.h"

int digit_count(int n) {
	n = abs(n);
	int len = ceil(log(n + 1) / log(10));
	return len;
}

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

int reverse_number (int num) {
	int negative = 0;
	if (num < 0) {
		negative = 1;
		num = -num;
	}

	int reversed = 0;
	while(num > 0) {
		reversed *= 10;
		reversed += num % 10;
		num /= 10;
	}

	return negative == 0 ? reversed : -reversed;
}

void put_zero_digit_at(int* num, int pos) {
	int is_negative = 0;
	int digit_at_pos = get_digit_at(*num, pos);
	if (digit_at_pos == -1)
		return;
	if (*num < 0){
		*num = abs(*num);
		is_negative = 1;
	}

	int power_of_ten = pow(10, pos - 1);
	*num = *num - digit_at_pos * power_of_ten;
	*num = is_negative == 0 ? *num : -(*num);
}

void put_given_digit_at(int* num, int digit, int pos) {
	int is_negative = 0;
	int digit_at_pos = get_digit_at(*num, pos);
	if (digit_at_pos == -1)
		return;
	if (*num < 0) {
		*num = abs(*num);
		is_negative = 1;
	}

	int power_of_ten = pow(10, pos - 1);
	*num = *num - digit_at_pos * power_of_ten;
	*num = *num + digit * power_of_ten;
	*num = is_negative == 0 ? *num : -(*num);
}

void swap_digits_at(int* num, int first_pos, int second_pos) {
	int is_negative = 0;
	int f_pos_digit = get_digit_at(*num, first_pos);
	int s_pos_digit = get_digit_at(*num, second_pos);
	
	if (f_pos_digit == -1)
		return;
	if (s_pos_digit == -1)
		return;
	if (*num < 0) {
		*num = abs(*num);
		is_negative = 1;
	}

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
	// negate number if needed :
	*num = is_negative == 0 ? *num : -(*num);
}

bool is_prime(int n) {
	if (n < 0)
		n = -n;

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

int calc_gcd(int a, int b) {
	int remainder = a % b;
	while(remainder > 0) {
		a = b;
		b = remainder;
		remainder = a % b;
	}

	return b;
}

int calc_lcd(int a, int b) {
	return a / calc_gcd(a, b) * b;
}