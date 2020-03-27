#include <stdio.h>
#include <stdint.h>

int get_bit_long(uint64_t n, uint64_t pos)
{
	uint64_t mask = (uint64_t)1 << pos;
	return (n & mask) != 0;
}

int main()
{
	uint64_t n = 0;
	int sift_count = 0;

	#ifdef _WIN32
		scanf("%llu %d", &n, &sift_count);
	#else
		scanf("%lu %d", &n, &sift_count);
	#endif

	int i;
	for (i = 0; i < sift_count; ++i) {
		uint64_t curr_sift = 0;
		#ifdef _WIN32
			scanf("%llu", &curr_sift);
		#else
			scanf("%lu", &curr_sift);
		#endif
		n ^= curr_sift;
		n &= ~curr_sift;
	}

	int ones_counter = 0;
	for (i = 0; i < sizeof(int64_t) * 8; ++i) {
		if(get_bit_long(n, i) == 1) {
			ones_counter++;
		}
	}

	printf("%d\n", ones_counter);
	return 0;
}