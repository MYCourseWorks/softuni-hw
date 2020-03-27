#include <stdio.h>
#include <ctype.h>
#include <math.h>

#include "../../lib/console_read_line.h"
#include "../../lib/string_builder/string_builder.h"
#include "../../lib/str_functions.h"

int main()
{
	char* line = console_read_line(50, 1000);
	int split_size = 0;
	char** line_split = sb_split(&split_size, line, " ");

	double sum = 0;
	for (int i = 0; i < split_size; ++i) {
		char* current = line_split[i];
		int curr_len = strlen(current);
		char first_letter = current[0];
		char last_letter = current[curr_len - 1];

		int n = 0;
		if(sscanf(current + 1, "%d", &n) == 0) {
			printf("Format error\n");
			exit(1);
		}

		double curr_sum = n;
		if (isupper(first_letter))
			curr_sum /= (first_letter - 'A' + 1);
		else
			curr_sum *= (first_letter - 'a' + 1);

		if (isupper(last_letter))
			curr_sum -= (last_letter - 'A' + 1);
		else
			curr_sum += (last_letter - 'a' + 1);

		sum += curr_sum;
	}

	sum = round(sum * 100) / 100;
	printf("%.2f\n", sum);
	free(line);
	str_arr_free(line_split, split_size);
	return 0;
} 