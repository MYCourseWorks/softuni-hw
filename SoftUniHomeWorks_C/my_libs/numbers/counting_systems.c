#include "counting_systems.h"

void int_to_bin(unsigned int n, char* buffer) {
	if (buffer == NULL)
		return;

	int i = (int)log2(n) + 1;
	buffer[i] = '\0';
	i--;

	while (n > 0) {
		int remainder = n % 2;
		buffer[i] = (remainder == 1 ? '1' : '0');
		n = n / 2;
		i--;
	}
}

int bin_to_int(const char* num_as_bin, int len, int* error) {
	if (num_as_bin == NULL) {
		*error = 1;
		return 0;
	}

	int i;
	int power = 1;
	int result = 0;

	for (i = len - 1; i >= 0; --i) {
		if (num_as_bin[i] == '0') {
			result += 0;
		} else if (num_as_bin[i] == '1') {
			result += power;
		} else {
			*error = 2;
			return 0;
		}
			

		power *= 2;
	}

	*error = 0;
	return result;
}

void int_to_hex(unsigned int n, char* buffer) {
	if (buffer == NULL)
		return;
	if (n == 0) {
		buffer[0] = '0';
		buffer[1] = '\0';
		return;
	}

	// Find the hex number :
	char hex_values[] = "0123456789ABCDEF";
	int i = 0;
	while (n > 0) {
		buffer[i] = hex_values[n % 16];
		n = n / 16;
		i++;
	}

	buffer[i] = '\0';

	// Reverse the hex number :
	int len = i;
	int k = 0;
	while (i > len / 2) {
		i--;
		char tmp = buffer[i];
		buffer[i] = buffer[k];
		buffer[k] = tmp;
		k++;
	}
}

int hex_to_int(const char* num_as_hex, int len, int* error) {
	if (num_as_hex == NULL) {
		*error = 1;
		return 0;
	}

	int number = 0, power = 1, i = 0;
	for (i = len - 1; i >= 0; --i) {
		int current_digit = 0;
		switch (num_as_hex[i]) {
			case '0': current_digit = 0; break;
			case '1': current_digit = 1; break;
			case '2': current_digit = 2; break;
			case '3': current_digit = 3; break;
			case '4': current_digit = 4; break;
			case '5': current_digit = 5; break;
			case '6': current_digit = 6; break;
			case '7': current_digit = 7; break;
			case '8': current_digit = 8; break;
			case '9': current_digit = 9; break;
			case 'A': current_digit = 10; break;
			case 'B': current_digit = 11; break;
			case 'C': current_digit = 12; break;
			case 'D': current_digit = 13; break;
			case 'E': current_digit = 14; break;
			case 'F': current_digit = 15; break;
			default: *error = 2;  return 0;
		};

		number += current_digit * power;
		power *= 16;
	}

	*error = 0;
	return number;
}