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
#include "list.h"

char isset(node *i)
{
	while (NULL != i)
	{
		node *j = i->link;
		while (NULL != j)
		{
			if (j->key == i->key) return 0;
			j = j->link;
		}
		i = i->link;
	}
	return 1;
}

node *list2set(node *list)
{
	node *i = list;
	while (NULL != i->link)
	{
		node *bj = i;
		node *j = i->link;
		while (NULL != j)
		{
			if (j->key == i->key)
			{
				bj->link = j->link;
				free(j);
				j = bj->link;
			}
			else
			{
				j = j->link;
				bj = bj->link;
			}
		}
		i = i->link;
	}
	return list;
}

char issubset(node *set, node *subset)
{
	while (NULL != subset)
	{
		node *i;
		for (i = set; (NULL != i) && (i->key != subset->key); i = i->link);
		if (NULL == i) return 0;
		subset = subset->link;
	}
	return 1;
}

char equal(node *set1, node *set2)
{
	return issubset(set1, set2) && (set2, set1);
}

node *sort(node *set)
{
	if (NULL != set)
	{
		node *i;
		for (i = set; NULL != i->link; i = i->link)
		{
			int tmp;
			node *j;
			node *min = i;
			for (j = i->link; NULL != j; j = j->link)
				if (j->key < min->key)	min = j;
			tmp = i->key;
			i->key = min->key;
			min->key = tmp;
		}
	}
	return set;
}

node *insert_ord(node *list, int el)
{
	node *new_node = (node*)malloc(sizeof(node));
	new_node->key = el;
	if ((NULL == list) || (el <= list->key))
	{
		new_node->link = list;
		return new_node;
	}
	else
	{
		node *i = list;
		while ((NULL != i->link) && (i->link->key < el)) i = i->link;
		new_node->link = i->link;
		i->link = new_node;
	}
	return list;
}

node *whatsbefore(node *list, int el)
{
	if (NULL != list)
	{
		node *i;
		for (i = list; NULL != i->link; i = i->link)
			if (i->link->key == el) return i;
	}
	return NULL;
}
