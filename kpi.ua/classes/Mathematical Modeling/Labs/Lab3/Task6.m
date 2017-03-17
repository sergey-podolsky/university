clc
clear all

syms t T

% Source matrix A, vector f and initial conditions
A = sym([2 -4; 1 -2]);
f = [36 * T^2; 6 * T];
t0 = sym(0);
x0 = sym([0; 0]);

% Search solution
X = expm(A * t);
X = simple(X);
c = subs(X, t0) \ x0;
x = X * c + simple(int(expm(-A * (T - t)) * f, T, 0, t))

% Solve the same Cauchy problem using 'dsolve' to prove that the result
% obtained above is the same and is correct
[x1 x2] = dsolve('Dx1 = 2*x1-4*x2+36*t^2, Dx2 = x1-2*x2+6*t, x1(0)=0, x2(0)=0');
dsolve_solution = [x1; x2]
