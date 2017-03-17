clc
close all

% Handfound solution
c1 = 19.5434;
c2 = 3836.032;
c3 = -55.4321;
Yhandfound = @(x) c1*x+c2*exp(-5/2*x)+c3-((25*x.^2-40*x+48)*x.^2)/1500-1/841*(145*x+74).*sin(x)+2/841*(29*x-165).*cos(x);

% Find explicit solution
Ycauchy = Lab_2_3(2, 'cauchy');

% Find numerical solutions
solution23 = Lab_2_3(2, @ode23);
solution45 = Lab_2_3(2, @ode45);

X23 = solution23(:, 1)
Y23 = solution23(:, 2)

X45 = solution45(:, 1)
Y45 = solution45(:, 2)

% Plot
figure
hold on
grid on
% Title
title('¹ 2')
% X label
xlabel('X')
% Y label
ylabel('Y')

% Plot explicit solution
fplot(Ycauchy, [3 19], 'g');
% Plot handfound solution
fplot(Yhandfound, [3 19], '-.r');
% plot ode23 and ode45 points
plot(X23, Y23, 'X', X45, Y45,'o');

hold off