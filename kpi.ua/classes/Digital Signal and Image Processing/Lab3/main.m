%clear variables
clc
[x, Fsamp] = wavread('Boy is Fiction - The Bits In The Numbers');

%fdatool
f1 = lowpass(Fsamp);
f2 = highpass(Fsamp);
f3 = bandpass(Fsamp);
f4 = bandstop(Fsamp, my_win);

fvtool(f1, f2, f3, f4);

y1 = filter(f1, x);
y2 = filter(f2, x);
y3 = filter(f3, x);
y4 = filter(f4, x);

px = audioplayer(x, Fsamp);
py1 = audioplayer(y1, Fsamp);
py2 = audioplayer(y2, Fsamp);
py3 = audioplayer(y3, Fsamp);
py4 = audioplayer(y4, Fsamp);
