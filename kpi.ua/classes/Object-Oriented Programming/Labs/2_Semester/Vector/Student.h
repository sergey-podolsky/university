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
	// ����������� �� ���������
	student();

	// ����������� �����������
	student(const student &obj);

	// ����������� � �������������� �����
	student(unsigned int _id, char *_f_name, char *_l_name, float _average_grade);

	// �������
	void clear();

	// ����������
	~student();

	// �������� ������������
	student &operator = (const student &obj);
	
	// ����� � �����
	friend ostream &operator << (ostream &stream, const student &obj);

	// ���� �� ������
	friend istream &operator >> (istream &stream, student &obj);

	// �������� ID
	unsigned int GetId();
};

#endif