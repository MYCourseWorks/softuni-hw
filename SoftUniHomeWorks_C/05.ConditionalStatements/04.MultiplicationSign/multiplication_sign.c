#include <stdio.h>

int main() {
	double a, b, c;
	printf("a = ");
	scanf("%lf", &a);
	printf("b = ");
	scanf("%lf", &b);
	printf("c = ");
	scanf("%lf", &c);

	if (a == 0 || b == 0 || c == 0) {
		printf("0\n");
		return 0;
	}

	int negative_count = 0;
	if(a < 0)
		negative_count++;
	if(b < 0)
		negative_count++;
	if(c < 0)
		negative_count++;

	if (negative_count % 2 == 0)
		printf("+\n");
	else 
		printf("-\n");

	return 0;
}