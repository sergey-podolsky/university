//Simpson.h
//author: Yu.Zorin
//written: 03/28/05
//last modified: 
////////////////////////////////
#ifndef _SIMPSON_H
#define _SIMPSON_H

#include <math.h>

//integrands
typedef double (*pf)(double , int, int);

double Simpson(double a, double b, int n, pf integrand, int i, int j);
//calculates definite integral with absolute error eps
double Runge_meth(double a, double b, double eps, double& h, pf integrand, int i, int j);

//calculates definite integral with relative error beta
double Runge_meth_rel(double a, double b, double beta, double& h, pf integrand, int i, int j);

#endif
