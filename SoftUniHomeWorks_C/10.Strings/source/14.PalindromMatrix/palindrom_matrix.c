#include <stdio.h>

int main() {
	int n = 0, k = 0, i = 0, j = 0;
	scanf("%d", &n);
	scanf("%d", &k);

	char curr_letter = 'a';
	for (i = 0; i < n; ++i) {
		for (j = 0; j < k; ++j) {
			printf("%c", curr_letter);
			printf("%c", curr_letter + j);
			printf("%c ", curr_letter);
		}

		printf("\n");
		curr_letter++;
	}

	return 0;
}