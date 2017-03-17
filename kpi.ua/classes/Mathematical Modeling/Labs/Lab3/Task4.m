clc
clear all

[x y] = dsolve('7 * D2x = -6 * x + 5 * y, 4 * D2y = 5 * x - 12 * y')
pretty(x)
pretty(y)


x1 = @(t) 2 * cos(t / sqrt(2));
y1 = @(t)     cos(t / sqrt(2));

x2 = @(t) -2 * cos(t * sqrt(47/14));
y2 = @(t)  7 * cos(t * sqrt(47/14));

limits = [0 16];

figure, hold on
fplot(x1, limits, 'r');
fplot(y1, limits, 'b');
xlabel('t')
ylabel('x1(t), y1(t)')
hold off

figure, hold on
fplot(x2, limits, 'r');
fplot(y2, limits, 'b');
xlabel('t')
ylabel('x2(t), y2(t)')
hold off


