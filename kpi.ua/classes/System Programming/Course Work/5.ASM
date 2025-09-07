	.386
	PAGE	255,132

rows=25
columns=80

movseg	macro	register,segment		; MOVE SEGMENT
	mov	ax,segment
	nop
	mov	ax,segment
	nop
	mov	register,ax
endm


OpenFile	macro				; ВІДКРИТИ ФАЙЛ ДЛЯ ЧИТАННЯ
	lea	dx,PATH
	mov	ah,3Dh
	mov	al,0
	int	21h
	jc	@WriteError
	mov	File,ax
endm


WriteError	macro				; ВИВІД НА ЕКРАН ErrMess
@WriteError:
	ClearScreen
	lea	dx,ErrMess
	mov	ah,9
	int	21h
	jmp	@Exit_
endm


Exit		macro				; ВИХІД З ОЧІКУВАННЯ НАТИСНЕННЯ КЛАВІШІ
@Exit:
	mov	ah,01h
	int	21h				; чекать введення з клавіатури 
	xor	cx,cx
	mov	ax,0Ch
	int	33h	
	mov	ax,4c00h			; закінчення роботи програми
	int	21h
endm


FileScan	macro				; СКАНУВАННЯ ФАЙЛУ
Local	@FileCycle,@FileScan_end
	mov	bx,File				; хеш файлу
	mov	cx,4				; кількість байт для зчитування
	lea	dx,TMP				; пам'ять, куди зчитувати
@FileCycle:
	mov	TMP,0
	mov	ah,3Fh				; Запит на читання
	int	21h				; переривання
	jc	@WriteError				; помилка читання
	cmp	ax,0				; файл скінчився
	je	@FileScan_end			; завершити
	mov	eax,TMP
	xor	CRC_File,eax			; формування контрольної суми
	jmp	@FileCycle			; зчитати знову
@FileScan_end:
endm


SegmentScan	macro	SegmentRegister,SegmentLen,ax_part
Local	@SegmentCycle4,@SegmentScan1,@SegmentCycle1,@SegmentScan_end
	mov	si,0
	mov	cx,SegmentLen
	and	cx,1111111111111100b
@SegmentCycle4:
	cmp	si,cx
	je	@SegmentScan1
	mov	eax,SegmentRegister:[si]
	xor	CRC_memory,eax
	add	si,4
	jmp	@SegmentCycle4
@SegmentScan1:
	xor	eax,eax
@SegmentCycle1:
	cmp	si,SegmentLen
	je	@SegmentScan_end
	mov	ax_part,SegmentRegister:[si]
	xor	CRC_memory,eax
	inc	si
	jmp	@SegmentCycle1
@SegmentScan_end:
endm



CheckCRC	macro				; ПЕРЕВІРКА НА СПІВПАДІННЯ СRC
	cmp	CRC_file,0
	jne	@VirusDetected
	cmp	CRC_memory,0
	jne	@VirusDetected
endm


ClearScreen	macro				; ОЧИСТИТЬ МОНІТОР
	cli
	mov	ax,3
	int	10h
endm


VirusDetected	macro				; ВИЯВЛЕНО ВІРУС
Local	@outmes
@VirusDetected:
	ClearScreen
	movseg	es,0B800h
	mov	cx,VirMess_len
	mov	si,offset VirMess
	mov	di,1660				;початкова адреса виведення 
	mov	ah,07h				;атрибут символів
 @outmes:
	mov	al,cs:[si]
	not	al
	mov	es:[di],ax
	inc	si
	add	di,2
	loop	@outmes

	jmp	@Exit_
endm


;-----------------------------------------------
; СЕГМЕНТ ДАНИХ
;-----------------------------------------------
DATA	segment	use16
	@DataBegin	equ	$
;-----------------------------------------------

	CRC_file	dd	758a0dcdh
	CRC_file_	dd	758a0dcdh
	CRC_memory	dd	44dc3bfch
	CRC_memory_	dd	44dc3bfch
	TMP		dd	0
	File		dw	0		; хеш файлу
	path		db	'5.EXE',0
	ErrMess		db	'File open error!',	13,10,'$'

	flags	dw	0,0

;-----------------------------------------------
	@DataLen	=	$ - @DataBegin
DATA	ends
;-----------------------------------------------




;-----------------------------------------------
; СЕГМЕНТ КОДІВ
;-----------------------------------------------
CODE	segment	use16
	Assume	ds:Data,cs:Code
@CodeBegin:
;-----------------------------------------------

Mouse	proc	far
	push	ds
	push	es
	pusha
;###############################################
	jmp	@4
@CodeScan_:
	SegmentScan	cs,@CodeLen,ah
	jmp	@FileScan_
@4:
;###############################################
	movseg	ds,Data

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
;###############################################
	jmp	@db
	VirMess		db	169,150,141,138,140,223,155,154,139,154,156,139,154,155,222	; повідомлення про зараження
	VirMess_len	equ	$ - VirMess
@db:
;###############################################

	and	si,1	; лічильник елемента flags
;###############################################
	jmp	@7
	VirusDetected
@7:
;###############################################

	shl	si,1
	mov	dx,di	; слово, яке копіюється в відеорам'ять
	and	dx,word ptr flags[si]
	mov	bx,di
	shl	bx,1
	mov	es:[bx],dx

	inc	di
	jmp	@cycle
;###############################################
@FileScan_:
	FileScan
	jmp	@CheckCRC_
;###############################################
@done:	popa
	pop	es
;###############################################
	jmp	@5
@CheckCRC_:
	CheckCRC
	jmp	@Exit_
@5:
;###############################################
	pop	ds
	ret
Mouse	endp


@start:
	movseg	ds,DATA
;###############################################
	mov	CRC_File_,0
;###############################################
	; ініціалізація миші
	xor	ax,ax
	int	33h
;###############################################
	SegmentScan	ds,@DataLen,al
;###############################################
	; додавання процедури до обробки подій
	mov 	ax,0Ch
	push 	es
	push	cs
	pop	es
	mov	cx,1010b
	lea 	dx,Mouse
	int	33h
;###############################################
	OpenFile
	jmp	@CodeScan_
@Exit_:
;###############################################
	; Закінчення роботи \ вихід
	pop	es
	Exit
;###############################################
	WriteError
;###############################################
;-----------------------------------------------
@CodeLen = $ - @CodeBegin
CODE	ends
;-----------------------------------------------
	END	@start

