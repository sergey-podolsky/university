// Polinimial.cpp: implementation of the CPolinimial class.
//author: Yu.Zorin
//written: 06/29/08
//last modified: 
//////////////////////////////////////////////////////////////
#include <stdio.h>
#include <math.h>

#include "Polinomial.h"
#include "Traits.h"

////////////////////////////////////////////////////////////////
// Construction/Destruction
////////////////////////////////////////////////////////////////

CPolinimial::CPolinimial(){
	degree = 0;
	coeffs = NULL;
}

CPolinimial::CPolinimial(int n, double *v){
	degree = n;
	coeffs = new double[degree + 1];
	for(int i = 0; i <= degree; i++)
		coeffs[i] = v[i];

}

double CPolinimial::Eval(double x){
	double b = 0;
	for(int i = 0; i <= degree; i++)
		b += coeffs[i] * phi(i,x);
	
	return b;
}

void CPolinimial::Print(){
	for(int i = 0; i <= degree; i++)
		printf("a[%u] = %.15f ", i, coeffs[i]);
	printf("\n");
}

CPolinimial::~CPolinimial(){
	delete [] coeffs;
}
