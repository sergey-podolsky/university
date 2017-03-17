clc;

fun = @(x) x.^3 .* cos(x) - 2 .* x .* sin(x);
a = -10;
b = 10;

[xmin ymin] = allmin(fun, a, b)
[xmax ymax] = allmax(fun, a, b)

% Plot
figure
% Plot function graph
fplot(fun,[a b])
hold on
grid on
% plot minima points as red circles
plot(xmin, ymin, 'ro')
% plot maxima circles as black circles
maxima = plot(xmax, ymax, 'ro');
set(maxima, 'Color', 'black')