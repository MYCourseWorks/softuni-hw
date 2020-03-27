FLAGS := -g -Wall
BIT_HELPERS := ../lib/bin_operations.c
01_FIRST_BIT := 01.FirstBit/first_bit.c
02_THIRD_BIT := 02.ThirdBit/third_bit.c
03_GET_BIT_AT := 03.GetBitAt/get_bit_at.c
04_BIT_DESTROYER := 04.BitDestroyer/bit_destroyer.c
05_MODIFY_BIT := 05.ModifyBit/modify_bit.c
06_BIT_EXCHANGE := 06.BitExchange/bit_exchange.c
07_BIT_EXCHANGE_ADV := 07.BitExchangeAdvanced/bit_exchange_advanced.c
08_BITS_UP := 08.BitsUp/bits_up.c
09_BIT_SIFTING := 09.BitSifting/bit_sifting.c

all: FirstBit ThirdBit GetBitAt BitDestroyer ModifyBit \
	BitExchange BitExchangeAdvanced BitsUp BitSifting

FirstBit: $(01_FIRST_BIT) $(BIT_HELPERS)
	gcc $(FLAGS) $(01_FIRST_BIT) $(BIT_HELPERS) \
	-o 01.FirstBit/bin/first_bit

ThirdBit: $(02_THIRD_BIT) $(BIT_HELPERS)
	gcc $(FLAGS) $(02_THIRD_BIT) $(BIT_HELPERS) \
	-o 02.ThirdBit/bin/third_bit

GetBitAt: $(03_GET_BIT_AT) $(BIT_HELPERS)
	gcc $(FLAGS) $(03_GET_BIT_AT) $(BIT_HELPERS) \
	-o 03.GetBitAt/bin/get_bit_at

BitDestroyer: $(04_BIT_DESTROYER) $(BIT_HELPERS)
	gcc $(FLAGS) $(04_BIT_DESTROYER) $(BIT_HELPERS) \
	-o 04.BitDestroyer/bin/bit_destroyer

ModifyBit: $(05_MODIFY_BIT) $(BIT_HELPERS)
	gcc $(FLAGS) $(05_MODIFY_BIT) $(BIT_HELPERS) \
	-o 05.ModifyBit/bin/modify_bit

BitExchange: $(06_BIT_EXCHANGE) $(BIT_HELPERS)
	gcc $(FLAGS) $(06_BIT_EXCHANGE) $(BIT_HELPERS) \
	-o 06.BitExchange/bin/bit_exchange

BitExchangeAdvanced: $(07_BIT_EXCHANGE_ADV) $(BIT_HELPERS)
	gcc $(FLAGS) $(07_BIT_EXCHANGE_ADV) $(BIT_HELPERS) \
	-o 07.BitExchangeAdvanced/bin/bit_exchange_adv

BitsUp: $(08_BITS_UP) $(BIT_HELPERS)
	gcc $(FLAGS) $(08_BITS_UP) $(BIT_HELPERS) \
	-o 08.BitsUp/bin/bits_up

BitSifting: $(09_BIT_SIFTING) $(BIT_HELPERS)
	gcc $(FLAGS) $(09_BIT_SIFTING) $(BIT_HELPERS) \
	-o 09.BitSifting/bin/bit_sifting	