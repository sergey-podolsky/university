clc
close all

% A * x <= b
A = [
        228     -24     -84
        -230    116     -202
        -27     72      -111
        406     23      -252
        49      -62     -233
        1       0       0
        0       1       0
        0       0       1
        -1      0       0
        0       -1      0
        0       0       -1
    ];

b = [ 408 442 103 -94 -215 392 333 444 -119 -204 -4];

plotregion(-A, -b, [], [], 'r')
% Title
title('LP Primal Problem Region Polytope')
% X label
xlabel('X1');
% Y label
ylabel('X2');
% Z label
zlabel('X3');
%axis equal

% f(X) = c * x	->  min
c = [ 237 139 181 ];

% Minimize primal f
[xmin fprimalmin] = linprog(c, A, b)

% Maximize primal f
[xmax fprimalmax] = linprog(-c, A, b);
xmax
fprimalmax = -fprimalmax

% Minimize dual f
[ymin fdualmin] = linprog(b, -A', -c, [], [], zeros(11,1))

% Maximize dual f
options = optimset('largescale','off','simplex','on');
[ymax fdualmax] = linprog(-b, -A', -c, [], [], zeros(11,1), [], [], options);
ymax
fdualmax = -fdualmax
