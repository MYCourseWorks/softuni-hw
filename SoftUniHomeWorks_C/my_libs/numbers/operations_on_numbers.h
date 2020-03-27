#include <stdbool.h>
#include <math.h>

#ifndef OPERATIONS_ON_NUMBERS_H
#define OPERATIONS_ON_NUMBERS_H 1

/*
summary:
	This function calculates the digit count of
	an integer number.
uses:
	math.h
*/
int digit_count(int n);
/*
summary:
	This function gives the digit at a given 
	position in an integer number.
returns:
	The found digit or -1 if the position is
	wrong.
*/
int get_digit_at(int num, int pos);
/*
summary:
	This function creates a reversed copy
	of the given number.
return:
	The reversed copy.
*/
int reverse_number(int num);
/*
summary:
	This function puts zero digit at a given position.
arguments:
	int* num -> takes the address of the number to change.
	int pos -> is the position. If the position is
		invalid the num variable will remain unchanged.
uses:
	math.h and get_digit_at(int n)
*/
void put_zero_digit_at(int* num, int pos);
/*
summary:
	This function puts any digit at a given position
arguments:
	int* num -> takes the address of the number to change.
	int pos -> is the position. If the position is
	invalid the num variable will remain unchanged. 
uses:
	math.h and get_digit_at(int n)
*/
void put_given_digit_at(int* num, int digit, int pos);
/*
summary:
	This functions swaps the digits at first and second pos.
arguments:
	int* num -> takes the address of the number to change.
	int first_pos, second_pos -> the positions to be swapped.
		If the any of the positions are invalid the num 
		variable will remain unchanged.
uses:
	math.h and get_digit_at(int n)
*/
void swap_digits_at(int* num, int first_pos, int second_pos);
/*
summary:
	Checks if a number is prime.
uses:
	math.h and stdbool.h
*/
bool is_prime(int n);
/*
summary:
	Finds the greatest common divisor between two numbers
*/
int calc_gcd(int a, int b);
/*
summary:
	Finds the lowest common divisor between two numbers
uses:
	calc_gcd(int a, int b)
*/
int calc_lcd(int a, int b);

#endif