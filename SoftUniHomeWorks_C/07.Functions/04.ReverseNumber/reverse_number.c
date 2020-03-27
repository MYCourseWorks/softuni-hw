#include <stdio.h>
#include <stdbool.h>
#include <math.h>

double reverse_double_number(char* number_as_char, int* error) {
	int i = 0;
	int number_as_int_reverse = 0;
	int power = 1;
	int real_part = 0;
	bool in_real_part = true;

	while(number_as_char[i] != '\0') {
		if (number_as_char[i] != '.') {
			if (!isdigit(number_as_char[i])) {
				*error = 1;
				return 0;
			}

			number_as_int_reverse += power * (number_as_char[i] - '0');
			power *= 10;

			if (in_real_part)
				real_part++;
		} else {
			in_real_part = false;
		}

		i++;
	}

	double number = 0;
	if (in_real_part)
		number = number_as_int_reverse;
	else 
		number = number_as_int_reverse * pow(0.1, real_part);

	*error = 0;
	return number;
}

int main() {
	char* number_as_char;
	printf("number = ");
	scanf("%s", number_as_char);

	int error;
	double revesed = reverse_double_number(number_as_char, &error);
	
	if (error != 0)
		printf("Invalid format\n");
	else 
		printf("%.3f\n", revesed);
	
	return 0;
}