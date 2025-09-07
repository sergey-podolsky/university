	.386
	PAGE	255,132
	TITLE	Подольський Сергій КВ-64

rows=25
columns=80


Exit	macro
	mov 	ah,01h
	int	21h
	xor	cx,cx
	mov	ax,0Ch
	int	33h
	mov	ax,4C00h
	int	21h
endm


Data	segment	use16
	flags	dw	0,0
Data	ends



Code	segment	use16
	assume	cs:Code,ds:Data

Mouse	proc	far
	push	ds
	push	es
	pusha

	mov	ax,Data
	mov	ds,ax

	mov	ax,0B800h
	mov	es,ax

	test	bx,01b
	jz	@1
	not	word ptr flags[0]
@1:
	test	bx,10b
	jz	@2
	not	word ptr flags[2]
@2:
	mov	di,0	; лічильник байту відеорам'яті
@cycle:
	cmp	di,rows*columns
	je	@done

	mov	si,di
	and	si,1	; лічильник елемента flags
	shl	si,1
	mov	dx,di	; слово, яке копіюється в відеорам'ять
	and	dx,word ptr flags[si]
	mov	bx,di
	shl	bx,1
	mov	es:[bx],dx

	inc	di
	jmp	@cycle

@done:	popa
	pop	es
	pop	ds
	ret
Mouse	endp

@begin:
	mov	ax,Data
	mov	ds,ax

	; ініціалізація миші
	xor	ax,ax
	int	33h

	; додавання процедури до обробки подій
	mov 	ax,0Ch
	push 	es
	push	cs
	pop	es
	mov	cx,1010b
	lea 	dx,Mouse
	int	33h

	; Закінчення роботи \ вихід
	pop	es
	Exit
Code	ends
	END	@begin

