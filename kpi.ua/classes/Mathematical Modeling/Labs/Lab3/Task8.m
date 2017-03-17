clc
clear all

syms x y
eq1 = 3 * x - 2 * y - x^2 - y^2;
eq2 = 2 * x - y - 3 * x * y;
 
[x y] = solve([eq1; eq2]);
 
realsolutions = imag(x) == 0 & imag(y) == 0;
x(realsolutions)
y(realsolutions)
