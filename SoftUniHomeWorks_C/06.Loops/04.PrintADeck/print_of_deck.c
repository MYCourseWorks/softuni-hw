#include <stdio.h>

int main() {
	char faces[] = {'C', 'D', 'H', 'S'};
	char* cards[] = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"}; 
	int i, j;
	int faces_len = sizeof(faces) * sizeof(char);
	int cards_len = sizeof(cards) / sizeof(*cards);

	for (i = 0; i < faces_len; ++i) {
		for (j = 0; j < cards_len; ++j) {
			printf("%s%c ", cards[j], faces[i]);
		}

		printf("\n");
	}

	return 0;
}