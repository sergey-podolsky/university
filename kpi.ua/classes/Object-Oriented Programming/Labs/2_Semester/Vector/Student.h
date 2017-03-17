/* * * * * * * * * * * * * * * * * 
 * Лабораторная работа №3 (2-ой семестр 2008)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * Vector.h - содержит параметризированный класс Vector
 * Student.h - содержит класс Student
 * Student.spp - содержит определения методов класса Student
 * StudLog.cpp - тест-драйв, предоставляющий пользовательское меню
 * * * * * * * * * * * * * * * * */

#ifndef __student
#define __student

#include <iostream>

using namespace std;
using std::cout;
using std::cin;
using std::endl;

class student{

	unsigned int id;
	char *f_name;
	char *l_name;
	float average_grade;
public:
	// Конструктор по умолчанию
	student();

	// Конструктор копирования
	student(const student &obj);

	// Конструктор с инициализацией полей
	student(unsigned int _id, char *_f_name, char *_l_name, float _average_grade);

	// Очистка
	void clear();

	// Деструктор
	~student();

	// Операция присваивания
	student &operator = (const student &obj);
	
	// Вывод в поток
	friend ostream &operator << (ostream &stream, const student &obj);

	// Ввод из потока
	friend istream &operator >> (istream &stream, student &obj);

	// Получить ID
	unsigned int GetId();
};

#endif