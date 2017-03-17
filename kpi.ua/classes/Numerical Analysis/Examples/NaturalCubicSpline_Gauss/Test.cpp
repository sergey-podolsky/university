/****************************************************
* Test.cpp - test of natural cubic spline
* method to solve linear equasions mut be defined in CubicSpline.h!!!
* written: 29.04.2008
* last modified: 05.08.2008
* author: Yu.Zorin
*****************************************************/

#include <stdio.h>
#include <math.h>

#include "LinearEquasions.h"
#include "CubicSpline.h"

//#define M_PI		3.14159265358979323846
#define M_PI atan( 1.0 ) * 4

//func to be approximated
double f(double x){
	//return  square( x ) * x ;//square( x ) * x;
	//return  1* x * log10(fabs( 3*sin ( x / 2))/1 )/12;
	return 1 / (1 + 25 * square ( x ));
}
int main(){
#define N 100
	
	FILE *out;

	int n = N;
	double a = -1, b = 1; //M_PI / 2;//N / 100.0;
	double _h = (b - a) / n;
	dbl_vector x(n + 1), y(n + 1);
	int i;
	for(i = 0; i < n + 1; i++){
		x[i] = a + _h * i;
		y[i] = f( x[i] ); 
	}

	/////////////////////////////////////////////////////////////////////
	//in matr there must be enough space for Ai, Bi, Ci, Di, Xi	i = 1,n
	/////////////////////////////////////////////////////////////////////
	dbl_vector matr(5 * (n + 1));
	//Xi
	for(i = 0; i < n + 1; i++)
		matr[i] = x[i];
	//Fi
	for(int j = 0; i <= 2 * n + 1; i++, j++)
		matr[i] = y[j];
		
	CubicSpline(matr, n);
	
//	printf("\n\n\n");
	
	out = fopen("plot.txt", "w");

	double _x = a;//  + _h / 2;
	
	for(i = 0; i < N - 1; i++){ 
		double s = Evaluate(matr, n, _x);
		printf(" %.17e\n", fabs( f(_x) - s));
		fprintf(out, "%.7f;", _x);
		fprintf(out, "%.7f\n", s);
		_x += _h;
	}
	
	//printf(" %.17f\n", fabs( f(_x) - Evaluate(matr, n, _x)));
	fclose( out );
	return 0;
}