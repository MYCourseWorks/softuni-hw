FLAGS := -g -Wall
SB := ../lib/string_builder.c
01_PRINT_FILE := 01.PrintFile/print_file.c
02_ODD_LINES := 02.OddLines/odd_lines.c
03_LINE_NUMBERS := 03.LineNumbers/line_numbers.c
04_FILE_COPY := 04.FileCopy/file_copy.c

all: PrintFile OddLines LineNumbers FileCopy

PrintFile: $(01_PRINT_FILE) $(SB)
	gcc $(FLAGS) $(01_PRINT_FILE) $(SB) \
	-o 01.PrintFile/bin/print_file -std=c11

OddLines: $(02_ODD_LINES) $(SB)
	gcc $(FLAGS) $(02_ODD_LINES) $(SB) \
	-o 02.OddLines/bin/odd_lines -std=c11

LineNumbers: $(03_LINE_NUMBERS) $(SB)
	gcc $(FLAGS) $(03_LINE_NUMBERS) $(SB) \
	-o 03.LineNumbers/bin/line_numbers -std=c11 -lm

FileCopy: $(04_FILE_COPY) $(SB)
	gcc $(FLAGS) $(04_FILE_COPY) $(SB) \
	-o 04.FileCopy/bin/file_copy -std=c11
