//LinearEquasions.cpp - solution of linear equasions
//author: Yu.Zorin
//written: 08/04/08
//last modified: 08/05/08
/////////////////////////////////////////////////////
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <math.h>
#include <float.h>

#include <valarray>

using namespace std;

///////////////////////////////////////////////////////
//all functions put solution into the last column of
//extended matrix passed as first parameter
//////////////////////////////////////////////////////

//pointer to simple or Zeidel iteration function
typedef void (* GetSolutionFunc)(valarray <double> &, int , 
							   valarray <double> , valarray <double> &);



//shell function to solve linear equasions by simple or Zeidel iteration
//return: true, if eps achived within maxiter, maxiter contains actual 
//        number of iterations
//      : false, if eps not achived within maxiter or system matrix is
//        singular
//////////////////////////////////////////////////////////////////////// 
bool Iterations(valarray <double > &va, int n, double eps, int &maxiter, GetSolutionFunc );

//simple iterarions
void GetSolution_si(valarray <double> &va, int n, valarray <double> prev_sol, valarray <double> &next_sol);
//Zeidel iterations
void GetSolution_ze(valarray <double> &va, int n, valarray <double> prev_sol, valarray <double> &next_sol);

//returns m-norm of ||x1 - x2||
double vect_norm(valarray <double> &x1, int , valarray <double> &x2);


//Gauss - Joradan elimination
bool GaussJordanElimination(valarray <double > &va, int n);

//progonka
void Progonka(valarray <double > &matrix, int n);

//Gauss elimination
bool GaussElimination(valarray <double > &va, int n);

//prints a matrix
void pr_matrix(valarray <double> m, int sz);

//prints a vector into screen
void pr_vector(valarray <double> v, int sz);

//prints a vector into file
void pr_vector_f(FILE *, valarray <double> v, int sz);

//copies a row number row_n into the matrix va of size sz
void valrow_cpy(valarray <double > &va, valarray <double> row, int sz, int row_n);

