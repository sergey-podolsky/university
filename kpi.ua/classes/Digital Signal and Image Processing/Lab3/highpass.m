function Hd = highpass( Fsamp )
%HIGHPASS Returns a discrete-time filter object.
%   Detailed explanation goes here

if nargin < 1       % If there is no input arguments
    Fsamp = 44100;  % Sampling Frequency
end
      
Fnyq = Fsamp / 2;   % Nyquist frequency
Fp = 16000;         % Passband Frequency
Wn = Fp / Fnyq;     % Normalized passband frequency

fOrder = 128;   % Filter order

% Filter numerator coefficients
num = fir1(fOrder, Wn, 'high', hanning(fOrder + 1));

Hd = dfilt.dffir(num);  % Create a dfilt object
end

