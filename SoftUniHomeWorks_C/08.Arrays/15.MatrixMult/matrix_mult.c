#include <stdio.h>
#include <stdlib.h>

void free_matrix(int** matrix, int n) {
	int i;
	for (i = 0; i < n; ++i) {
		free(matrix[i]);
	}

	free(matrix);
}

void read_matrix(int** matrix, int rows, int cols) {
	int i, j;
	for (i = 0; i < rows; ++i) {
		matrix[i] = malloc(cols * sizeof(int));
		for (j = 0; j < cols; ++j) {
			int current;
			scanf("%d", &current);
			matrix[i][j] = current;
		}
	}
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

int** matrix_mult(int** m1, int** m2, int rows, int cols) {
	int i, j, k;
	int result_dim = rows < cols ? rows : cols;
	int m = rows > cols ? rows : cols;
	int** result = malloc(sizeof(int*) * result_dim);

	for (i = 0; i < result_dim; i++) {
		result[i] = malloc(sizeof(int) * result_dim);
		for (j = 0; j < result_dim; j++) { 
			int sum = 0;
			for (k = 0; k < m; k++) {
				int el1 = m1[i][k];
				int el2 = m2[k][j];
				sum += el1 * el2; 
			}

			result[i][j] = sum;  
		}
	}

	return result;
}


int main() {
	int rows, cols;
	scanf("%d", &rows);
	scanf("%d", &cols);
	int** matrix_1 = malloc(sizeof(int*) * rows);
	int** matrix_2 = malloc(sizeof(int*) * cols);

	read_matrix(matrix_1, rows, cols);
	read_matrix(matrix_2, cols, rows);
	
	int** result = matrix_mult(matrix_1, matrix_2, rows, cols);
	int result_dimensions = rows < cols ? rows : cols;

	printf("\n");
	print_matrix(result, result_dimensions, result_dimensions);
	
	free_matrix(matrix_1, rows);
	free_matrix(matrix_2, cols);
	free_matrix(result, result_dimensions);
	return 0;
}