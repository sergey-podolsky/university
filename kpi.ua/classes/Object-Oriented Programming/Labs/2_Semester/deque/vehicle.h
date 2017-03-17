#ifndef __vehicle
#define __vehicle
#define _AFXDLL
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Лабораторная работа №4 (2-ой семестр 2008)
 *	(домашняя контрольная работа)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * chunk.h			содержит параметризированный класс, представляющий кусок контейнера _chunk
 * iterator.h		содержит параметризированный класс iterator
 * deque.h			содержит параметризированный класс deque
 * vehicle.h		содержит класс vehicle
 * deque_test.h		тест-драйв, предоставляющий пользовательское меню
 * data.csv			файл исходных данных об автомобилях в csv-формате
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#include <afx.h>
#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <iostream>
#include <string>
using namespace std;
using std::endl;
using std::cout;
using std::cin;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Класс "Автомобиль"
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
class vehicle{
public:
	// Конструктор по умолчанию
	vehicle():id(0), m_strOwner("<NONE>"), m_strModel("<NONE>"){};

	// Конструктор
	vehicle(int _id, const char* _owner, const char *_model):id(_id), m_strOwner(_owner), m_strModel(_model){};

	// Вывод в поток
	friend ostream &operator <<(ostream& stream, vehicle &obj){
		return stream << obj.id << endl << obj.m_strOwner << endl << obj.m_strModel << endl;
	}

	// Оператор присвоения
	vehicle &operator = (const vehicle &_right){
		id = _right.id;
		m_strOwner = _right.m_strOwner;
		m_strModel = _right.m_strModel;
		return *this;
	}

	// Ввод из потока
	friend istream &operator >> (istream &stream, vehicle &obj){
		// Ввод csv-строки из потока
		string s;
		stream >> s;
		// Разделение строки на подстроки, разделённые ";"
		string ss[3];
		for (int i = 0; i < 3; i++){
			int n = s.find_first_of(';');
			if (n == -1)
				// "ERROR: Incorrect input csv format!"
				return stream;
			ss[i] = s.substr(0, n);
			s = s.substr(n + 1, s.length() - 1);
		}
		// Заполнение полей объекта
		obj.id = atoi(ss[0].data());
		obj.m_strOwner = strcpy(new char[ss[1].length() + 1], ss[1].data());
		obj.m_strModel = strcpy(new char[ss[2].length() + 1], ss[2].data());
		return stream;
	}

private:
	int id;
	CString m_strOwner;
	CString m_strModel;
};


#endif