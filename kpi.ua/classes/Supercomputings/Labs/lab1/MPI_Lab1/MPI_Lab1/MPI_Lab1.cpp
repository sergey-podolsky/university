/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Parallel Arcsin evaluation using MPI								 *
 * Programming of computer networks Lab №1 (1st semester 2010)		 *
 *																	 *
 *		Author:														 *
 * Podolsky Sergey													 *
 * Group:	KV-64M													 *
 *																	 *
 * written:	21.10.2010												 *
 * remarks:	debugged with Visual Studio 2010. Tested on a cluster.	 *
 *																	 *
 *		Project definition:											 *
 * MPI_Lab1.cpp		The entry point for the console application		 *
 * stdafx.h			Include file for standard system include files	 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#include "stdafx.h"

#define EPSILON				1E-11		// Точність обчислення значення
#define VALUE_TAG			1			// Теґ показнику ступеня числа E
#define ELEMENT_NUMBER_TAG	2			// Теґ номера поточного елемента ряда
#define ELEMENT_TAG			3			// Теґ значення поточного елемента ряда
#define BREAK_TAG			4			// Теґ сигналу про завершення обчислень

#define input_file_name		"in.txt"	// Ім'я файла вхідних даних
#define output_file_name	"out.txt"	// Ім'я файла результату

/* Функція обчислення факторіалу */
double factorial(int value)
{
	/* Факторіал від'ємного числа не визначений */
	if (value < 0)
		return 0; // NAN

	/* 0! = 1 за визначенням */
	if (value == 0)
		return 1.;

	/* обчислення факторіалу N як добутку всіх натуральних чисел від 1 до N */
	double fact = 1.;
	for (int i = 2; i <= value; i++)
		fact *= i;
	return fact;
}

/* Функція обчислення елемента ряду за його номером в точці x
 * Для arcsin(x) елемент ряду дорівнює x^(2n+1) * (2n)! / (4^n * n!^2 * (2n+1)))
 */
double calc_series_element(int element_number, double x)
{
	return pow(x, 2 * element_number + 1) * factorial(2 * element_number) / (pow(4., element_number) * pow(factorial(element_number), 2) * (2 * element_number + 1));
}

int _tmain(int argc, char* argv[])
{
	/* Ініціалізація середовища MPI */
	MPI_Init(&argc, &argv);
	
	/* Отримання номеру даної задачі */
	int rank;
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	
	/* Отримання загальної кількості задач */
	int np;
	MPI_Comm_size(MPI_COMM_WORLD, &np);
	
	/* Значення х для обчислення arcsin(x) */
	double x;
	
	/* Введення х в задачу 0 з файлу */
	if (rank == 0)
	{
		FILE *input_file = fopen(input_file_name, "r");
		/* Аварійне завершення всіх задач, якщо не вдається відкрити вхідний файл */
		if (!input_file)
		{
			fprintf(stderr, "Can't open input file!\n\n");
			MPI_Abort(MPI_COMM_WORLD, 1);
			return 1;
		}
		/* Зчитування х з файлу */
		fscanf(input_file, "%lf", &x);
		fclose(input_file);
	}
	
	/* Розсилка х з задачі 0 всім іншим задачам */
	if (rank == 0)
	{
		/* Послідовна передача х кожній задачі 1..np */
		for (int i = 1; i < np; i++)
			MPI_Send(&x, 1, MPI_DOUBLE, i, VALUE_TAG, MPI_COMM_WORLD);
	}
	else
		/* Прийом х від задачі 0 */
		MPI_Recv(&x, 1, MPI_DOUBLE, 0, VALUE_TAG, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
	
	/* Номер останнього обчисленого елемента ряду */
	int last_element_number = 0;
	/* Сума елементів ряду */
	double sum = .0;
	
	/* Основний цикл ітерації */
	for (int step = 0; step < 1000; step++)
	{
		/* Номер елемента, що обчислюється на поточному кроці в даній задачі */
		int element_number;
		
		/* Пересилка з задачі 0 до всіх інших задач номерів елементів, які вони
		 * мають розрахувати на поточному кроці
		 */
		if (rank == 0)
		{
			element_number = last_element_number++;
			int current_element_number = last_element_number;
			for (int i = 1; i < np; i++)
			{
				MPI_Send(&current_element_number, 1, MPI_INT, i, ELEMENT_NUMBER_TAG, MPI_COMM_WORLD);
				current_element_number++;
			}
			last_element_number = current_element_number;
		}
		else
			MPI_Recv(&element_number, 1, MPI_INT, 0, ELEMENT_NUMBER_TAG, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		
		/* Обчислення поточного елемента ряду */
		double element = calc_series_element(element_number, x);
		
		/* Прапорець "ітерація завершена, так як досягнуто необхідну точність" */
		int need_break = false;
		
		/* Обчислення суми елементів ряду */
		if (rank == 0)
		{
			double current_element = element;
			/* Додавання до загальної суми елементу, обчисленого в задачі 0 */
			sum += current_element;
			
			/* Оскільки ряд для arcsin(x) є монотонно спадаючим, елементи ряду
			 * обчислюються задачами за зростанням рангу та прийом елементів ряду
			 * від задач ведеться за зростанням рангу, то якщо останній прийнятий
			 * елемент за модулем менше константи EPSILON, то і всі наступні елементи
			 * також менше цієї константи.  Після додавання такого елементу необхідна
			 * точність досягнута і можна завершувати ітерацію
			 */
			if (abs(current_element) < EPSILON)
				need_break = true;
			
			for (int i = 1; i < np; i++)
			{
				/* Прийом елемента від i-тої задачі, додавання його до загальної суми */
				MPI_Recv(&current_element, 1, MPI_DOUBLE, i, ELEMENT_TAG, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
				sum += current_element;
				
				/* Перевірка умови завершення ітерації (див. вище) */
				if (abs(current_element) < EPSILON)
				{
					need_break = true;
					break;
				}
			}
			
			/* Передача сигналу про необхідність завершення ітерації з задачі 0 всім
			 * іншим задачам */
			for (int i = 1; i < np; i++)
				MPI_Send(&need_break, 1, MPI_INT, i, BREAK_TAG, MPI_COMM_WORLD);
		}
		else
		{
			/* Передача обчисленого елементу ряда в задачу 0 */
			MPI_Send(&element, 1, MPI_DOUBLE, 0, ELEMENT_TAG, MPI_COMM_WORLD);
			
			/* Прийому від задачі 0 сигналу про необхідність завершення ітерації */
			MPI_Recv(&need_break, 1, MPI_INT, 0, BREAK_TAG, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		}
		
		/* Завершення ітерації, якщо досягнута необхідна точність */
		if (need_break)
			break;
	}
	
	/* Вивід результату в задачу 0 */
	if (rank == 0)
	{
		FILE *output_file = fopen(output_file_name, "w");
		/* Аварійне завершення, якщо не вдається відкрити файл результату */
		if (!output_file)
		{
			fprintf(stderr, "Can't open output file!\n\n");
			MPI_Abort(MPI_COMM_WORLD, 2);
			return 2;
		}
		fprintf(output_file, "%.15lf\n", sum);
	}
	
	/* Де-ініціалізація середовища MPI та вихід з програми */
	MPI_Finalize();
	return 0;
}
