clc
close all

% Handfound solution
c1 = -404.579;
c2 = 305.709;
Yhandfound = @(x) c1*exp(2/7*x)+c2+1/500000*(3*(2500*x.^2-34300*x-7277).*sin(2*x)+3*(17500*x.^2+7400*x-25039).*cos(2*x)+62500*x.*(x.^3+14*x.^2+147*x+1029));

% Find explicit solution
Ycauchy = Lab_2_3(1, 'cauchy');

% Find numerical solutions
solution23 = Lab_2_3(1, @ode23);
solution45 = Lab_2_3(1, @ode45);

X23 = solution23(:, 1)
Y23 = solution23(:, 2)

X45 = solution45(:, 1)
Y45 = solution45(:, 2)

% Plot
figure
hold on
grid on
% Title
title('¹ 1')
% X label
xlabel('X')
% Y label
ylabel('Y')

% Plot explicit solution
fplot(Ycauchy, [5 17], 'g');
% Plot handfound solution
fplot(Yhandfound, [5 17], '-.r');
% plot ode23 and ode45 points
plot(X23, Y23, 'X', X45, Y45,'o');

hold off