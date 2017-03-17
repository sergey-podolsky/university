clc

f = @(d, P0, t0, k) (d + k * P0^2) / (k * P0 + d / P0 * exp(-(d + k * P0^2) / P0 * t0) );

d = 1e3;
P0 = 1e5;
t0 = 1;

options = optimset('Display','iter', 'MaxIter', 10000, 'MaxFunEvals',50000, 'TolFun', 1e-26, 'LargeScale' , 'off');
fsolve( @(k) f(d, P0, t0, k), 0, options)