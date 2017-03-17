/* * * * * * * * * * * * * * * * * 
 * Лабораторная работа №1 (2-ой семестр)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * string.h - содержит прототипы функций;
 * string.cpp - содержит определеня функций-членов;
 * stringtest.cpp - тест-драйв, демонстрирующий работоспособность функций.
 * * * * * * * * * * * * * * * * */

#include "string.h"
#include <iostream>

using std::cout;
using std::endl;

void main(){
	CString s1("HeLlO, CString!");
	CString s2(s1);
	CString s3;

	s3 = "Microsoft ";

	s1.Print();
	s2.Print();
	s3.Print();


	s1.SetAt(7, s1[s1.GetLength() - 1]);
	s1.Print();

	cout << "s1.IsEmpty = " << s1.IsEmpty() << endl;

	cout << "s2.Compare(s1) = " << s2.Compare(s1) << endl;
	cout << "s2.Compare(s2) = " << s2.Compare(s2) << endl;

	cout << "s2.Find('C') = " << s2.Find('C') << endl;
	cout << "s2.Find(''trin'') = " << s2.Find("trin") << endl;

	s1 = "qwerty With ";

	s3 += s2.Mid(8, 6) + s1.Right(6) + s2.Left(5);
	s3.Print();
}