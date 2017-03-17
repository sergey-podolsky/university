%-- 21.02.2011 13:17 --%
F0=262;
A=2;
phi = pi/4;
fSampling = 8000;
tSamp = 1 / fSampling;
tt=-0.005 : tSamp : 0.005;
xtt = A * sin(2*pi*F0*t+phi);
Xff=fft(xxt, 1024);
Xff=fft(xtt, 1024);
magXff=fftshift(abs(Xff));
phaseXff=fftshift(unwrap(angle(Xff)));
fAx = -fSamp/2 : fSamp / 1024 : (fSamp/2-fSamp/1024);
fAx = -fSamp/2 : fSamp / 1024 : (fSamp/2-fSampling/1024);
fAx = -fSampling/2 : fSampling / 1024 : (fSamp/2-fSampling/1024);
fAx = -fSampling/2 : fSampling / 1024 : (fSampling/2-fSampling/1024);
clc
fSampling = 4000;
tSampling = 1/fSampling;
t=0:tSampling:0.5;
fNote = [524 588 660 698 784 880 988 ];
Do = sin(2*pi*fNote(1)*t+2*pi*rand);
Re = sin(2*pi*fNote(2)*t+2*pi*rand);
Mi = sin(2*pi*fNote(3)*t+2*pi*rand);
Fa = sin(2*pi*fNote(4)*t+2*pi*rand);
So = sin(2*pi*fNote(5)*t+2*pi*rand);
La = sin(2*pi*fNote(6)*t+2*pi*rand);
Ti = sin(2*pi*fNote(7)*t+2*pi*rand);
noteSequence=[Do Re Mi Fa So La Ti];
soundsc(noteSequence, fSampling);
Do2=sin(2*pi*fNote(1)*2*t+2*pi*rand);
noteSequence2 = [Do Re Mi Fa So La Ti Do2];
octaveF = fft(noteSequence);
nFFT = length(octaveF);
nFFT
magOctave = abs(octaveF);
phaseOctave = unwrap(angle(octaveF));
fSpacing = fSampling / nFFT;
fAxis = -fSampling/2 : fSpacing : fSampling/2 - fSpacing;
magOctave=ffshift(magOctave);
num = [ 1 1.1 ];
den = [1 0 -0.1]
[h,t] = impz(num,den);
figure, stem(t,h);
load unknownFilter
y=filter(num, den, x);


%-- 04.04.2011 10:25 --%
fstop1=400;
fpass1=900;
fpass2=2500;
fstop2=3000;
Rs=60;
Rp=1;
fsamp1=22050;
FNyq=fsamp1/2;
ws(1)=fstop1/FNyq;
ws(2)=fstop2/FNyq;
ws(3)=fpass1/FNyq;
ws(4)=fpass2/FNyq;
wp(3)=fpass1/FNyq;
wp(4)=fpass2/FNyq;
[nB,WnB]=buttord(wp, ws, Rp, Rs)
ws(1)=fstop1/FNyq;
ws(2)=fstop2/FNyq;
[nB,WnB]=buttord(wp, ws, Rp, Rs)
[numB, denB]=butter(nB,WnB);
[nE, WpE]=ellipord(wp,ws,Rp,Rs);
[numE,denE]=ellip(nE,Rp,Rs,WpE);
fvtool(numB,denB,numE,denE)
[x,fs]=wavread('myRecord');
sundsc(x,fs)
y=filter(numE,denE,x); - робить згортку
soundsc(y,fs)
% [num,den]=butter(nb,Wn,'high');
% [bum,den]=ellip(nE,Rp,Rs,wp,'high');
% cheby1, cheby2 - фільри Чбишева


%-- 18.04.2011 10:32 --%
fpass1=2700;
fpass2=4300;
Rp=1;
Rs=60;
fSamp=22050;
fNyq=fSamp/2;
Wp(1)=fpass1/fNyq;
Wp(2)=fpass2/fNyq;
fOreder=127;
num=fir1(fOreder,Wp);
fvtool(num,1)
wintool
numBlack=fir1(fOreder,Wp,window_1);
fvtool(numBlack,1)
[x,fs]=wavread('C:/WELCOME.WAV');
soundsc(x,fs)
y=filter(numBlack,1,x);
soundsc(y,fs)
fvtool(numK,1)
yK=filter(numK,1,x);
soundsc(yK,fs)


%-- 28.04.2011 8:54 --%
imgRGB = imread('C:/penguins.jpg');
size(imgRGB)
imshow(imgRGB)
imshow(imgRGB(:,:,1))
imshow(imgRGB(:,:,2))
figure, imshow(imgRGB(:,:,2))
imshow(imgRGB(:,:,1))
img=rgb2gray(imgRGB);
figure, imshow(imgRGB(:,:,2))
imshow(img)
size(img)
imhist(img)
imwrite(img, 'C:/Users/Podolsky/Desktop/img.bmp')
imgYCbCr = rgb2ycbcr(imgRGB);
close all
size(imgYCbCr)
imshow(imgYCbCr);
test_fft1=fft2(im2double(imgRGB));
figure('Name','FFT')
imshow(log(1+abs(fftshift(test_fft1))),[])
imshow(log(1+abs(test_fft1)),[])
test_ifft2=ifft2(test_fft1);
imshow(test_ifft2)
clc
F0=20; F1=200; F2=2000; fSamp=8000; tSamp=1/fSamp; t=-0.005:tSamp:0.005;
S=sin(2*pi*F1*t) + sin(2*pi*F2*t)  ;
plot(S)
[cal,cd1]=dwt(S,'haar');
subplot(321), plot(S), title('Original signal');
subplot(322), plot(cal), title('cA for Haar');
subplot(323), plot(cd1), title('cD for Haar');
[ca,cd1]=dwt(S,'db4');
subplot(324), plot(cal), title('cD for Haar');
subplot(324), plot(cdl), title('cD for Haar');
subplot(324), plot(cd1), title('cD for Haar');
imshow(img)
img = imread('C:/Penguins.jpg');
[cA1,cH1,cV1,cD1]=dwt2(img,'haar');
figure,imshow(mat2gray(cA1)), figure, imshow(mat2gray(cH1)),figure, imshow(mat2gray(cV1));
wavemenu

% Однорівневе одновимірне дискретне вейвлет-перетворення
% Wavelet Families: Additional Discussion :: Advanced Concepts
% unctions -- By Category (Wavelet toolbox)