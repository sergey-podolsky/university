function solution = Lab_1_7( solver )
%Lab_1_7 Solution of differential equation dy/dx = 1 + x + y + x * y
%   Return two vectors of X and Y values or explicit solution function Y(X)
%   handle depending on argument. solver might be ode23 handle or ode45
%   handle or string, e.g. @ode23 or ode@45 or 'cuchy' or other string

x0 = 1;
y0 = 7;

if ischar(solver)
    equation = 'Dy = 1 + x + y + x * y';
    if strcmp('cauchy', solver)
        initial = strcat('y(', num2str(x0), ') = ', num2str(y0));
        solution = inline(dsolve(equation, initial, 'x'));
    else
        solution = inline(dsolve(equation, 'x'));
    end
elseif isa(solver, 'function_handle')
    points_count = 21;
    x_max = 2.5;
    xspan = x0 : (x_max - x0) / (points_count - 1) : x_max;
    odefun = @(x, y) 1 + x + y + x .* y;
    options = odeset('RelTol', 1.0e-3);
    [X Y] = solver(odefun, xspan, y0, options);
    solution = [X Y];
else
    error('MATLAB:Lab_7_1:InvalidArgumentType',...
      'Invalid argument type. ode23 or ode45 handle or string expected');
end

end

