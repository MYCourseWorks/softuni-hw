#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MANAGER_MAX_SIZE 500
#define COMPANY_MAX_SIZE 2000
#define MANAGER_FORMATTER "Manager Name: %s %s\nManager Age: %u\nManager phone number: %s"
#define COMPANY_FORMATTER "Company name: %s\nAddress: %s\n\
Company phone: %s\nCompany fax: %s\n%s"

typedef struct Manager {
	char* first_name;
	char* last_name;
	unsigned short age;
	char* phone_number;
} Manager;

char* manager_to_string(Manager * manager, int manager_str_size) {
	if (manager_str_size < 0 || manager_str_size > MANAGER_MAX_SIZE) {
		return NULL;
	}

	char* buffer = malloc(sizeof(char) * manager_str_size);
	snprintf(buffer,
		manager_str_size,
		MANAGER_FORMATTER,
		manager->first_name,
		manager->last_name,
		manager->age,
		manager->phone_number);

	return buffer;
}

typedef struct  Company {
	char* name;
	char* address;
	char* phone;
	char* fax_number;
	char* web_site;
	struct Manager manager;
} Company;

char* company_to_string(Company* company, int company_str_size) {
	if (company_str_size < 0 || company_str_size > COMPANY_MAX_SIZE) {
		return NULL;
	}

	char* buffer = malloc(sizeof(char)* company_str_size); 
	char* manager_str = manager_to_string(&company->manager, MANAGER_MAX_SIZE); 
	snprintf(buffer,
		company_str_size,
		COMPANY_FORMATTER,
		company->name,
		company->address,
		company->phone,
		company->fax_number == NULL ? "undefined" : company->fax_number,
		manager_str);

	free(manager_str);
	return buffer;
}

int main() {
	Manager mg = {"Pesho", "Peshev", 20, "0889794123"};
	Company comp = {
		"Software University", 
		"15-18 Tintyava, Sofia", 
		"+359 899 55 55 92",
		NULL,
		"http:/softuni.bg",
		mg,
	};
	
	char* company_str = company_to_string(&comp, COMPANY_MAX_SIZE);
	printf("%s\n", company_str);
	free(company_str);
	return 0;
}