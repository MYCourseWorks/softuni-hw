#include <stdio.h>
#include <stdlib.h>

int main() {
	int n, i, j;
	scanf("%d", &n);
	if (n < 0) {
		return;
	}

	int* arr = malloc(n * sizeof(int));
	for (i = 0; i < n; ++i) {
		scanf("%d", &arr[i]);
	}

	printf("\n");
	int seq_len = 1;
	int seq_start = 0;
	int longest_seq_len = 1;
	int longest_seq_start = 0;

	for (i = 1; i <= n; ++i) {
		if (i != n && arr[i - 1] < arr[i]) {
			seq_len++;
		} else {
			for (j = 0; j < seq_len; ++j) {
				printf("%d ", arr[j + seq_start]);
			}

			if (seq_len > longest_seq_len) {
				longest_seq_len = seq_len;
				longest_seq_start = seq_start;
			}

			printf("\n");
			seq_start = i;
			seq_len = 1;
		}
	}

	printf("Longest: ");
	for (i = 0; i < longest_seq_len; ++i) {
		printf("%d ", arr[i + longest_seq_start]);
	}

	printf("\n");
	free(arr);
	return 0;
}