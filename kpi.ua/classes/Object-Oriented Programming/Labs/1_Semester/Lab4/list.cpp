#include <stdio.h>
#include "list.h"

void list::cleanup()
{
	if(!hd) return;
	if(!hd->link )
	{
		delete hd;
		hd = 0;
		return;
	}
	node *del = hd;
	node *ptr = hd->link;
	while (del)
	{
		delete del;
		if (del = ptr)
			ptr = ptr->link;
	}
	hd = 0;
}


void list::reverse()
{
	if(isempty()) return;
	list tmp;
	for(list s = *this; !s.isempty(); s = s.tail())
		tmp.push_front(s.head());
	cleanup();
	*this = tmp;
}


void list::unique()
{
	for (node *i = hd; i; i = i->link)
		for (node *j = i; j->link;)
			if (j->link->el == i->el)
			{
				node *tmp = j->link;
				j->link = j->link->link;
				delete tmp;
			}
			else	j = j->link;
}


bool list::operator >= (list &sublist)
{
	if (!sublist.hd)	return	true;
	for (node *i = hd; i; i = i->link)
	{
		node *j = sublist.hd;
		while (j && (j->el != i->el))	j = j->link;
		if (!j)	return	false;
	}
	return	0 != hd;
}


bool list::operator == (list &l)
{
	return	(*this >= l) && (l >= *this);
}


void list::sort()
{
	if (hd)
		for (node *i = hd; i->link; i = i->link)
		{
			node* m = i;
			for (node *j = i->link; j; j = j->link)
				if (j->el < m->el)	m = j;
			int tmp = i->el;
			i->el = m->el;
			m->el = tmp;
		}
}


void list::push_back(int value)
{
	if (hd)
	{
		node *last = hd;
		while (last->link)	last = last->link;
		last->link = new node(value, 0);
	}
	else	hd = new node(value, 0);
}

void list::push_front(int value)
{
	hd = new node(value, hd);
}

int list::pop_back()
{
	if (!hd)	return	0;
	if (!hd->link)
	{
		int value = hd->el;
		delete hd;
		hd = 0;
		return value;
	}
	node *last = hd;
	while (last->link->link)	last = last->link;
	int value = last->link->el;
	delete last->link;
	last->link = 0;
	return	value;
}


int list::pop_front()
{
	if (!hd)	return 0;
	int value = hd->el;
	node *tmp = hd;
	hd = hd->link;
	delete tmp;
	return value;
}


void list::remove(int value)
{
	if (!hd)	return;
	if (value == hd->el)
	{
		delete hd;
		hd = 0;
		return;
	}
	for (node *i = hd; i->link; i = i->link)
		if (value == i->link->el)
		{
			node *tmp = i->link;
			i->link = i->link->link;
			delete tmp;
			return;
		}
}

void list::print(char *caption)
{
	printf("%s[ ", caption);
	if (!hd)	printf("list is empty");
	for (node *i = hd; i; i = i->link)
		printf("%i ", i->el);
	printf("]\n");
}

void list::print()
{
	print("");
}