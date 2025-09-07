; 02375641
;     |
;    \|/
; 76543210

.286
data	SEGMENT	byte
 val	db	11111111b
data 	ENDS


code	SEGMENT
	ASSUME	cs:code,ds:data

begin:
	mov	ax,data
	mov	ds,ax

	mov	dl,val
	mov	dh,00000000b


	mov	al,dl
	and	al,10000000b
	shr     al,7
	or	dh,al

	mov	al,dl
	and	al,01000000b
	shr	al,4
	or	dh,al

	mov	al,dl
	and	al,00100000b
	shr	al,2
	or	dh,al

	mov	al,dl
	and	al,00010000b
	shl	al,3
	or	dh,al

	mov	al,dl
	and	al,00001000b
	shl	al,2
	or	dh,al

	mov	al,dl
	and	al,00000100b
	shl	al,4
	or	dh,al

	mov	al,dl
 	and	al,00000010b
	shl	al,3
	or	dh,al

	mov	al,dl
	and	al,00000001b
 	shl	al,1
	or	dh,al

	nop
	nop

	mov	ax,4c00h	; выход в MS-DOS
	int	21h

code	ENDS
	end	begin