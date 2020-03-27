#include <stdio.h>
#include <stdlib.h>

#define MAX_NAME_SIZE 300
#define MAX_BANK_ACC_STR_SIZE 1000
#define BANK_ACCOUNT_FORMATTER "Bank Account data :\n\t%s\n\tBank name = %s\n\tBalance = %0.2f\n\tIBAN = %s\n\tCredit card numbers : %llu %llu %llu"

typedef struct Name{
	char * first_name;
	char * middle_name;
	char * last_name;
} Name;

char * name_to_string(Name * name, int name_str_size) {
	if (name_str_size < 0 || name_str_size > MAX_NAME_SIZE) {
		return NULL;
	}

	char* buffer = malloc(sizeof(char) * name_str_size);
	snprintf(buffer,
		name_str_size,
		"Name = %s %s %s",
		name->first_name,
		name->middle_name,
		name->last_name);

	return buffer;
} 

typedef struct Bank_Account {
	Name name;
	double money_amount;
	char * bank_name;
	char * IBAN;
	unsigned long long * credit_card_numbers;
} Bank_Account;

char * bank_account_to_string(Bank_Account * bank_account, int max_bank_account_size) {
	if (max_bank_account_size < 0 || max_bank_account_size > MAX_BANK_ACC_STR_SIZE) {
		return NULL;
	}

	char * buffer = malloc(sizeof(char) * max_bank_account_size);
	char * name_str = name_to_string(&bank_account->name, MAX_NAME_SIZE);
	
	snprintf(buffer,
		max_bank_account_size,
		BANK_ACCOUNT_FORMATTER,
		name_str, 
		bank_account->bank_name,
		bank_account->money_amount, 
		bank_account->IBAN,
		bank_account->credit_card_numbers[0],
		bank_account->credit_card_numbers[1],
		bank_account->credit_card_numbers[2]);

	free(name_str);
	return buffer;
}

int main() {
	unsigned long long credit_card_numbers[3];
	credit_card_numbers[0] = 378282246310005;
	credit_card_numbers[1] = 674212246310025;
	credit_card_numbers[2] = 124412242330425;

	Name person_name = { "Pesho",  "Peshev", "Gacov" };
	Bank_Account bank_account = { person_name, 12.20, "PESHOs BANK", "GB29 NWBK 6016 1331 9268 19", credit_card_numbers};
	
	char * account_str = bank_account_to_string(&bank_account, MAX_BANK_ACC_STR_SIZE);
	printf("%s\n", account_str);
	free(account_str);
	
	return 0;
}