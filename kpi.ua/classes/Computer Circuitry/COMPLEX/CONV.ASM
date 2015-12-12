macro mov reg1, reg2: {or reg1, z, reg2;}
macro inc reg: {add reg, 1;}

link l1:ct
accept r11: 0fffah

\ Convert to direct code
{and nil, r11, 8000h; load rn, flags;}
{cjp rn_z, ENDCONVPRM;}
{xor r11, 7fffh;}
{inc r11;}
ENDCONVPRM

\ Get power
{and r9, r11, 7fffh;} \ will shift source int in r9; Drop signum
{mov r8, 0;} \ r8 = power :=0
GETPOW
{or r9, r9; load rn, flags;}
{cjp rn_z, END_GETPOW;}
{or srl, r9, r9;}
{add r8, 0100h;}
{cjp nz, GETPOW;}
END_GETPOW

\ Get mantisa
{and r7, r11, 7fffh;} \ will shift source int in r7; Drop signum

SHIFTRIGHT
{and nil, r7, 0ff00h; load rn, flags;}
{cjp rn_z, SHIFTLEFT;}
{or srl, r7, r7;}
{cjp nz, SHIFTRIGHT;}


SHIFTLEFT
{and nil, r7, 0ff80h; load rn, flags;}
{cjp not rn_z, ENDSLL;}
{or sll, r7, r7;}
{cjp nz, SHIFTLEFT;}
ENDSLL

\ Total result in r6
{and r11, 8000h;}
{or r11, r7;}
{or r11, r8;}

{cjp nz, END;}
end{}
