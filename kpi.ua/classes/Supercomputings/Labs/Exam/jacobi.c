#include <mpi.h>

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#include "linalg.h"

/* Time measurement file */
#define TIME_FILE "time.txt"

/* Точність обчислення коренів */
const double epsilon = 0.001;

/* Функція обчислення наступного наближення ітераційного процесу Якобі */
void jacobi_iteration(
    int start_row,                     // Індекс першого рядка частини матриці,
                                       // яка отримується даною функцією, в 
                                       // головній матриці

    struct my_matrix *mat_A_part,      // Частина рядків матриці коефіціентів
    struct my_vector *b_part,          // Частина вектору вільних членів
    struct my_vector *vec_prev_x,      // Вектор попереднього наближення
    struct my_vector *vec_next_x_part, // Частина вектору наступного наближення
                                       // (встановлюється в функції)
    double *residue_norm_part)         // Значення норми на попередньому кроці
                                       // обчислень (встановлюється в функції)
{
  /* Акумулятор значення норми даної частини обчислень */
  double my_residue_norm_part = 0.0;

  /* Поелементне обчислення частини вектору наступного наближення */
  for(int i = 0; i < vec_next_x_part->size; i++)
  {
    double sum = 0.0;
    for(int j = 0; j < mat_A_part->cols; j++)
    {
      if(i + start_row != j)
      {
        sum += mat_A_part->data[i * mat_A_part->cols + j] * vec_prev_x->data[j];
      }
    }

    sum = b_part->data[i] - sum;

    vec_next_x_part->data[i] =
      sum / mat_A_part->data[i * mat_A_part->cols + i + start_row];

    /* Обчислення норми на попередньому кроці */
    sum = -sum + mat_A_part->data[i * mat_A_part->cols + i + start_row] *
                 vec_prev_x->data[i + start_row];
    my_residue_norm_part += sum * sum;
  }

  *residue_norm_part = my_residue_norm_part;
}

/* Основна функція */
int main(int argc, char *argv[])
{
  const char *input_file_MA = "MA.txt";
  const char *input_file_b = "b.txt";
  const char *output_file_x = "x.txt";

   /* Execution start time */
   clock_t start_clock;

  /* Ініціалізація MPI */
  MPI_Init(&argc, &argv);

  /* Отримання загальної кількості задач та рангу поточної задачі */
  int np, rank;
  MPI_Comm_size(MPI_COMM_WORLD, &np);
  MPI_Comm_rank(MPI_COMM_WORLD, &rank);
  
  /* Зчитування даних в задачі 0 */
  struct my_matrix *MA;
  struct my_vector *b;
  int N;
  if(rank == 0)
  {
    MA = read_matrix(input_file_MA);
    b = read_vector(input_file_b);

    if(MA->rows != MA->cols) {
      fatal_error("Matrix is not square!", 4);
    }
    if (MA->rows % np != 0)
	fatal_error("Matrix size must be a multiple number of processors!", 42);
    if(MA->rows != b->size) {
      fatal_error("Dimensions of matrix and vector don't match!", 5);
    }
    N = b->size;

    start_clock = clock();
  }

  /* Розсилка всім задачам розмірності матриць та векторів */
  MPI_Bcast(&N, 1, MPI_INT, 0, MPI_COMM_WORLD);
  /* Резервування пам'яті для зберігання вектора вільних членів */
  if(rank != 0)
  {
    b = vector_alloc(N, .0);
  }

  /* Обчислення частини векторів та матриць, яка буде зберігатися в кожній
   * задачі, вважаемо що N = k*np. Резервування пам'яті для зберігання частин
   * векторів та матриць в кожній задачі та встановлення їх початкових значень */
  int part = N / np;
  struct my_matrix *MAh = matrix_alloc(part, N, .0);
  struct my_vector *oldx = vector_alloc(N, .0);
  struct my_vector *newx = vector_alloc(part, .0);
  struct my_vector *b_part = vector_alloc(part, .0);

  /* Розбиття вихідної матриці MA та вектора вільних членів b на частини
   * по part рядків та по part елементів відповідно, а також розсилка частин
   * у всі задачі. */
  if(rank == 0) 
  {
    MPI_Scatter(MA->data, N*part, MPI_DOUBLE,
                MAh->data, N*part, MPI_DOUBLE,
                0, MPI_COMM_WORLD);
	/* Повернення пам'яті, виділеної для матриці МА системі. */
    free(MA);
	
	MPI_Scatter(b->data, part, MPI_DOUBLE,
				b_part->data, part, MPI_DOUBLE,
				0, MPI_COMM_WORLD);
  } 
  else 
  {
    MPI_Scatter(NULL, 0, MPI_DATATYPE_NULL,
                MAh->data, N*part, MPI_DOUBLE,
                0, MPI_COMM_WORLD);
	MPI_Scatter(NULL, 0, MPI_DATATYPE_NULL,
				b_part->data, part, MPI_DOUBLE,
				0, MPI_COMM_WORLD);
  }

  /* Обчислення норми вектору вільних членів в задачі 0 та розсилка її значення
   * у всі задачі */
  double b_norm = 0.0;
  if(rank == 0)
  {
    for(int i = 0; i < b->size; i++)
    {
      b_norm += b->data[i] * b->data[i];
    }
    b_norm = sqrt(b_norm);
	
	/* Повернення пам'яті, виділеної для вектора b системі */
	free(b);
  }
  MPI_Bcast(&b_norm, 1, MPI_DOUBLE, 0, MPI_COMM_WORLD);

  /* Значення критерію зупинки ітерації */
  double last_stop_criteria;
  /* Основний цикл ітерації Якобі */
  for(int i = 0; i < 1000; i++)
  {
    double residue_norm_part;
    double residue_norm;

    jacobi_iteration(rank * part, MAh, b_part, oldx, newx,
        &residue_norm_part);

    /* Обчислення сумарного значення нев'язки */
    MPI_Allreduce(&residue_norm_part, &residue_norm, 1,
        MPI_DOUBLE, MPI_SUM, MPI_COMM_WORLD);

    residue_norm = sqrt(residue_norm);

    /* Перевірка критерію зупинки ітерації.  Оскільки на кожному кроці
     * обчислюється значення норми на попередньому кроці, то результатом
     * обчислення є дані попереднього кроку */
    last_stop_criteria = residue_norm / b_norm;
    if(last_stop_criteria < epsilon)
    {
      break;
    }

    /* Збір значень поточного наближення вектору невідомих */
    MPI_Allgather(newx->data, part, MPI_DOUBLE,
        oldx->data, part, MPI_DOUBLE, MPI_COMM_WORLD);
  }

  /* Вивід результату */
  if(rank == 0) 
  {
    /* Time of computations in milliseconds */
    clock_t milliseconds = (clock() - start_clock) * 1000 / CLOCKS_PER_SEC;

    /* Create file */
    FILE *file = fopen(TIME_FILE, "w");
    if (file == NULL)
    {
	fatal_error("Unable to create time measurement file!", 666);
    }
    fprintf(file, "Execution time:\t%ld milliseconds\n", milliseconds);
    fclose(file);

    write_vector(output_file_x, oldx);
  }
  
  /* Повернення виділених ресурсів системі та фіналізація середовища MPI */
  free(MAh);
  free(oldx);
  free(newx);
  free(b_part);
  return MPI_Finalize();
}

