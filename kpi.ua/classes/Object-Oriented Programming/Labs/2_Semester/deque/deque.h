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

#ifndef __deque
#define __deque

#include "iterator.h"
#include "vehicle.h"
#include <fstream>

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Класс "Двусторонняя очередь"
 * Представляет собой двусвязный список, звеньями которого являются куски
 * Каждое звено есть объектом класса "chunk" и имеет ссылки на следующий и предыдущий кусок
 * Ссылка на предыдущий кусок первого звена и ссылка на следующий кусок последнего звена равны NULL
 * Объект данного класса содержит два поля:
 *	1) итератор, указывающий на ячейку перед первым элементом;
 *	2) итератор, указывающий на ячейку после последнего элемента.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
template <typename T>
class deque{
private:
	typedef deque<T> dq_type;
	typedef T val_type;
	typedef _iterator<T> iterator;
	typedef _chunk<T> chunk;
public:
	////// constructors / destructors /////////////
	deque();
	deque(size_type _Count, const T& _Val);
	deque(iterator _First, iterator _Last); 
	~deque();

   	///// member functions ///////////////////
	void push_back(const T &);
	void push_front(const T &);
	void pop_front();
	void pop_back();
    void insert(iterator _Where, const T& _Val);
	void insert(iterator _Where, iterator _First, iterator _Last);
	T &operator[](size_type);
	iterator begin() const;
	iterator end() const;	
	size_type size() const;
	size_type max_size();
	void resize(size_type _Newsize);
	void resize(size_type _Newsize, const T& _Val);
	void swap(deque<T> &dq);
	bool empty();
	void erase(size_type indx);
	void erase(iterator _First, iterator _Last);
	void clear();
	T &back();
	T &front();

	// вывод итератора в поток
	friend ostream &operator <<(ostream& stream, iterator &obj) {return stream << *obj;}

	// вывод двусторонней очереди в поток
	friend ostream &operator <<(ostream& stream, dq_type &obj){
		for (size_type i = 0; i < obj.size(); i++) stream << obj[i] << endl;
		return stream;
	}

	// ввод двусторонней очереди из потока
	friend istream &operator >>(istream &stream, dq_type &obj){
		obj.clear();
		T tmp;
		while (stream >> tmp)
			obj.push_back(tmp);
		return stream;
	}

	// Загрузка двусторонней очереди из csv-файла
	bool FromFile(string path){
		ifstream _in(path.data());
		if (_in.fail()){
			_in.close();
			return false;
		}
		_in >> *this;
		_in.close();
		return true;
	}

private:
	iterator *first, *last;
};

template <typename T>
deque<T>::deque()
{
	first = new iterator();
	last = new iterator();
	first->ptr = last->ptr = new chunk();
	first->index = last->index = CHUNK_SIZE / 2;
	++*last;
}

template <typename T>
void deque<T>::push_back(const T &_Val)
{
	if (last->index == CHUNK_SIZE - 1)
		last->ptr->next = new chunk(last->ptr, 0);
	*((*last)++) = _Val;
}

template <typename T>
void deque<T>::push_front(const T &_Val)
{
	if (first->index == 0)
		first->ptr->prev = new chunk(0, first->ptr);
	*((*first)--) = _Val;
}

template <typename T>
void deque<T>::pop_back()
{
	if ((--*last).index == CHUNK_SIZE - 1){
		delete last->ptr->next;
		last->ptr->next = 0;
	}
}

template <typename T>
void deque<T>::pop_front()
{
	if ((++*first).index == 0){
		delete first->ptr->prev;
		first->ptr->prev = 0;
	}
}

template <typename T>
deque<T>::deque(size_type _Count, const T &_Val)
{
	first = new iterator();
	last = new iterator();
	first->ptr = last->ptr = new chunk();
	first->index = last->index = CHUNK_SIZE / 2;
	++*last;
	for (int i = 0; i < _Count; i++) push_back(_Val);
}

template <typename T>
deque<T>::deque(typename deque<T>::iterator _First, typename deque<T>::iterator _Last)
{
	first = new iterator();
	last = new iterator();
	first->ptr = last->ptr = new chunk();
	first->index = last->index = CHUNK_SIZE / 2;
	++*last;
	for (iterator i(_First); i <= _Last; i++)
		push_back(*i);
}

template <typename T>
void deque<T>::insert(iterator _Where, const T& _Val)
{
	if (last->index == CHUNK_SIZE - 1)
		last->ptr->next = new chunk(last->ptr, 0);
	for (iterator l(*last); l > _Where; l--)
		*l = *(l - 1);
	*_Where = _Val;
	++*last;
}

template <typename T>
void deque<T>::insert(iterator _Where, iterator _First, iterator _Last)
{
	size_type count = _Last - _First + 1;
	iterator l(*last);
	for (last->index += count; last->index >= CHUNK_SIZE; last->index -= CHUNK_SIZE)
		last->ptr = last->ptr->next = new chunk(last->ptr, 0);
	for (iterator k(*last); k > _Where; *--k = *--l);
	for(size_type j = 0; j < count; j++)
		_Where[j] = _First[j];
}

template <typename T>
T &deque<T>::operator [](size_type indx)
{
	return (*first)[indx + 1];
}

template <typename T>
_iterator<T> deque<T>::begin() const
{
	return *first + 1;
}

template <typename T>
_iterator<T> deque<T>::end() const
{
	return *last - 1;
}

template <typename T>
size_type deque<T>::size() const
{
	return *last - *first - 1;
}

template <typename T>
size_type deque<T>::max_size()
{
	size_type count = 0;
	for (iterator i(*first); i != *last; i.ptr = i.ptr->next)
		count++;
	return count;
}

template <typename T>
void deque<T>::resize(size_type _Newsize)
{
	size_type count = _Newsize - size();
	if (count > 0)
		for (last->index += count; last->index >= CHUNK_SIZE; last->index -= CHUNK_SIZE)
			last->ptr = last->ptr->next = new chunk(last->ptr, 0);
	else if (count < 0)
		erase(begin() + _Newsize, end());
}

template <typename T>
void deque<T>::resize(size_type _Newsize, const T &_Val)
{
	size_type count = _Newsize - size();
	if (count > 0)
		for (; count > 0; count--)
			push_back(_Val);
	else resize(_Newsize);
}

template <typename T>
void deque<T>::swap(deque<T> &dq)
{
	iterator *tmp;
	tmp = dq.first;
	dq.first = first;
	first = tmp;
	tmp = dq.last;
	dq.last = last;
	last = tmp;
}

template <typename T>
bool deque<T>::empty()
{
	return 0 == size();
}

template <typename T>
void deque<T>::erase(size_type indx)
{
	for (iterator i(begin() + indx); i < end(); i++)
		*i = *(i + 1);
	pop_back();
}

template <typename T>
void deque<T>::erase(iterator _First, iterator _Last)
{
	iterator f(_First), l(_Last + 1);
	while (l < *last){
		*(f++) = *(l++);
	}
	for (size_type count = _Last - _First + 1; count > 0; count--)
		pop_back();
}

template <typename T>
void deque<T>::clear()
{
	for (first->ptr = first->ptr->next; first->ptr != 0; first->ptr = first->ptr->next)
		delete first->ptr->prev;
	last->ptr->prev = 0;
	first->ptr = last->ptr;
	first->index = CHUNK_SIZE / 2;
	last->index = CHUNK_SIZE / 2 + 1;
}

template <typename T>
T &deque<T>::front()
{
	return *begin();
}

template <typename T>
T &deque<T>::back()
{
	return *end();
}

template <typename T>
deque<T>::~deque()
{
	clear();
	delete first->ptr;
	delete first;
	delete last;
}

#endif