clc

% Find explicit solution
y = Lab_1_7('cauchy');

% Find numerical solutions
solution23 = Lab_1_7(@ode23);
solution45 = Lab_1_7(@ode45);

X23 = solution23(:, 1);
Y23 = solution23(:, 2);

X45 = solution45(:, 1);
Y45 = solution45(:, 2);

% Plot
figure
% Plot function graph
fplot(y, [1, 2.5]);
hold on
grid on
% Title
title('y'' = 1 + x + y + x * y, y(1) = 7, x in [1, 2.5]')
% X label
xlabel('X');
% Y label
ylabel('Y');
% plot ode23 and ode45 points
plot(X23, Y23, 'X', X45, Y45,'o')
hold off


