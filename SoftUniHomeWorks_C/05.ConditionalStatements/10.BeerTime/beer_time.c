#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <stdbool.h>

#include "console_read_line.h"

int main () {
	char* line = console_read_line(20, 500);
	int line_size = strlen(line);
	bool time_is_pm = false;

	if (line == NULL) {
		printf("Console read error\n");
		return 1;
	}

	if (line[line_size - 2] == 'P' &&
		line[line_size - 1] == 'M') {
	
		time_is_pm = true;
	} else if (line[line_size - 2] == 'A' &&
			   line[line_size - 1] == 'M') {

		time_is_pm = false;
	} else {
		printf("Invalid time\n");
		return 1;
	}

	bool in_hour = true;
	int i, hour = 0, min = 0;
	for (i = 0; i < line_size; ++i) {
		if (line[i] == ':') {
			in_hour = false;
			continue;
		}

		if (in_hour && isdigit(line[i])) {
			if (hour == 0)
				hour = line[i] - '0';
			else 
				hour = hour * 10 + (line[i] - '0');

			if (hour < 0 || hour > 12) {
				printf("Invalid time\n");
				return 1;
			}
		} else if (isdigit(line[i])) {
			if (min == 0)
				min = line[i] - '0';
			else
				min = min * 10 + (line[i] - '0');

			if (min < 0 || min > 60) {
				printf("Invalid time\n");
				return 1;
			}
		} else {
			break;
		}
	}
		
	bool beer_time = false;
	if (time_is_pm) {
		if (hour > 0) {
			beer_time = true;
		}
	} else {
		if (hour < 3) {
			beer_time = true;
		}
	}
		
	printf("%s", beer_time == true ? "beer time": "non-beer time");
	if (line != NULL)
		free(line);
	return 0;
}