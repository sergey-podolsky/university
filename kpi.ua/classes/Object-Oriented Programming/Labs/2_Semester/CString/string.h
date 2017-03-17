/* * * * * * * * * * * * * * * * * 
 * ������������ ������ �1 (2-�� �������)
 *
 *		��������:
 * ���������� ������
 * ������: ��-64
 *
 *		�������� �������:
 * string.h - �������� ��������� �������;
 * string.cpp - �������� ���������� �������-������;
 * stringtest.cpp - ����-�����, ��������������� ����������������� �������.
 * * * * * * * * * * * * * * * * */

#ifndef	__CString
#define	__CString

class CString{
public:
	//constructors
	CString();
	CString(const char *psz); 
	CString(const CString &stringSrc); 

	//methods
	int GetLength() const;
	bool IsEmpty();
	void SetAt(int nIndex, char ch);
	int Compare(const CString s) const;
	int Find(char ch) const;
  	int Find(char *pszSub) const;
  
	CString Mid(int nFirst, int nCount) const;
	CString Left(int nCount) const;	
	CString Right(int nCount) const;

	//operators
	CString &operator =(const CString &stringSrc);
	const CString &operator =(const unsigned char *psz);	
	char operator [](int indx);

	friend CString operator +(const CString &string1, const CString &string2);
	CString &operator +=(const CString &string);

	//for test purposes
	void Print();
	virtual ~CString();
private:
	char *str;
	int len;
	void Empty();
};

#endif