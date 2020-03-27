FLAGS := -g -Wall
CONSOLE_READ_LINE := ../lib/console_read_line.c
STRINGS := ../lib/str_functions.c
GENERICS := ../lib/generics.c
SB := ../lib/string_builder/string_builder.c
01_REVERSE_STR := 01.StringReverse/reverse_str.c
02_STR_LEN := 02.StrLength/str_len.c
03_SERIES := 03.SeriesOfLetters/series_of_letters.c
04_COUNT_SUBSTRING := 04.CountSubstring/count_substring.c
05_TEXT_FILTER := 05.TextFilter/text_filter.c
06_PALINDROMS := 06.Palindroms/palindroms.c
07_STRCOPY := 07.Strcopy/strcopy.c
08_STRCONCAT := 08.Strconcat/strconcat.c
09_WORD_COUNT := 09.WordCount/word_count.c
10_STR_LEN := 10.StringLen/string_len.c
11_STR_SEARCH := 11.StringSearch/str_search.c
12_SUB_STR := 12.Substring/substring.c
13_READ_LINE := 13.ReadLine/readline.c
14_PALINDROM_MATRIX := 14.PalindromMatrix/palindrom_matrix.c
15_REMOVE_NAMES := 15.RemoveNames/remove_names.c
16_LONGEST_WORD := 16.LongestWord/longest_word.c
17_XML_PARSER := 17.XmlParser/xml_parser.c
18_LONGEST_AREA_IN_ARRAY := 18.LongestAreaInArray/longest_area.c
19_SORT_CITY_NAMES := 19.SortCityNames/sort_city_names.c
20_PRINT_DIAGONAL := 20.PrintDiagonal/print_diagonal.c
21_DIAMOND := 21.Diamond/diamond.c
22_LETTERS_CHANGE_NUMBERS := 22.LettersChangeNumbers/letters_change_numbers.c

All: StringReverse StringLength SeriesOfLetters CountSubstring \
	TextFilter Palindroms StringCopy StrConcat WordCount \
	StringLen StringSearch Substring ReadLine PalindromMatrix \
	RemoveNames LongestWord XmlParser LongestAreaInArray \
	SortCityNames PrintDiagonal Diamond LettersChangeNumbers

StringReverse: $(01_REVERSE_STR) $(CONSOLE_READ_LINE)
	gcc $(FLAGS) $(01_REVERSE_STR) $(CONSOLE_READ_LINE) \
	-o 01.StringReverse/bin/str_reverse

StringLength: $(02_STR_LEN) $(CONSOLE_READ_LINE)
	gcc $(FLAGS) $(02_STR_LEN) $(CONSOLE_READ_LINE) \
	-o 02.StrLength/bin/str_len

SeriesOfLetters: $(03_SERIES) $(CONSOLE_READ_LINE)
	gcc $(FLAGS) $(03_SERIES) $(CONSOLE_READ_LINE) \
	-o 03.SeriesOfLetters/bin/series_of_letters

CountSubstring: $(04_COUNT_SUBSTRING) $(CONSOLE_READ_LINE)
	gcc $(FLAGS) $(04_COUNT_SUBSTRING) $(CONSOLE_READ_LINE) \
	-o 04.CountSubstring/bin/count_substring

TextFilter: $(05_TEXT_FILTER) $(CONSOLE_READ_LINE)
	gcc $(FLAGS) $(05_TEXT_FILTER) $(CONSOLE_READ_LINE) \
	-o 05.TextFilter/bin/text_filter

Palindroms: $(06_PALINDROMS) $(CONSOLE_READ_LINE) $(STRINGS) $(GENERICS)
	gcc $(FLAGS) $(06_PALINDROMS) $(CONSOLE_READ_LINE) $(STRINGS) \
	$(GENERICS) -o 06.Palindroms/bin/palindroms -std=c11

StringCopy: $(07_STRCOPY)
	gcc $(FLAGS) $(07_STRCOPY) -o 07.Strcopy/bin/strcopy

StrConcat: $(08_STRCONCAT)
	gcc $(FLAGS) $(08_STRCONCAT) -o 08.Strconcat/bin/strconcat

WordCount: $(09_WORD_COUNT)
	gcc $(FLAGS) $(09_WORD_COUNT) -o 09.WordCount/bin/wordcount

StringLen: $(10_STR_LEN)
	gcc $(FLAGS) $(10_STR_LEN) -o 10.StringLen/bin/string_len

StringSearch: $(11_STR_SEARCH)
	gcc $(FLAGS) $(11_STR_SEARCH) -o 11.StringSearch/bin/str_search

Substring: $(12_SUB_STR)
	gcc $(FLAGS) $(12_SUB_STR) -o 12.Substring/bin/substring

ReadLine: $(13_READ_LINE)
	gcc $(FLAGS) $(13_READ_LINE) -o 13.ReadLine/bin/readline 

PalindromMatrix: $(14_PALINDROM_MATRIX)
	gcc $(FLAGS) $(14_PALINDROM_MATRIX) \
	-o 14.PalindromMatrix/bin/palindrom_matrix

RemoveNames: $(15_REMOVE_NAMES) $(STRINGS) $(CONSOLE_READ_LINE)
	gcc $(FLAGS) $(15_REMOVE_NAMES) $(STRINGS) $(CONSOLE_READ_LINE) \
	-o 15.RemoveNames/bin/reamove_names

LongestWord: $(16_LONGEST_WORD) $(CONSOLE_READ_LINE) $(SB)
	gcc $(FLAGS) $(16_LONGEST_WORD) $(CONSOLE_READ_LINE) $(SB) \
	-o 16.LongestWord/bin/longestword -std=c11

XmlParser: $(17_XML_PARSER) $(CONSOLE_READ_LINE) $(SB)
	gcc $(FLAGS) $(17_XML_PARSER) $(CONSOLE_READ_LINE) $(SB) \
	-o 17.XmlParser/bin/xml_parser -std=c11

LongestAreaInArray: $(18_LONGEST_AREA_IN_ARRAY)
	gcc $(FLAGS) $(18_LONGEST_AREA_IN_ARRAY) \
	-o 18.LongestAreaInArray/bin/longest_area

SortCityNames: $(19_SORT_CITY_NAMES) $(GENERICS) $(STRINGS) $(CONSOLE_READ_LINE)
	gcc $(FLAGS) $(19_SORT_CITY_NAMES) $(GENERICS) $(STRINGS) \
	$(CONSOLE_READ_LINE) -o 19.SortCityNames/bin/sort_city_names -std=c11

PrintDiagonal: $(20_PRINT_DIAGONAL) $(SB) $(CONSOLE_READ_LINE) $(STRINGS)
	gcc $(FLAGS) $(20_PRINT_DIAGONAL) $(SB) $(CONSOLE_READ_LINE) $(STRINGS) \
	-o 20.PrintDiagonal/bin/print_diagonal -std=c11

Diamond: $(21_DIAMOND)
	gcc $(FLAGS) $(21_DIAMOND) -o 21.Diamond/bin/diamond -std=c11

LettersChangeNumbers: $(22_LETTERS_CHANGE_NUMBERS) $(CONSOLE_READ_LINE) $(SB) $(STRINGS)
	gcc $(FLAGS) $(22_LETTERS_CHANGE_NUMBERS) $(CONSOLE_READ_LINE) $(SB) $(STRINGS) \
	-o 22.LettersChangeNumbers/bin/letters_change_numbers -std=c11 -lm