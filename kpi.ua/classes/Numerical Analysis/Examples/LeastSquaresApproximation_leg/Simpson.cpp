//Simpson.cpp
//author: Yu.Zorin
//written: 03/28/05
//last modified: 
////////////////////////////////
#include <stdio.h>
#include <conio.h>

#include "Simpson.h"

double Simpson(double a, double b, int n, pf integrand, int i, int j){
	int k;
	double res = 0;
	double h = (b - a) / n;
	double x = a + h;
	double odd_sum = 0, even_sum = 0;
	for(k = 1; k <= n - 1; k++ ){
		double _integrand = integrand( x , i, j);
		if( k % 2) //odd
			odd_sum += _integrand;
		else
			even_sum += _integrand;
		x += h;

	}
	res += integrand( a ,i , j) + integrand( b , i, j) + 4 * odd_sum + 2 * even_sum;
	return h * res / 3;
}

double Runge_meth(double a, double b, double eps, double& h, pf integrand, int i, int j){
	double res1, res2;
	int n = (b - a)/sqrt(sqrt( eps ));
	if(n % 2) n++;

	res1 = Simpson( a, b, n, integrand, i, j);
	n *= 2;
	res2 = Simpson( a, b, n, integrand, i ,j);
	
	if( !res2) return 0;

	while(fabs(res1 - res2) > 15 * eps){
		res1 = res2;
		n *= 2;
		res2 = Simpson( a, b, n, integrand, i, j);
	}
	
	h = (b - a) / n;
	return res2;

}

//calculates definite integral with relative error beta
double Runge_meth_rel(double a, double b, double beta, double& h, pf integrand, int i, int j){

	double res1, res2;
	int n = (b - a)/sqrt(sqrt( beta ));
	if(n % 2) n++;
	//////////////////////////////////
	//n = 2;
	/////////////////////////////////
	res1 = Simpson( a, b, n, integrand, i, j);
	n *= 2;
	res2 = Simpson( a, b, n, integrand, i, j);
	
	if( !res2) return 0;

	while(fabs(res1 - res2) / res2 > 15 * beta){
		///////////////////////////////////////////
	  printf("i = %u  res1 = %.12f res2 = %.12f\n", i, res1, res2);
	  //getch();
	    ///////////////////////////////////////////
		res1 = res2;
		n *= 2;
	}
	
	h = (b - a) / n;
	return res2;
}


