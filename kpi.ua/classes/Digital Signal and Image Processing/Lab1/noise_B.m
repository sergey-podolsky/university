function [ result ] = noise_B( f )
%Signal_B Noise function
%   Generate noise function B according to variant 17 of Lab 1
    T = 1/f;
    t = 23 : T : 94;
    t1 = 23 : T : 67;
    t2 = 67+T : T : 94;
    result( 1 : length(t1) ) = 13-1.5*(randn(1, length(t1))-5*cos(t1-pi/5));
    result( length(t1)+1 : length(t1)+length(t2) ) = 1-1.0*(randn(1, length(t2))+11*sin(3*t2+pi/3));
    figure, plot(t, result);
    xlabel('t, sec');
    ylabel('B(t)')
    title('Noise A in Time Domain');
    grid on
end