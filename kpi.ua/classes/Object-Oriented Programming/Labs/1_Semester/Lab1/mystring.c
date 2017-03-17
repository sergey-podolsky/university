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


#include <string.h>
#include <stdlib.h>
#include "mystring.h" 


int substr(char *string1, char *string2)
{
	int i, len = strlen(string1) - strlen(string2);

	for (i = 0; i <= len; i++)
	{
		int j;
		for (j = 0; string2[j] && (string1[i+j] == string2[j]); j++);
		if (!string2[j]) return i;
	}
	return -1;
}


char *compact(char *string, int count)
{
	char *res, *string_cur = string;
	int res_len = 0;

	//Calculating length for result string
	while (*string_cur)
	{
		int j = 1;
		while (*++string_cur == *(string_cur-1)) j++;
		if (j < count) res_len+= j;
		else
			for (res_len+= 3; j>0; j/= 10) res_len++;
	}

	//Allocating memory for result string
	if (NULL == (res = (char*) malloc(res_len + 1))) return NULL;

	//Making Result string
	string_cur = string;
	while (*string_cur)
	{
		int j = 1;
		while (*++string_cur == *(string_cur - 1)) j++;	
		if (j < count)
		{
			int i;
			for (i=0; i<j; i++)
				*res++ = *(string_cur - 1);
		}
		else
		{
			sprintf(res, "%c%c%i%c", *(string_cur - 1), '(', j, ')');
			for (res+=3; j>0; j/= 10) res++;
		}
	}

	*res = '\0';
	return res - res_len;
}


int subseq(char *string1, char *string2)
{
	int i, j, max = 0;

	for (i = 0; string1[i]; i++)
		for (j = 0; string2[j]; j++)
		{
			int j0 = j;
			while (string1[i] && string2[j] && (string1[i+j] == string2[j])) j++;
			if ((j - j0) > max) max = j - j0;
		}
	return max;
}


char addword(char *word, char *arr, int size)
{
	int i = 0;
	while (i < size)
	{
		while ((i < size)&&(arr[i])) i++;
		if (i >= size) return -1;
		if (!arr[++i])
		{
			if (size - i < strlen(word)) return -1;
			strcpy(&arr[i],word);
			return 1;
		}
		if (!strcmp(&arr[i], word)) return 0;
	}
}


char **sort(char **strings, int size)
{
	int i;
	for (i = size - 1 ; i > 0; i--)
	{
		char *tmp;
		int j, max = 0;
		for (j = 1; j <= i; j++)
			if (strcmp(strings[j], strings[max]) == 1)
				max = j;
		tmp = strings[i];
		strings[i] = strings[max];
		strings[max] = tmp;
	}
	return strings;
}


char ispal(char *string)
{
	int i = 0;
	int j = strlen(string) - 1;
	while (i < j)
		if (string[i++] != string[j--]) return 0;
	return 1;
}


char *makepal(char *string)
{
	int res_len = 2 * strlen(string);
	int i = 0;	
	char *res;

	if (NULL == (res = (char*) malloc(res_len))) return NULL;
	strcpy(res, string);
	while (string[i])
		res[res_len - i - 2] = string[i++];

	res[res_len - 1] = '\0';
	return res;
}


double *txt2double(char *string, int *size)
{
	double *res;
	int k = 0;
	char *c1 = string;
	char *c2 = string;

	//Calculating result array length
	*size = 1;
	while (*c2)
	{
		if (';' == *c2) (*size)++;
		c2++;
	}

	//Allocating memory for result
	if (NULL == (res = (double*)calloc(sizeof(double), *size)))
	{
		*size = 0;
		return NULL;
	}

	//Making result
	for (c2 = strstr(c1, ";"); NULL != c2; k++)
	{
		char *tmp = malloc(c2-c1+1);
		char *tmp_cur = tmp;
		while (*c1 != ';')
		{
			*tmp_cur = *c1;
			tmp_cur++;
			c1++;
		}
		*tmp_cur = '\0';
		c1 = c2 + 1;
		c2 = strstr(c1, ";");
		res[k] = atof(tmp);
		free(tmp);
	}
	res[k] = atof(c1);

	//Checking result double array for values of 0.0
	for (k = 0; k < *size; k++)
		if (0.0 == res[k])
		{
			free(res);
			*size = 0;
			return NULL;
		}
	return res;
}


