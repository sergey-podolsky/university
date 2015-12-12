macro mov reg1, reg2: {or reg1, z, reg2;}
macro inc reg1: {add reg1, 1;}

\ROZM
accept r0: 0bh
link l1 : ct
link l2 : rdm
link ewh : 16
link m : 7, 6, 5, 4, 3, 2, 1, 0, z, z, z, z
dw 0h : 100h
dw 100h: 0c530h \ CONV REGc
dw 101h: 0c540h \ CONV REGd
dw 102h: 06540h \ SQRT REGd
dw 103h: 08534h \ DIV REGc, REGd
dw 104h: 0FF00h \ END
dw 0bh: 0105h \ PSW
dw 03h: 14 \ REGc value
dw 04h: 49 \ REGd value
accept rdm_delay : 2 \ speed

\SUBROUT1
S1 {xor r1, r1; oey; ewh;}
{or nil, r1, z; oey; ewl;}
{xor r6, r6;}
P1 {cjp rdm, P1; r; or r6, bus_d, z;}
{or nil, r6, z; oey; ewl;}
{xor r4, r4;}
P2 {cjp rdm, P2; r; or r4, bus_d, z;}
{xor r2, r2;}
{or r2, r4, Z;}
{push nz, 7;}
{rfct; or sr.0, r2, r2, z;}
{xor r5, r5;} \ R5:=0
{or r5, r4;} \ R5:=command, R4:=command
{and r4, 000fh;} \ R4:=000 REGy
{and r5, 00f0h;} \ R5:=00 REGx 0
{push nz, 3;}
{rfct; or sr.0, r5, z;}
{or nil, r4, z; oey; ewl;} \ RgA:=0000 REGy
{xor r10, r10;}
P3{cjp rdm, P3; r; or r10, bus_d, z;} \ R10:=(REGy)
{or nil, r5, z; oey; ewl;} \ RgA:=0000 REGx
{xor r11, r11;}
P4{cjp rdm, P4; r; or r11, bus_d, z;} \ R11:=(REGx)
{jmap; or nil, r2, z; oey;} \ jump to operation microprogram

\SUBROUT2
S2 {or nil, r0, z; oey; ewl;} \ RgA:=(R0)
{xor r12, r12;}
P5{cjp rdm, p5; r; or r12, bus_d, z;} \ R12:=(PSW)
{cjp rn_v, D1;}
{and r12, 0fbffh;} \ set 0 to O
{cjp nz, J1;}
D1 {or r12, 0400h;} \ set 1 to O
J1 {cjp rn_c, D2;}
{and r12, 0fffeh;} \ set 0 to C
{cjp nz, J2;}
D2{or r12, 0001h;} \ set 1 to C
J2{cjp rn_n, D3;}
{and r12, 0feffh;} \ set 0 to S
{cjp nz, J3;}
D3{or r12, 0100h;} \ set 1 to S
J3 {load rm, flags; and nil, r15, 00ffh;}
{cjp rm_z, D4;}
{and r12, 0ffbfh;} \ set 0 to Z
{cjp nz, J4;}
D4{or r12, 0040h;} \ set 1 to Z
J4 {or nil, r0, z; oey; ewl;}
RR1{cjp rdm, RR1; w; or nil, r12, z; oey;}
{or nil, r5, z; oey; ewl;}
RR2{cjp rdm, RR2; w; or nil, r15, z; oey;}
{add r6, 1;} \ PC:=PC+1
{or nil, r1, z;oey;ewl;} \ RgA:=00000
RR3{cjp rdm, RR3; w; or nil, r6, z; oey;} \ write PC to memory
{cjp nz, S1;}

ORG 0c50h
MCCONV \ convert INT to REAL
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
\ Total result
{and r11, 8000h;}
{or r11, r7;}
{or r11, r8;}
{mov r15, r11;}
{cjp nz, S2;}

ORG 650h
MCSQRT \ Square root
\ Check if argument not negative (highest digit is not zero)
{and nil, r11, 0800h; load rn, flags;}
\ If negative then cansel operation
{cjp not rn_z, END;}
\ Power of number
{and r15, r11, 0FF00h;}
\ Maitisa (X register)
{and r2, r11, 00FFh;}
\ Power parity analisys
{and nil, r15, 0100h; load rn, flags;}
\ If not pair then shift mantisa and inc power
{cjp rn_z, end_parity;}
\ Inc power
{add r15, 0100h;}
\ Shift right mantisa
{or srl, r2, r2;}
end_parity
\ Shift right power
{or srl, r15, r15;}
\ Square root from mantisa
\ Initialize register D
{mov r9, 0300h;}
\ Initialize register Z
{mov r12, 0;}
\ Initialize counter
{mov r13, 0;}
\ Variable for each Z register bit binding
{mov r14, 0080h;}
\ Prepare cycle for 8 iterations
{push nz, 7;}
\ PX := L1PX
{or sll, r2, r2;}
\ PD := r15PD
{or srl, r9, 0400h;}
\ -2PZ
{xor r7, r12, 03FFh;}
{add sll, r7, 1;}
\ Pdelta := PX - 2PZ + PD
{mov r8, r2;}
{add r8, r7;}
{add r8, r9;}
\ Check signum
{and nil, r8, 0200h; load rn, flags;}
\ If signum bit is zero then PX := Pdelta; PZ(i) := 1
{cjp not rn_z, end_signum;}
\ PX := Pdelta
{mov r2, r8;}
\ PZ(i) := 1
{or r12, r14;}
end_signum
\ Shift right current bit
{or srl, r14, r14;}
\ Increase counter
{inc r13;}
\ Repeat cycle
{rfct;}
\ Total result
{and r15, 0FF00h;}
{or r15, r12;}
\ END operation
{cjp nz, S2;}

ORG 850h
MCDIV \ Division
\ Signum
{mov r15, r11;} \ R1 = result
{xor r15, r10;}
{and r15, 8000h;}
\ Power
{and r9, r11, 7F00h;}
{and r8, r10, 7F00h;}
{sub r9, r8, nz; load rn, flags;}
{cjp rn_c, CONTINUE;}
{mov r9, 0;}
CONTINUE
\ Mantisa
{mov r8, 0;} \ Z
{and r14, r11, 0ffh;} \ X
{and r12, r10, 0ffh;} \ Y
{xor r13, r12, 03ffh;} \ -Y-1
{inc r13;}        \ -Y
{add r14, r13;} \ R:=X-Y
{and nil, r14, 0200h; load rm, flags;}
{cjp not rm_z, CYCLE;}
{or r8, 1;} \ Z(i):=1
CYCLE
{push nz, 6;} \ Cycle for 7 iterations
{or sll, r14, r14;} \ R:=2R
{and nil, r14, 0200h; load rn, flags;}
{cjp rn_z, LSUB;} \ if (r14>=0) then SUB
{add r14, r12;} \ R:=R+Y
{cjp nz, BINDZ;}
LSUB
{add r14, r13;} \ R:=R-Y
BINDZ
{or sll, r8, r8;}
{and nil, r14, 0200h; load rn, flags;}
{cjp not rn_z, ENDCYCLE;}
{or r8, 1;}
ENDCYCLE
{rfct;}
\ Normalize
{cjp not rm_z, TOTAL;}
{add r9, 0100h;}
TOTAL
\ Total result
{and r9, 7f00h;}
{and r8, 00ffh;}
{or r15, r9;}
{or r15, r8;}
{cjp nz, S2;}

ORG 0FF0h
MCFINISH \ End
{cjp nz, END;}

END{}
