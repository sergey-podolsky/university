f = 800;
A = signal_A(f);
B = noise_B(f);
C = conv(A, B);
t = 23+23 : 1/f : 94+94;
figure, plot(t, C);
xlabel('t, sec');
ylabel('Convolution(A, B)(t)');
title('Convolution in Time Domain');
grid on;

C = xcorrcoef(A, B);
t = 23-94 : 1/f : 94-23;
figure, plot(t, C);
xlabel('t, sec');
ylabel('Cross-correlation coefficient(A, B)(t)');
title('Cross-correlation Coefficient in Time Domain');
grid on;