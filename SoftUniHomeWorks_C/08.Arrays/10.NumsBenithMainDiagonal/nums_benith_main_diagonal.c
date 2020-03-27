#include <stdio.h>
#include <stdlib.h>

int main() {
	int n, i, j;
	scanf("%d", &n);

	int** nums_benith_diagonal = malloc(n * sizeof(int*));
	int curr_diagonal_indx = 1;

	for (i = 0; i < n; ++i) {
		nums_benith_diagonal[i] = malloc(curr_diagonal_indx * sizeof(int));
		for (j = 0; j < n; ++j) {
			int current;
			scanf("%d", &current);
	
			if (j <= curr_diagonal_indx)
				nums_benith_diagonal[i][j] = current;
		}

		curr_diagonal_indx++;
	}

	curr_diagonal_indx = 1;
	for (i = 0; i < n; ++i) {
		for (j = 0; j < curr_diagonal_indx; ++j) {
			printf("%d ", nums_benith_diagonal[i][j]);
		}

		printf("\n");
		curr_diagonal_indx++;
	}

	for (i = 0; i < n; ++i)
		free(nums_benith_diagonal[i]);

	free(nums_benith_diagonal);
	return 0;
}