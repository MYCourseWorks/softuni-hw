#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void memory_dump(void* ptr, size_t n, int row_len) {
	int i = 0;
	int j = 0;
	int mem_block_counter = 0;

	while (mem_block_counter < n) {
		printf("%p    ", (ptr + row_len * i));
		
		for (j = 0; j < row_len; ++j) {
			mem_block_counter++;
			char* byte = (char*)ptr + j + i * row_len;
			printf("%02x ", *byte);
		}

		printf("\n");
		i++;
	}
}

void example_1() {
	char* text = "I love to break free";
	int len = strlen(text) + 1;
	memory_dump(text, len, 5);
}

void example_2() {
	int array[] = {7, 3, 2, 10, -5};
	int size = sizeof(array) / sizeof(int);
	memory_dump(array, size * sizeof(int), 4);
}	

int main() {
	example_1();
	//example_2();
	return 0;
}