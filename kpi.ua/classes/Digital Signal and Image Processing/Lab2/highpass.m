function Hd = highpass( Fsamp )
%HIGHPASS Returns a discrete-time filter object.
%   Detailed explanation goes here

if nargin < 1       % If there is no input arguments
    Fsamp = 44100;  % Sampling Frequency
end
      
Fnyq = Fsamp / 2;   % Nyquist frequency

Fst = 15000;     % Stopband Frequency
Fp = 16000;      % Passband Frequency

Wp = Fp / Fnyq;     % Normalized passband frequency
Ws = Fst / Fnyq;	% Normalized stopband frequency

Rp = 1;         % Passband Ripple (dB)
Rs = 80;        % Stopband Attenuation (dB)

[n, Wp] = ellipord(Wp, Ws, Rp, Rs); % n - order; Ws - cutoff frequency
[z, p, k] = ellip(n, Rp, Rs, Wp, 'high');
[sos,g] = zp2sos(z, p, k);          % Convert to SOS form
Hd = dfilt.df2tsos(sos,g);          % Create a dfilt object

end

