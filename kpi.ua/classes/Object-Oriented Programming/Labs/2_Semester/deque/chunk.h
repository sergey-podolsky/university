/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ������������ ������ �4 (2-�� ������� 2008)
 *	(�������� ����������� ������)
 *
 *		��������:
 * ���������� ������
 * ������: ��-64
 *
 *		�������� �������:
 * chunk.h			�������� ������������������� �����, �������������� ����� ���������� _chunk
 * iterator.h		�������� ������������������� ����� iterator
 * deque.h			�������� ������������������� ����� deque
 * vehicle.h		�������� ����� vehicle
 * deque_test.h		����-�����, ��������������� ���������������� ����
 * data.csv			���� �������� ������ �� ����������� � csv-�������
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#ifndef __chunk
#define __chunk

// ������ ������� �����
#define CHUNK_SIZE 4

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ����� "�����
 * ������������ ����� ����� ����������� ������
 * �������� ������ ��������� � ��������� �� �������� �����
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
template <typename T>
class _chunk{
public:
	// ��������� �� �������� �����
	_chunk *next, *prev;
	
	// ������ ���������
	T buf[CHUNK_SIZE];

	// ����������� �� ���������
	_chunk() {next = 0; prev = 0;}

	// ����������� � �������������� ���������� �� �������� �����
	_chunk(_chunk *_prev, _chunk *_next) {prev = _prev; next = _next;}
};

#endif