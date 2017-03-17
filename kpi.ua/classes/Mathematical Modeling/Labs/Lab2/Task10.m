clc
close all

% Find explicit solution - might not solve 
 Ycauchy = Lab_2_3(3, 'cauchy')

% Find numerical solutions
solution23 = Lab_2_3(3, @ode23);
solution45 = Lab_2_3(3, @ode45);
solution113 = Lab_2_3(3, @ode113);

X23 = solution23(:, 1)
Y23 = solution23(:, 2)

X45 = solution45(:, 1)
Y45 = solution45(:, 2)

X113 = solution113(:, 1)
Y113 = solution113(:, 2)

% Plot
figure
hold on
grid on
% Title
title('¹ 3')
% X label
xlabel('X')
% Y label
ylabel('Y')

% plot ode23, ode45 and ode113 points
plot(X23, Y23, 'X', X45, Y45,'o', X113, Y113, '+');

hold off