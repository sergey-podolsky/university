clc
clear
close all

% Case 1
eq1 = 'Dx1 = -1/2 * x1';
eq2 = 'Dx2 = 1/2 * x1 - 1/5 * x2';
eq3 = 'Dx3 = 1/5 * x2 - 1/7 * x3';

cond1 = 'x1(0) = 3';
cond2 = 'x2(0) = 0';
cond3 = 'x3(0) = 0';

[x1, x2, x3] = dsolve(eq1, eq2, eq3, cond1, cond2, cond3)

limits = [0 40];
figure, hold on
title('Case 1')
fplot(inline(x1), limits, 'r')
fplot(inline(x2), limits, 'g')
fplot(inline(x3), limits, 'b')

% Case 2
eq1 = 'Dx1 = 10/35-1/2 * x1';
cond1 = 'x1(0) = 0';
[x1, x2, x3] = dsolve(eq1, eq2, eq3, cond1, cond2, cond3)
figure, hold on
title('Case 2')
fplot(inline(x1), limits, 'r')
fplot(inline(x2), limits, 'g')
fplot(inline(x3), limits, 'b')