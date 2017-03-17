clc
clear all

[x y] = dsolve('Dx = y, Dy = -x')

bound = 10;
[x y] = meshgrid(-bound:bound, -bound:bound);

dx = y;
dy = -x;
figure, quiver(x, y, dx, dy)
