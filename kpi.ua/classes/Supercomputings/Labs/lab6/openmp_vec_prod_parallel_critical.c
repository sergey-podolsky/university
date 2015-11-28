/* Увага!  Це -- приклад, як програмувати не треба! */
#include <stdio.h>
#include <omp.h>

const int N = 100;
const int P = 4;
int main()
{
  int x[N];
  int y[N];
  int a = 0;

  for(int i = 0; i < N; i++) /* Ініціалізація векторів */
  {
    x[i] = 1; y[i] = 1;
  }

#pragma omp parallel num_threads(P) default(none) shared(x, y, a)
  {
    int task_id = omp_get_thread_num();
    int H = N / P;
    int start_index = task_id * H;
    int end_index = start_index + H - 1;
    for(int i = start_index; i <= end_index; i++)
    {
#pragma omp critical
      a = a + x[i] * y[i];
    }
  }

  printf("x * y = %d\n", a);
  return 0;
}

