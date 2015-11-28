/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Parallel system of linear equations solving using MPI
 * Jacobi method, contiguous MPI data type
 * and master-slave schema is used.
 * Programming of computer networks Lab ¹4 (1st semester 2010)
 *
 *		Author:
 * Podolsky Sergey
 * Group:	KV-64M
 *
 * written:	12.12.2010
 * remarks:	Compiled with Visual Studio 2010.
 *			Debugged on Microsoft HPC Pack 2008
 *			Tested on a cluster.
 *
 *		Project definition:
 * MPI_Lab4.cpp		The entry point for the console application
 * stdafx.h			Include file for standard system include files
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
																	
#include "stdafx.h"

#define SIZE_INPUT_FILE	"N.txt"
#define MATRIX_INPUT_FILE "A.txt"
#define	FREE_MEMBERS_INPUT_FILE	"B.txt"
#define RESULT_FILE "X.txt"

/* Roots precision */
#define	EPS	0.0001

/* Allowable number of iterations */
#define MAX_INERATIONS	1000

/* Rank of master process */
#define MASTER	0


int main(int argc, char* argv[])
{
	/* Execution start time */
	clock_t start_clock;

	/* MPI Initialization */
	MPI_Init(&argc, &argv);

	/* Get total number of processes and current process rank */
	int p, rank;
	MPI_Comm_size(MPI_COMM_WORLD, &p);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);

	/* Source matrix, free members vector. Used in master process only */
	double *a, *b;

	/* Source matrix size */
	int n;
	
	/* Read matrix in master process */
	if (rank == MASTER)
	{
		/* Open file of roots count for reading */
		FILE *file = fopen(SIZE_INPUT_FILE, "r");
		if (file == NULL)
		{
			printf("Unable to open input file ");
			printf(SIZE_INPUT_FILE);
			MPI_Abort(MPI_COMM_WORLD, 1);
		}

		/* Read count of roots */
		fscanf(file, "%d", &n);

		/* Close file */
		fclose(file);

		/* Check if matrix size is a multiple number of processors */
		if (n % p != 0)
		{
			printf("Matrix size must be a multiple number of processors");
			MPI_Abort(MPI_COMM_WORLD, 2);
		}

		/* Open file of free members for reading */
		file = fopen(FREE_MEMBERS_INPUT_FILE, "r");
		if (file == NULL)
		{
			printf("Unable to open input file ");
			printf(FREE_MEMBERS_INPUT_FILE);
			MPI_Abort(MPI_COMM_WORLD, 3);
		}

		// Allocate array of free members
		b = (double*) calloc(n, sizeof(double));

		// Read free members array from file
		for (int i = 0; i < n; i++)
			fscanf(file, "%lf", &b[i]);

		/* Close file */
		fclose(file);

		/* Open file of matrix elements for reading */
		file = fopen(MATRIX_INPUT_FILE, "r");
		if (file == NULL)
		{
			printf("Unable to open input file ");
			printf(MATRIX_INPUT_FILE);
			MPI_Abort(MPI_COMM_WORLD, 4);
		}

		/* Allocate matrix */
		a = (double*) calloc(n * n, sizeof(double));
		
		/* Fill matrix with elements from file */
		for (int i = 0; i < n * n; i++)
			fscanf(file, "%lf", &a[i]);

		/* Close file */
		fclose(file);

		/* Initialize start time */
		start_clock = clock();
	}

	/* Broadcast roots count to all processes */
	MPI_Bcast(&n, 1, MPI_INT, MASTER, MPI_COMM_WORLD);

	/* Evaluate norm of free members vector in master process */
	double b_norm = 0;
	if (rank == MASTER)
	{
		for (int i = 0; i < n; i++)
			b_norm += b[i] * b[i];
		b_norm = sqrt(b_norm);
	}

	/* Broadcast norm of free members vector to all processes */
	MPI_Bcast(&b_norm, 1, MPI_DOUBLE, MASTER, MPI_COMM_WORLD);

	/* Row count per each process */
	int rows_count = n / p;

	/* Create row type as array of elements with the size of matrix */
	MPI_Datatype row_type;
	MPI_Type_contiguous(n, MPI_DOUBLE, &row_type);
	MPI_Type_commit(&row_type);

	/* Create column chunk type */
	MPI_Datatype chunk_type;
	MPI_Type_contiguous(rows_count, MPI_DOUBLE, &chunk_type);
	MPI_Type_commit(&chunk_type);

	/* Allocate array for chunk of free members in each process */
	double *b_chunk = (double*) calloc(rows_count, sizeof(double));
	
	/* Scatter free members vector to all processes */
	if (rank == MASTER)
	{
		MPI_Scatter(b, 1, chunk_type, b_chunk, 1, chunk_type, MASTER, MPI_COMM_WORLD);
		free(b);
	}
	else
		MPI_Scatter(NULL, 0, MPI_DATATYPE_NULL, b_chunk, 1, chunk_type, MASTER, MPI_COMM_WORLD);
	
	/* Allocate count of rows per each process */
	double *rows = (double*) calloc(rows_count * n, sizeof(double));

	/* Scatter matrix as count of rows per process */
	if (rank == MASTER)
	{
		MPI_Scatter(a, rows_count, row_type, rows, rows_count, row_type, MASTER, MPI_COMM_WORLD);
		free(a);
	}
	else
		MPI_Scatter(NULL, 0, MPI_DATATYPE_NULL, rows, rows_count, row_type, MASTER, MPI_COMM_WORLD);

	/* Vector of roots */
	double *roots = (double*) calloc(n, sizeof(double));

	/* Roots vector  chunk*/
	double *roots_chunk = (double*) calloc(rows_count, sizeof(double));

	/* Initial roots values */
	for (int i = 0; i < n; i++)
		roots[i] = 1;

	/* Begin approximation iterations */
	for (int iteration = 0; ; iteration++)
	{
		/* Check for iterations limit */
		if (rank == MASTER && iteration >= MAX_INERATIONS)
		{
			printf("Iteration limit %d is reached", MAX_INERATIONS);
			MPI_Abort(MPI_COMM_WORLD, 5);
		}

		/* Partial residue of roots in the current process */
		double residue = 0;

		/* Approximate each next root value */
		for (int i = 0; i < rows_count; i++)
		{
			double sum = 0;
			for (int j = 0; j < n; j++)
					sum += roots[j] * rows[n * i + j];
			int j = rows_count * rank + i;
			double r = b_chunk[i] - sum;
			roots_chunk[i] = (r + roots[j] * rows[i * n + j]) / rows[n * i + j];
			residue += r * r; // Error for current root
		}

		/* Reduce total error */
		// MPI_Allreduce(MPI_IN_PLACE, &residue, 1, MPI_DOUBLE, MPI_SUM, MPI_COMM_WORLD);
		if (rank == MASTER)
			MPI_Reduce(MPI_IN_PLACE, &residue, 1, MPI_DOUBLE, MPI_SUM, MASTER, MPI_COMM_WORLD);
		else
			MPI_Reduce(&residue, NULL, 1, MPI_DOUBLE, MPI_SUM, MASTER, MPI_COMM_WORLD);
		MPI_Bcast(&residue, 1, MPI_DOUBLE, MASTER, MPI_COMM_WORLD);

		/* Check stop criteria */
		if (sqrt (residue) / b_norm < EPS)
			break;

		/* Gather all roots in all processes */
		// MPI_Allgather(roots_chunk, 1, chunk_type, roots, 1, chunk_type, MPI_COMM_WORLD);
		if (rank == MASTER)
			MPI_Gather(roots_chunk, 1, chunk_type, roots, 1, chunk_type, MASTER, MPI_COMM_WORLD);
		else
			MPI_Gather(roots_chunk, 1, chunk_type, NULL, 0, MPI_DATATYPE_NULL, MASTER, MPI_COMM_WORLD);
		MPI_Bcast(roots, 1, row_type, MASTER, MPI_COMM_WORLD);
	}

	/* Write results */
	if (rank == MASTER)
	{
		/* Calculate execution time in milliseconds*/
		clock_t milliseconds = (clock() - start_clock) * 1000 / CLOCKS_PER_SEC;

		/* Create file */
		FILE *file = fopen(RESULT_FILE, "w");
		if (file == NULL)
		{
			printf("Unable to open output file ");
			printf(RESULT_FILE);
			MPI_Abort(MPI_COMM_WORLD, 6);
		}

		/* Write result */
		for (int i = 0; i < n; i++)
			fprintf(file, "x[%d] = \t%f\n", i, roots[i]);
		fprintf(file, "\n");
		fprintf(file, "Number of processes:\t%d\n", p);
		fprintf(file, "Execution time:\t%ld milliseconds\n", milliseconds);


		/* Close file */
		fclose(file);
	}

	/* Free resources */
	MPI_Type_free(&row_type);
	MPI_Type_free(&chunk_type);
	free(b_chunk);
	free(roots);
	free(roots_chunk);
	return MPI_Finalize();
}
