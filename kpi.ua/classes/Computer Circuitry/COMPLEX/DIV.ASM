macro mov reg1, reg2: {or reg1, z, reg2;}
macro inc reg: {add reg, 1;}

link l1:ct
accept r11: 06c4h\85f0h
accept r10: 03e0h\3a0h

\ Signum
{mov r1, r11;} \ R1 = result
{xor r1, r10;}
{and r1, 8000h;}

\ Power
{and r2, r11, 7F00h;}
{and r3, r10, 7F00h;}
{sub r2, r3, nz; load rn, flags;}
{cjp rn_c, CONTINUE;}
{mov r2, 0;}
CONTINUE

\ Mantisa
{mov r3, 0;} \ Z
{and r4, r11, 0ffh;} \ X
{and r5, r10, 0ffh;} \ Y
{xor r6, r5, 03ffh;} \ -Y-1
{inc r6;}        \ -Y

{add r4, r6;} \ R:=X-Y
{and nil, r4, 0200h; load rm, flags;}
{cjp not rm_z, CYCLE;}
{or r3, 1;} \ Z(i):=1

CYCLE
{push nz, 6;} \ Cycle for 7 iterations
{or sll, r4, r4;} \ R:=2R
{and nil, r4, 0200h; load rn, flags;}
{cjp rn_z, LSUB;} \ if (r4>=0) then SUB
{add r4, r5;} \ R:=R+Y
{cjp nz, BINDZ;}
LSUB
{add r4, r6;} \ R:=R-Y
BINDZ
{or sll, r3, r3;}
{and nil, r4, 0200h; load rn, flags;}
{cjp not rn_z, ENDCYCLE;}
{or r3, 1;}
ENDCYCLE
{rfct;}

\ Normalize
{cjp not rm_z, TOTAL;}
{add r2, 0100h;}

TOTAL
\ Total result
{and r2, 7f00h;}
{and r3, 00ffh;}
{or r1, r2;}
{or r1, r3;}
{mov r11, r1;}

{cjp nz, END;}
END{}
