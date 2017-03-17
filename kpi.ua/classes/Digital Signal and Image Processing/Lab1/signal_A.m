function [ result ] = signal_A( f )
%Function_A Actual sigal function
%   Generate actual signal A according to variant 17 of Lab 1
    T = 1/f;
    t = 23 : T : 94;
    t1 = 23 : T : 67;
    t2 = 67+T : T : 94;
    d = min(t2):7:max(t2);
    result( 1 : length(t1) ) = 13-45*diric(0.3*pi*t1+pi/3, 9);
    result( length(t1)+1 : length(t1)+length(t2) ) = 1+45*pulstran(t2, d, 'tripuls');
    figure, plot(t, result);
    xlabel('t, sec');
    ylabel('A(t)')
    title('Signal A in Time Domain');
    grid on
end