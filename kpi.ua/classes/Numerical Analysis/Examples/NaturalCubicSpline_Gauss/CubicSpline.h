/****************************************************
* CubicSpline.h - function prototypes to build and evaluate 
* a natural cubic spline
* uses different methods to solve linear equasions
* written: 29.04.2008
* last modified: 05.08.2008
* author: Yu.Zorin
*****************************************************/

#ifndef _CUBICSPLINE_H
#define _CUBICSPLINE_H

//methods to solve linear equasions

//#define _PROGONKA_
//#define _SIMPLEITERATIONS_
//#define _ZEIDELITERATIONS_
//#define _GAUSSELIMINATION_
#define _GAUSSJORDANELIMINATION_


#include <conio.h>
#include "LinearEquasions.h" //for valarray 

#define square( x ) ((x) * (x))
typedef valarray<double> dbl_vector;


//builds a natural cubic spline
//upon n + 1 knots
bool CubicSpline(dbl_vector &matr, int n);
//cubic spline evaluation at x
double Evaluate(dbl_vector matr, int n, double x);
//prints extended matrix with n rows and n + 1 columns
void pr_matrix( dbl_vector m, int sz);
void pr_vector(dbl_vector v, int sz);

#endif