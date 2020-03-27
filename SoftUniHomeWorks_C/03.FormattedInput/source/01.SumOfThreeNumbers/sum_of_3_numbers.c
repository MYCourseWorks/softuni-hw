#include <stdio.h>

int main() {
	double first_num, second_num, third_num;

	printf("n1 = ");
	scanf("%lf", &first_num);
	printf("n2 = ");
	scanf("%lf", &second_num);
	printf("n3 = ");
	scanf("%lf", &third_num);
	
	printf("sum %lf\n", first_num + second_num + third_num);
	return 0;
}