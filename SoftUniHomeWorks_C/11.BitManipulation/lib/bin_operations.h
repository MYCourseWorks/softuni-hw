#include <assert.h>

#ifndef BIT_OPERATIONS_H_
#define BIT_OPERATIONS_H_ 1

int get_bit(int n, int pos);
int set_bit(int n, int pos, int bit_val);
int exchange_bits(int n, int pos_1, int pos_2);

#endif