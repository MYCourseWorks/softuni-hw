#include <stdio.h>
#include <string.h>

int main () {
	int type;
	int n;
	double d;
	char str[100];
	printf("Please choose a type: \n");
	printf("1 --> int\n");
	printf("2 --> double\n");
	printf("3 --> string\n");

	scanf("%d", &type);
	switch (type) {
		case 1 : 
			scanf("%d", &n); 
			printf("%d\n", ++n);
			break;
		case 2 : 
			scanf("%lf", &d); 
			printf("%.1f\n", ++d);
			break;
		case 3 : 
			scanf("%s", str); 
			int str_len = strlen(str);
			str[str_len] = '*';
			str[str_len + 1] = '\0';
			printf("%s\n", str);
			break;
		default : 
			printf("invalid command \n"); 
			return 1;
	}
}