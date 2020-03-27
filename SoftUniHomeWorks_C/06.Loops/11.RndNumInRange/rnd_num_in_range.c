#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int gen_rnd_int(int min, int max) {
	return rand() % (max + 1 - min) + min;
}

int main() {
	int n, i, min, max;
	printf("n = ");
	scanf("%d", &n);
	printf("min = ");
	scanf("%d", &min);
	printf("max = ");
	scanf("%d", &max);

	if (min >= max) {
		printf("Invalid input\n");
		return 1;
	}

	srand((unsigned)time(NULL));
	for (i = 0; i < n; ++i) {
		int random_num = gen_rnd_int(min, max);
		printf("%d ", random_num);
	}

	printf("\n");
	return 0;
}