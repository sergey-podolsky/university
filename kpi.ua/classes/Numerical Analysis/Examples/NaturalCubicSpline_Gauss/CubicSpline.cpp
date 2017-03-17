/****************************************************
* CubicSpline.cpp - functions to build and evaluate 
* a natural cubic spline
* uses different methods to solve linear equasions
* written: 29.04.2008
* last modified: 05.08.2008
* author: Yu.Zorin
*****************************************************/

#include <stdio.h>
#include <conio.h>
#include "LinearEquasions.h"
#include "CubicSpline.h"

/*********************************************************
* copies row with number row_n into 
*extended  matrix va of (sz * (sz + 1)) size
**********************************************************/
void valrow_cpy(dbl_vector &va, dbl_vector row, int sz, int row_n);

/*************************************************************
*builds a natural cubic spline Si(x) upon n + 1 knots
*	Si(x) = Ai + Bi(X - Xi) + Ci/2(X - Xi)^2 + Di/6(X - Xi)^3
* parameters: matr - first (n + 1) elemnts - Xi
*					  next (n + 1) elemnts - Fi
* returns: true if spline was built
*		   false - otherwise
* on success vect containes:
*				Ai - first n elements
*				Bi - next n elements
*				Ci - next n elements
*				Di - next n elements
*				Xi - next n elements
*	i = 1,n
**************************************************************/
bool CubicSpline(dbl_vector &matr, int n){
	int i;
	dbl_vector h( n );//Hi
	dbl_vector xi( n );//Xi

	for(i = 0; i < n; i++){
		xi[i] = matr[i];
		if(matr[i + 1] < matr[i])//unordered knots
			return false;
		h[i] = matr[i + 1] - matr[i];

	}

	//3D matrix for progonka() to calculate Ci i = 1...n - 1
	dbl_vector m( (n - 1) * n );
	//C0 = Cn = 0
	
	//Fi
	dbl_vector fi(n + 1);
	int j;
	for( i = n + 1, j = 0; i <= 2 * n + 1; i++, j++){
		fi[j] = matr[i];
		//printf("fi = %f ", fi[j]);
	}
	
	for(i = 0; i < n - 1; i++/*, j++*/){
		dbl_vector cur_row(n + 1);
		int k = 0;
		
		//first equasion
		if( i == 0 ){ 
			cur_row[k++] = 2 * (h[i] + h[i + 1]);
			cur_row[k++] = h[i + 1];
			//pad the rest with zeros
			for(int l = k; l < n - 1; l++ )
				cur_row[l] = 0;
			//right-hand side column
			cur_row[l] = 6 * ((fi[i + 2] - fi[i + 1]) / h[i + 1] - 
							   (fi[i + 1] - fi[i]) / h[i]);

			valrow_cpy( m, cur_row, n - 1, 0);
			continue;
		}
		
		//last equasion
		if(i == (n - 2)){
			//leading zeros
			for(k = 0; k < n - 3; k++)
				cur_row[k] = 0;
			cur_row[k++] = h[i];
			cur_row[k++] = 2 * (h[i] + h[i + 1]);
			
			cur_row[k] = 6 * ((fi[i + 2] - fi[i + 1]) / h[i + 1] - 
							   (fi[i + 1] - fi[i]) / h[i]);

			valrow_cpy( m, cur_row, n - 1, n - 2);
			break;
		}

		//number of leading zeros
		int l_z;
		if( i > 1)
			l_z = i - 1;
		else
			l_z = -1;
		//padding with zeroes
		for(k = 0; k < l_z; k++)
			cur_row[k] = 0;

		//first element of triplet
		cur_row[k++] = h[i];
		//second element of triplet
		cur_row[k++] = 2 * (h[i] + h[i + 1]);
		//third element of triplet
		cur_row[k++] = h[i + 1];
		//pad with trailing zeros
		for( ; k < n - 1 ; k++)
			cur_row[k] = 0;
		
		cur_row[k] = 6 * ((fi[i + 2] - fi[i + 1]) / h[i + 1] - 
							   (fi[i + 1] - fi[i]) / h[i]);

		valrow_cpy( m, cur_row, n - 1, i);			
		
	}
	
	//find C1, ... Cn-11 values

//methods to solve linear equasions

#ifdef _PROGONKA_
	Progonka(m, n - 1);
#elif defined(_GAUSSELIMINATION_)
	GaussElimination( m, n - 1);
#elif defined(_GAUSSJORDANELIMINATION_)
	GaussJordanElimination( m, n - 1);
#elif defined(_SIMPLEITERATIONS_)
	GetSolutionFunc gsf = GetSolution_ze;
	int maxiter = 300;
	Iterations( m, n - 1, 1e-5, maxiter, gsf);
#elif defined(_ZEIDELITERATIONS_)
	GetSolutionFunc gsf = GetSolution_si;
	int maxiter = 300;
	Iterations( m, n - 1, 1e-5, maxiter, gsf);
#else 
	printf("Linear system method not defined\n");
	exit( 1 );
#endif

 
	dbl_vector res = m[slice (n - 1, n - 1,  n)]; //last column
	
	//Ci
	dbl_vector ci( n + 1);
	ci[0]= ci[n] = 0;
	for(i = 1; i < n; i++)
		ci[i] = res[i - 1];

	//calculation of Di for i = 1...n
	dbl_vector di(n + 1);
	for(i = 1 ; i <= n; i++){
		di[i] = (ci[i] - ci[i - 1]) / h[i - 1];
	}


	//calculation of Bi for i = 1...n
	dbl_vector bi(n + 1);
	for(i = 1 ; i <= n; i++){
		bi[i] = ci[i] * h[i - 1] / 2 - square(h[i - 1]) * di[i] / 6 + (fi[i] - fi[i - 1]) / h[i - 1];
	}
	

	//shift Fi, Ci, Di, Bi to left
	for(i = 0; i < n; i++){
		fi[i] = fi[i + 1];
		ci[i] = ci[i + 1];
		di[i] = di[i + 1];
		bi[i] = bi[i + 1];
	}

	//put the into matr: Fi, Bi, Ci, Di, Xi
	for(i = 0; i < n; i++)
		matr[i] = fi[i];
	for(j = 0; j < n; j++, i++)
		matr[i] = bi[j];

	for(j = 0; j < n; j++, i++){
		matr[i] = ci[j];
	}

	
	for(j = 0; j < n; j++, i++)
		matr[i] = di[j];
	
	for(j = 0; j < n; j++, i++)
		matr[i] = xi[j];
	
	return true;
}

/*************************************************************
*evaluates a natural cubic spline Si(x)
* where Xi-1 <= x <= Xi,  i = 1,n
*	Si(x) = Ai + Bi(X - Xi) + Ci/2(X - Xi)^2 + Di/6(X - Xi)^3
* parameters: matr - first n elemnts - Ai
*					 next n elemnts - Bi
*					 next n elemnts - Ci
*					 next n elemnts - Di
*					 next n elemnts - Xi
* returns Si(x)
**************************************************************/
double Evaluate(dbl_vector matr, int n, double x){
	int i,j;
	//get spline coeffs
	dbl_vector ai(n), bi(n), ci(n), di(n), xi(n);

	for(i = 0; i < n; i++){
		ai[i] = matr[i];
	
	}
	

	for(j = 0; j < n; j++, i++)
		bi[j] = matr[i];

	for(j = 0; j < n; j++, i++){
		 ci[j] = matr[i];
		
	}
	
	for(j = 0; j < n; j++, i++)
		di[j] = matr[i] ;

	for(j = 0; j < n; j++, i++){
		xi[j] = matr[i] ;
	
	}
	

	//find interval number i
	i = 0;
	while( 1 ){
		if( x <= xi[i + 1]){
			i++;
			break;
		}
		i++;
	}

	
	double s = ai[i - 1] + bi[i - 1] * (x - xi[i]) + ci[i - 1] / 2 * square(x - xi[i]) 
					+ di[i - 1] / 6 *(x - xi[i]) * square(x - xi[i]);

		
	return s;
}

/*
void valrow_cpy(dbl_vector &va, dbl_vector row, int sz, int row_n){
	int start_p, i;
	start_p = row_n * (sz + 1);
	for(i = 0; i < sz + 1; i++)
		va[start_p + i] = row[i];

}

void pr_matrix( dbl_vector m, int sz){
	int i,j;
	for(i = 0; i < sz; i++){
		for(j = 0; j < sz + 1; j++)
			printf("%f ", m[i*(sz + 1) + j]);
		printf("\n");

	}
	printf("\n\n");
}
*/