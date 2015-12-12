macro mov reg1, reg2 : {or reg1, z, reg2;}
accept poh: 1Ah, 5Dh, 50h, 2Bh, 6Fh, 60h, 0ABh, 0FFh, 0D4h, 0CDh, 40h, 70h, 8Fh, 90h, 7Ch, 2Ah

link l1: z
link l3: nz

org 100h

{nxor r9, r8;}
{mov r10, r9;}   \ R10 := not(R9 xor R8)

{mov r11, r9;}
{sub sla, r11, r10, z;} \ R11 := 2(R9-R10-1)
{push nz, 3;}   \ set iteration count

{mov r12, r13;}
{sub sra, r12, z;}  \ R12 := (R13-1)/2

{cjs not l1, subroutine;} \ Condition Jump to Subroutine

{rfct;}    \ repeat cycle

{mov r7, r5;}
{nand r7, r6;}

{cjp nz, END;}  \ END


org 200h

subroutine
{mov r7, r5;}
{sub sla, r7, r1, z;} \ R7 :=  2(R5-R1-1)

{cjp l3, label;}  \ jump to label if LC3=1

{mov r8, r7;}
{add r8, z, nz;}  \ R8 := R7+1

label
{mov r6, r9;}
{sub sra, r6, z, nz;}  \ R6 := (R9-1)/2

{mov r5, r8;}
{add r5, r6;}  \ R5 := R8+R6

{crtn nz;}  \ return

END{}
