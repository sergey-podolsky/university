Program lab4;
uses    crt;
const   len = 30;
type
	bigvalue = array [1..len] of byte;
var
	i:word;
	x:bigvalue;
        al:byte;

{$L BigShow.obj}
{$F+}
Procedure BigShow(var x; len:word);external;
Function FcBigShl(var x; len:word):byte;external;
{$F-}
begin
 clrscr;
 for i:=1 to len do x[i]:=i;

  write('x= ');
  BigShow(x,len);
  al:=FcBigShl(x,len);
  write('x= ');
  BigShow(x,len);
  write('al=',al);
  readln
end.
