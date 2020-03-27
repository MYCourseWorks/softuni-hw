#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

int main() {
	int i = 0;
	char raw_input[20];
	char* date_arr[3];
	char* token_buffer;

	printf("Give me yout age in the format (dd.mm.yyyy) : ");
	scanf("%s", raw_input);
	token_buffer = strtok(raw_input, ".");
	while (token_buffer != NULL) {
		if (i >= 3) {
			return 1;
		}

		date_arr[i] = token_buffer;
		token_buffer = strtok(NULL, ".");
		i++;
	}

	if (i < 2) {
		printf("Incorrect input format!\n");
		return 1;
	}

	time_t time_now_raw = time( NULL );
	struct tm* date_time_now = localtime( &time_now_raw );
	int curr_year = date_time_now->tm_year + 1900;
	int user_age = atoi(date_arr[2]);
	int date_diff = curr_year - user_age;

	printf("Now: %d\n", date_diff);
	printf("After 10 years: %d\n", date_diff + 10);
	return 0;
}