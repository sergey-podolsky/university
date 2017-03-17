clc

% Source function

fun = @(x1, x2) (x1-7).^2 + (x2-3).^2 + 5.*sin(x1) - cos(x1);

% x1 bounds
a1 = -5;
b1 = 5;

% x2 bounds
a2 = -5;
b2 = 5;

% Count of nodes on grid per each dimension
nodes = 16;

% Create Mesh Grid
[X Y] = meshgrid(a1:(b1-a1)/nodes:b1, a2:(b2-a2)/nodes:b2);

Z = fun(X, Y);

% Plot countours (level lines)
[CMatr h] = contour(X, Y, Z);
clabel(CMatr, h)

% Plot surface
figure
surf(X, Y, Z)

% Supply a starting point and invoke an optimization routine
x0 = [0; 0];    % Starting guess at the solution
lb = [a1 a2];   % Lower bounds
ub = [b1 b2];   % Upper bounds
myfun = @(x) fun(x(1), x(2));
[xmin, fmin] = fmincon(myfun, x0, [], [], [], [], lb, ub)
[xmax, fmax] = fmincon(@(x) -myfun(x), x0, [], [], [], [], lb, ub);
% Print X of max
xmax
% Print function max value
fmax = - fmax
