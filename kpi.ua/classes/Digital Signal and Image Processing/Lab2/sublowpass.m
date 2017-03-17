function Hd = sublowpass( Fsamp )
%SUBLOWPASS Returns a discrete-time filter object.

if nargin < 1       % If there is no input arguments
    Fsamp = 44100;  % Sampling Frequency
end

Fst1 = 600;     % Stopband Frequency 1
Fp1 = 700;      % Passband Frequency 1
Fp2 = 7000;     % Passband Frequency 2
Fst2 = 7100;    % Stopband Frequency 2

Ast1 = 80;      % Stopband Attenuation 1 (dB)
Ast2 = 80;      % Stopband Attenuation 2 (dB)
Ap = 1;         % Passband Ripple (dB)

d = fdesign.bandpass(Fst1, Fp1, Fp2, Fst2, Ast1, Ap, Ast2, Fsamp);
Hd = design(d, 'cheby1');
