#include <ctype.h>
#include <stdio.h>

int main() {
	unsigned char symbol;
	for ( symbol = 0; symbol < 255; symbol++) {
		if (isprint(symbol)) {
			printf("%c ", symbol);
		} else {
			printf("@ ");
		}
	}

	return 0;
}