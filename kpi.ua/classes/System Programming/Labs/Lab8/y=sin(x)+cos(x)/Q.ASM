	.386
	PAGE	255,132

Color =	100


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


Scale	macro	p1
	fld	max_&p1			; st(0):=max_&p1	; top=7
	fsub	min_&p1			; st(0):=st(0)-min_&p1	; top=7
	fild	max_crt_&p1		; st(1):=screen_&p1	; top=6
	fdivp	st(1),st(0)		; st(1):=st(1)/st(0)	; top=7
	fstp	scale_&p1		; scale_&p1:=st(0)	; top=0
endm


XtoReal	macro
	fld	scale_x
	fild	crt_x
	fmulp	st(1),st(0)
	fadd	min_x
endm


GetFunc	macro
	fst	tmp
	fcos
	fld	tmp
	fsin
	faddp	st(1),st(0)
endm


YtoPix	macro
	fcom	min_y			; порівняння ST(0) та min_y
	fstsw	ax			; ax:=результат порівняння
	sahf				; flags:=ah		
	jnc	@NotLess
	movmem	crt_y,max_crt_y		; st(0) < min_y
	dec	crt_y
	jmp	@ffree
 @NotLess:
	fcom	max_y			; порівняння ST(0) та max_y
	fstsw	ax			; ax:=результат порівняння
	sahf				; flags:=ah
	jna	@NotGreater		; st0 > max_y (zf=cf=0)
	mov	crt_y,0
	jmp	@ffree
 @NotGreater:
	fsub	min_y
	fdiv	scale_y
	frndint				; округлення до цілого
	fist	crt_y			; crt_y:=ST(0)		; TOP=NULL
	mov	ax,max_crt_y		; дзеркальне відображення
	sub	ax,crt_y
	mov	crt_y,ax
@ffree:	ffree	st(0)
endm



;---------------------------------------
; Сегмент даних
;---------------------------------------
Data	segment	use16
;---------------------------------------
	min_x		dq	-10.0	; мінімальне значення по осі х
	max_x		dq	 10.0	; максимальне значення по осі х
	max_crt_x	dw	320	; максимальна кількість точок на екрані по осі х
	crt_x		dw	?	; екранна координата по осі х
	scale_x		dq	?	; масштаб по осі х

	min_y		dq	-2.0	; мінімальне значення по осі y
	max_y		dq	 2.0	; максимальне значення по осі y
	max_crt_y	dw	200	; максимальна кількість точок на екрані по осі y
	crt_y		dw	?	; екранна координата по осі y
	scale_y		dq	?	; масштаб по осі y

	tmp		dq	?	; тимчасова змінна
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
	
	movmem	crt_x,max_crt_x		; початкові установки циклу
 @cycle:
	cmp	crt_x,0
	je	@Exit

	XtoReal
	GetFunc
	YtoPix

	mov	bx,max_crt_x
	imul	bx,crt_y
	add	bx,crt_x
	mov	byte ptr es:[bx],Color
	dec	crt_x
	jmp	@cycle	
 @Exit:
	Exit
Code	ends


	END	@start
