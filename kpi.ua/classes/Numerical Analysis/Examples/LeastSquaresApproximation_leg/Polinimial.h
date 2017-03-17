// Polinimial.h: interface for the CPolinomial class.
//author: Yu.Zorin
//written: 06/29/08
//last modified: 
////////////////////////////////////////////////////////

#if !defined(AFX_POLINIMIAL_H__F5489A81_5CF2_11DD_A815_AC5280493858__INCLUDED_)
#define AFX_POLINIMIAL_H__F5489A81_5CF2_11DD_A815_AC5280493858__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CPolinomial  
{
public:
	CPolinomial();
	CPolinomial( int , double * );
	double Eval( double );
	void Print();
	virtual ~CPolinomial();
private:
	int degree;
	double *coeffs;
};

#endif // !defined(AFX_POLINIMIAL_H__F5489A81_5CF2_11DD_A815_AC5280493858__INCLUDED_)
