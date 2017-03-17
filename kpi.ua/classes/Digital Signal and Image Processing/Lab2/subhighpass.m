function Hd = subhighpass( Fsamp )
%SUBHIGHPASS Returns a discrete-time filter object.

if nargin < 1       % If there is no input arguments
    Fsamp = 44100;  % Sampling Frequency
end

Fnyq = Fsamp / 2;   % Nyquist frequency

Fst1 = 7600;    % Stopband Frequency 1
Fp1 = 7700;     % Passband Frequency 1
Fp2 = 14900;    % Passband Frequency 2
Fst2 = 15000;   % Stopband Frequency 2

Wp = [ Fp1 Fp2 ] / Fnyq;    % Normalized passband frequencies
Ws = [ Fst1 Fst2 ] / Fnyq;  % Normalized stopband frequencies

Rp = 1;         % Passband Ripple (dB)
Rs = 80;        % Stopband Attenuation (dB)

[n, Ws] = cheb2ord(Wp, Ws, Rp, Rs); % n - order; Ws - cutoff frequencies

% Show that there is no 'cheby2' design method in any specification with N
% designmethods(fdesign.bandpass('Fst1,Fp1,Fp2,Fst2,Ast1,Ap,Ast2'))
% designmethods(fdesign.bandpass('N,F3dB1,F3dB2'))
% designmethods(fdesign.bandpass('N,Fc1,Fc2'))
% designmethods(fdesign.bandpass('N,Fc1,Fc2,Ast1,Ap,Ast2'))
% designmethods(fdesign.bandpass('N,Fp1,Fp2,Ap'))
% designmethods(fdesign.bandpass('N,Fp1,Fp2,Ast1,Ap,Ast2'))
% designmethods(fdesign.bandpass('N,Fst1,Fp1,Fp2,Fst2'))
% designmethods(fdesign.bandpass('N,Fst1,Fp1,Fp2,Fst2,Ap'))

n = 2 * round(n / 2);       % Nearest greater even integer
d = fdesign.bandpass('N,F3dB1,F3dB2', n, Ws(1), Ws(2));
%designmethods(d, 'full')
Hd = design(d); %Hd = design(d, 'cheby2');  % 'cheby2' is invalid method
