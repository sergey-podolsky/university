/* * * * * * * * * * * * * * * * * 
 * ������������ ������ �3 (2-�� ������� 2008)
 *
 *		��������:
 * ���������� ������
 * ������: ��-64
 *
 *		�������� �������:
 * Vector.h - �������� ������������������� ����� Vector
 * Student.h - �������� ����� Student
 * Student.spp - �������� ����������� ������� ������ Student
 * StudLog.cpp - ����-�����, ��������������� ���������������� ����
 * * * * * * * * * * * * * * * * */

#ifndef __vector
#define __vector

#include <iostream>

#define SIZE 16		// ����� ����� ������� (����������)
#define LEN 1024	// ���������� �����������
// ������������ ������ ���������� ������� = SIZE * LEN

template <class T>
class Vector{
private:
	// ���������������� ���������� ���������
	int count;

	// ����� �����������
	T *buf[LEN];

public:
	// �����������, ������� ������� ������ ��������� �������
	Vector(int _Count = 0){
		count = _Count;
		int parts = count / SIZE + 1;
		for (int i = 0; i < parts; i++)
			buf[i] = new T[SIZE];
	}

	// �����������, ������� ������ ������ ��������� ������� � ��������� � ���  �������� ��������� ��������
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

	// �����������, ������� ������ ������, ���������� ������ ������� �������
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

	// ������� ������ � �������� � ���� �������� ��������
	void assign(int _Count, const T &_Val){
		// ������� �������
		int parts = count / SIZE + 1;
		for (int i = 0; i < parts; i++)
			delete[] buf[i];
		// ����������� � ������ �������� ���������
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

	// ������� ������ � �������� � ���� �������� �������� ��������� �������
	void assign(const Vector &_Right){
		// ������� �������
		int parts = count / SIZE + 1;
		for (int i = 0; i < parts; i++)
			delete[] buf[i];
		// ����������� � ������ �������� ���������
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

	// ���������� ������ �� ��������� �������
	T &at(int _Pos){
		return buf[_Pos / SIZE][_Pos % SIZE];
	}

	// ������� �������� �������
	void clear(){
		int parts = count / SIZE + 1;
		for (int i = 1; i < parts; i++)
			delete[] buf[i];
		count = 0;
	}

	// ���������� true, ���� ������ ����
	bool  empty(){
		return 0 == count;
	}

	// ������� �������� �������
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

	// ������� �������� � ��������� ���������
	void erase(int _Pos){
		erase(_Pos, _Pos);
	}

	// ��������� ���� ������� � ������
	void insert(int _Where, const T &_Val){
		insert(_Where, 1, _Val);
	}

	// ��������� ��������� ��������� � ������
	void insert(int _Where, int _Count, const T &_Val){
		// ��������� ���������� ����������� ����� �������
		int parts = (count + _Count) / SIZE + 1;
		// �������� ������������ ���������� �������������� ����������� ��� �������
		for (int i = count / SIZE + 1; i < parts; i++)
			buf[i] = new T[SIZE];
		// ����� ���������
		for (int i = count - 1; i >= _Where; i--)
			buf[(i + _Count) / SIZE][(i + _Count) % SIZE] = buf[i / SIZE][i % SIZE];
		// ������� ��������� � ����������� �������
		for (int i = _Where; i < _Where + _Count; i++)
			buf[i / SIZE][i % SIZE] = _Val;
		count += _Count;
	}

	// ���������� ������������ ����� �������
	int max_size(){
		return (count / SIZE + 1) * SIZE;
	}

	// ������� ��������� ������� �������
	void pop_back(){
		if (0 == count % SIZE)
			delete[] buf[count-- / SIZE];
	}

	// ��������� ������� � ����� �������
	void push_back(const T &_Val){
		if (SIZE - 1 == count % SIZE)
			buf[count / SIZE + 1] = new T[SIZE];
		buf[count / SIZE][count++ % SIZE] = _Val;
	}

	// ������ ����� �������� ����� �������
	void resize(int _Newsize){
		resize(_Newsize, new T());
	}

	// ������ ����� �������� ����� �������; ���� ����� �������� _Newsize ������ �������, �������������� ����� ������� ����������� ��������� ���������� _Val
	void resize(int _Newsize, const T &_Val){
		if (_Newsize < count)
			erase(_Newsize, count - 1);
		else if (_Newsize > count)
			insert(count, _Newsize - count, _Val);
	}

	// ���������� ���������� ��������� �������
	int size(){
		return count;
	}

	// ������ ������� �������� ���� ��������
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

	// ����������
	~Vector(){
		clear();
		delete[] buf[0];
	}

	// �������� << ������ ������� � �����
	friend ostream &operator << (ostream &stream, Vector<T> &obj){
		for (int i = 0; i < obj.count; i++)
			stream << obj.at(i);
		return stream;
	}

	// �������� >> ����� ������� � ������
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
