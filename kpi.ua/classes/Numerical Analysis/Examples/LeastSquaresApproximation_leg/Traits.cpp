//Traits.cpp
//author: Yu.Zorin
//written: 07/30/08
//last modified: 
//uses Legendre polinomials 
////////////////////////////////

#include "Traits.h"

double a = 0;
double b = 5.7;

//polinomial degree
int n = 26;

//relative accuracy for Simpson rule 
double eps = 1e-3;

//function to approximate
double f(double x){
	//return 1 / (1 + 25 * x * x );//x*x* log10( x ) * sin ( x/2 );
	return 0.5 * pow(x, 3) * sin(3 * x);
		   //1 * exp((x-15)^1.0 / 4) * sin ( 1.2 * x )
	//return 1 / x - 0.1 * x * x *  sin ( 2 * x );
}


//basic functions
#ifdef _LEGENDRE_
	double phi(int n, double x){
		if( n == 0 ) return 1;
		if( n == 1 ) return x;
		return (double)(2 * (n - 1)  + 1 ) / n * x * phi(n - 1, x)
					- (double)(n - 1) / n * phi(n - 2, x);
	}
#elif defined(_POLINOMIALS_)
	double phi(int n, double x){
		return pow(x, (double)n);
	}
#else 
	#ifdef  _CHEBYSHEV_
	double phi(int n, double x){
		if( n == 0 ) return 1;
		if( n == 1 ) return x;
		return 2 * x * phi(n - 1, x) - phi(n - 2, x);
	}	
	#endif
#endif


//phi-integrand - normal system coefficients
double phi_integrand(double x, int i, int j){
	return phi(i, x) * phi(j, x);

}

//f-integrand - normal system right-hand side values
double f_integrand(double x, int i, int j/*unused*/){
	return phi(i, x) * f(x);
}

