#include <stdio.h>
#include <omp.h>

int main()
{
  int x = 42;

#pragma omp parallel if(x < 0) num_threads(100)
  printf("part 1\n");

#pragma omp parallel if(x > 0) num_threads(3)
  printf("part 2\n");

#pragma omp parallel num_threads(3)
  printf("part 3\n");

#pragma omp parallel
  printf("part 4\n");

  return 0;
}

