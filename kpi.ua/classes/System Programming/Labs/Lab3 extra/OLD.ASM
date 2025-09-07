	.386
	PAGE	255,132

exit	macro
	mov	ax,4c00h
	int	21h
endm

movseg	macro	Xs,XX
	mov	ax,XX
	mov	Xs,ax
endm


Data1	segment	use16
	x1=3
	x2=2
	x3=7
	x4=5

	A1	db	x1 dup (x2 dup (x3 dup (x4 dup (?))))
	I1	db	0
	I2	db	0
	I3	db	0
	I4	db	0
Data1	ends


Data2	segment	use16
	xx1=7
	xx2=5
	xx3=2

	A2	db	xx1 dup (xx2 dup (xx3 dup (?)))
	II1	db	0
	II2	db	0
	II3	db	0
Data2	ends



Code1	segment	use16
	assume	cs:Code1,ds:Data1,es:Data2
	a_c2	dd	@a_c2
@a_c1:
	movseg	ds,Data1
	movseg	es,Data2
@c1_begin:
	;занести в кожний елемент масиву А1 значення його зміщення відносно початку масиву
	mov	cx,x1*x2*x3*x4-1
	mov	A1[0],0
@go:
	mov	di,cx
	mov	A1[di],cl
	loop	@go

	;переслати, використовуючи значення індексів масивів по адресах І1,І2,І3,І4 та ІI1,ІI2,IІ3,
	;17 елементів масиву А1 починаючи з елементу А1[1,0,3,2] в масив А2, починаючи з елементу А2[3,4,0]
	count=17
	
	si1=1
	si2=0
	si3=3
	si4=2

	di1=3
	di2=4
	di3=0
	
	mov	I1,si1
	mov	I2,si2
	mov	I3,si3
	mov	I4,si4
	mov	II1,di1
	mov	II2,di2
	mov	II3,di3

	xor	ax,ax
	mov	cx,count

@copy:	;формування ефективних адрес
	mov	al,I1
	mov	si,ax
	imul	si,si,x2
	mov	al,I2
	add	si,ax
	imul	si,si,x3
	mov	al,I3
	add	si,ax
	imul	si,si,x4
	mov	al,I4
	add	si,ax

	mov	al,II1
	mov	di,ax
	imul	di,di,xx2
	mov	al,II2
	add	di,ax
	imul	di,di,xx3
	mov	al,II3
	add	di,ax

	;пересилка елемента
	mov	al,byte ptr A1[si]
	mov	byte ptr A2[di],al

	;інкрименти
	inc	I4
	cmp	I4,x4
	jnz	@inc1

	mov	I4,0
	inc	I3
	cmp	I3,x3
	jnz	@inc1

	mov	I3,0
	inc	I2
	cmp	I2,x2
	jnz	@inc1
	
	mov	I2,0
	inc	I1
	cmp	I1,x1
	je	@c1_end
@inc1:
	inc	II3
	cmp	II3,xx3
	jnz	@inc2

	mov	II3,0
	inc	II2
	cmp	II2,xx2
	jnz	@inc2

	mov	II2,0
	inc	II1
	cmp	II1,xx1
	je	@c1_end
@inc2:
	dec	cx
	cmp	cx,0
	jne	@copy
@c1_end:
	jmp	a_c2
Code1	ends


Code2	segment	use16
	assume	cs:Code2
@a_c2:
	movseg	ds,Data1
	movseg	es,Data2
@c2_begin:
	;пересилання вказаних елементів масиву А1 в масив А2, починаючи з елементу А2[0,3,1]
	_di1=0
	_di2=3
	_di3=1

	cld
	mov	si,offset A1 + ((si1*x2 + si2)*x3 + si3)*x4 + si4
	mov	di,offset A2 + (_di1*xx2 + _di2)*xx3 + _di3
	mov	cx,count
	rep	movsb

	exit
@c2_end:
Code2	ends




END	@a_c1










