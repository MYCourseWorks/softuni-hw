#include <stdio.h>
#include <stdlib.h>

#include "../../lib/bin_operations.h"

int main()
{
	int i, n, step;
	scanf("%d %d", &n, &step);

	int* arr = (int*)malloc(n * sizeof(int));
	for (i = 0; i < n; ++i) {
		scanf("%d", &arr[i]);
	}

	int count = 0;
	for (i = 1; i < n * 8; i += step) {
		int pos = 7 - i % 8;
		arr[count] = set_bit(arr[count], pos, 1);

		int tmp = 8 * (count + 1);
		while (i + step >= tmp) {
			count++;
			tmp += 8;
		}
	}

	for (i = 0; i < n; ++i) {
		printf("%d\n", arr[i]);
	}

	free(arr);
	return 0;
}