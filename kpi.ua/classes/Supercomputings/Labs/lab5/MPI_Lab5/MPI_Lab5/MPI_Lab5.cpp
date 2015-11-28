/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Numerical solution for Poisson's equation
 * Programming of computer networks Lab №5 (2nd semester 2010-2011)
 *
 *		Author:
 * Podolsky Sergey
 * Group:	KV-64M
 *
 * written:	05.05.2011
 * remarks:	Compiled with Visual Studio 2010.
 *			Debugged on Microsoft HPC Pack 2008 R2
 *			Tested on a cluster.
 *
 *		Project definition:
 * MPI_Lab5.cpp		The entry point for the console application
 * stdafx.h			Include file for standard system include files
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#include "stdafx.h"
#include "mpi.h"


/***************** Опис типів,структур та функцій *****************/

struct matrix	/* Структура, що описує матриці */
{
	int rows;		/* Кількість строк у матриці */
	int cols;		/* Кількість стовпців у матриці */
	double* data;	/* Вказівник на матрицю, розвернуту у одномірний масив*/
};

MPI_Datatype node_mat_t;			/* Тип, що забезпечує розповсюдження частин сітки дискретизації по матриці процессів*/
MPI_Datatype mat_col;				/* Тип, що забезпечує передачу стовпця матриці */
double func(double X, double Y);	/* Повертає значення правої частини диференційного рівняння у точці X,Y*/
void evaluate(int);				/* Виконує одну ітерацію обчислення нового значення в точці з заданим індексом */
void fatal_error(const char* message, int errorcode);				/* Функція виведення помилок вводу-виводу */
struct matrix* matrix_alloc(int rows, int cols, double initial);	/* Фунція, що забеспечує виділення пам'яті та ініціалізацію матриці*/
void matrix_print(const char* filename, struct matrix* mat);		/* Фунція, що забеспечує виведення матриці у файл*/
struct matrix* read_matrix(const char* filename);				/* Функція, що забеспечує зчитування матриці із файлу*/
double boundary(double, double);									/* Функція, що повертає початкові значення граничних вузлів сітки дискретизації */


/* ************************************************************************ */
/* Опис змінних */
int np;					/* Кількість процесів */
int rank;				/* Ранг процесу у MPI_COMM_WORLD */
int total_width;		/* Ширина матриці вузлів сітки дискретизації */
int points_per_node;	/* Ширина частини матриці вузлів сітки дискретизації, що припадає на кожен процес*/
matrix* allcoords_X;	/* Матриця реальних горизонтальних координат вузлів сітки дискретизації */
matrix* allcoords_Y;	/* Матриця реальних вертикальних координат вузлів сітки дискретизації */
matrix* coords_X;	/* Частина матриці реальних координат сітки дискретизації, яка зберігається у кожному з процессів */
matrix* coords_Y;	/* Частина матриці реальних координат сітки дискретизації, яка зберігається у кожному з процессів */
matrix* node_mat;	/* Частина сітки дискретизації, яка зберігається у кожному з процессів*/
matrix* f_xy;		/* Масив значень функції у вузлах сітки дискретизації */
bool* local_stop;		/* Масив для запам'ятовування локальних умов зупинки */
int* node_iter;			/* Лічильники ітерацій для кожної точки частини сітки дискретизації вузла */
MPI_Status stat;		/* Змінна, у яку повертається статус прийому повідомленнь */
double h;				/* Крок сітки дискретизації */
#define EPSILON	0.001	/* Точність розв'язку */
#define OMEGA	0.4		/**/
int global_stop;		/* Глобальна ознака завершення обчислень*/
double* left_col;		/* Стовпці, що процесс буде приймати з лівого та правого процессів під час ітерацій */
double* right_col;
double* top_row;		/* Рядки, що процесс буде приймати з верхнього та нижнього процессів під час ітерацій */
double* bot_row;

#define MAX_ITER	INT_MAX	/* Масимально допустима кількість ітерацій на кожен вузол сітки */
#define	GRID_MIN	-1.0	/* Мінімальне значення координати кожної з осей координатної сітки*/
#define	GRID_MAX	1.0		/* Максимальне значення координати кожної з осей координатної сітки*/
#define	GRID_N		128		/* Ширина координатної сітки по кожній з осей */
#define OUTP_FILE	"outp.txt"	/* Ім'я файлу, куди виводиться результат */
#define FUNC_FILE	"func.txt"	/* Ім'я файлу, куди виводяться значення вхідної функції */
#define TIME_FILE	"time.txt"	/* Time measurement results file */
/* ************************************************************************ */


// TODO: In the “Project Properties” under “Configuration Properties”,
// select the “Debugging” node and switch the “Debugger to launch:”
// combobox value to “MPI Cluster Debugger”.
int main(int argc, char* argv[])
{
	MPI_Init(&argc, &argv);					/* Ініціалізуємо середовище */
	MPI_Comm_size(MPI_COMM_WORLD, &np);		/* Отримуємо розмір MPI_COMM_WORLD */
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);	/* Отримуємо ранг процеса у MPI_COMM_WORLD*/
	int nodes_width = (int) sqrt((double) np);	/* Отримуємо ширину матриці процесів */
	int node_X = rank % nodes_width;		/* Отримуємо горизонтальну координату процесу у матриці процесів */
	int node_Y = rank / nodes_width;		/* Отримуємо вертикальну кординату процесу у матриці процесів */
	printf("Rank %d\n", rank);

	/* Total process lifetime and idle time */
	double total_time = MPI_Wtime(), eval_time = 0, idle_time = 0;

	h = (GRID_MAX - GRID_MIN) / GRID_N;	/* Крок сітки дискретизації */
	if (rank == 0)
	{
		allcoords_X = matrix_alloc(GRID_N, GRID_N, 0.0);
		allcoords_Y = matrix_alloc(GRID_N, GRID_N, 0.0);
		for (int i = 0; i < GRID_N; i++)
			for (int j = 0; j < GRID_N; j++)
			{
				allcoords_X->data[i * GRID_N + j] = GRID_MIN + h * j;
				allcoords_Y->data[i * GRID_N + j] = GRID_MIN + h * i;
			}
		total_width = allcoords_X->rows;		/* Отримуємо ширину сітки дискретизації */
	}

	/* Розповсюджуємо ширину сітки дискретизації */
	MPI_Bcast(&total_width, 1, MPI_INT, 0, MPI_COMM_WORLD);
	
	/* Ширина частини матриці вузлів сітки дискретизації, що припадає на кожен процес */
	points_per_node = total_width / nodes_width;

	/* Створюємо тип, що відповідає частині матриці, яка буде передаватися */
	MPI_Type_vector(points_per_node, points_per_node, total_width, MPI_DOUBLE, &node_mat_t);
	
	MPI_Type_commit(&node_mat_t);	/* Реєструємо тип */
	coords_X = matrix_alloc(points_per_node, points_per_node, 0.0);
	coords_Y = matrix_alloc(points_per_node, points_per_node, 0.0);
	if (rank == 0)	/* Процесс 0 розсилає реальні координати сітки дискретизації*/
	{
		for (int i = 0; i < nodes_width; i++)
			for (int j = 0; j < nodes_width; j++)
				if (i != 0 || j != 0)
				{
	                MPI_Send(allcoords_X->data + i * total_width * points_per_node + j * points_per_node, 1, node_mat_t, i * nodes_width + j, 0, MPI_COMM_WORLD);
	                MPI_Send(allcoords_Y->data + i * total_width * points_per_node + j * points_per_node, 1, node_mat_t, i * nodes_width + j, 0, MPI_COMM_WORLD);
	            }

		for (int i = 0; i < points_per_node; i++)
			for (int j = 0; j < points_per_node; j++)
			{
	            coords_X->data[i * points_per_node + j] = allcoords_X->data[i * total_width + j];
	            coords_Y->data[i * points_per_node + j] = allcoords_Y->data[i * total_width + j];   
	        }
	}
	else	/* Інші процесси їх приймають */
	{
	    matrix* temp_X = matrix_alloc(total_width, points_per_node, 0);
	    matrix* temp_Y = matrix_alloc(total_width, points_per_node, 0);
	    MPI_Recv(temp_X->data, 1, node_mat_t, 0, 0, MPI_COMM_WORLD, &stat);
	    MPI_Recv(temp_Y->data, 1, node_mat_t, 0, 0, MPI_COMM_WORLD, &stat);
	    for (int i = 0; i < points_per_node; i++)
			for (int j = 0; j < points_per_node; j++)
			{
				coords_X->data[i * points_per_node + j] = temp_X->data[i * total_width + j];
				coords_Y->data[i * points_per_node + j] = temp_Y->data[i * total_width + j];
	        }
	}
	
	/* Ініціалізуємо умови локальної зупинки алгоритму */
	local_stop = (bool*) calloc(points_per_node * points_per_node, sizeof(bool));

	/* Ініціалізуємо і встановлюємо початкові значення внутрішнього діапазону */
	node_mat = matrix_alloc(points_per_node, points_per_node, 0);

	/* Встановлюємо початкові значення граничних вузлів сітки дискретизації */
	if (node_X == 0)
		for (int i = 0; i < points_per_node * points_per_node; i += points_per_node)
		{
			node_mat->data[i] = boundary(coords_X->data[i], coords_Y->data[i]);
			local_stop[i] = true;
	    }
	if (node_X == nodes_width - 1)
		for (int i = points_per_node - 1; i < points_per_node * points_per_node; i += points_per_node)
		{
			node_mat->data[i] = boundary(coords_X->data[i], coords_Y->data[i]);
			local_stop[i] = true;
		}
	if (node_Y == 0)
		for (int i = 0; i < points_per_node; i++)
		{
			node_mat->data[i] = boundary(coords_X->data[i], coords_Y->data[i]);
			local_stop[i] = true;
		}
	if (node_Y == nodes_width - 1)
		for (int i = (points_per_node - 1) * points_per_node; i < points_per_node * points_per_node; i++)
		{
			node_mat->data[i] = boundary(coords_X->data[i], coords_Y->data[i]);
			local_stop[i] = true;
		}
	
	/* Створимо масив значень функції в локальних вузлах сітки дискретизації*/
	f_xy = matrix_alloc(points_per_node, points_per_node, 0.0);
	for (int i = 0; i < points_per_node * points_per_node; i++)
		f_xy->data[i] = func(coords_X->data[i], coords_Y->data[i]);

	/* Виведення значень функції у файл */
	if (rank == 0)
		matrix_print(FUNC_FILE, f_xy);
	
	/* Визначимо типи для передач під час ітерацій*/
	/* Тип, що визначає стовпець матриці*/
	MPI_Type_vector(points_per_node, 1, points_per_node, MPI_DOUBLE, &mat_col);
	MPI_Type_commit(&mat_col);	/* Реєструємо тип */
	
	/* Стовпці, що процесс буде приймати з лівого та правого процессів під час ітерацій */	
	left_col = (double*) calloc(points_per_node, sizeof(double));
	right_col = (double*) calloc(points_per_node, sizeof(double));
	/* Рядки, що процесс буде приймати з верхнього та нижнього процессів під час ітерацій */
	top_row = (double*) calloc(points_per_node, sizeof(double));
	bot_row = (double*) calloc(points_per_node, sizeof(double));

	/* Лічильники ітерацій для кожної точки частини сітки дискретизації вузла */
	node_iter = (int*) calloc(points_per_node * points_per_node, sizeof(int));
	
	/* Початок ітерацій */
	do
	{
		eval_time -= MPI_Wtime();
		
		/* Виконуємо основні ітерації */
		for (int i = 0; i < points_per_node; i++)
			for (int j = 0; j < points_per_node; j++)
				evaluate(i * points_per_node + j);

		eval_time += MPI_Wtime();
		idle_time -= MPI_Wtime();

	    /* Обмін між процессами у сітці*/
	    if (node_X != 0)
			/* Приймемо стовпець з лівого процесу */
			MPI_Recv(left_col, points_per_node, MPI_DOUBLE, rank - 1, rank - 1, MPI_COMM_WORLD, &stat);
	    
	    if (node_X != nodes_width - 1)
		{
			/* Відішлемо стовпець до правого процесу */
			MPI_Send(node_mat->data + points_per_node - 1, 1, mat_col, rank + 1, rank, MPI_COMM_WORLD);

			/* Приймемо стовпець з правого процессу */
			MPI_Recv(right_col, points_per_node, MPI_DOUBLE, rank + 1, rank + 1, MPI_COMM_WORLD, &stat);
	    }
	        
	    if (node_X != 0)
			/* Відішлемо стовпець до лівого процесу */
			MPI_Send(node_mat->data, 1, mat_col, rank - 1, rank, MPI_COMM_WORLD);
	    
	    if (node_Y != 0)
			/* Приймемо строку з верхнього процесу */
			MPI_Recv(top_row, points_per_node, MPI_DOUBLE, rank - nodes_width, rank - nodes_width, MPI_COMM_WORLD, &stat);
	   
	    if (node_Y != nodes_width - 1)
		{
			/* Відішлемо строку до нижнього процесу */
			MPI_Send(node_mat->data + (points_per_node - 1) * points_per_node, points_per_node, MPI_DOUBLE, rank + nodes_width, rank, MPI_COMM_WORLD);
			/* Приймемо строку з нижнього процесу */
			MPI_Recv(bot_row, points_per_node, MPI_DOUBLE, rank + nodes_width, rank + nodes_width, MPI_COMM_WORLD, &stat);
	    }

	    if (node_Y != 0)
			/* Відішлемо строку до верхнього процесу */
			MPI_Send(node_mat->data, points_per_node, MPI_DOUBLE, rank - nodes_width, rank, MPI_COMM_WORLD);

		idle_time += MPI_Wtime();
				
	    /* Якщо усі вузли сітки дискретизації у процесі завершили обчислення - встановлюємо ознаку завершення обчислень у процесі*/
	    int node_stop = true;
	    for (int i = 0; i < points_per_node * points_per_node; i++)
			if (!local_stop[i])
			{
				node_stop = false;
				break;
			}

		idle_time -= MPI_Wtime();

	    /* Перевіряємо чи всі процеси закінчили обчислення */
		MPI_Allreduce(&node_stop, &global_stop, 1, MPI_INT, MPI_LAND, MPI_COMM_WORLD);

		idle_time += MPI_Wtime();
	}
	while(!global_stop);

	/* Збираємо результат із частин сітки дискретизації від усіх процесів у процесі 0*/
	if (rank != 0)
		MPI_Send(node_mat->data, points_per_node * points_per_node, MPI_DOUBLE, 0, rank, MPI_COMM_WORLD);
	else
	{
		/* Повна сітка дискретизації, що виводиться у процессі 0 */
		matrix* total_mat = matrix_alloc(total_width, total_width, 0.0);
		for (int i = 0; i < nodes_width; i++)
			for (int j = 0; j < nodes_width; j++)
				if (i != 0 || j != 0)
				{
					matrix* temp = matrix_alloc(points_per_node, points_per_node, 0.0);
					/* Приймаємо частини матриці сітки дискретизації з кожного процессу */
					MPI_Recv(temp->data, points_per_node * points_per_node, MPI_DOUBLE, i * nodes_width + j, i * nodes_width + j, MPI_COMM_WORLD, &stat);
					/* Та розташовуємо їх у повній матриці */
					for (int k = 0; k < points_per_node; k++)
						for (int l = 0; l < points_per_node; l++)
							total_mat->data[i * total_width * points_per_node + j * points_per_node + k * total_width + l] = temp->data[k * points_per_node + l];
				}

				for (int i = 0; i < points_per_node; i++)
					for (int j = 0; j < points_per_node; j++)
						total_mat->data[i * total_width + j] = node_mat->data[i * points_per_node + j];

				matrix_print(OUTP_FILE, total_mat);
	}

	/* Time measurements */
	total_time = MPI_Wtime() - total_time;
	double time[] = { total_time, eval_time, idle_time };
	double *all_time = (double*) malloc(np * 3 * sizeof(double));
	MPI_Gather(time, 3, MPI_DOUBLE, all_time, 3, MPI_DOUBLE, 0, MPI_COMM_WORLD);
	if (rank == 0)
	{
		FILE *f = fopen(TIME_FILE, "w");
		if (f == NULL)
			fatal_error("can't write time measurements to file ", 2);	
		for (int i = 0; i < np; i++)
			fprintf(f, "Process %d:\n total time:\t%f s\n eval time:\t%f s\n idle time:\t%f s\n\n", i, all_time[i * 3], all_time[i * 3 + 1], all_time[i * 3 + 2]);
		fclose(f);
	}

	MPI_Finalize();
	return 0;
}


/* ************************************************************************* */
/* Допоміжні функції */
double func(double X, double Y)
{
	return Y * Y - X * X;
}

double boundary(double X, double Y)
{
	return 0.0;
}

void inline evaluate(int index)
{
	if (local_stop[index])
		return;
	double left = index % node_mat->cols == 0 ? left_col[index / node_mat->cols] : node_mat->data[index - 1];
	double right = (index + 1) % node_mat->cols == 0 ? right_col[index / node_mat->cols] : node_mat->data[index + 1];
	double top = index / node_mat->cols == 0 ? top_row[index % node_mat->cols] : node_mat->data[index - node_mat->cols];
	double bottom = index / node_mat->cols == node_mat->rows - 1 ? bot_row[index % node_mat->cols] : node_mat->data[index + node_mat->cols];
	double old_node = node_mat->data[index];
	double LU = old_node - (left + right + top + bottom - 4 * old_node) / (h * h);
	node_mat->data[index] = old_node - OMEGA * h * h / 4 * (LU - f_xy->data[index]);
	if (abs(node_mat->data[index] - old_node) <= abs(node_mat->data[index] * EPSILON) || ++node_iter[index] > MAX_ITER)
		local_stop[index] = true;
}

void fatal_error(const char *message, int errorcode)
{
	printf("fatal error: code %d, %s\n", errorcode, message);
	fflush(stdout);
	MPI_Abort(MPI_COMM_WORLD, errorcode);
}

struct matrix *matrix_alloc(int rows, int cols, double initial)
{
	struct matrix *result = (matrix*) malloc(sizeof(struct matrix));
	result->rows = rows;
	result->cols = cols;
	result->data = (double*) malloc(sizeof(double) * rows * cols);
	
	for (int i = 0; i < rows; i++)
		for (int j = 0; j < cols; j++)
			result->data[i * cols + j] = initial;
	
	return result;
}

void matrix_print(const char *filename, struct matrix *mat)
{
	FILE *f = fopen(filename, "w");
	if (f == NULL)
		fatal_error("can't write to file", 2);
	
	for (int i = 0; i < mat->rows; i++)
	{
		for (int j = 0; j < mat->cols; j++)
			fprintf(f, "%f\t", mat->data[i * mat->cols + j]);
		fprintf(f, "\n");
	}
	fclose(f);	
}