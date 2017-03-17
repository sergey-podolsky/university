//NormalSystem.cpp: routine to calculate polinomial coeffs
//author: Yu.Zorin
//written: 07/29/08
//last modified: 
////////////////////////////////////////////////////////

#include <stdlib.h>

#include "Traits.h"
#include "Simpson.h"
#include "GaussJordanElimination.h"


bool PolinomialCoeffs(double *coeffs){
	double *matr = new double[(n + 1) * (n + 2)];
	
	int i, j;
	double h;
	double coeff;
	for(i = 0; i <= n; i++){
		for(j = 0; j <= n + 1; j++){

			if( j != (n + 1)){
				pf integrand =	phi_integrand;
				coeff = Runge_meth_rel(a, b, eps, h, integrand, i, j);
			}
			else{
				pf integrand =	f_integrand;
				coeff = Runge_meth_rel(a, b, eps, h, integrand, i, -1);
				
			}
			matr[i * (n + 2) + j] = coeff;
			//printf("coeff = %.12f\n", coeff);
		}
	}


	/*
	/////////////////////////////////////
	for(i = 0; i <= n; i++){
		for(j = 0; j <= n + 1; j++)
			printf("%f ", matr[i * (n + 2) + j]);
		printf("\n");
	}
	printf("\n");
	////////////////////////////////////
	*/

	valarray <double> a(matr, (n + 1)*(n + 2));
	bool done = GaussJordanElimination( a, n + 1);

	if( done ){
		valarray <double> res = a[slice(n + 1, n + 1, n + 2)];
	
		for(i = 0; i <= n ; i++){
			coeffs[i] = res[i];
			//printf("coeffs[%u] = %f\n", i, coeffs[i]);
		}
	}

	return done;
}



