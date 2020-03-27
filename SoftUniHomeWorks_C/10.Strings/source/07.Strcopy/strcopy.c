#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* my_strncpy(char* dest, const char *src, int n) {
	if (dest == NULL) {
		dest = malloc(n + 1);
		if (dest == NULL) exit(1);
	}

	int i = 0;
	for (i = 0; i < n; i++) {
		dest[i] = src[i];
		if (src[i] == '\0') 
			return dest;
	}

	dest[i] = '\0';
	return dest;
}

int main() {
	char buffer[10];
	my_strncpy(buffer, "SoftUni", 7);
	printf("%s\n", buffer);
	my_strncpy(buffer, "SoftUni", 3);
	printf("%s\n", buffer);
	my_strncpy(buffer, "C is cool", 0);
	printf("%s\n", buffer);

	char* result = my_strncpy(NULL, "SoftUni", 7);
	printf("%s\n", result);
	
	free(result);
	return 0;
}