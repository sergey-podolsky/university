//GaussJordanElimination.cpp
//author: Yu.Zorin
//written: 03/28/05
//last modified: 
////////////////////////////////
#include "GaussJordanElimination.h"

#include <stdio.h>
#include <conio.h>

//elimination itself
//upon success returns result un (n + 1)-th row of va
bool GaussJordanElimination(valarray <double > &va, int n){
	int i , j;
		
	for(i = 0; i < n; i++){
		slice row_s(i * ( n + 1), n + 1, 1);
		valarray <double> m_row = va[row_s];  //current major row
		double d = m_row[i];
		
		if( !d )
			return false;

		m_row /= d;//modified major row 
		valrow_cpy( va, m_row, n, i );
		
		for( j = 0; j < n; j++){
			//column to be modified
			slice col_s(i , n, n + 1);
			valarray <double> col = va[col_s];
			
			if( i == j) continue;
			valarray <double> tmp = m_row * col[j];
			valarray <double> row = va[slice(j * ( n + 1), n + 1, 1 )];
			row -= tmp;
			//put in into matrix
			valrow_cpy( va, row, n, j );
		
		}
	}
	return true;
}


void valrow_cpy(valarray <double> &va, valarray <double> row, int sz, int row_n){
	int start_p, i;
	start_p = row_n * (sz + 1);
	for(i = 0; i < sz + 1; i++)
		va[start_p + i] = row[i];

}

void pr_matrix( valarray <double> m, int sz){
	int i,j;
	for(i = 0; i < sz; i++){
		for(j = 0; j < sz + 1; j++)
			printf("%f ", m[i*(sz + 1) + j]);
		printf("\n");
	}
	printf("\n\n");
}

void pr_vector(valarray <double> v, int sz){
	int i;
	for(i = 0; i < sz; i++)
		printf("%f ", v[i]);
	printf("\n");
}
