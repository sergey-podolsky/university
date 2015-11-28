/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Parallel Arcsin evaluation using MPI								 *
 * Programming of computer networks Lab №2 (1st semester 2010)		 *
 *																	 *
 *		Author:														 *
 * Podolsky Sergey													 *
 * Group:	KV-64M													 *
 *																	 *
 * written:	17.11.2010												 *
 * remarks:	debugged with Visual Studio 2010. Tested on a cluster.	 *
 *																	 *
 *		Project definition:											 *
 * MPI_Lab1.cpp		The entry point for the console application		 *
 * stdafx.h			Include file for standard system include files	 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#include "stdafx.h"

#define input_filename	"input.txt"
#define output_filename	"output.txt"

/* Обчислення функції */
double function(double x)
{
	return pow(x, 3) * cos(x);
}

/* Інтегрування методом трапецій */
double integrate_composite_trapezium_rule(double start, double finish, double epsilon)
{
	int iteration_count = (int)(1 / sqrt(epsilon));	/* Початкова кількість ітерацій */
	double previous_result, next_result = 0;
	do
	{
		previous_result = next_result;
		next_result = (function(start) + function(finish)) / 2;
		double delta_x = (finish - start) / iteration_count;
		for (int i = 1; i < iteration_count; i++)
			next_result += function(start + i * delta_x);
		next_result *= delta_x;
		iteration_count *= 2;
	}
	while (abs(next_result - previous_result) / 3 > epsilon);
	return next_result;
}

int main(int argc, char* argv[])
{
	int np;
	int rank;
	
	/* Ініціалізація MPI */
	MPI_Init(&argc,&argv);
	
	/* Отримати кількість процесів */
	MPI_Comm_size(MPI_COMM_WORLD, &np);
	
	/* Отримати індивідуальний ідентифікатор процесу */
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	
	/* Введення даних з файлу в масив з трьох змінних.
	 * Відбувається у процесі з рангом 0.
	 * 1 - нижня межа інтегрування
	 * 2 - верхня межа інтегрування
	 * 3 - допустима похибка */
	double input[3];
	if (rank == 0)
	{
		/* Відкриття вхідного файлу у режимі лише для читання */
		FILE *file;
		/* Перевірка правильності відкриття файлу */
		if (fopen_s(&file, input_filename, "r") != 0)
		{
			printf("Failed to open the file");
			/* Завершення усіх процесів, що включені в комунікатор MPI_COMM_WORLD */
			MPI_Abort(MPI_COMM_WORLD, 1);
		}
		/* Зчитування 3 чисел типу double */
		for (int i = 0; i < 3; i++)
			fscanf_s(file, "%lg", &input[i]);
		/* Закриття файлу */
		fclose(file);
	}
	/* Передача введених даних від процесу з рангом 0 до всіх інших процесів,
	 * що включені у комунікатор MPI_COMM_WORLD */
	MPI_Bcast(input, 3, MPI_DOUBLE, 0, MPI_COMM_WORLD);
	double start = input[0];
	double finish = input[1];
	double epsilon = input[2];
	double step = (finish - start) / np;
	double result_part = integrate_composite_trapezium_rule(start + rank * step, start + (rank + 1) * step, epsilon / np);
	double total_result;
	/* Передача проміжного результату інтегрування від усіх процесів до процесу з рангом 0
	 * та збереження суми проміжних результатів у змінній result */
	MPI_Reduce(&result_part, &total_result, 1, MPI_DOUBLE, MPI_SUM, 0, MPI_COMM_WORLD);
	
	/* Виведення процесом 0 результату роботи програми у вихідний файл */
	if (rank == 0)
	{
		/* Відкриття файлу на запис */
		FILE *file;
		/* Перевірка правильності відкриття файлу */
		if (fopen_s(&file, output_filename, "w") != 0)
		{
			printf("Failed to open the file");
			/* Завершення усіх процесів, що включені в комунікатор MPI_COMM_WORLD */
			MPI_Abort(MPI_COMM_WORLD, 1);
		}
		/* Запис 1 числа типу double в файл */
		fprintf_s(file, "%f\n", total_result);
		/* Закриття файлу */
		fclose(file);
	}
	
	/* Закінчити роботу з MPI */
	MPI_Finalize();
	return 0;
}