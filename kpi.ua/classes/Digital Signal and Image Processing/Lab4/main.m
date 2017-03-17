function main( path )
%MAIN Summary of this function goes here
%   Detailed explanation goes here

clc

% 1.	Виконати перетворення довільного кольорового зображення з формату RGB в формат grayscale
imgRGB = imread(path);
img = rgb2gray(imgRGB);
figure, imshow(img), title('Original Black&White Image')

% 2.	Застосувати перетворення Фур’є до зображення у відтінках сірого кольору 
test_fft2=fft2(im2double(img));
figure, imshow(test_fft2), title('Furier Transform')
figure, imshow(log(1+abs(test_fft2)),[]), title('Logarithm of Furier Transform')
figure, imshow(log(1+abs(fftshift(test_fft2))),[]), title('Logarithm of Furier Transform with Shift')

% 3.	Виконати зворотне перетворення Фур’є та впевнитись в тому, що зображення повністю відновлено.
inverse = ifft2(test_fft2);
figure, imshow(inverse), title('Inverse Furier Transform')

% 4.	Виконати вейвлет-перетворення зображення у відтінках сірого кольору відповідно до варіанту
[cA1,cH1,cV1,cD1] = dwt2(img,'sym2');     % Symplets
[cA2,cH2,cV2,cD2] = dwt2(img,'coif1');    % Coiflets
[cA3,cH3,cV3,cD3] = dwt2(img,'haar');     % Haar

% Symplets
figure,
subplot(221), imshow(mat2gray(cA1)), title('Respectively')
subplot(222), imshow(mat2gray(cH1)), title('Horizontal')
subplot(223), imshow(mat2gray(cV1)), title('Vertical')
subplot(224), imshow(mat2gray(cD1)), title('Diagonal')

% Coiflets
figure,
subplot(221), imshow(mat2gray(cA2)), title('Respectively')
subplot(222), imshow(mat2gray(cH2)), title('Horizontal')
subplot(223), imshow(mat2gray(cV2)), title('Vertical')
subplot(224), imshow(mat2gray(cD2)), title('Diagonal')

% Haar
figure,
subplot(221), imshow(mat2gray(cA3)), title('Respectively')
subplot(222), imshow(mat2gray(cH3)), title('Horizontal')
subplot(223), imshow(mat2gray(cV3)), title('Vertical')
subplot(224), imshow(mat2gray(cD3)), title('Diagonal')

% 5.	Виконати зворотне вейвлет-перетворення та впевнитись в тому, що зображення повністю відновлено.
inverse1 = idwt2(cA1,cH1,cV1,cD1, 'sym2');
inverse2 = idwt2(cA2,cH2,cV2,cD2, 'coif1');
inverse3 = idwt2(cA3,cH3,cV3,cD3, 'haar');

figure,
subplot(131), imshow(mat2gray(inverse1)), title('Symplets inverse')
subplot(132), imshow(mat2gray(inverse2)), title('Coiflets inverse')
subplot(133), imshow(mat2gray(inverse3)), title('Haar inverse')

% 6.	Проаналізувати можливості застосування вейвлет-перетворення для аналізу сигналів та зображень,
% скориставшись можливостями Wavelet Toolbox Main Menu.
wavemenu
end

