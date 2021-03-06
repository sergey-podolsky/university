/* * * * * * * * * * * * * * * * * 
 * ������������ ������ �2
 * (����������� ��������� ������)
 *
 *		��������:
 * ���������� ������
 * ������: ��-64
 *
 *		�������� �������:
 * Lab2.h - �������� ��������� �������;
 * Lab2.c - �������� ���������� �������;
 * Lab2test.c -  ����-�����, ��������������� ����������������� �������
 * * * * * * * * * * * * * * * * */


#ifndef list_
#define list__

/* ����� ������ */
struct _node
{
     int key;
     struct _node *link;
};
typedef struct _node node;

char isset(node *);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ����������, ��������  ��  ������  ����������.
 * ��� ���������� ������� �������� ������������ ������� ��������� ���������.
 * ��������� ���������������. ������� ���������� � ����������� ����� �������� ���������
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

node *list2set(node *);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ������������� ������ � ���������
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

char equal(node *, node *);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ���������� ��������� ���� ��������, �������������� ��������
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

char issubset(node *set, node *subset);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ����������, �������� �� ��������� subset ������������� set
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

node *sort(node *);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ������������ �� �����������  ���������, ��������������  �������. 
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

node *insert_ord(node *, int el);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ��������� ������� � ������������� ������ �.�., ����� ��������������� �� ����������
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

node *whatsbefore(node *, int el);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ��������� � �������� ��������a ��������� �� ������ ������ � ����� �����
 * � ������������ � �������� ���������� ��������� �� �������,
 * ��������������� ��������, ����������� �������� �����
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#endif