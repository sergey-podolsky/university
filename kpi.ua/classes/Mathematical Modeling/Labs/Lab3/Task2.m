clc

eq1 = 'Dx = 5 * y + 1';
eq2 = 'Dy = -10 * x';
cond1 = 'x(0) = 7';
cond2 = 'y(0) = 8';

[x y] = dsolve(eq1, eq2, cond1, cond2)