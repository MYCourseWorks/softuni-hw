#include <stdio.h>

int my_strlen(const char* str) {
	int symbol_count = 0;
	while(str[symbol_count] != '\0') {
		symbol_count++;
	}

	return symbol_count;
}

int main() {
	int ex_1 = my_strlen("Soft");
	int ex_2 = my_strlen("SoftUni");
	char buffer[10] = { 'C', '\0', 'B', 'a', 'b', 'y' };
	int ex_3 = my_strlen(buffer);
	char* c_buffer = "Derp"; // {'D', 'e', 'r', 'p'} -> doesn't work
	int ex_4 = my_strlen(c_buffer);

	printf("%d\n", ex_1);
	printf("%d\n", ex_2);
	printf("%d\n", ex_3);
	printf("%d\n", ex_4);
	return 0;
}