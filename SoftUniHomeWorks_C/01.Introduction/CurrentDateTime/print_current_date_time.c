#include <stdio.h>
#include <time.h>

#include "../environment_new_line.h"

int main() {
	time_t raw_time = time(NULL);
	struct tm* curr_time = localtime(&raw_time);

	char buffer[80];
	strftime (buffer, 80, "%y %A %Y %H:%M:%S", curr_time);
	printf("%s\n", buffer);
	return 0;
}