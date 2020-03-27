#include <stdio.h>
#include <string.h>

int main() {
	char c[20];
	int is_card = 0;
	printf("card = ");
	scanf("%s", c);

	if (strlen(c) > 1) {
		if (*c == '1' && *(c + 1) == '0')
			is_card = 1;
		else 
			is_card = 0;
	} else {
		switch (*c) {
			case '2': is_card = 1; break;
			case '3': is_card = 1; break;
			case '4': is_card = 1; break;
			case '5': is_card = 1; break;
			case '6': is_card = 1; break;
			case '7': is_card = 1; break;
			case '8': is_card = 1; break;
			case '9': is_card = 1; break;
			case 'J': is_card = 1; break;
			case 'Q': is_card = 1; break;
			case 'K': is_card = 1; break;
			case 'A': is_card = 1; break;
			default : is_card = 0; break;
		}
	}

	printf("%s\n", is_card ? "yes" : "no");
	return 0;
}