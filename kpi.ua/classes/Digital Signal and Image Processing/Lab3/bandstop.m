function Hd = bandstop( Fsamp, my_win )
%BANDSTOP Returns a discrete-time filter object.
%   Detailed explanation goes here

if nargin < 1       % If there is no input arguments
    Fsamp = 44100;  % Sampling Frequency
end

Fnyq = Fsamp / 2;   % Nyquist Frequency

Fpass = 700;        % Passband Frequency
Fstop = 7000;       % Stopband Frequency

Wn(1) = Fpass / Fnyq;   % Normalized passband frequency
Wn(2) = Fstop / Fnyq;   % Normalized stopband frequency

fOrder = length(my_win) - 1;   % Filter order

% Filter numerator coefficients
num = fir1(fOrder, Wn, 'stop', my_win);

Hd = dfilt.dffir(num);  % Create a dfilt object
end

