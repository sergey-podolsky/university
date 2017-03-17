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

#ifndef _ITERATOR_H
#define _ITERATOR_H

#include "chunk.h"

typedef int size_type;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Класс "Итератор"
 * Содержит указатель на кусок и индекс элемента в массиве внутри куска
 * Кусок так же содержит указатели на соседние куски
 * Бинарные операции возможны только над кусками одной двусторонней очереди
 * При инкрементах и декремантах итератора изменяется не только индекс массива,
 *  но и указатель на кусок в случае необходимости, т.е. если индекс выходит за пределы текущего массива куска
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
template <typename T>
class _iterator
{
public:
	typedef _chunk<T> chunk;
	chunk *ptr;		// указатель на кусок
	size_type index;
	typedef T value_type;
	typedef _iterator<T> it_type;
	_iterator() {ptr = 0; index = 0;}
	_iterator(chunk *_ptr, size_type indx) {ptr = _ptr, index = indx;}
	_iterator(it_type &_Val) {ptr = _Val.ptr, index = _Val.index;}
	T& operator *();
	it_type& operator++();
	it_type  operator++(int);
	it_type& operator--();
	it_type  operator--(int);
	it_type& operator+=(int offset);
	it_type  operator+(int offset) const;
	it_type& operator-=(int offset);
	it_type  operator-(int offset) const;
	int		 operator-(const it_type& left) const;
	T&		 operator[](int i);
	bool     operator==(const it_type& _iter) const;
	bool     operator!=(const it_type& _iter) const;
	bool     operator<(const it_type& _iter) const;
	bool     operator>(const it_type& _iter) const;
	bool     operator<=(const it_type& _iter) const;
	bool     operator>=(const it_type& _iter) const;
};

template <typename T>
T& _iterator<T>::operator *()
{
	return ptr->buf[index];
}

template <typename T>
_iterator<T>& _iterator<T>::operator ++()
{
	return *this += 1;
}

template <typename T>
_iterator<T> _iterator<T>::operator ++(int)
{
	it_type tmp(ptr, index);
	++*this;
	return tmp;
}

template <typename T>
_iterator<T>& _iterator<T>::operator --()
{
	return *this -= 1;
}

template <typename T>
_iterator<T> _iterator<T>::operator --(int)
{
	it_type tmp(ptr, index);
	--*this;
	return tmp;
}

template <typename T>
_iterator<T>& _iterator<T>::operator +=(int offset)
{
	for (index += offset; index >= CHUNK_SIZE; index -= CHUNK_SIZE)
		ptr = ptr->next;
	return *this;
}

template <typename T>
_iterator<T> _iterator<T>::operator +(int offset) const
{
	it_type tmp(ptr, index);
	return tmp += offset;
}

template <typename T>
_iterator<T>& _iterator<T>::operator -=(int offset)
{
	for (index -= offset; index < 0; index += CHUNK_SIZE)
		ptr = ptr->prev;
	return *this;
}

template <typename T>
_iterator<T> _iterator<T>::operator -(int offset) const
{
	it_type tmp(ptr, index);
	return tmp -= offset;
}

template <typename T>
int _iterator<T>::operator -(const it_type &right) const
{
	it_type tmp1(ptr, index);
	for (size_type count = 0; tmp1.ptr != 0; tmp1.ptr = tmp1.ptr->prev, count++)
		if (tmp1.ptr == right.ptr)
			return count * CHUNK_SIZE + index - right.index;
	it_type tmp2(ptr, index);
	for (size_type count = 0; tmp2.ptr != 0; tmp2.ptr = tmp2.ptr->next, count--)
		if (tmp2.ptr == right.ptr)
			return count * CHUNK_SIZE + index - right.index;
	cout << "ERROR: Different iterators' deques" << endl;
	return 0;
}

template <typename T>
T& _iterator<T>::operator[](size_type i)
{
	return *(*this + i);
}

template <typename T>
bool _iterator<T>::operator ==(const it_type &_iter) const
{
	return (ptr == _iter.ptr) && (index == _iter.index);
}

template <typename T>
bool _iterator<T>::operator !=(const it_type &_iter) const
{
	return !(*this == _iter);
}

template <typename T>
bool _iterator<T>::operator <(const it_type &_iter) const
{
	return (*this - _iter < 0);
}

template <typename T>
bool _iterator<T>::operator >(const it_type &_iter) const
{
	return (_iter < *this);
}

template <typename T>
bool _iterator<T>::operator <=(const it_type &_iter) const
{
	return !(*this > _iter);
}

template <typename T>
bool _iterator<T>::operator >=(const it_type &_iter) const
{
	return !(*this < _iter);
}

#endif
