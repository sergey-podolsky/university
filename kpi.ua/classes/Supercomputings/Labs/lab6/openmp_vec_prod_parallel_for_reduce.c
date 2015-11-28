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

#pragma omp parallel num_threads(P) default(none) shared(x, y) reduction(+:a)
#pragma omp for schedule(static)
  for(int i = 0; i < N; i++)
  {
    a = a + x[i] * y[i];
  }

  printf("x * y = %d\n", a);
  return 0;
}

