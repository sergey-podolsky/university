#include <stdio.h>
#include <omp.h>

const int N = 100;
const int P = 4;
int main()
{
  int x[N];
  int y[N];
  int S[P];
  int a = 0;

  for(int i = 0; i < N; i++) /* Ініціалізація векторів */
  {
    x[i] = 1; y[i] = 1;
  }

#pragma omp parallel num_threads(P) default(none) shared(x, y, S)
  {
    int task_id = omp_get_thread_num();
    int H = N / P;
    int start_index = task_id * H;
    int end_index = start_index + H - 1;
    int my_S = 0; /* Змінна для накопичення часткової суми,
                     яку обчислює дана задача */
    for(int i = start_index; i <= end_index; i++)
    {
      my_S = my_S + x[i] * y[i];
    }
    S[task_id] = my_S; /* Запис результату */
  }

  /* Підсумовування часткових сумм */
  for(int i = 0; i < P; i++)
  {
    a = a + S[i];
  }

  printf("x * y = %d\n", a);
  return 0;
}

