clc
clear all
echo off

syms fii fjj fkk fij fji fik fki fjk fkj dii djj dkk dij dji dik dki djk dkj


Rij = ...
	(dik - djk) * (fik - fjk) +	... % Missed g = k in delta ij
	(dki - dkj) * (fki - fkj) + ... % Missed g = k in delta ij
	(dii - djj) * (fii - fjj) +	... % Loopback
	(dij - dji) * (fij - fji);      % Reverse flows direction

Rik = ...
	(dij - dkj) * (fki - fji) +	... % Missed g = j in delta ik
	(dji - djk) * (fik - fij) + ... % Missed g = j in delta ik
	(dii - dkk) * (fkk - fjj) +	... % Loopback
	(dki - dik) * (fjk - fkj);      % Reverse flows direction

Rjk = ...
	(dki - dji) * (fij - fkj) +	... % Missed g = i in delta jk
	(dik - dij) * (fji - fjk) + ... % Missed g = i in delta jk
	(djj - dkk) * (fkk - fii) +	... % Loopback
	(dkj - djk) * (fik - fki);      % Reverse flows direction

R_ik = ...
	(dij - dkj) * (fkj - fij) + ... % Missed g = j in delta* ik
	(dji - djk) * (fjk - fji) + ... % Missed g = j in delta* ik
	(dii - dkk) * (fkk - fii) + ... % Loopback
	(dik - dki) * (fki - fik);      % Reverse flows direction

R_jk = ...
	(dji - dki) * (fki - fji) +	... % Missed g = i in delta* jk
	(dij - dik) * (fik - fij) + ... % Missed g = i in delta* jk
	(djj - dkk) * (fkk - fjj) +	... % Loopback
	(djk - dkj) * (fkj - fjk);      % Reverse flows direction
 

x = - Rik - Rjk + Rij + R_ik + R_jk;

simplify(x)


