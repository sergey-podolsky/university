/* * * * * * * * * * * * * * * * * 
 * Лабораторная работа №4
 *		(Классы)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * list.h - содержит прототипы функций, а также описание класса list и струтуры node;
 * list.cpp - содержит определеня функций-членов;
 * list_test.cpp - тест-драйв, демонстрирующий работоспособность функций.
 * * * * * * * * * * * * * * * * */

#ifndef	__list
#define	__list

struct node
{
   node *link;
   int el;
   node(int i, node *n)
   {
	   el = i;
	   link = n;
   }
 };

class list
{
	node *hd;

 public:

   	list(node *n = 0)
	{
		hd = n;
	}
   	
   	int head()
    {
		return hd->el;
	}

   	list tail()
	{
		return list(hd->link);
	}

   	bool isempty()
   	{
		return hd == 0;
	}

	//memory discharge
	void cleanup();

	//reverse the list
	void reverse();

	/*****************************************************
	* to be done
	*****************************************************/

	//overloaded comparison operator
	bool operator == (list&);

	//true if left operand contains right operand
	bool operator >= (list&);

	//appends an elmnt to the list end
	void push_back(int );

	//inserts an elmnt to the list beginning
	void push_front(int );

	//removes elemnt with a specified value
	void remove(int );

	//removes elemnt from the list beginning
	int pop_front();

	//removes elemnt from the list end
	int pop_back();

	//removes duplicates
	void unique();

	//sorts the list in ascending order
	void sort();
	
	//prints list on a screen
	void print();

	//prints list on a screen with caption before
	void print(char*);
};

#endif

