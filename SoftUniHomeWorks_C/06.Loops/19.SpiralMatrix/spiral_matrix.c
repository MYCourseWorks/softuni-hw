#include <stdio.h>

int main() {
	int n;		
	printf("n = ");
	scanf("%d", &n);

	int matrix[n][n],
		i = 0,
		j = 0,
		dir = 0, 
		row = 0, 
		col = 0, 
		up = 0, 
		down = 0, 
		left = 0, 
		right = 0;

	for (i = 1; i <= n * n; i++) {
		
		if (dir == 0) {
			matrix[col][row] = i;
			row++;
			if (row >= n - down) {
				row--;
				col++;
				dir++;
				right++;
			}
		}
		else if (dir == 1) {
			matrix[col][row] = i;
			col++;
			if (col >= n - left) {
				row--;
				col--;
				dir++;
				down++;
			}
		}
		else if (dir == 2) {
			matrix[col][row] = i;
			row--;
			if (row < 0 + up) {
				row++;
				col--;
				dir++;
				left++;
			}
		}
		else {
			matrix[col][row] = i;
			col--;
			if (col < 0 + right) {
				row++;
				col++;
				dir = 0;
				up++;
			}
		}
	}

	for (i = 0; i < n; ++i) {
		for (j = 0; j < n; ++j) {
			printf("%02d ", matrix[i][j]);
		}

		printf("\n");
	}

	return 0;
}