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
#include "Vector.h"
#include <fstream>
#include <string>


// Основной пользовательский вектор
Vector<student> *vect1;

// Вектор для осуществления обмена и копирования
Vector<student> *vect2;

// Пользовательский запрос загрузки вектора с файла
char *RequestFromFile(){
	cout << "Please, enter file path" << endl;
	string path;
	cin >> path;
	ifstream in(path.data());
	if (in.fail()){
		in.close();
		return ">FAILED: BAD FILE";
	}
	in >> *vect1;
	in.close();
	return ">LOADED SUCCESSFULLY";
}

// Пользовательский запрос удаления студента из вектора по указанному ID
char *RequestDelete(){
	cout << "Enter student id" << endl;
	string s;
	cin >> s;
	int id = atoi(s.data());
	for (int i = 0; i < vect1->size(); i++)
		if (vect1->at(i).GetId() == id){
			vect1->erase(i);
			return ">DELETED SUCCESSFULLY";
		}
	return ">FAILED: ALREADY ABSENTS";
}

// Пользовательский запрос корректировки студента по ID
char *RequestCorrect(){
	cout << "Enter student id" << endl;
	string s;
	cin >> s;
	int id = atoi(s.data());
	cout << "Enter student info in csv-format" << endl;
	student *stud = new student();
	cin >> *stud;
	for (int i = 0; i < vect1->size(); i++)
		if (vect1->at(i).GetId() == id){
			vect1->at(i) = *stud;
			delete stud;
			return ">CORRECTED SUCCESSFULLY";
		}
	return ">FAILED: NOT FOUND";
}

// Пользовательский запрос добавления студента в вектор
char *RequestAdd(){
	cout << "Enter student info in csv-format" << endl;
	student *stud = new student();
	cin >> *stud;
	for (int i = 0; i < vect1->size(); i++)
		if (vect1->at(i).GetId() == stud->GetId()){
			delete stud;
			return ">FAILED: ALREADY EXISTS";
		}
	vect1->push_back(*stud);
	delete stud;
	return ">ADDED SUCCESSFULLY";
}

// Пользовательский запрос копирования вектора vect1 в vect2
char *RequestCopy(){
	vect2->assign(*vect1);
	return ">COPIED SUCCESFULLY";
}

// Пользовательский запрос обмена векторов vect1 и vect2
char *RequestSwap(){
	swap(*vect1, *vect2);
	return ">SWAPPED SUCCESFULLY";
}

// Запрос с пользовательским меню
void Request(){
	cout << endl;
	cout << "'1' - Load Vector<students> from file" << endl;
	cout << "'2' - Print vector<students>" << endl;
	cout << "'3' - Delete student by id" << endl;
	cout << "'4' - Correct student by id" << endl;
	cout << "'5' - Add new student" << endl;
	cout << "'6' - Create copy of Vector<student>" << endl;
	cout << "'7' - Swap current vector with copy" << endl;
	cout << "'0' - Exit" << endl;

	string s;
	cin >> s;

	if ("1" == s) cout << RequestFromFile() << endl;
	else if ("2" == s) cout << *vect1;
	else if ("3" == s) cout << RequestDelete() << endl;
	else if ("4" == s) cout << RequestCorrect() << endl;
	else if ("5" == s) cout << RequestAdd() << endl;
	else if ("6" == s) cout << RequestCopy() << endl;
	else if ("7" == s) cout << RequestSwap() << endl;
	else if ("0" == s) exit(1);

	Request();
}

int main(){
	vect1 = new Vector<student>();
	vect2 = new Vector<student>();
	Request();
	return 0;
}