macro mov reg1, reg2: {or reg1, z, reg2;}
macro inc reg1: {add reg1, 1;}

link l1: ct

\ Source floating point number
accept r0: 05C8h

\ Check if argument not negative (highest digit is not zero)
{and nil, r0, 0800h; load rn, flags;}
\ If negative then cansel operation
{cjp not rn_z, END;}

\ Power of number
{and r1, r0, 0FF00h;}

\ Maitisa (X register)
{and r2, r0, 00FFh;}

\ Power parity analisys
{and nil, r1, 0100h; load rn, flags;}

\ If not pair then shift mantisa and inc power
{cjp rn_z, end_parity;}

\ Inc power
{add r1, 0100h;}

\ Shift right mantisa
{or srl, r2, r2;}

end_parity

\ Shift right power
{or srl, r1, r1;}

\ Square root from mantisa
\ Initialize register D
accept r3: 0300h
\ Initialize register Z
accept r4: 0
\ Initialize counter
accept r5: 0
\ Variable for each Z register bit binding
accept r6: 0080h


\ Prepare cycle for 8 iterations
{push nz, 7;}

\ PX := L1PX
{or sll, r2, r2;}

\ PD := R1PD
{or srl, r3, 0400h;}

\ -2PZ
{xor r7, r4, 03FFh;}
{add sll, r7, 1;}

\ Pdelta := PX - 2PZ + PD
{mov r8, r2;}
{add r8, r7;}
{add r8, r3;}

\ Check signum
{and nil, r8, 0200h; load rn, flags;}

\ If signum bit is zero then PX := Pdelta; PZ(i) := 1
{cjp not rn_z, end_signum;}

\ PX := Pdelta
{mov r2, r8;}

\ PZ(i) := 1
{or r4, r6;}

end_signum

\ Shift right current bit
{or srl, r6, r6;}

\ Increase counter
{inc r5;}

\ Repeat cycle
{rfct;}

\ Total result
{and r1, 0FF00h;}
{or r1, r4;}


{cjp nz, END;}
END {}
