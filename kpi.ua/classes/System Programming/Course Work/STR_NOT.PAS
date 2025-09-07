uses    crt;
var     s,path:string;
        c:byte;
        i:word;
begin
 clrscr;
 writeln('Enter any string:');
 readln(s);
 writeln('Enter output file name:');
 readln(path);
 assign(output,path);
 rewrite(output);
 for i:=1 to length(s) do
 begin
      asm
         mov    bx,i
         mov    al,byte ptr[s+bx]
         not    al
         mov    [c],al
      end;
      write(c);
      if (i<length(s)) then write(',')
 end;
 close(output);
 assign(output,'');
 rewrite(output);
 writeln('Each char "not" ASCI code was generated to ',path);
 readln
end.