#include "bin_operations.h"
/*
c pitfalls when using long and the << operator :
int get_bit_long(unsigned long n, int pos)
{
	long mask = (long)1 << pos; !!!!!!!!!!
	return (n & mask) != 0;
}
*/
int get_bit(int n, int pos)
{
	assert(pos >= 0 && pos < 32);
	int mask = 1 << pos;
	return (n & mask) != 0; 
}

int set_bit(int n, int pos, int bit_val)
{
	assert(pos >= 0 && pos < 32);
	assert(bit_val == 0 || bit_val == 1);

	int mask = 1 << pos;

	if (bit_val){
		n = n | mask;
	} else {
		mask = ~mask;
		n = n & mask;
	}

	return n;
}

int exchange_bits(int n, int pos_1, int pos_2) 
{
	assert(pos_1 >= 0 && pos_1 < 32);
	assert(pos_2 >= 0 && pos_2 < 32);
	int bit_1 = get_bit(n, pos_1);
	int bit_2 = get_bit(n, pos_2);
	n = set_bit(n, pos_1, bit_2);
	n = set_bit(n, pos_2, bit_1);
	return n;
}