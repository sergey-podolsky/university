clc

% Source function f(x, y, y') = 0
odefun = @(x, y, dy) dy .* y.^3 - y.^4 .* cos(x) + x * sin(dy);
x0 = 3;
x_max = 11;
y0 = 13;
points_count = 21;
% Get initial value of y' by solving equation
yp0 = fsolve(@(dy) odefun(x0, y0, dy), 0);
tspan = x0 : (x_max - x0) / (points_count - 1) : x_max;
% Compute consistent initial conditions for ode15i
[y0mod, yp0mod] = decic(odefun, x0, y0mod, [], yp0mod, []);
% Get numerical solution of source uquation
options = odeset('RelTol', 1.0e-3);
[X, Y] = ode15i(odefun, tspan, y0, yp0, options);

% Plot
figure
% plot points as blue (b) circles(o) - 'bo'
plot(X, Y, 'bo')
grid on
% Title
title('y''y^3 - y^4cos(x) + x sin(y'') = 0, y(3) = 13, x in [3, 11]')
% X label
xlabel('X');
% Y label
ylabel('Y');
