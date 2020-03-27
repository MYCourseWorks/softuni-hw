## ``` 1. bool contains(void*, void*, int, size_t, int(*cmp_fn)(void* a, void* b)) ```
### Contains with integers:
```c
int int_comparator(void* a, void* b)
{
	return *(int*)a - *(int*)b;
}

int main()
{
	int arr[] = {1, 2, 3, 4};
	int n = 4;
	int key = 2;
	bool contained = contains(arr, &key,  n, sizeof(int), int_comparator);
	printf("%s\n", contained ? "true" : "false"); // prints true
	return 0;
}
```
### Contains with char* arrays:
```c
int str_cmp(void* a, void* b)
{
	char* first = *(char**)a;
	char* second = *(char**)b;
	return strcmp(first, second);
}

int main()
{
	char* str_arr[] = {"test", "example", "something"};
	int n = 3;
	char* key = "example";
	bool contained = contains(str_arr, &key,  n, sizeof(char*), str_cmp);
	printf("%s\n", contained ? "true" : "false"); // prints true
	return 0;
}
```
## ``` 2. int linear_search(void*, void*, int, size_t, int (*cmp_fn)(void* a, void* b)) ```
### Linear search with integer:
```c
int int_comparator(void* a, void* b)
{
	return *(int*)a - *(int*)b;
}

int main()
{
	int arr[] = {1, 2, 3, 4};
	int n = 4;
	int key = 3;
	int index = linear_search(arr, &key,  n, sizeof(int), int_comparator);
	printf("%d\n", index); // prints 2
	return 0;
}
```
### Linear search with char* arrays:
```c
int str_cmp(void* a, void* b)
{
	char* first = *(char**)a;
	char* second = *(char**)b;
	return strcmp(first, second);
}

int main()
{
	char* str_arr[] = {"test", "example", "something"};
	int n = 3;
	char* key = "test";
	int index = linear_search(str_arr, &key,  n, sizeof(char*), str_cmp);
	printf("%d\n", index); // prints 0
	return 0;
}
```
## ``` 3. bool swap(void* a, void* b) ```
### swap with integers:
```c
int main()
{
	int a = 2;
	int b = 6;
	swap(&a, &b, sizeof(int));
	printf("%d %d\n", a, b); // prints 6 2
	return 0;
}
```
### swap with char*:
```c
int main()
{
	char* a = "test";
	char* b = "something";
	swap(&a, &b, sizeof(char*));
	printf("%s %s\n", a, b); // prints something test
	return 0;
}
```
### swap with dynamic char* arrays:
```c
int main()
{
	char** a = malloc(2);
	char** b = malloc(2);
	a[0] = strdup("test");
	a[1] = strdup("test");
	b[0] = strdup("something");
	b[1] = strdup("something");

	swap(&a, &b, sizeof(char*));
	printf("%s %s\n", a[0], b[0]); // prints something test
	printf("%s %s\n", a[1], b[1]); // prints something test
	
	// free memory ....
	return 0;
}
```
## ``` 4. void selection_sort(void*, int, size_t, int(*cmp_fn)(void* a, void* b)) ```
### selection sort with integer array:
```c
int int_comparator(void* a, void* b)
{
	return *(int*)a - *(int*)b;
}

int main()
{
	int arr[] = {4, 3, 8, 2};
	int n = 4;
	selection_sort(arr, 4, sizeof(int), int_comparator);
	printf("%d\n", arr[0]); // 2
	printf("%d\n", arr[1]); // 3
	printf("%d\n", arr[2]); // 4
	printf("%d\n", arr[3]); // 8
	return 0;
}

```
### selection sort with char* array:
```c
int str_cmp(void* a, void* b)
{
	char* first = *(char**)a;
	char* second = *(char**)b;
	return strcmp(first, second);
}

int main()
{
	char* arr[] = {"zzz", "aaa", "bbb"};
	int n = 3;
	selection_sort(arr, n, sizeof(char*), str_cmp);
	printf("%s\n", arr[0]); // "aaa"
	printf("%s\n", arr[1]); // "bbb"
	printf("%s\n", arr[2]); // "zzz"
	return 0;
}
```
## ``` 5. void arr_print(void*, int, size_t, void(*print_fn)(void* a)) ```
### arr_print with integers:
```c
void print_integers(void* a) 
{
	printf("%d ", *(int*)a);
}

int main()
{
	int arr[] = {1, 2, 3, 4, 5};
	int n = sizeof(arr) / sizeof(int);
	arr_print(arr, n, sizeof(int), print_integers); // 1 2 3 4 5
	printf("\n");
	return 0;
}
```
### arr_print with char* array:
```c
void print_str(void* a) 
{
	printf("%s ", *(char**)a);
}

int main()
{
	char* arr[] = {"one", "two", "three"};
	int n = sizeof(arr) / sizeof(char*);
	arr_print(arr, n, sizeof(char*), print_str); // one two three
	printf("\n");
	return 0;
}
```
