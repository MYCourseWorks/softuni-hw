#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void swap(void* a, void* b, size_t type_size) {
	char* buffer = malloc(type_size);
	memcpy(buffer, a, type_size);
	memcpy(a, b, type_size);
	memcpy(b, buffer, type_size);
	free(buffer);
}

void selection_sort(void* arr, 
					int len, 
					size_t elem_size, 
					int(*cmp_fn)(void*, void*)) 
{
	for (int i = 0; i < len; i++) {
		int flag = i;
		void* smallest_addr = (char*)arr + i * elem_size;
		for (int j = i + 1; j < len; j++) {
			void* curr_elem_addr = (char*)arr + j * elem_size;
			if (cmp_fn(smallest_addr, curr_elem_addr) > 0) {
				smallest_addr = (char*)arr + j * elem_size;
				flag = j;
			}
		}

		if (flag != i) {
			void* first_addr = (char*)arr + i * elem_size;
			void* second_addr = (char*)arr + flag * elem_size;
			swap(first_addr, second_addr, elem_size);
		}
	}
}

typedef struct {
	char* name;
	int age;
	double balance;
} Client;

void sort_clients(Client* clients, 
				  int clients_count, 
				  int(*cmp_fn)(void*, void*))
{
	selection_sort(clients, clients_count, sizeof(Client), cmp_fn);
}

int age_comparer(void* a, void* b) {
	Client* first = (Client*)a;
	Client* second = (Client*)b;
	return first->age - second->age;
}

int balance_comparer(void* a, void* b) {
	Client* first = (Client*)a;
	Client* second = (Client*)b;
	double balance_diff = first->balance - second->balance;

	if (balance_diff == 0)
		return 0;
	else if (balance_diff > 0)
		return 1;
	else 
		return -1;
}

int name_comparer(void* a, void* b) {
	Client* first = (Client*)a;
	Client* second = (Client*)b;
	return strcmp(first->name, second->name);
}

void print_clients(Client* c, int len, char* padding) {
	int i;
	for (i = 0; i < len; ++i) {
		Client current = c[i];
		printf("%s{ name: %s, age: %d, balance: %.2f }\n", 
			padding, current.name, current.age, current.balance);
	}
}

int main() {
	Client clients[] = { 
		{ "Pesho", 53, 20.3 }, 
		{ "Asen", 20, 30 }, 
		{ "Gosho", 12, 10 }
	};
	int clients_count = sizeof(clients) / sizeof(Client);

	printf("Initial clients arr: \n");
	print_clients(clients, clients_count, "\t");
	
	printf("Sort by age: \n");
	sort_clients(clients, clients_count, &age_comparer);
	print_clients(clients, clients_count, "\t");
	
	printf("Sort by balance: \n");
	sort_clients(clients, clients_count, &balance_comparer);
	print_clients(clients, clients_count, "\t");

	printf("Sort by name: \n");
	sort_clients(clients, clients_count, &name_comparer);
	print_clients(clients, clients_count, "\t");
	return 0;
}