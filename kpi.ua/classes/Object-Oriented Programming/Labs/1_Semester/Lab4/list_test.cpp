#include <stdio.h>
#include "list.h"

int	main()
{
	list l1,l2;
	for (int i = 0; i <10; i++)
	{
		l1.push_front(i);
		l2.push_back(i);
	}
	l1.print("l1 = ");
	l2.print("l2 = ");

	printf("l1 == l2 : %i\n", l1 == l2);

	l1.sort();
	l1.print("sorted l1 = ");

	printf("l1.pop_front() = %i\n", l1.pop_front());
	printf("l1.pop_back()  = %i\n", l1.pop_back());
	l1.print("l1 = ");

	printf("l1.remove(5): ");
	l1.remove(5);
	l1.print("l1 = ");

	printf("l1 == l2 : %i\n", l1 == l2);

	for (int i = 0; i < 5; i++)	l1.push_back(5);
	l1.print("\nl1 = ");
	l1.unique();
	l1.print("l1.unique(): l1 = ");
	return	0;
}