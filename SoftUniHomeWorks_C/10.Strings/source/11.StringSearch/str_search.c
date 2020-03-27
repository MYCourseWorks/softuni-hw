#include <stdio.h>
#include <string.h>

int str_search(char* src, char* substr) {
	int i = 0;
	int src_len = strlen(src);
	int substr_len = strlen(substr);

	while(i < src_len) {
		if (strncmp(src + i, substr, substr_len) == 0)
			return 1;
		
		i++;
	}

	return 0;
}

int main() {
	int ex_1 = str_search("SoftUni", "Soft");
	int ex_2 = str_search("Hard Rock", "Rock");
	int ex_3 = str_search("Ananas", "nasa");
	int ex_4 = str_search("Coolness", "cool");

	printf("%d\n", ex_1);
	printf("%d\n", ex_2);
	printf("%d\n", ex_3);
	printf("%d\n", ex_4);
	return 0;
}