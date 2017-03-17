//GaussJordanElimination.h
//author: Yu.Zorin
//written: 03/28/05
//last modified: 
////////////////////////////////
#ifndef _GJELIMINATIO_H
#define _GJELIMINATIO_H

#include <stdlib.h>
#include <valarray>

using namespace std;

//prints a matrix
void pr_matrix(valarray <double> m, int sz);
//prints a vector
void pr_vector(valarray <double> v, int sz);
//copies a row number row_n into the matrix va of size sz
void valrow_cpy(valarray <double > &va, valarray <double> row, int sz, int row_n);

//elimination itself
bool GaussJordanElimination(valarray <double > &va, int n);
#endif
