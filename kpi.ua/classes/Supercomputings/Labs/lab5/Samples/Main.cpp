#include <mpi.h>
#include <math.h>
#include <stdio.h>
#include <stdarg.h>
#include <stdlib.h>

/* Опис типів,структур та функцій */

struct my_matrix /* Структура, що описує матриці */
{
  int rows; /* Кількість строк у матриці */
  int cols; /* Кількість стовпців у матриці */
  double *data; /* Ссилка на матрицю, розвернуту у одномірний масив*/
};

MPI_Datatype node_mat_t; /* Тип, що забеспечує розповсюдження частин сітки
                                     дискретизації по матриці процессів*/
MPI_Datatype mat_col; /* Тип, що забеспечує передачу стовпця матриці */
double func(double X,double Y);/* Повертає значення правої частини 
                                    диференційного рівняння у точці X,Y*/
void fatal_error(const char *message, int errorcode);/* Функція виведення 
                                                     помилок вводу-виводу */
struct my_matrix *matrix_alloc(int rows, int cols, double initial);/* Фунція, 
                     що забеспечує виділення пам'яті та ініціалізацію матриці*/
void matrix_print(const char *filename, struct my_matrix *mat);/* Фунція, що 
                                          забеспечує виведення матриці у файл*/
struct my_matrix *read_matrix(const char *filename);/* Функція, що забеспечує 
                                                  зчитування матриці із файлу*/


/* ************************************************************************ */
/* Опис змінних */
int np; /* Кількість процесів */
int rank; /* Ранг процесу у MPI_COMM_WORLD */
int nodes_width; /* Ширина матриці процессів */
int node_X; /* Координата Х у матриці процессів */
int node_Y; /* Координата У у матриці процессів */
int total_width; /* Ширина матриці вузлів сітки дискретизації*/
int points_per_node; /* Ширина частини матриці вузлів сітки дискретизації, 
                                                 що припадає на кожен процес*/
const char* inpfileX="inpX.csv"; /* Ім'я файлу з якого вводяться горизонтальні 
                                              координати сітки дискретизації */
const char* inpfileY="inpY.csv"; /* Ім'я файлу з якого вводяться вертикальні 
                                              координати сітки дискретизації */
const char* outpfile="outp.csv";/* Ім'я файлу куди виводиться результат */
my_matrix* allcoords_X;/* Матриця реальних горизонтальних координат вузлів 
                                                        сітки дискретизації */
my_matrix* allcoords_Y;/* Матриця реальних вертикальних координат вузлів сітки 
                                                               дискретизації */
my_matrix* total_mat;/* Повна сітка дисретизації, що виводиться у процессі 0*/
my_matrix* coords_X;/* Частина матриці реальних координат сітки дискретизації,
                                       яка зберігається у кожному з процессів*/
my_matrix* coords_Y;/* Частина матриці реальних координат сітки дискретизації,
                                       яка зберігається у кожному з процессів*/
my_matrix* node_mat;/* Частина сітки дискретизації, яка зберігається у кожному 
                                                                  з процессів*/
my_matrix* f_xy;/* Масив значень функції в узлах сітки дискретизації*/
MPI_Status stat;/* Змінна, у яку повертається статус прийому повідомленнь */
double epsilon=0.001;/* Точність рішення*/
double omega=0.4;/**/ 
double h;/* Крок сітки дискретизації */
bool* local_stop;/* Масив для запам'ятовування локальних умов зупинки */
bool node_stop;/* Ознака завершення обчислень у процесі*/
bool global_stop;/* Глобальна ознака завершення обчислень*/
double* left_col;/* Стовпці, що процесс буде приймати з лівого та правого 
                                                процессів під час ітерацій */
double* right_col;
double* top_row;/* Рядки, що процесс буде приймати з верхнього та нижнього 
                                                процессів під час ітерацій */
double* bot_row;
/* ************************************************************************ */

/* Головна программа */
int main(int argc, char *argv[])
{
    
    MPI_Init(&argc,&argv); /* Ініціалізуємо середовище */
    MPI_Comm_size(MPI_COMM_WORLD,&np); /* Отримуємо розмір MPI_COMM_WORLD */
    MPI_Comm_rank(MPI_COMM_WORLD,&rank); /* Отримуємо ранг процеса у MPI_COMM_WORLD*/
    nodes_width=sqrt(np); /* Отримуємо ширину матриці процесів*/
    node_X=rank%nodes_width; /* Отримуємо горизонтальну кординату процесу у матриці */
    node_Y=rank/nodes_width; /* Отримуємо вертикальну кординату процесу у матриці */
    printf("Rank %d",rank); 
     
    if (rank==0){
        //allcoords_X=matrix_alloc(1600,1600,1.3);
        //allcoords_X=matrix_alloc(1600,1600,1.4);
        allcoords_X=read_matrix(inpfileX);/* Вводимо координати */ 
        allcoords_Y=read_matrix(inpfileY);/* Вводимо координати */ 
        total_width=allcoords_X->rows; /* Отримуємо ширину сітки дискретизації */    
    }
    MPI_Bcast(&total_width,1,MPI_INT,0,MPI_COMM_WORLD); /* Розповсюджуємо ширину 
                                                            сітки дискретизації */
    h=1.0/total_width;/* Визначаємо крок сітки дискретизації */
    points_per_node=total_width/nodes_width;
    /* Створюємо тип, що відповідає частині матриці, яка буде передаватися */
    MPI_Type_vector(points_per_node,points_per_node,total_width,MPI_DOUBLE,&node_mat_t);
    
    MPI_Type_commit(&node_mat_t); /* Регіструємо тип */
    coords_X=matrix_alloc(points_per_node,points_per_node,0.0);
    coords_Y=matrix_alloc(points_per_node,points_per_node,0.0);
    if(rank==0){/* Процесс 0 розсилає реальні координати сітки дискретизації*/
        for(int i=0;i<nodes_width;i++){
            for(int j=0;j<nodes_width;j++){
                if(!(i==0&&j==0)){
                    MPI_Send(allcoords_X->data+i*total_width*points_per_node+j*points_per_node
                                                ,1,node_mat_t,i*nodes_width+j,0,MPI_COMM_WORLD);
                    MPI_Send(allcoords_Y->data+i*total_width*points_per_node+j*points_per_node
                                                ,1,node_mat_t,i*nodes_width+j,0,MPI_COMM_WORLD);
                }
             }
        }
        for(int i=0;i<points_per_node;i++){
            for(int j=0;j<points_per_node;j++){
                coords_X->data[i*points_per_node+j]=allcoords_X->data[i*total_width+j];
                coords_Y->data[i*points_per_node+j]=allcoords_Y->data[i*total_width+j];   
            }
        }
        
    }
    
    else{/* Інші процесси їх приймають */
        my_matrix* temp_X=matrix_alloc(total_width,points_per_node,0);
        my_matrix* temp_Y=matrix_alloc(total_width,points_per_node,0);
        MPI_Recv(temp_X->data,1,node_mat_t,0,0,MPI_COMM_WORLD,&stat);
        MPI_Recv(temp_Y->data,1,node_mat_t,0,0,MPI_COMM_WORLD,&stat);
        for(int i=0;i<points_per_node;i++){
            for(int j=0;j<points_per_node;j++){
                coords_X->data[i*points_per_node+j]=temp_X->data[i*total_width+j];
                coords_Y->data[i*points_per_node+j]=temp_Y->data[i*total_width+j];
            }
        }
    }


    /* Ініціалізуємо умови локальної зупинки алгоритму*/
    local_stop=(bool*)malloc(points_per_node*points_per_node*sizeof(bool));
    for(int i=0;i<points_per_node*points_per_node;i++){
        local_stop[i]=false;
    }

    
    /* Ініціалізуємо і встановлюємо початкові значення внутрішнього діапазону */
    node_mat=matrix_alloc(points_per_node,points_per_node,0);
    /* Встановлюємо початкові значення граничних вузлів сітки дискретизації */
    if(node_X==0){
        for(int i=0;i<points_per_node*points_per_node;i+=points_per_node){
            node_mat->data[i]=(1+3*M_PI)*sin(3*M_PI*(coords_X->data[i]+coords_Y->data[i]));
            local_stop[i]=true;
        }
    }
    if(node_X==nodes_width-1){
        for(int i=points_per_node-1;i<points_per_node*points_per_node;i+=points_per_node){
            node_mat->data[i]=(1+3*M_PI)*sin(3*M_PI*(coords_X->data[i]+coords_Y->data[i]));
            local_stop[i]=true;
        }
    }
    if(node_Y==0){
        for(int i=0;i<points_per_node;i++){
            node_mat->data[i]=(1+3*M_PI)*sin(3*M_PI*(coords_X->data[i]+coords_Y->data[i]));
            local_stop[i]=true;
        }
    }
    if(node_Y==nodes_width-1){
        for(int i=(points_per_node-1)*points_per_node;i<points_per_node*points_per_node;i++){
            node_mat->data[i]=(1+3*M_PI)*sin(3*M_PI*(coords_X->data[i]+coords_Y->data[i]));
            local_stop[i]=true;
        }
    }
    
    
    /* Створимо масив значень функції в локальних узлах сітки дискретизації*/
    f_xy=matrix_alloc(points_per_node,points_per_node,0.0);
    for(int i=0;i<points_per_node*points_per_node;i++){
        f_xy->data[i]=func(coords_X->data[i],coords_Y->data[i]);
    }
    
    
    /*Визначимо типи для передач під час ітерацій*/
    /* Тип, що визначає стовпець матриці*/
    MPI_Type_vector(points_per_node,1,points_per_node,MPI_DOUBLE,&mat_col);
    MPI_Type_commit(&mat_col);/* Регіструємо тип */
    
    left_col=(double*)malloc(points_per_node*points_per_node*sizeof(double));
    right_col=(double*)malloc(points_per_node*points_per_node*sizeof(double));
    top_row=(double*)malloc(points_per_node*points_per_node*sizeof(double));
    bot_row=(double*)malloc(points_per_node*points_per_node*sizeof(double));
    int max_iter=10000;
    int* node_iter=(int*)malloc(points_per_node*points_per_node*sizeof(int));
    for(int i=0;i<points_per_node*points_per_node;i++){
         node_iter[i]=0;
    }
    /* Початок ітерацій */
    
    do{
        for(int i=1;i<points_per_node-1;i++){/*Внутрішні точки*/
            for(int j=1;j<points_per_node-1;j++){
                if (!(local_stop[i*points_per_node+j])){
                    int old_node=node_mat->data[i*points_per_node+j];
                    double LU=old_node-(node_mat->data[i*points_per_node+j-1]
                    +node_mat->data[i*points_per_node+j+1]+
                    node_mat->data[(i-1)*points_per_node+j]+
                    node_mat->data[(i+1)*points_per_node+j]-4*old_node)/(h*h);
                    node_mat->data[i*points_per_node+j]=old_node-(omega*h*h/4)*
                    (LU-f_xy->data[i*points_per_node+j]);
                    node_iter[i]+=1;
                    if ((node_mat->data[i*points_per_node+j]-old_node||node_iter[i]>max_iter)
                    /node_mat->data[i*points_per_node+j]<epsilon){
                        local_stop[i*points_per_node+j]=true;
                    }
                }   
            }
        }
           
        /* Обмін між процессами у сітці*/
        if(node_X!=0){
            /* Приймемо стовпець з лівого процессу */
            MPI_Recv(left_col,1,mat_col,rank-1,rank-1,MPI_COMM_WORLD,&stat);
            
        }
        
        if(node_X!=nodes_width-1){
            /* Відішлемо стовпець до правого процессу */
            MPI_Send(node_mat->data+points_per_node-1,1,mat_col
                                    ,rank+1,rank,MPI_COMM_WORLD);
            /* Приймемо стовпець з правого процессу */
            MPI_Recv(right_col,1,mat_col,rank+1,rank+1,MPI_COMM_WORLD,&stat);
        }
            
        if(node_X!=0){
            /* Відішлемо стовпець до лівого процессу */
            MPI_Send(node_mat->data,1,mat_col,rank-1,rank,MPI_COMM_WORLD);
        }
        
        if(node_Y!=0){
            /* Приймемо строку з верхнього процессу */
             MPI_Recv(top_row,points_per_node,MPI_DOUBLE,rank-nodes_width
                                   ,rank-nodes_width,MPI_COMM_WORLD,&stat);
        }
       
        if(node_Y!=nodes_width-1){
            /* Відішлемо строку до нижнього процессу */
            MPI_Send(node_mat->data+(points_per_node-1)*points_per_node,points_per_node
                ,MPI_DOUBLE,rank+nodes_width,rank,MPI_COMM_WORLD);
            /* Приймемо строку з нижнього процессу */
            MPI_Recv(bot_row,points_per_node,MPI_DOUBLE,rank+nodes_width,
                                    rank+nodes_width,MPI_COMM_WORLD,&stat);
        }
        if(node_Y!=0){
            /* Відішлемо строку до верхнього процессу */
            MPI_Send(node_mat->data,points_per_node,MPI_DOUBLE,
                            rank-nodes_width,rank,MPI_COMM_WORLD);
        }
        
        
        /* Граничні точки процесса */
        if(!(node_X==0||node_Y==0)){/* Лівий верхній кут */
            if (!(local_stop[0])){
                int old_node=node_mat->data[0];
                double LU=old_node-(left_col[0]
               +top_row[0]+
               node_mat->data[points_per_node]+
               node_mat->data[1]-4*old_node)/(h*h);
               node_mat->data[0]=old_node-(omega*h*h/4)*(LU-f_xy->data[0]);
               node_iter[0]+=1;
               if ((node_mat->data[0]-old_node)/node_mat->data[0]<epsilon||node_iter[0]>max_iter){
                   local_stop[0]=true;
               }
            }   
        }
        
        if(!(node_X==nodes_width-1||node_Y==0)){/* Правий верхній кут */
            if (!(local_stop[points_per_node-1])){
                int old_node=node_mat->data[points_per_node-1];
                double LU=old_node-(right_col[0]
                +top_row[points_per_node-1]+
                node_mat->data[2*points_per_node-1]+
                node_mat->data[points_per_node-2]-4*old_node)/(h*h);
                node_mat->data[points_per_node-1]=old_node-(omega*h*h/4)
                *(LU-f_xy->data[points_per_node-1]);
                node_iter[points_per_node-1]+=1;
                if ((node_mat->data[points_per_node-1]-old_node)
                /node_mat->data[points_per_node-1]<epsilon||node_iter[points_per_node-1]>max_iter){
                    local_stop[points_per_node-1]=true;
                }
            }
        }
        
        if(!(node_X==0||node_Y==nodes_width-1)){/* Лівий нижній кут */
            if (!(local_stop[(points_per_node-1)*points_per_node])){
                int old_node=node_mat->data[(points_per_node-1)*points_per_node];
                double LU=old_node-(left_col[points_per_node*(points_per_node-1)]
                +bot_row[0]+
                node_mat->data[(points_per_node-1)*points_per_node+1]+
                node_mat->data[(points_per_node-2)*points_per_node]-4*old_node)/(h*h);
                node_mat->data[(points_per_node-1)*points_per_node]=old_node-
                (omega*h*h/4)*(LU-f_xy->data[(points_per_node-1)*points_per_node]);
                node_iter[(points_per_node-1)*points_per_node]+=1;
                if ((node_mat->data[(points_per_node-1)*points_per_node]-old_node)
                /node_mat->data[(points_per_node-1)*points_per_node]<epsilon||node_iter[(points_per_node-1)*points_per_node]>max_iter){
                    local_stop[(points_per_node-1)*points_per_node]=true;
                }
            }
        }
        
        if(!(node_X==nodes_width-1||node_Y==nodes_width-1)){/* Правий нижній кут */
            if (!(local_stop[points_per_node*points_per_node-1])){
                int old_node=node_mat->data[points_per_node*points_per_node-1];
                double LU=old_node-(right_col[points_per_node*(points_per_node-1)]
                +bot_row[points_per_node-1]+
                node_mat->data[points_per_node*points_per_node-2]+
                node_mat->data[(points_per_node-1)*points_per_node-1]-4*old_node)/(h*h);
                node_mat->data[points_per_node*points_per_node-1]=old_node-
                (omega*h*h/4)*(LU-f_xy->data[points_per_node*points_per_node-1]);
                node_iter[points_per_node*points_per_node-1]+=1;
                if ((node_mat->data[points_per_node*points_per_node-1]-old_node)
                /node_mat->data[points_per_node*points_per_node-1]<epsilon||node_iter[points_per_node*points_per_node-1]>max_iter){
                    local_stop[points_per_node*points_per_node-1]=true;
                }
            }
        }
        if(node_X!=0){/* Ліва сторона */
            for(int i=1;i<points_per_node-1;i++){
               if (!(local_stop[i*points_per_node])){
                    int old_node=node_mat->data[i*points_per_node];
                    double LU=old_node-(node_mat->data[i*points_per_node+1]
                    +node_mat->data[(i-1)*points_per_node]+
                    left_col[i]+
                    node_mat->data[(i+1)*points_per_node]-4*old_node)/(h*h);
                    node_mat->data[i*points_per_node]=old_node-
                    (omega*h*h/4)*(LU-f_xy->data[i*points_per_node]);
                    node_iter[i*points_per_node]+=1;
                    if ((node_mat->data[i*points_per_node]-old_node)
                    /node_mat->data[i*points_per_node]<epsilon||node_iter[i*points_per_node]>max_iter){
                        local_stop[i*points_per_node]=true;
                    }
                }
         
            }
        }
        if(node_X!=nodes_width-1){/* Права сторона */
            for(int i=1;i<points_per_node-1;i++){
                if (!(local_stop[(i+1)*points_per_node-1])){
                    int old_node=node_mat->data[(i+1)*points_per_node-1];
                    double LU=old_node-(node_mat->data[(i+2)*points_per_node-1]
                    +node_mat->data[(i)*points_per_node-1]+
                    right_col[i]+
                    node_mat->data[(i+1)*points_per_node-2]-4*old_node)/(h*h);
                    node_mat->data[i*points_per_node]=old_node-
                    (omega*h*h/4)*(LU-f_xy->data[(i+1)*points_per_node-1]);
                    node_iter[(i+1)*points_per_node-1]+=1;
                    if ((node_mat->data[(i+1)*points_per_node-1]-old_node)
                    /node_mat->data[(i+1)*points_per_node-1]<epsilon||node_iter[(i+1)*points_per_node-1]>max_iter){
                        local_stop[(i+1)*points_per_node-1]=true;
                    }
                }
            }
        }
        if(node_Y!=0){/* Верхня сторона */
            for(int i=1;i<points_per_node-1;i++){
                if (!(local_stop[i])){
                    int old_node=node_mat->data[i];
                    double LU=old_node-(node_mat->data[i-1]
                    +node_mat->data[i+1]+
                    top_row[i]+
                    node_mat->data[points_per_node+i]-4*old_node)/(h*h);
                    node_mat->data[i]=old_node-(omega*h*h/4)*(LU-f_xy->data[i]);
                    node_iter[i]+=1;
                    if ((node_mat->data[i]-old_node)/node_mat->data[i]<epsilon||node_iter[i]>max_iter){
                        local_stop[i]=true;
                    }
                }
            }
        }
        if(node_Y!=nodes_width-1){/* Нижня сторона */
             for(int i=1;i<points_per_node-1;i++){
                if (!(local_stop[(points_per_node-1)*points_per_node+i])){
                    int old_node=node_mat->data[(points_per_node-1)*points_per_node+i];
                    double LU=old_node-(node_mat->data[(points_per_node-1)*points_per_node+i-1]
                    +node_mat->data[(points_per_node-1)*points_per_node+i+1]+
                    bot_row[i]+
                    node_mat->data[(points_per_node-2)*points_per_node+i]-4*old_node)/(h*h);
                    node_mat->data[(points_per_node-1)*points_per_node+i]=old_node-
                    (omega*h*h/4)*(LU-f_xy->data[(points_per_node-1)*points_per_node+i]);
                    node_iter[(points_per_node-1)*points_per_node+i]+=1;
                    if ((node_mat->data[(points_per_node-1)*points_per_node+i]-old_node)
                    /node_mat->data[(points_per_node-1)*points_per_node+i]<epsilon||node_iter[(points_per_node-1)*points_per_node+i]>max_iter){
                        local_stop[(points_per_node-1)*points_per_node+i]=true;
                    }
                }
            }            
        }
        
        /*Якщо усі вузли сітки дискретизації у процесі завершили 
                    обчислення - встановлюємо ознаку завершення обчислень у процесі*/
        node_stop=true;
        for(int i=0;i<points_per_node*points_per_node;i++){
            if (!local_stop[i]){
                node_stop=false;
                break;
            }
        }
        global_stop=true;
        /*Перевіряємо чи всі процеси закінчили обчислення*/
        MPI_Reduce(&node_stop,&global_stop,1,MPI_SHORT,MPI_LAND,0,MPI_COMM_WORLD);
  
        /*Якщо всі - то посилаємо сигнал про завершення*/
        MPI_Bcast(&global_stop,1,MPI_BYTE,0,MPI_COMM_WORLD);
      
    } while(!global_stop);
    /* Збираємо результат */
    total_mat=matrix_alloc(total_width,total_width,0.0);
    if(rank==0){
        for(int i=0;i<nodes_width;i++){
            for(int j=0;j<nodes_width;j++){
                if(!(i==0&&j==0)){
                    my_matrix* temp=matrix_alloc(points_per_node,points_per_node,0.0);
                    /* Приймаємо частини матриці сітки дискретизації з кожного процессу */
                    MPI_Recv(temp->data,points_per_node*points_per_node,
                    MPI_DOUBLE,i*nodes_width+j,i*nodes_width+j,MPI_COMM_WORLD,&stat);
                    /* Та розташовуємо їх у повній матриці */
                    for(int k=0;k<points_per_node;k++){
                        for(int l=0;l<points_per_node;l++){ 
                            total_mat->data[i*total_width*points_per_node+
                            j*points_per_node+k*total_width+l]
                            =temp->data[k*points_per_node+l];
                        }
                    }
                }
             }
        }
       
        for(int i=0;i<points_per_node;i++){
            for(int j=0;j<points_per_node;j++){
                total_mat->data[i*total_width+j]=node_mat->data[i*points_per_node+j];
           }
        }
    }
    else{
        MPI_Send(node_mat->data,points_per_node*points_per_node
        ,MPI_DOUBLE,0,rank,MPI_COMM_WORLD);
    }    
    if (rank==0){
       matrix_print(outpfile,total_mat);;
    }
    
    MPI_Finalize();

}



/* ************************************************************************* */
/* Допоміжні функції */
double func(double X,double Y){
    return X*Y;
}
void fatal_error(const char *message, int errorcode)
{
  printf("fatal error: code %d, %s\n", errorcode, message);
  fflush(stdout);
  MPI_Abort(MPI_COMM_WORLD, errorcode);
}

struct my_matrix *matrix_alloc(int rows, int cols, double initial)
{
  struct my_matrix *result = (my_matrix*)malloc(sizeof(struct my_matrix));
  result->rows = rows;
  result->cols = cols;
  result->data = (double*)malloc(sizeof(double) * rows * cols);

  for(int i = 0; i < rows; i++)
  {
    for(int j = 0; j < cols; j++)
    {
      result->data[i * cols + j] = initial;
    }
  }

  return result;
}

void matrix_print(const char *filename, struct my_matrix *mat)
{
   
  FILE *f = fopen(filename, "w");
  if(f == NULL)
  {
    fatal_error("cant write to file", 2);
  }

  for(int i = 0; i < mat->rows; i++)
  {
    for(int j = 0; j < mat->cols; j++)
    {
      fprintf(f, "%lf ", mat->data[i * mat->cols + j]);
    }
    fprintf(f, "\n");
  }
  fclose(f);

}

struct my_matrix *read_matrix(const char *filename)
{
  FILE *mat_file = fopen(filename, "r");
  if(mat_file == NULL)
  {
    fatal_error("can't open matrix file", 1);
  }

  int rows;
  int cols;
  fscanf(mat_file, "%d %d", &rows, &cols);

  struct my_matrix *result = matrix_alloc(rows, cols, 0.0);
  for(int i = 0; i < rows; i++)
  {
    for(int j = 0; j < cols; j++)
    {
      fscanf(mat_file, "%lf", &result->data[i * cols + j]);
    }
  }

  fclose(mat_file);
  return result;
}

