clc
clear
close all

eq1 = '750 * D2x1 = -3000 * x1 + 3000 * x2';
eq2 = '500 * D2x2 = 3000 * x1 - 6000 * x2 + 3000 * x3';
eq3 = '750 * D2x3 = 3000 * x2 - 3000 * x3';

cond1 = 'x1(0) = 0';
cond2 = 'x2(0) = 0';
cond3 = 'x3(0) = 0';

cond4 = 'Dx1(0) = 1';
cond5 = 'Dx2(0) = 0';
cond6 = 'Dx3(0) = 0';

[x1, x2, x3] = dsolve(eq1, eq2, eq3, cond1, cond2, cond3, cond4, cond5, cond6);

t1 = fsolve(inline(x2 - x1), 2);
t2 = fsolve(inline(x3 - x2), 2);

Dx1 = inline(diff(x1));
Dx2 = inline(diff(x2));
Dx3 = inline(diff(x3));

v1 = Dx1(t1)
v2 = Dx2(t2)
v3 = Dx3(t2)

750 * v1^2 + 500 * v2^2 + 750 * v3^2


limits = [0 2];
figure, hold on
title('x1(t), x2(t), x3(t)')
xlabel('t')
ylabel('X : v0')
fplot(inline(x1), limits, 'r')
fplot(inline(x2), limits, 'g')
fplot(inline(x3), limits, 'b')
hold off

limits = [0 t2];
figure, hold on
title('v1(t), v2(t), v3(t)')
xlabel('t')
ylabel('DX : v0')
fplot(Dx1, limits, 'r')
fplot(Dx2, limits, 'g')
fplot(Dx3, limits, 'b')
fplot(@(t) 0, limits, 'k')
line([t1 t1], [0 1], 'Color', 'k')
line([t2 t2], [0 1], 'Color', 'k')
hold off