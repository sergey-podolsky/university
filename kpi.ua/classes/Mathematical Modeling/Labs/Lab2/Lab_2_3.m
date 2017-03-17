function solution = Lab_2_3( equation_number, solver )
%Lab_2_3 Solution of specified differential equation
%   Return two vectors of X and Y values or explicit solution function Y(X)
%   handle depending on argument. solver might be ode solver function
%   handle or string, e.g. @ode23 or @ode45 or 'cuchy' or other

if equation_number == 1
    equation = '7 * D2y - 2 * Dy = -3 * x^2 * cos(2 * x) - x^3';
    x0 = 5;
    y0 = [15 27];
elseif equation_number == 2
    equation = '2 * D3y + 5 * D2y = x * sin(x) - x^2';
    x0 = 3;
    y0 = [4.5 13.5 12.1];
elseif equation_number == 3
    equation = 'D3y - y = log(x)^sin(x)';
    x0 = 1;
    y0 = [ 1 2 3];
else
     error('MATLAB:Lab_2_3:InvalidArgument',...
      'Invalid equation_number value: 1 or 2 or 3 expected');
end

if ischar(solver)
    % Solve cauchy problem
    if strcmp('cauchy', solver)      
        initial = strcat('y(', num2str(x0), ') = ', num2str(y0(1)));
        for i = 2:length(y0)
            initial = strcat(initial, ', D', num2str(i-1), 'y(', num2str(x0), ') = ', num2str(y0(i)));
        end
        solution = inline(dsolve(equation, initial, 'x'));
    else
        % Find explicit solution
        solution = inline(dsolve(equation, 'x'));
    end
elseif isa(solver, 'function_handle')
    % Get numerical solution
    points_count = 21;
    if equation_number == 1
        x_max = 17;
        % y1 = y
        % y2 = y'
        % y1' = y2
        % y2' = (-3 * x^2 * cos(2 * x) - x^3 + 2 * y2) / 7
        odefun = @(x, y) [y(2); (-3 * x.^2 .* cos(2 * x) - x.^3 + 2 * y(2)) / 7];
    elseif equation_number == 2
        x_max = 19;
        % y1 = y
        % y2 = y'
        % y3 = y''
        % y1' = y2
        % y2' = y3
        % y3' = (x * sin(x) - x^2 - 5 * y3) / 2
        odefun = @(x, y) [y(2); y(3); (x .* sin(x) - x.^2 - 5 * y(3)) / 2];
    else
        x_max = 10;
        % y1 = y
        % y2 = y'
        % y3 = y''
        % y1' = y2
        % y2' = y3
        % y3' = ln(sin(ln(x)))/cos(x) + y1
        odefun = @(x, y) [y(2); y(3); log(x).^sin(x) + y(1)];
    end
    xspan = x0 : (x_max - x0) / (points_count - 1) : x_max;
    options = odeset('RelTol', 1.0e-3);
    [X Y] = solver(odefun, xspan, y0, options);
    solution = [X Y];
else
    error('MATLAB:Lab_7_1:InvalidArgumentType',...
      'Invalid argument type. ode23 or ode45 handle or string expected');
end

end