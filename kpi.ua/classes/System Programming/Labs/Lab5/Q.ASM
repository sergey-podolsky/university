	.386
	PAGE	255,132
	TITLE	Подольський Сергій КВ-64

empty=0
rows=25
columns=80
adress=0B800h


Exit	macro
	xor	cx,cx
	mov	ax,0Ch
	int	33h
	mov	ax,4C00h
	int	21h
endm


WaitKey	macro
	mov 	ah,01h
	int	21h
endm


Draw	macro
	mov	ah,5
	mov	al,0
	int	10h
endm


Fill	macro	v1,v2		;парні,непарні значення пам'яті
	local	@c1,@c2,@_c1,@par,@nepar,@impar,@draw
	mov	ax,adress
	mov	es,ax
	mov	cx,0		;лічильник рядку
@c1:	cmp	cx,rows
	jnb	@draw
	mov	dx,0		;лічильник стовпичику
@c2:	cmp	dx,columns*2
	jnb	@_c1
	mov	bx,cx
	imul	bx,columns*2
	add	bx,dx
	; перевірка, парний\непарний елемент сторінки
	mov	ax,dx
	and	ax,11b
	cmp	ax,0
	je	@par
	mov	ax,v2
	jmp	@nepar
@par:	mov	ax,v1
@nepar:	mov	word ptr es:[bx],ax
	add	dx,2
	jmp	@c2
@_c1:	inc	cx
	jmp	@c1
@draw:	draw
endm


_data	segment
	v1	db	0
	v2	db	0
_data	ends




_text	segment	use16
	assume	cs:_text,ds:_data

Mouse	proc	far
	push	ds
	push	es
	pusha
	
	mov	ax,bx
	and	ax,01b
	jz	@v2
	not	v1

@v2:	mov	ax,bx
	and	ax,10b
	jz	@xx
	not	v2

@xx:	cmp	v1,0
	je	@0x
	cmp	v2,0
	je	@10
@11:	Fill	bx,bx
	jmp	@done
@10:	Fill	bx,0
	jmp	@done

@0x:	cmp	v2,0
	je	@00
@01:	Fill	0,bx
	jmp	@done
@00:	Fill	0,0

@done:	popa
	pop	es
	pop	ds
	ret
Mouse	endp

@begin:
	mov	ax,_data
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
	WaitKey
	Exit
_text	ends
	END	@begin




























                   