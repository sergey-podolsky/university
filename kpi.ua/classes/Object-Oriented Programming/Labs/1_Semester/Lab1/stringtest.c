/* * * * * * * * * * * * * * * * * 
 * Лабораторная работа №1
 * (работа со строками)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * mystring.h - содержит прототипы функций;
 * mystring.c - содержит определеня функций;
 * stringtest.c -  тест-драйв, демонстрирующий работоспособность функций
 * * * * * * * * * * * * * * * * */


#include <stdio.h>
#include "mystring.h"

int main()
{
	/*substr*/
	{
		char *string1 = "Microsoft";
		char *string2 = "soft";
		printf("substr(''%s'', ''%s'') == %d\n", string1, string2, substr(string1, string2));
	}
	
	/*compact*/
	{
		char *string = "abbcccddddeeeeedddddd";
		int count = 5;
		printf("compact(''%s'', %i) == ''%s''\n", string, count, compact(string, count));
	}

	/*subseq*/
	{
		char *string1 = "__student";
		char *string2 = "__docent";
		printf("subseq(''%s'', ''%s'') == %i\n", string1, string2, subseq(string1, string2));
	}

	/*addword*/
	{
		int i, size = 10;
		char *arr = (char*) malloc(size);
		char *word = "word";
		arr[0] = '0';
		arr[1] = '1';
		arr[2] = '2';
		arr[3] = '\0';
		arr[4] = '\0';
		printf("addword(''%s'', ''", word);
		for (i=0; i < size; i++)
			printf("%c", arr[i]);
		printf("'', %i) = %i;  arr == ''", size, addword(word, arr, size));
		for (i=0; i < size; i++)
			printf("%c", arr[i]);
		printf("''\n\n");
	}

	/*sort*/
	{
		char i, *strings[] = {"ab", "ac", "aba"};
		for (i = 0; i < 3; i++) printf("  strings[%i] == ''%s''\n",i, strings[i]);
		printf("// After sort(strings, 3):\n");
		sort(strings, 3);
		for (i = 0; i < 3; i++) printf("  strings[%i] == ''%s''\n",i, strings[i]);
	}

	/*ispal*/
	{
		char *string = "abcba";
		printf("\nispal(%s) == %i\n", string, ispal(string));
	}

	/*makepal*/
	{
		char *string = "abc";
		printf("makepal(%s) == %s\n", string, makepal(string));
	}

	/*txt2double*/
	{
		char *string = " 3.14; 100; -1.4";
		int k, size;
		double *res = txt2double(string, &size);
		printf("txt2double(''%s'', size):\n", string);
		printf("  size == %i\n", size);
		if (0 == size)
			printf("  Incorrect convertation\n");
		else
			for (k = 0; k < size; k++)
				printf("  res[%i] == %g\n", k, res[k]);
	}

	return 0;
}

