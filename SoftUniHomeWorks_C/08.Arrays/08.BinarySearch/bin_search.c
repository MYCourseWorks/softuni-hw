#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

int binary_search(void* sorted_arr, 
				  void* key, 
				  int len, 
				  int type_size,
				  int(*cmp_fn)(void* a, void* b)) 
{
	if (len < 0)
		return -1;

	int mid = len / 2;
	int low = 0;
	int high = len;
	int key_index = 0;
	bool done = false;

	while(!done) {
		void* curr_elem = (char*)sorted_arr + mid * type_size;

		if (cmp_fn(curr_elem, key) == 0) {
			key_index = mid;
			done = true;
		} else if (cmp_fn(curr_elem, key) < 0) {
			low = mid;
			if(low + 1 == high) {
				key_index = -1;
				done = true;
			}
		} else if (cmp_fn(curr_elem, key) > 0) {
			high = mid;
			if(high == low) {
				key_index = -1;
				done = true;
			}
		}

		mid = (high - low) / 2 + low;
	}

	return key_index;
}

int int_cmp(void* a, void* b) {
	return *(int*)a - *(int*)b;
}

int main() {
	int n, key, i;
	scanf("%d", &n);
	int* arr = malloc(n * sizeof(int));
	for (i = 0; i < n; ++i)	{
		scanf("%d", &arr[i]);
	}

	scanf("%d", &key);
	printf("%d\n", binary_search(arr, &key, n, sizeof(int), int_cmp));
	free(arr);
	return 0;
}