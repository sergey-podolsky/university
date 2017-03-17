function [ result ] = xcorrcoef( x, y )
%UNTITLED2 Summary of this function goes here
%   Detailed explanation goes here

    result = xcorr(x, y) / (norm(x) * norm(y));
end

