#include <stdio.h>
#include <string.h>

void print_digit_as_word (char symbol) {
	switch (symbol) {
		case '0' : printf("zero\n"); break;
		case '1' : printf("one\n"); break;
		case '2' : printf("two\n"); break;
		case '3' : printf("three\n"); break;
		case '4' : printf("four\n"); break;
		case '5' : printf("five\n"); break;
		case '6' : printf("six\n"); break;
		case '7' : printf("seven\n"); break;
		case '8' : printf("eight\n"); break;
		case '9' : printf("nine\n"); break;
		default: printf("not a digit !\n"); break;
	}
}

int main() {
	char line[20];
	printf("digit = ");
	scanf("%s", line);

	if (strlen(line) > 1)
		printf("not a digit !\n");
	else 
		print_digit_as_word(line[0]);
}