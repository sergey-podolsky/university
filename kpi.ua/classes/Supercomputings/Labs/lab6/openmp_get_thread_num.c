#include <stdio.h>
#include <omp.h>

int main()
{
#pragma omp parallel num_threads(3)
  {
    int task_id = omp_get_thread_num();
    if(task_id == 0)
    {
      printf("I am Master!\n");
    }
    else
    {
      printf("I am Slave number %d\n", task_id);
    }
  }

  return 0;
}

