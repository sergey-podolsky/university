clc
clear all

syms t

% Source matrix A and initial conditions
A = sym([13 4; 4 7]);
t0 = sym(17);
x0 = sym([11; 5]);

% Search solution
X = expm(A * t);
c = subs(X, t0) \ x0;
x = simple(X * c)

% Solve the same Cauchy problem using 'dsolve' to prove that the result
% obtained above is the same and is correct
[x1 x2] = dsolve('Dx1 = 13*x1+4*x2, Dx2 = 4*x1+7*x2, x1(17)=11, x2(17)=5');
dsolve_solution = simple([x1; x2])

