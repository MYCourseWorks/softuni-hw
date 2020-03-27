#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

#define MAX_EMPL_STR_SIZE 1000
#define EMPLOYEE_FORMATTER "First name: %s\nLast name: %s\nAge: %u\nGender: %s\nPersonal ID: %llu\nUnique Employee number: %u\n"

enum Gender {
	undefined = 0,
	male = 1,
	fmale = 2
};

char * print_gender(enum Gender gender) {
	switch (gender) {
		case 0: return "undefined";
		case 1: return "male";
		case 2: return "fmale";
		default: return NULL;
	}
}

typedef struct {
	char* firstName;
	char* lastName;
	unsigned int age;
	enum Gender gender;
	unsigned long long personal_id;
	unsigned int employee_number;
} Employee;

char * employee_to_string (Employee* empl, int empl_string_size) {
	if (empl_string_size < 0 || empl_string_size > MAX_EMPL_STR_SIZE) {
		return NULL;
	}

	char* buffer = malloc(sizeof(char) * empl_string_size);
	snprintf(buffer, 
		empl_string_size,
		EMPLOYEE_FORMATTER, 
		empl->firstName, 
		empl->lastName,
		empl->age,
		print_gender(empl->gender),
		empl->personal_id,
		empl->employee_number);
	
	return buffer;
}

int main() {
	Employee empl;
	empl.firstName = "Pesho";
	empl.lastName = "Peshev";
	empl.age = 20;
	empl.gender = male; 
	empl.personal_id = 8306112507;
	empl.employee_number = 27563571;

	char* empl_str = employee_to_string(&empl, 200);
	printf("%s", empl_str);
	free(empl_str);
	return 0;
}