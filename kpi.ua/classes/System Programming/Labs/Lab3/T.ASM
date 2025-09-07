	.286
exit	macro
	mov	ax,4c00h
	int	21h
endm

Data1	segment	byte	public	use16
	v1	dw	?
	v2	dw	?
Data1	ends

Code1	segment	byte	public	use16
	assume	cs:Code1,	ds:Data1
	mov	ax,Data1
	mov	ds,ax
begin:
	mov	ax,cx


	exit
Code1	ends

end	begin
