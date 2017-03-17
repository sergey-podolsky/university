clc

odefun = @(t, xy) [5 * xy(2) + 1; -10 * xy(1)];

t0 = 0;
x0 = 7;
y0 = 8;

points_count = 21;
tmax = 1;
solver = @ode113;

tspan = t0 : (tmax - t0) / (points_count - 1) : tmax;
options = odeset('RelTol', 1.0e-3);
[T XY] = solver(odefun, tspan, [x0 y0], options)
