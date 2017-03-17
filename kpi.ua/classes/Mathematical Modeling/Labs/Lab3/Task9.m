clc
clear all

disp('Eigenvalues for (0;0):');
A = sym([5 0; 0 -2])
d = eig(A)

disp('Eigenvalues for (5;0):');
A = sym([5 -5; 0 3])
d = eig(A)

disp('Eigenvalues for (2;3):');
A = sym([-2 -2; 3 0])
d = eig(A)