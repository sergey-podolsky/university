@ECHO OFF
set /p p=Enter number of processes: 
@ECHO ON
mpiexec -n %p% ..\Debug\MPI_Lab4.exe
@ECHO OFF
PAUSE
