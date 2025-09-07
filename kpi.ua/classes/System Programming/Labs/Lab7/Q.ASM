	.386p
	PAGE	255,132

;---------------------------------------------
;Структура "дескриптор"
;---------------------------------------------
descr	struc
;---------------------------------------------
limit_1		dw	0		; молодші 2 байта розміру сегменту (розряди 0-15)
base_1		dw	0		; молодші 2 байта фізичної 32-розрядної адреси сегменту 
base_2		db	0		; 3-тій ба	йт фізичної 32-розрядної адреси сегменту
attrib		db	0		; байт атрибутів сегменту
bt6		db	0		; старші 4 розряди байту – атрибути сегменту, молодші 4 розряди байту - розряди 16-19 розміру сегмету
base_3		db	0		; 4-тий байт фізичної 32-розрядної адреси сегменту
descr	ends


;---------------------------------------------
;БАЙТИ АТРИБУТІВ
;---------------------------------------------
code_seg	equ	10011010b	; непідпорядкований сегмент кодів, дозволено читати 
data_seg	equ	10010010b	; сегмент даних, дозволено записувати
stack_seg	equ	10010110b	; сегмент стека


;----------------------------------------------
;Опис вказівника таблиці дескрипторів
;----------------------------------------------
point_dt	struc
;----------------------------------------------
lim		dw	0
adr		dd	0
point_dt	ends


;----------------------------------------------
;Визначення таблиці глобальних дескрипторів
;----------------------------------------------
GDT	segment	para	public	'data'	use16
;----------------------------------------------
selector0	descr	<>
descr_gdt 	descr	<>
descr_ds 	descr	<>
descr_es 	descr	<>; video
descr_ss 	descr	<>
descr_cs 	descr	<>
gdt_size	equ	$-selector0-1
GDT	ends


;----------------------------------------------
;Сегмент стеку
;----------------------------------------------
Stack	segment	use16
;----------------------------------------------
b1000		Db	1000 dup (0)
Top_stp		equ	$-b1000			; Top_stp=1000
Stack		ends


;----------------------------------------------
;Сегмент даних
;----------------------------------------------
Data	segment	para	public	'data'	use16
;----------------------------------------------
pgdt		point_dt<>			; вказівник для GDT 
Top_real_mode	dd	?			; логічна адреса стека реального режиму
message		db	'abcde'
Data_size	equ	$-pgdt
Data	ends


;----------------------------------------------
;Сегмент кодів
;----------------------------------------------
Code	segment	use16
@code_size=@code_end-@code_begin
Assume	cs:Code
;----------------------------------------------
@code_begin:

	mov	ax,Data
	mov	ds,ax

	mov	word ptr ds:[Top_real_mode],  sp; зберегти логічну адресу вершини стека реального режиму
	mov	word ptr ds:[Top_real_mode+2],ss

	xor	eax,eax				; формування 6-байтного вказівника на GDT
	mov	ax,GDT
	shl	eax,4
	mov	ds:[pgdt.adr], eax
	mov	ax, gdt_size
	mov	ds:[pgdt.lim], ax

	lgdt	ds:[pgdt]				; завантаження регістра GDT вказівником


	mov	ax,GDT				; загальна частина для всіх дескрипторів
	mov	ds,ax
	Assume	ds:GDT 

;Формування дескриптора сегмента кодів
	mov	descr_cs.limit_1, @code_size	; розмір сегмента кодів
	xor	eax,eax				; формування фізичної адреси сегмента кодів
	mov	ax,CODE
	shl	eax,4				; відлуння реального режиму від TASM, TASM транслює _CODE для реального режиму
	mov	dword ptr descr_cs.base_1, eax	; атрибути сегмента кодів
	mov	descr_cs.attrib, code_seg
;Формування дескриптора сегмента GDT
	mov	descr_gdt.limit_1, gdt_size
	xor	eax,eax
	mov	ax,GDT
	shl	eax,4
	mov	dword ptr descr_gdt.base_1, eax
	mov	descr_gdt.attrib, data_seg
;Формування дескриптора сегмента стеку
	mov	descr_ss.limit_1, 10
	xor	eax,eax
	mov	ax,Stack
	shl	eax,4
	mov	dword ptr descr_ss.base_1, eax
	mov	descr_ss.attrib, stack_seg
;Формування дескриптора сегмента відеобуфера
	mov	descr_es.limit_1, 0ffffh;
	mov	dword ptr descr_es.base_1, 0b8000h
	mov	descr_es.attrib, data_seg
;Формування дескриптора сегмента даних
	mov	descr_ds.limit_1, data_size
	xor	eax,eax
	mov	ax,Data
	shl	eax,4
	mov	dword ptr descr_ds.base_1, eax
	mov	descr_ds.attrib, data_seg

	Cli					; заборонити переривання

	mov	eax,cr0
	or	al,1
	mov	cr0,eax				; переключення в захищений режим

	in	al,92h				;розблокувати 20-й розряд адрес ПЕОМ
	or	al,2
	out	92h,al


;завантажити селектор в регістр коду cs
	db	0eah				;машинний код команди jmp
	dw	offset protect			;зміщення мітки переходу в сегменті кодів
	dw	offset descr_cs			;селектор сегмента кодів 

protect:
;завантажити селектори для інших дескрипторів
; припускаємо, що RPL=0
	mov	ax, offset descr_ss
	mov	ss, ax
	mov	ax, top_stp
	mov	sp, ax
	mov	ax, offset descr_es
	mov	es, ax
	mov	ax, offset descr_ds
	mov	ds, ax

;Виведення повідомлення на екран
@write:
	mov	cx,4
	mov	si,offset message
	mov	di,1640				;початкова адреса виведення 
	mov	ah,07h				;атрибут символів
outmes:
	mov	al,ds:[si]
	mov	es:[di],ax
	inc	si
	add	di,2
	loop	outmes

return_dos:
	assume	ds:GDT; 
	cli
	mov	ax, offset descr_GDT		; в режимі реальних адрес в цьому випадку виконували команду mov ax,GDT
	mov	ds,ax
	mov	descr_cs.limit_1, 0ffffh
	mov	descr_ds.limit_1, 0ffffh
	mov	descr_es.limit_1, 0ffffh
	mov	descr_ss.attrib,  data_seg

; перезавантаження тіньових регістрів
	mov	ax, offset descr_ds
	mov	ds, ax
	mov	ax, offset descr_es
	mov	es,ax
	mov	ax, offset descr_ss
	mov	ss, ax
	db	0eah
	dw	offset jumpt
	dw	offset descr_cs			; TASM не забезпечує
jumpt:

; переключення в режим реальних адрес
        mov	eax,cr0
        and	al,0feh
        mov	cr0,eax
        db	0eah
        dw	offset r_mode
        dw	CODE
r_mode:
        mov	ax,Data
        mov	ds,ax
        lss	sp,ds:[Top_real_mode]
        sti
	mov	ah,01h
	int	21h				; чекать введення з клавіатури 
	mov	ax,3
	int	10h				; переключить відеоконтролер
					
        mov	ax,4c00h			; закінчення роботи програми (стандартно)
        int	21h
@code_end:
Code	ends


END



