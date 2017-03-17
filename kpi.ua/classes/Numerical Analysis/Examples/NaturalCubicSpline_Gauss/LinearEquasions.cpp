//LinearEquasions.cpp - solution of linear equasions
//author: Yu.Zorin
//written: 08/04/08
//last modified:08/05/08
/////////////////////////////////////////////////////
#include "LinearEquasions.h"


//elimination itself
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

//Gauss elimination
bool GaussElimination(valarray <double > &va, int n){
	
	int i , j;
	
	//direct move
	for(i = 0; i < n; i++){
		slice row_s(i * ( n + 1), n + 1, 1);
		valarray <double> m_row = va[row_s];  //current major row
		double pivot = m_row[i];
		
		if( !pivot ){
			//+++++++++++++++++++++
			//printf("i = %u\n", i);
			//pr_matrix( va, n);
			//++++++++++++++++++++++
			return false;
		}

		m_row /= pivot;//modified major row 
		valrow_cpy( va, m_row, n, i );
		
		for( j = i + 1; j < n; j++){

			//row to be modified
			slice row_s(j * (n + 1) , n + 1, 1);
			valarray <double> row = va[row_s];
			
			//make a copy of major row
			valarray <double> cpy( n + 1 );
			cpy = m_row;
			cpy *= row[i];
			//substract them 
			cpy -= row;
			//put in into matrix
			valrow_cpy( va, cpy, n , j );
					
		}
	}

	//reverse move
	valarray <double> x( n );
	x[n - 1] = va[n * (n + 1) - 1];
	for(i = n - 2; i >= 0; i--){
		x[i] = 0;
		valarray <double> row = va[slice(i * ( n + 1), n + 1, 1)];
			for(j = i + 1; j <= n - 1; j++)
				x[i] += row[j] * x[j];
		x[i] = row[n] - x[i];
	}

	//solution is in the last column of matrix
	for(i = 0, j = n; i < n; i++, j += n + 1){
		va[j] = x[i];
	}
		
	return true;
}
  

bool Iterations(valarray <double > &va, int n, double eps, int &maxiter, GetSolutionFunc gsf){
	FILE *f = fopen("log.txt", "w");
	
	int i, j;
	double alpha_norm, x_norm;
	//iteration counter
	int iter_count = 0;

	//solution vect
	valarray <double> sol( n );

	//converted matrix
	valarray <double> alpha( n*(n + 1));
	//get alpha matr
	for(i = 0; i < n; i++){
		valarray <double> row = va[slice(i * ( n + 1), n + 1, 1)];  //current row
		double alpha_i1 = row[i];

		if( !alpha_i1) return false;
		
		row[i] = 0;
		for(j = 0; j <= n; j++){
			if( j != i)
				row[j] /= alpha_i1;
		}
		valrow_cpy( alpha, row, n, i );
	}

	
	//beta vect
	valarray <double> beta = alpha[slice( n, n , n + 1)];
	//start approxim
	for(i = 0; i < n; i++ )
		sol[i] = beta[i];
	
	//calculate  alpha_norm
	alpha_norm = DBL_MIN;
	if( !alpha_norm ) return false;

	for(i = 0; i < n; i++ ){
		double sum = 0;
		valarray <double> row = alpha[slice( i * (n + 1), n , 1)];
		for(j = 0; j < n; j++)
			sum += fabs(row[j]);
		if( sum > alpha_norm ) alpha_norm = sum;
	}

	//get first solution
	valarray <double> next_sol( n );
	iter_count++;
	gsf( alpha, n, beta, next_sol);
	
	//fprintf( f, "beta\n");
	//pr_vector_f( f, beta, n );
	//fprintf( f, "f_sol\n");
	//pr_vector_f( f, next_sol, n );

	x_norm = vect_norm( beta, n, next_sol );//beta, n, next_sol
	 
	while(x_norm > (1 - alpha_norm) / alpha_norm * eps){
		//pr_matrix( next_sol, n);
		for(i = 0; i < n; i++)
			beta[i] = next_sol[i];

		gsf( alpha, n, beta, next_sol);
///////////////////////////////////////////////
		pr_vector_f( f, next_sol, n );
///////////////////////////////////////////////
		iter_count++;
		x_norm = vect_norm( beta, n, next_sol );

	};

	maxiter = iter_count;
	//pr_matrix( alpha, n);
	//pr_vector( next_sol, n);
	//printf("sol = %.12f\n", next_sol);
	fclose( f );
	//solution is in the last column of matrix
	for(i = 0, j = n; i < n; i++, j += n + 1){
		va[j] = next_sol[i];
	}
	return true;
}


void GetSolution_si(valarray <double> &va, int n, valarray <double> prev_sol, valarray <double> &next_sol){
	int i, j;
	for(i = 0; i < n; i++){
		next_sol[i] = 0;
		valarray <double> row = va[slice( i * (n + 1), n + 1 , 1)];
		for(j = 0; j < n ; j++)
			next_sol[i] += row[j] * prev_sol[j];
		next_sol[i] = row[n] - next_sol[i];
	}

}

//Zeidel iterations
void GetSolution_ze(valarray <double> &va, int n, valarray <double> prev_sol, valarray <double> &next_sol){
	int i, k;

	for(i = 0; i < n; i++)
		next_sol[i] = 0;
	for(i = 0; i < n; i++){
	//	next_sol[i] = 0;
		valarray <double> row = va[slice( i * (n + 1), n + 1 , 1)];
		for(k = 0; k < i ; k++)
			next_sol[i] += row[k] * next_sol[k];

		for(k = i; k < n ; k++)
			next_sol[i] += row[k] * prev_sol[k];

		next_sol[i] = row[n] - next_sol[i];
	}
}

//matrix - extended matrix including right-hand side column
// n - system dimension
void Progonka(valarray <double> &matrix, int n){
	typedef valarray<double> dbl_vector;
		int i;
		dbl_vector row;
		dbl_vector alpha( n ), beta( n );
		//initial alpha & beta for reccurent calculation
		alpha[1] = -matrix[1] / matrix[0];
		beta[1] = matrix[n] / matrix[0];
		//get the rest alpha and beta
		for(i = 1; i < n - 1; i++){
			slice row_i(i*(n + 1), n + 1, 1);
			//get row number i
			dbl_vector cur_row = matrix[slice(i*(n + 1), n + 1, 1)];
			alpha[i + 1] = -cur_row[i + 1] /(cur_row[i - 1] * alpha[i] + cur_row[i]);
			beta[i + 1] = (cur_row[n] - cur_row[i - 1] * beta[i]) /
				(cur_row[i - 1] * alpha[i] + cur_row[i]);
			
		}
		dbl_vector last_row = matrix[slice((n - 1) * (n + 1), n + 1, 1)];//last row
		dbl_vector res( n );
		//Xn
		res[n - 1] = (last_row[n] - last_row[n - 2] * beta[n - 1]) / 
			(last_row[n - 1] + last_row[n - 2] * alpha[n - 1]);
		//the rest roots	
	   	for(i = n - 2; i >= 0; i--){
			res[i] = alpha[i + 1] * res[i + 1] + beta[i + 1];
		}
		int j;
	    //solution is in the last column of matrix
		for(i = 0, j = n; i < n; i++, j += n + 1){
			matrix[j] = res[i];
		}
}

double vect_norm(valarray <double> &x1, int n, valarray <double> &x2){
	double norm = DBL_MIN;
	for(int i = 0; i < n; i++){
		double delta = fabs(x1[i] - x2[i]);
		if( delta > norm) norm = delta;
	}
	return norm;

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

//prints a vector into file
void pr_vector_f(FILE *f, valarray <double> v, int sz){
	int i;
	for(i = 0; i < sz; i++)
		fprintf( f, "%.16f ", v[i]);
	fprintf( f, "\n");
}




