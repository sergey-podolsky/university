/* * * * * * * * * * * * * * * * * 
 * ������������ ������ �3
 * (�������� ����-�����)
 *
 *		��������:
 * ���������� ������
 * ������: ��-64
 *
 *		�������� �������:
 * scanner.h - �������� ��������� �������;
 * scanner.c - �������� ���������� �������;
 * scanner_db.c -  ����-�����, ��������������� ����������������� �������
 * * * * * * * * * * * * * * * * */


#ifndef __scanner
#define __scanner

struct SCAN_INFO
{ 
	char model[25];	// ������������ ������
	double price;	// ����       
	int x_size;		// �������������� ������ ������� ������������
	int y_size;		// ������������ ������ ������� ������������
	int optr;		// ���������� ����������
	char grey;		// ����� �������� ������
};
typedef	struct SCAN_INFO scan_info;

int add_scan_info(scan_info *info, char *path);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ���������� � �������� ���� �� ����� path  ������ � ������� �� ����������� ���������.
 * ��������� �����: � ������ sizeof(int) ������ ����������� �������� ���� int, ������������ ���������� ������� � �����,
 * ����� ��� ��������� ����������� ������ � ��������.
 * ������� ������ �������, ����� � ����� �� ���� ������������� �������.
 * ������������ ���������:
 * -1 - � ����� ������������� ������;
 *  0 - ���� ��� �������� ��������� ������;
 *  1 - ��������� ������ ��������� ������� � ������������ ����;
 *  2 - ������ ��������� ������� � ����� ����, ����� ���� ������������ ���� ��� ����.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

int csv_to_dat(char *source, char *destination);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * �������������� ���������� ��������� ����� destination �� ���������� ����� source.
 * ������ .csv(Comma Separated Values) ������������, ��� ������ ������ ����� �������� ���� ������,
 * � �� ���� ���������� ���� �� ����� �������� �;�.
 * ���������� ���������� ���������� ��������, ���� -1 � ������ ������������� ������.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

scan_info *read_at(int number, char *path);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ��������� �� ����� ������ � ������� �� ������ ������.
 * ������� ���������� �������� ���� (SCAN_INFO *), ���� ������ ������ �������, � NULL  � ��������� ������.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

int delete_at(int number, char *path);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ������� �� ����� ������ � ������� �� ������ ������.
 * ������� ���������� ��������� ��������, ���� �������� ������ �������, � -1 � ��������� ������.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

int get_cheaper_than(double price, char *source, char *destination);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ������ �� ����� source ������ � �������� � ������� � ��������� ���� destination ������ ��������,
 * ���� ������� �� ��������� ��������. 
 * ���������� ���������� ��������, ���������� � ����, ���� -1 � ������ ������������� ������ ������/������.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

void print_info(scan_info *info);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ������� �� ����� ������ info ��� �� ��������� �� ������ ��� ��������� �� NULL.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

int fprint_info(scan_info *info, FILE *file);
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * ������� � ��������� ���� file ������ info.
 * ���������� 1, ���� ������� ������ �������, � -1 � ��������� ������.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#endif