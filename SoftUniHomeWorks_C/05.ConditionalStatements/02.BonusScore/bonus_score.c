#include <stdio.h>

int main() {
	int s, is_invalid = 0;
	printf("score = ");
	scanf("%d", &s);
	
	if (s < 1)
		is_invalid = 1;
	else if (s < 4)
		s *= 10;
	else if (s < 7)
		s *= 100;
	else if (s < 10)
		s *= 1000;
	else 
		is_invalid = 1;

	if (is_invalid)
		printf("invalid score\n");
	else 
		printf("%d\n", s);

	return 0;
}