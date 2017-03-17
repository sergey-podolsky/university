//Traits.h: Least squares approximation traits
//author: Yu.Zorin
//written: 07/28/08
//last modified: 07/30/08
////////////////////////////////
#ifndef _TRAITS_H
#define _TRAITS_H

#include <math.h>
#include <stdio.h>
#include <conio.h>

//basic function definitions 
//#define _LEGENDRE_
//#define _POLINOMIALS_
#define _CHEBYSHEV_

//interval
extern double a;
extern double b;

//polinomial degree
extern int n;

//relative accuracy for Simpson rule 
extern double eps;

//relative accuracy for Simpson rule 
extern double eps;

//function to approximate
double f(double x);

//basic functions
double phi(int n, double x);

//phi-integrand - normal system coefficients
double phi_integrand(double x, int i, int j);

//f-integrand - normal system right-hand side values
double f_integrand(double x, int i, int j/*unused*/);


#endif