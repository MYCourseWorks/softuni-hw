#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// implementation with dynamic memory :
char* copy_sub_str(const char* src, int pos, int len) {
	int src_len = strlen(src);
	int substr_len = pos + len;
	
	if (src == NULL)
		return NULL;
	if (pos >= src_len)
		return NULL;
	if (substr_len > src_len) 
		substr_len = src_len;

	char* substring = malloc(substr_len + 1);
	if (!substring) 
		return NULL;

	memcpy(substring, src + pos, substr_len);
	substring[substr_len] = '\0';
	return substring;
}

int main() {
	char* substring = copy_sub_str("Breaking Bad", 0, 2);	
	printf("%s\n", substring);
	if (substring) free(substring);

	substring = copy_sub_str("Maniac", 3, 3);
	printf("%s\n", substring);
	if (substring) free(substring);

	substring = copy_sub_str("Maniac", 3, 5);
	printf("%s\n", substring);
	if (substring) free(substring);

	substring = copy_sub_str("Master Yoda", 13, 5);
	printf("%s\n", !substring ? "(empty string)" : substring);
	if (substring) free(substring);

	return 0;
}