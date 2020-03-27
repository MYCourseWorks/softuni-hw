#include <stdio.h>

int first_larger_than_neighbours(int* arr, int n);

int first_larger_than_neighbours(int* arr, int n) {
	int i;
	int index = -1;

	for (i = 1; i < n - 1; ++i) {
		if (arr[i] > arr[i + 1] && arr[i] > arr[i - 1]) {
			index = i;
			break;
		}
	}

	return index;
}

int main() {
	int sequence_one[] = { 1, 3, 4, 5, 1, 0, 5 };
	int size = sizeof(sequence_one) / sizeof(int);
	printf("%d\n", first_larger_than_neighbours(sequence_one, size));
	
	int sequence_two[] = { 1, 2, 3, 4, 5, 6, 6 };
	size = sizeof(sequence_two) / sizeof(int);
	printf("%d\n", first_larger_than_neighbours(sequence_two, size));
	
	int sequence_three[] = { 1, 1, 1 };
	size = sizeof(sequence_three) / sizeof(int);
	printf("%d\n", first_larger_than_neighbours(sequence_three, size));

	return 0;
}