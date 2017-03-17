function [xmax, ymax] = allmax (fun, a, b)
mirror = @(x) -fun(x);
[xmax ymax] = allmin(mirror, a, b);
ymax = -ymax;
