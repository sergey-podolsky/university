{1}  Program TEST0015;
{2}  Var
{3}   j:integer;
{4}   A:array [2..15] of byte;
{5}  Begin
{6}   j:=4;
{7}   A[2]:=1;
{8}   A[3]:=1;
{9}   repeat
{10     A[j]:=A[j-1]+A[j-2];}
	ASM
		MOV    DI,[J]
		MOV    AL,BYTE PTR A[DI-4]
		MOV    AH,BYTE PTR A[DI-3]
		ADD    AL,AH
		MOV    BYTE PTR A[DI-2],AL
{11     If A[j]>127}
		CMP    BYTE PTR A[DI-2],127
		JNA    @LABEL
{12     Then A[j]:=0;}
		MOV    BYTE PTR A[DI-2],0
{13     inc(j)}
	@LABEL:	INC	WORD PTR [J]
	END;
{14}  until j>15;
{15}  for j:=2 to 15 do
{16}     write(A[j]:4);
{17}  writeln
{18} end.
