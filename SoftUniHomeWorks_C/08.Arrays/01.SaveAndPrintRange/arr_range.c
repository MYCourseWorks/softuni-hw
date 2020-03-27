#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() {
	int n = 0;
	char line_buffer[100]; 
	printf("n = ");
	fgets(line_buffer, 10, stdin);
	
	if(sscanf(line_buffer, "%d", &n) == 0) {
		printf("Invalid input\n");
		return 1;
	}

	if (n < 0) {
		printf("Invalid input\n");
		return 1;
	}

	printf("line = ");
	fgets(line_buffer, 100, stdin);
	
	int i = 0;
	int* arr = malloc(n * sizeof(int));
	char* current_split = strtok(line_buffer, " ");
	while(current_split != NULL) {
		if (i >= n) {
			printf("Invalid input\n");
			return 1;
		}

		arr[i] = strtol(current_split, NULL, 10);
		current_split = strtok(NULL, " ");
		i++;
	}

	for (i = 0; i < n; ++i) {
		printf("%d ", arr[i]);
	}

	printf("\n");
	free(arr);
	return 0;
}