#include <stdio.h>

int wc(char* input, char delimiter) {
	int i = 0;
	int w_count = 1;

	while(input[i] != '\0') {
		if (input[i] == delimiter)
			w_count++;
		i++;
	}

	return w_count;
}

int main() {
	int ex_1 = wc("Hard Rock, Hallelujah!", ' '); 
	int ex_2 = wc("Hard Rock, Hallelujah!", ',');
	int ex_3 = wc("Uncle Sam wants you Man", ' ');
	int ex_4 = wc("Beat the beat!", '!');

	printf("%d\n", ex_1);
	printf("%d\n", ex_2);
	printf("%d\n", ex_3);
	printf("%d\n", ex_4);
	return 0;
}