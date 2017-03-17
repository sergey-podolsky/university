/* * * * * * * * * * * * * * * * * 
 * Лабораторная работа №1 (2-ой семестр)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * string.h - содержит прототипы функций;
 * string.cpp - содержит определеня функций-членов;
 * stringtest.cpp - тест-драйв, демонстрирующий работоспособность функций.
 * * * * * * * * * * * * * * * * */

#include "string.h"
#include <string.h>
#include <iostream>

using std::cout;
using std::endl;


#define CLEAR len = 0;	delete[] str;

CString::CString(){
	str = new char('\0');
	len = 0;
}

CString::CString(const CString &stringSrc){
	strcpy(str = new char[1 + (len = stringSrc.len)], stringSrc.str);
}

CString::CString(const char *psz){
	if (psz) strcpy(str = new char[1 + (len = strlen(psz))], (char*)psz);
	else{
		str = new char('\0');
		len = 0;
	}
}

CString::~CString(){
	CLEAR;
}

void CString::Empty(){
	CLEAR;
	str = NULL;
}

CString &CString::operator =(const CString &stringSrc){
	if (this != &stringSrc){
		delete[] str;
		strcpy(str = new char[1 + (len = stringSrc.len)], stringSrc.str);
	}
	return *this;
}

const CString &CString::operator =(const unsigned char *psz){
	if (psz) *this = CString((char*)psz);
	else{
		CLEAR;
		str = new char('\0');
	}
	return *this;
}

CString &CString::operator +=(const CString &string){
	str = strcat(strcpy(new char[1 + (len += string.len)], str), string.str);
	return *this;
}

CString operator +(const CString &string1, const CString &string2){
	return *new CString(string1) += string2;
}

CString CString::Mid(int nFirst, int nCount) const{
	if ((nFirst < 0) || (nCount < 0) || (nFirst >= len)) return NULL;
	CString *res = new CString();
	res->Empty();
	res->len = len < nFirst + nCount ? len - nFirst : nCount;
	strncpy(res->str = new char[res->len + 1], str + nFirst, res->len)[res->len] = '\0';
	return *res;
}

CString CString::Left(int nCount) const{
	return Mid(0, nCount);
}

CString CString::Right(int nCount) const{
	if (nCount > len) return *this;
	return Mid(len - nCount, nCount);
}

int CString::Find(char *pszSub) const{
	int p = strstr(str, pszSub) - str;
	return p < 0 ? -1 : p;
}

int CString::Find(char ch) const{
	int p = strchr(str, ch) - str;
	return p < 0 ? -1 : p;
}

void CString::SetAt(int nIndex, char ch){
	if (nIndex < len)
		str[nIndex] = ch;
}

char CString::operator [](int indx){
	if ((indx < 0) || (indx >= len)) return NULL;
		return str[indx];
}

int CString::GetLength() const{
	return len;
}

bool CString::IsEmpty(){
	return 0 == len;
}

int CString::Compare(const CString s) const{
	return strcmp(str, s.str);
}

void CString::Print(){
	cout << str << endl;
}
