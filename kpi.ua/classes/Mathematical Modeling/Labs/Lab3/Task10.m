clc
clear all

syms x y u v
system = [ 3 * x - 2 * x^2 - 1/5 * x * y; 3 * x * y - 2 * y ];
critical_points = solve(system);

for i = 1 : size(critical_points.x)
    if imag(critical_points.x(i)) ~= 0 || imag(critical_points.y(i)) ~= 0
        continue
    end
    
    syms u v
    
    x = u + critical_points.x(i);
    y = v + critical_points.y(i);
    
    changed = subs(system);
    J = jacobian(changed);
    u = sym(0);
    v = sym(0);
    linearized = subs(J);

    [eigenvectors, eigenvalues] = eig(linearized);
    % Return the main diagonal of eigenvalues matrix
    eigenvalues = diag(double(eigenvalues));
   
    fprintf('Stationary point (%s, %s) type:\t', char(critical_points.x(i)), char(critical_points.y(i)));
    
    % Determine stationary point type
    if real(eigenvalues) < 0
        fprintf('Asymptotically stable');
    elseif real(eigenvalues) == 0
        fprinf('Stable')
    else
        fprintf('Unstable')
    end
    
    if imag(eigenvalues) == 0
        if size(eigenvectors, 2) == 1
            fprintf(' improper node')
        elseif eigenvalues(1) == eigenvalues(2)
            fprintf(' proper node')
        elseif eigenvalues(1) * eigenvalues(2) < 0
            fprintf(' saddle point')
        else % distinct eigenvalues < 0
            printf(' improper node');
        end
    elseif real(eigenvalues) == 0
        fprintf(' center')
    else
        fprintf(' spiral point')
    end
    
    fprintf('\n')
end