#include <stdio.h>
#include <stdlib.h>

void free_matrix(int** matrix, int n) {
	int i;
	for (i = 0; i < n; ++i){
		free(matrix[i]);
	}

	free(matrix);
}

void read_matrix(int** matrix, int rows, int cols) {
	int i, j;
	for (i = 0; i < rows; ++i) {
		matrix[i] = malloc(cols * sizeof(int));
		for (j = 0; j < cols; ++j) {
			int current = 0;
			scanf("%d", &current);
			matrix[i][j] = current;
		}
	}
}

int** matrix_add(int** m1, int** m2, int rows, int cols) {
	int i, j;
	int** result = malloc(rows * sizeof(int*));
	
	for (i = 0; i < rows; ++i) {
		result[i] = malloc(cols * sizeof(int));
		for (j = 0; j < cols; ++j) {
			result[i][j] = m1[i][j] + m2[i][j];
		}
	}	

	return result;
}

int** print_matrix(int** m, int rows, int cols) {
	int i, j;
	for (i = 0; i < rows; ++i) {
		for (j = 0; j < cols; ++j) {
			printf("%d ", m[i][j]);
		}

		printf("\n");
	}	
}

int main() {
	int rows, cols;
	scanf("%d", &rows);
	scanf("%d", &cols);
	int** matrix_1 = malloc(sizeof(int*) * rows);
	int** matrix_2 = malloc(sizeof(int*) * rows);

	read_matrix(matrix_1, rows, cols);
	read_matrix(matrix_2, rows, cols);

	int** result;
	result = matrix_add(matrix_1, matrix_2, rows, cols);

	printf("\n");
	print_matrix(result, rows, cols);

	free_matrix(matrix_1, rows);
	free_matrix(matrix_2, rows);
	free_matrix(result, rows);
	return 0;
}