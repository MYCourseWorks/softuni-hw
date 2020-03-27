#include <stdio.h>
#include <stdlib.h>

int r_bin_search(int* arr, int key, int start, int end) {
	int mid = (end - start) / 2 + start;

	if (arr[mid] < key) {
		if(mid + 1 == end)
			return -1;
		else 
			r_bin_search(arr, key, mid, end);
	} else if (arr[mid] > key) {
		if (mid == start)
			return -1;
		else 
			r_bin_search(arr, key, start, mid);
	} else {
		return mid;
	}
}

int bin_search(int* arr, int key, int len) {
	return r_bin_search(arr, key, 0, len);
} 

int main() {
	int n, key, i;
	scanf("%d", &n);
	int* arr = malloc(n * sizeof(int));
	for (i = 0; i < n; ++i)	{
		scanf("%d", &arr[i]);
	}

	scanf("%d", &key);
	printf("%d\n", bin_search(arr, key, n));
	free(arr);
	return 0;
}