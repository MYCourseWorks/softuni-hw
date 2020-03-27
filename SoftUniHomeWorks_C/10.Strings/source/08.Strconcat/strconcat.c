#include <stdio.h>
#include <string.h>

char* my_strconcat(char* dest, const char* src, size_t n) {
	int i;
	int dest_len = strlen(dest);

	for (i = 0; i < n; ++i) {
		dest[i + dest_len] = src[i];
	}

	dest[i + dest_len] = '\0';
	return dest;
}

void example_1() {
	char buffer[10] = "Soft";
	strncat(buffer, "Uni", 7);
	printf("%s\n", buffer);
}

void example_2() {
	// 10 faulty reads happen in this example :
	char buffer[5] = "Soft";
	strncat(buffer, "ware University", 15);
	printf("%s\n", buffer);
}

void example_3() {
	char buffer[10] = "C";
	strncat(buffer, " is cool", 8);
	printf("%s\n", buffer);
}

void example_4() {
	// the buffer becomes a constant in this example :
	char * buffer = "C";
	strncat(buffer, " is cool", 8);
	printf("%s\n", buffer);
}

int main() {
	example_1();
	//example_2(); // seg fault
	example_3();
	//example_4(); // seg fault
	return 0;
}