#include <stdio.h>

int main() {
	int start, end, p, i;
	printf("start = ");
	scanf("%d", &start);
	printf("end = ");
	scanf("%d", &end);

	for (i = start; i <= end; ++i) {
		if (i % 5 == 0)
			p++;
	}

	printf("%d\n", p);
	return 0;
}