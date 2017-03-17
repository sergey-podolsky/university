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

#ifndef __vector
#define __vector

#include <iostream>

#define SIZE 16		// Длина части вектора (подвектора)
#define LEN 1024	// Количество подвекторов
// Максимальный размер возможного вектора = SIZE * LEN

template <class T>
class Vector{
private:
	// Пользовательское количесвто элементов
	int count;

	// Масив подвекторов
	T *buf[LEN];

public:
	// Конструктор, который создает вектор заданного размера
	Vector(int _Count = 0){
		count = _Count;
		int parts = count / SIZE + 1;
		for (int i = 0; i < parts; i++)
			buf[i] = new T[SIZE];
	}

	// Конструктор, который создаёт вектор заданного размера и размещает в нем  элементы заданного значения
	Vector(int _Count, const T &_Val){
		count = _Count;
		int parts = count / SIZE;
		for (int i = 0; i < parts; i++){
			buf[i] = new T[SIZE];
			for (int j = 0; j < SIZE; j++)
				buf[i][j] = _Val;
		}
		buf[parts] = new T[SIZE];
		int remain = count % SIZE;
		for (int j = 0; j < remain; j++)
			buf[parts][j] = _Val;
	}

	// Конструктор, который создаёт вектор, являющийся копией другого вектора
	Vector(const Vector<T> &_Right){
		count = _Right.count;
		int parts = count / SIZE;
		for (int i = 0; i < parts; i++){
			buf[i] = new T[SIZE];
			for (int j = 0; j < SIZE; j++)
				buf[i][j] = _Right.buf[i][j];
		}
		buf[parts] = new T[SIZE];
		int remain = count % SIZE;
		for (int j = 0; j < remain; j++)
			buf[parts][j] = _Right.buf[parts][j];
	}

	// Очищает вектор и копирует в него заданные элементы
	void assign(int _Count, const T &_Val){
		// очистка вектора
		int parts = count / SIZE + 1;
		for (int i = 0; i < parts; i++)
			delete[] buf[i];
		// копирование в вектор заданных элементов
		count = _Count;
		parts = count / SIZE;
		for (int i = 0; i < parts; i++){
			buf[i] = new T[SIZE];
			for (int j = 0; j < SIZE; j++)
				buf[i][j] = _Val;
		}
		buf[parts] = new T[SIZE];
		int remain = count % SIZE;
		for (int j = 0; j < remain; j++)
			buf[parts][j] = _Val;
	}

	// Очищает вектор и копирует в него заданные элементы заданного вектора
	void assign(const Vector &_Right){
		// очистка вектора
		int parts = count / SIZE + 1;
		for (int i = 0; i < parts; i++)
			delete[] buf[i];
		// копирование в вектор заданных элементов
		count = _Right.count;
		parts = count / SIZE;
		for (int i = 0; i < parts; i++){
			buf[i] = new T[SIZE];
			for (int j = 0; j < SIZE; j++)
				buf[i][j] = _Right.buf[i][j];
		}
		buf[parts] = new T[SIZE];
		int remain = count % SIZE;
		for (int j = 0; j < remain; j++)
			buf[parts][j] = _Right.buf[parts][j];
}

	// Возвращает ссылку на указанный элемент
	T &at(int _Pos){
		return buf[_Pos / SIZE][_Pos % SIZE];
	}

	// Удаляет элементы вектора
	void clear(){
		int parts = count / SIZE + 1;
		for (int i = 1; i < parts; i++)
			delete[] buf[i];
		count = 0;
	}

	// Возвращает true, если вектор пуст
	bool  empty(){
		return 0 == count;
	}

	// Удаляет заданный элемент
	void erase(int _StartPos, int _EndPos){
		int start = _StartPos;
		int end = _EndPos + 1;
		for (; end < count; start++, end++)
			buf[start / SIZE][start % SIZE] = buf[end / SIZE][end % SIZE];
		int parts = count / SIZE + 1;
		for (int i = end / SIZE + 1; i < parts; i++)
			delete[] buf[i];
		count -= _EndPos - _StartPos + 1;
	}

	// Удаляет элементы в указанном диапазоне
	void erase(int _Pos){
		erase(_Pos, _Pos);
	}

	// Вставляет один элемент в вектор
	void insert(int _Where, const T &_Val){
		insert(_Where, 1, _Val);
	}

	// Вставляет несколько элементов в вектор
	void insert(int _Where, int _Count, const T &_Val){
		// Ожидаемое количество подвекторов после вставки
		int parts = (count + _Count) / SIZE + 1;
		// Создание необходимого количества дополнительных подвекторов для вставки
		for (int i = count / SIZE + 1; i < parts; i++)
			buf[i] = new T[SIZE];
		// Сдвиг элементов
		for (int i = count - 1; i >= _Where; i--)
			buf[(i + _Count) / SIZE][(i + _Count) % SIZE] = buf[i / SIZE][i % SIZE];
		// Вставка элементов в раздвинутую обдасть
		for (int i = _Where; i < _Where + _Count; i++)
			buf[i / SIZE][i % SIZE] = _Val;
		count += _Count;
	}

	// Возвращает максимальную длину вектора
	int max_size(){
		return (count / SIZE + 1) * SIZE;
	}

	// Удаляет последний элемент вектора
	void pop_back(){
		if (0 == count % SIZE)
			delete[] buf[count-- / SIZE];
	}

	// Добавляет элемент в конец вектора
	void push_back(const T &_Val){
		if (SIZE - 1 == count % SIZE)
			buf[count / SIZE + 1] = new T[SIZE];
		buf[count / SIZE][count++ % SIZE] = _Val;
	}

	// Задает новое значение длины вектора
	void resize(int _Newsize){
		resize(_Newsize, new T());
	}

	// Задает новое значение длины вектора; если новое значение _Newsize больше старого, образовавшийся конец вектора заполняется заданными значениями _Val
	void resize(int _Newsize, const T &_Val){
		if (_Newsize < count)
			erase(_Newsize, count - 1);
		else if (_Newsize > count)
			insert(count, _Newsize - count, _Val);
	}

	// Возвращает количество элементов вектора
	int size(){
		return count;
	}

	// Меняет местами элементы двух векторов
	friend void swap(Vector<T> &_Left, Vector<T> &_Right){
		int tmp = _Left.count;
		_Left.count = _Right.count;
		_Right.count = tmp;
		int count = _Left.count > _Right.count ? _Left.count : _Right.count;
		int parts = count / SIZE + 1;
		for (int i = 0; i < parts; i++){
			T* tmp = _Left.buf[i];
			_Left.buf[i] = _Right.buf[i];
			_Right.buf[i] = tmp;
		}
	}

	// Деструктор
	~Vector(){
		clear();
		delete[] buf[0];
	}

	// Оператор << вывода вектора в поток
	friend ostream &operator << (ostream &stream, Vector<T> &obj){
		for (int i = 0; i < obj.count; i++)
			stream << obj.at(i);
		return stream;
	}

	// Оператор >> ввода вектора с потока
	friend istream &operator >> (istream &stream, Vector<T> &obj){
		obj.clear();
		T *t = new T();
		while (stream >> *t)
			obj.push_back(*t);
		delete t;
		return stream;
	}
};

#endif
