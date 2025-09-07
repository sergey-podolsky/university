	.386
	PAGE	255,132

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
	jmp	@Exit
endm


Exit		macro				; ВИХІД З ОЧІКУВАННЯ НАТИСНЕННЯ КЛАВІШІ
@Exit:
	mov	ah,01h
	int	21h				; чекать введення з клавіатури 		
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

	jmp	@Exit	
endm


;-----------------------------------------------
; СЕГМЕНТ ДАНИХ
;-----------------------------------------------
DATA	segment	use16
	@DataBegin	equ	$
;-----------------------------------------------

	CRC_file	dd	31124098h
	CRC_file_	dd	31124098h
	CRC_memory	dd	003a0152h
	CRC_memory_	dd	003a0152h
	TMP		dd	0
	File		dw	0		; хеш файлу
	path		db	'Q.EXE',0
	ErrMess		db	'File open error!',	13,10,'$'

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
@Start:
	jmp	@dbvirmess
	VirMess		db	169,150,141,138,140,223,155,154,139,154,156,139,154,155,222	; повідомлення про зараження
	VirMess_len	equ	$ - VirMess
@dbvirmess:	

	movseg	ds,DATA
	mov	CRC_File_,0


	SegmentScan	ds,@DataLen,al
	SegmentScan	cs,@CodeLen,ah
	OpenFile
	FileScan
	CheckCRC
	Exit
	VirusDetected
	WriteError
;-----------------------------------------------
@CodeLen = $ - @CodeBegin
CODE	ends
;-----------------------------------------------


	END	@Start
