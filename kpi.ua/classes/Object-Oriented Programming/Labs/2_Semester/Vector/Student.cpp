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

#include "Student.h"
#include <string>

student::student(){
	id = 0;
	#define DEF "<default>"
	f_name = strcpy(new char[strlen(DEF) + 1], DEF);
	l_name = strcpy(new char[strlen(DEF) + 1], DEF);
	average_grade = 0;
}

student::student(const student &obj){
	id = obj.id;
	f_name = strcpy(new char[strlen(obj.f_name) + 1], obj.f_name);
	l_name = strcpy(new char[strlen(obj.l_name) + 1], obj.l_name);
	average_grade = obj.average_grade;
}

student::student(unsigned int _id, char *_f_name, char *_l_name, float _average_grade){
	id = _id;
	f_name = strcpy(new char[strlen(_f_name) + 1], _f_name);
	l_name = strcpy(new char[strlen(_l_name) + 1], _l_name);
	average_grade = _average_grade;
}

void student::clear(){
	delete[] f_name;
	delete[] l_name;
}

student::~student(){
	clear();
}

student &student::operator = (const student &obj){
	if (this != &obj){
		clear();
		id = obj.id;
		f_name = strcpy(new char[strlen(obj.f_name) + 1], obj.f_name);
		l_name = strcpy(new char[strlen(obj.l_name) + 1], obj.l_name);
		average_grade = obj.average_grade;
	}
	return *this;
}

ostream &operator << (ostream &stream, const student &obj){
	char *c = "; ";
	return stream << obj.id << c << obj.f_name << c << obj.l_name << c << obj.average_grade << c << endl;
}



istream &operator >> (istream &stream, student &obj){
	// Ввод csv-строки из потока
	string s;
	stream >> s;
	// Разделение строки на подстроки, разделённые ";"
	//string s = buf;
	string ss[4];
	for (int i = 0; i < 4; i++){
		int n = s.find_first_of(';');
		if (n == -1)
			// "ERROR: Incorrect input csv student format!"
			return stream;
		ss[i] = s.substr(0, n);
		s = s.substr(n + 1, s.length() - 1);
	}
	// Очистка полей объекта
	obj.clear();
	// Заполнение полей объекта
	obj.id = atoi(ss[0].data());
	obj.f_name = strcpy(new char[ss[1].length() + 1], ss[1].data());
	obj.l_name = strcpy(new char[ss[2].length() + 1], ss[2].data());
	obj.average_grade = (float)atof(ss[3].data());
	return stream;
}

unsigned int student::GetId(){
	return id;
}