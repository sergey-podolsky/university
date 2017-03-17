clc
% Original population function P(t)
p = @(t) 1 ./ 700 .* (49 .* exp(0.0375 .* (t - 1350)) + (t + 595).^2 - 75 .* (t - 350) .* 7.^3.5 + 273914997);

format

p(1800 : 50 : 1900)

% Malthus function
malthus = @(c, k, t) c .* exp(k .* t);

% options = optimset('Display', 'iter', 'MaxIter', 10000, 'MaxFunEvals',50000, 'TolFun', 2e-48, 'LargeScale' , 'off');
% options = optimset(options, 'TolX', 2e-48);
% fsolve( @(ck) p([1800 1900]) - malthus(ck(1), ck(2), [1800 1900]), [1.4e-22 0.035], options)

year1 = 1850;
year2 = 1900;
syms c k;
[c k] = solve(malthus(c, k, year1) - p(year1), malthus(c, k, year2) - p(year2));

% Verhulst finction
verhulst = @(P0, M, K, t) M .* P0 ./ (P0 + (M - P0) .* exp(-K .* M .* t));
% syms P0 M K;
% [P0 M K] = solve(verhulst(P0, M, K, 1800) - p(1800), verhulst(P0, M, K, 1850) - p(1850), verhulst(P0, M, K, 1900) - p(1900))
% fsolve(@(P0_M_K) verhulst(P0_M_K(1), P0_M_K(2), P0_M_K(3), 1800 : 50 : 1900), [10e-21, -10e8, -10e-11], options)

P0 = 2.34518e-21;
M = -3.63207e8;
K = -9.46393e-11;

t = (1800 : 10 : 2010)'

values_p = p(t)
values_malthus = double(malthus(c, k, t))
values_verhulst = verhulst(P0, M, K, t)

error = @(A, a) abs((A - a) ./ a);

error_malthus = error(values_p, values_malthus)
error_verhulst = error(values_p, values_verhulst)

norm_malthus = norm(error_malthus, 'fro')
norm_verhulst = norm(error_verhulst, 'fro')