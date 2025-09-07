	.386
	PAGE	255,132

Color	=	100
width_	=	320
Height_	=	200


movmem	macro	p1,p2
	mov	ax,p2
	mov	p1,ax
endm


Exit	macro
	mov	ah,1
	int	21h			; чекать введення з клавіатури 			
        mov	ax,4C00h
        int	21h			; закінчення роботи програми
endm


Scale	macro	p
	fld	max_&p			; st(0):=max_&p1	; top=7
	fsub	min_&p			; st(0):=st(0)-min_&p1	; top=7
	fild	max_crt_&p		; st(1):=screen_&p1	; top=6
	fdivp	st(1),st(0)		; st(1):=st(1)/st(0)	; top=7
	fstp	scale_&p		; scale_&p1:=st(0)	; top=0
endm




GetFunc	macro
	fld	value_x
	fld	value_x
	fcos
	fdivp	st(1),st(0)
	fstp	value_y
endm



Rotate	macro
	sub	crt_x,hx
	sub	crt_y,hy	
X:
	fild	crt_x
	fld	angle
	fcos
	fmulp	st(1),st(0)

	fild	crt_y
	fld	angle
	fsin
	fmulp	st(1),st(0)

	fsubp	st(1),st(0)
	frndint
	fistp	crt_x
Y:
	fild	crt_x
	fld	angle
	fsin
	fmulp	st(1),st(0)

	fild	crt_y
	fld	angle
	fcos
	fmulp	st(1),st(0)

	faddp	st(1),st(0)
	frndint
	fistp	crt_y
;-----------------------
	mov	ax,hx
	add	crt_x,ax

	mov	ax,hy
	add	crt_y,ax
endm




GetCrt	macro	p
	fld	value_&p
	fsub	min_&p
	fdiv	scale_&p
	frndint				; округлення до цілого
	fistp	crt_&p			; crt_y:=ST(0)		; TOP=NULL
endm



Check	macro	p
Local	@NotLess,@Done
	fld	value_&p
	fcomp	min_&p
	fstsw	ax
	sahf
	jnc	@NotLess
	fld	min_&p
	fstp	value_&p
	jmp	@Done
@NotLess:
	fld	value_&p
	fcomp	max_&p
	fstsw	ax
	sahf
	jna	@Done
	fld	max_&p
	fstp	value_&p
@Done:
endm


Mirror	macro	p
	mov	ax,max_crt_&p		; дзеркальне відображення
	sub	ax,crt_&p
	mov	crt_&p,ax
endm


Draw	macro
	mov	bx,max_crt_x
	imul	bx,crt_y
	add	bx,crt_x
	mov	byte ptr es:[bx],Color
endm


;---------------------------------------
; Сегмент даних
;---------------------------------------
Data	segment	use16
;---------------------------------------
	min_x		dq	-18.0	; мінімальне значення по осі х
	max_x		dq	 18.0	; максимальне значення по осі х
	max_crt_x	dw	width_	; максимальна кількість точок на екрані по осі х
	crt_x		dw	?	; екранна координата по осі х
	scale_x		dq	?	; масштаб по осі х

	min_y		dq	-0.36	; мінімальне значення по осі y
	max_y		dq	 0.36	; максимальне значення по осі y
	max_crt_y	dw	height_	; максимальна кількість точок на екрані по осі y
	crt_y		dw	?	; екранна координата по осі y
	scale_y		dq	?	; масштаб по осі y

	value_x		dq	?
	value_y		dq	?

	Delta		dq	0.01		; приріст функції по Х
	Angle		dq	0.0

	hx		=	width_  / 2
	hy		=	height_ / 2

Data	ends


;---------------------------------------
; Сегмент кодів
;---------------------------------------
Code	segment	use16
Assume	cs:Code,ds:Data
@start:
;---------------------------------------
	movmem	ds,Data
	movmem	es,0A000h		; es - відеопам'ять

	mov	ax,13h
	int	10h			; ініціалізація відеорежиму 320*200

	finit				; ініціалізація співпроцесора
	Scale	x			; масштаб по х
	Scale	y			; масщтаб по у
	
	fld	min_x
	fstp	value_x
 @cycle:
	fld	value_x
	fcomp	max_x
	fstsw	ax
	sahf
	ja	@Exit

	GetFunc


	Check	X
	Check	Y

	GetCrt	Y
	GetCrt	X

	Mirror	Y

	Rotate

	Draw

	fld	value_x
	fadd	delta
	fstp	value_x
	jmp	@cycle	
 @Exit:
	Exit
Code	ends


	END	@start
