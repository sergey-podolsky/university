clc
clear
close all

eq1 = '70 * D2x1 = -2.5 * x1 + 2.5 * x2';
eq2 = '59 * D2x2 = 2.5 * x1 - 5 * x2 + 2.5 * x3';
eq3 = '70 * D2x3 = 2.5 * x2 - 2.5 * x3';

cond1 = 'x1(0) = 0';
cond2 = 'x2(0) = 0';
cond3 = 'x3(0) = 0';

cond4 = 'Dx1(0) = 1';
cond5 = 'Dx2(0) = 0';
cond6 = 'Dx3(0) = 0';

[x1, x2, x3] = dsolve(eq1, eq2, eq3, cond1, cond2, cond3, cond4, cond5, cond6)

% Disconnection time moments
t1 = fsolve(inline(x2 - x1), 13)
t2 = fsolve(inline(x3 - x2), 13)

% Velocities functions
Dx1 = inline(diff(x1));
Dx2 = inline(diff(x2));
Dx3 = inline(diff(x3));

% Instantaneous velocities after disconnections
v1 = Dx1(t1)
v2 = Dx2(t2)
v3 = Dx3(t2)

% Total kinetic energy before collision assuming v0 = 1 m/s
E1 = 70 * 1^2 / 2;
% Total kinetic energy after collision
E2 = 70 * v1^2 / 2 + 59 * v2^2 / 2 + 70 * v3^2 / 2;
% Difference in kinetic energies. Must be equal to zero
DeltaE = E1 - E2

% Plot X
limits = [0 18];
figure, hold on
title('x1(t), x2(t), x3(t)')
xlabel('t')
ylabel('X : v0')
fplot(inline(x1), limits, 'r')
fplot(inline(x2), limits, 'g')
fplot(inline(x3), limits, 'b')
hold off

% Plot velocities
limits = [0 t2 + 1];
figure, hold on
title('v1(t), v2(t), v3(t)')
xlabel('t')
ylabel('dx/dt : v0')
fplot(Dx1, limits, 'r')
fplot(Dx2, limits, 'g')
fplot(Dx3, limits, 'b')
fplot(@(t) 0, limits, 'k')
line([t1 t1], [0 1], 'Color', 'k')
line([t2 t2], [0 1], 'Color', 'k')
hold off