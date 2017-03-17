//LeastSquaresApproximation.cpp
//author: Yu.Zorin
//written: 06/28/08
//last modified: 
////////////////////////////////
#include <stdio.h>

#include "Traits.h"
#include "GaussJordanElimination.h"
#include "Simpson.h"
#include "Polinomial.h"
#include "NormalSystem.h"

int main(){
	///////////// Legendre test /////////////////
	//printf("%f\n", phi(1, 1.5));
	//return 0;
	////////////////////////////////////
	FILE *out;
//basic functions
#ifdef _LEGENDRE_
	out = fopen("plot_leg.txt", "w");
#elif defined(_POLINOMIALS_)
	out = fopen("plot_pol.txt", "w");
#else 
	#ifdef  _CHEBYSHEV_
	out = fopen("plot_che.txt", "w");	
	#endif
#endif

	int i, j;
	int int_numb = 100;

	const int count = 25;

	for(i = 8; i < count; i++){
		n = i;
		double *v = new double[n + 1];
		PolinomialCoeffs( v );
		CPolinimial p(n , v);
		double x = a, h = (b - a)/ int_numb;
		
		printf("\n n = %u\n", n);
		double sum = 0;
		
		for(j = 0; j <= int_numb; j++){
			double delta = fabs(f( x ) - p.Eval( x ));
			printf("%.12e ", delta );
			sum += delta * delta;
		
			if(i == count-1){
				fprintf(out, "%.7f;", x);
				fprintf(out, "%.7f\n", p.Eval( x ));
			}
		
			x += h;
		}
		
		double sko = pow(sum, 1.0 / 2) / int_numb;
		printf("\nsko = %.15f\n", sko);
	    //getch();
	}

	fclose( out );
	return 0;
}