#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int gen_rnd_int(int min, int max) {
	return rand() % (max + 1 - min) + min;
}

int main() {
	int n, i;
	printf("n = ");
	scanf("%d", &n);

	int* arr = malloc(sizeof(int) * n);

	for (i = 0; i < n; ++i) {
		arr[i] = 0;		
	}

	srand((unsigned)time(NULL));
	for (i = 0; i < n; ++i) {
		int rnd = gen_rnd_int(0, n - 1);
		while(arr[rnd] != 0) {
			rnd = gen_rnd_int(0, n - 1);
			if (arr[rnd] == 0)
				break;
		}
		
		arr[rnd] = i + 1;
	}

	for (i = 0; i < n; ++i)
	{	
		printf("%d ", arr[i]);
	}

	printf("\n");
	if (arr != NULL)
		free(arr);
	
	return 0;
}