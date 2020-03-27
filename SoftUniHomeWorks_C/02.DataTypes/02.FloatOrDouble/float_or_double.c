#include <stdio.h>

int main()
{
	double a = 34.567839023;
	float b = 12.345;
	double c = 8923.1234857;
	float d = 3456.091;
	
	printf("%.9lf\n", a);
	printf("%.3f\n", b);
	printf("%.7lf\n", c);
	printf("%.3f\n", d);

	return 0;
}