/* * * * * * * * * * * * * * * * * 
 * Лабораторная работа №2
 * (Рекурсивные структуры данных)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * Lab2.h - содержит прототипы функций;
 * Lab2.c - содержит определеня функций;
 * Lab2test.c -  тест-драйв, демонстрирующий работоспособность функций
 * * * * * * * * * * * * * * * * */

#include <stdlib.h>
#include <stdio.h>
#include "list.h"

/* Метод для вывода на экран списка */
void print_list(node *list, char* name)
{
	printf("%s:", name);
	if (NULL == list) printf(" NULL");
	else
		for (; NULL != list; list = list->link)
			printf(" %i", list->key);
	printf("\n");
}

/* Метод для добавления в начало списка звена с ключом el */
node *add(node *list, int el)
{
	node *new_node = (node*)malloc(sizeof(node));
	new_node->key = el;
	new_node->link = list;
	return new_node;
}

int main()
{
	node *list1 = NULL;
	node *list2 = NULL;
	char *s1 = "list1";
	char *s2 = "list2";
	int i;

	for (i = 0; i < 10; i++)	list2 = add(list2, i);
	print_list(list1,s1);
	print_list(list2, s2);
	printf("\n");

	printf("for (i = 10; i > 0; i--) list1 = insert_ord(list1, i/2);\n");
	for (i = 10; i > 0; i--) list1 = insert_ord(list1, i/2);
	print_list(list1, s1);
	printf("\n");

	printf("isset(list1): %i\n", isset(list1));
	printf("isset(list2): %i\n", isset(list2));
	printf("\n");


	printf("list2set(list1);\n");
	print_list(list2set(list1), s1);
	printf("\n");

	sort(list2);
	printf("sort(list2);\n");
	print_list(list2, s2);
	printf("\n");

	printf("issubset(list2, list1): %i\n", issubset(list2, list1));
	printf("issubset(list1, list2): %i\n", issubset(list1, list2));
	printf("\n");

	printf("equal(list1, list2): %i\n", equal(list1, list2));
	printf("\n");

	print_list(whatsbefore(list2, 5), "print_list(whatsbefore(list2, 5), ''whatsbefore(list2, 5)''): ");
	printf("\n");

	return 0;
}