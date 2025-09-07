	.386p
	PAGE	255,132

;---------------------------------------------
;Структура "дескриптор"
;---------------------------------------------
descr	struc
;---------------------------------------------
limit_1		dw	0		; молодші 2 байта розміру сегменту (розряди 0-15)
base_1		dw	0		; молодші 2 байта фізичної 32-розрядної адреси сегменту 
base_2		db	0		; 3-тій байт фізичної 32-розрядної адреси сегменту
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
descr_es 	descr	<>			; video
descr_ss 	descr	<>
descr_cs 	descr	<>
descr_gs	descr	<>
descr_Int_code	descr	<>
gdt_size	equ	$-selector0
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
pidt		point_dt<>			; вказівник для IDT
Top_real_mode	dd	?			; логічна адреса стека реального режиму
message		db	'This message was generated in safe mode.'
message_size	equ	$-message
Data_size	equ	$-pgdt
Data	ends


;----------------------------------------------
;Сегмент кодів обробки переривань
;----------------------------------------------
Int_code	segment	para	public	'code'	use16
Assume	cs:Int_code
;----------------------------------------------
Vector=0
@int_code_begin:
	Pusha
	Mov	ax,vector
	Jmp	common_int
@Int0_end:
Proc_int_size  =  @Int0_end  -  @int_code_begin

Vector=1
Rept	255
	pusha
	Mov	ax,vector
	Jmp	common_int
 Vector = Vector + 1
Endm

Mes_int	Db		'INTERUPT N'

common_int:					; формування номера переривання в Mes_int
	mov	cl,10
	div	cl				; молодша цифра в ah
	or	ah,30h				;формування текстового коду цифри
	mov	bh,ah
	xor	ah,ah
	div	cl				; середня цифра в ah, старша - в al
	or	ax,3030h			;формування текстового коду цифр
	mov	dx,ax
; виведення повідомлення на екран
	push	offset descr_es			; селектор дескриптора із 1-го етапу
	pop	es
	mov	si,offset Mes_int
	mov	cx,10
	mov	di,2620				;початкова адреса для виведення 
	mov	ah,07h				;атрибут символів
outstr:
	mov	al,CS:[si]
	stosw
	inc	si
	loop	outstr
	mov	al,' '
	stosw
	mov	al,dl				;старша десяткова цифра номера вектора 
	stosw
	mov	al,dh				;середня десяткова цифра номера вектора
	stosw
	mov	al,bh				;молодша десяткова цифра номера вектора
	stosw
; після виведення повідомлення організуємо передачу управління в основний сегмент для переключення в режим реальних адрес
; Для цього використаємо команду IRET
; В даній точці програми в стек записано вміст всіх регістрів, адреса команди, яка визвала виключення, та вміст регістра ознак. 
; Ми все це проігноруємо і запишемо в стек нові дані
	pushf
	push	offset descr_cs			; селектор дескриптора сегмента кодів із 1-го етапу
	push	offset return_dos
	iret					; передача управління по адресі return_dos основного сегмента кодів
@int_code_end:
int_code_size = @int_code_end - @int_code_begin
Int_code	ends


;----------------------------------------------
;Сегмент таблиці векторів переривань. Містить дескриптори (шлюзи) пасток, переривань та задач
;----------------------------------------------
IDT		segment para public 'data' use16
;----------------------------------------------
Vector=0
Rept		256
	Dw	Vector * Proc_int_size		; зміщення процедури
	Dw	offset descr_Int_code		; селектор дескриптора в GDT
	Db	0				; завжди 0
	Db	10001111b			; байт атрибутів - шлюз пастки
	Dw	0				; всі процедури розміщуються в перших 64К
 Vector=Vector+1
Endm
idt_size = 8*256
IDT	ends




;----------------------------------------------
;Сегмент кодів
;----------------------------------------------
Code	segment	use16
@code_size=@code_end-@code_begin
Assume	cs:Code
;----------------------------------------------
@code_begin:
	mov	ax,3
	int	10h				; переключить відеоконтролер

	mov	ax,Data
	mov	ds,ax
	Assume	ds:Data

	mov	word ptr Top_real_mode,   sp	; зберегти логічну адресу вершини стека реального режиму
	mov	word ptr Top_real_mode+2, ss

; формування 6-байтного вказівника на GDT
	xor	eax,eax				
	mov	ax,GDT
	shl	eax,4
	mov	pgdt.adr, eax
	mov	ax, gdt_size
	mov	pgdt.lim, ax
	lgdt	pgdt				; завантаження регістра GDT вказівником

; формування 6-байтного вказівника на IDT
	xor	eax,eax
	mov	ax,IDT
	shl	eax,4
	mov	pidt.adr, eax
	mov	ax, idt_size
	mov	pidt.lim, ax
	lidt	pidt				; завантаження регістра IDT вказівником


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
;Формування дескриптора сегмента gs
	mov	descr_gs.bt6,10000000b
	mov	descr_gs.base_1,0ffffh
	mov	descr_gs.base_2,0ffh
	mov	descr_gs.base_3,0ffh
	mov	descr_gs.attrib, data_seg
;формування дескриптора сегмента Int_code
	mov	descr_Int_code.limit_1, int_code_size
	xor	eax,eax
	mov	ax, Int_code
	shl	eax,4
	mov	dword ptr descr_Int_code.base_1,  eax
	mov	descr_Int_code.attrib,code_seg



	in	al,92h				;розблокувати 20-й розряд адрес ПЕОМ
	or	al,2
	out	92h,al

	Cli					; заборонити переривання

	mov	eax,cr0
	or	al,1
	mov	cr0,eax				; переключення в захищений режим


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
	mov	ax, offset descr_gs
	mov	gs, ax
	Assume	ds:Data

;Виведення повідомлення на екран
@write:
	mov	cx,message_size
	mov	si,offset message
	mov	di,1640				;початкова адреса виведення 
	mov	ah,07h				;атрибут символів
outmes:
	mov	al,[si]
	mov	es:[di],ax
	inc	si
	add	di,2
	loop	outmes

;##########################################
	mov	cs:[0],ah
;##########################################



return_dos:
	mov	ax, offset descr_GDT		; в режимі реальних адрес в цьому випадку виконували команду mov ax,GDT
	mov	ds,ax
	Assume	ds:GDT

	mov	descr_int_code.limit_1,	0ffffh
	mov	descr_cs.limit_1,	0ffffh
	mov	descr_ds.limit_1,	0ffffh
	mov	descr_es.limit_1,	0ffffh
	mov	descr_gs.limit_1,	0ffffh
	mov	descr_ss.limit_1,	0ffffh
	mov	descr_ss.attrib,	data_seg

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
        dw	offset real_mode
        dw	CODE
real_mode:					;вже в реальному режимі
        mov	ax,Data
        mov	ds,ax
	Assume	ds:Data

        lss	sp,Top_real_mode		;повернути стек реального режиму

; необхідно в IDTR завантажити покажчик таблиці переривань реального режиму
	xor	eax,eax
	mov	pidt.adr,eax
	mov	pidt.lim,3ffh
	lidt	pidt

        sti
 
	mov	ah,01h
	int	21h				; чекать введення з клавіатури 
				
        mov	ax,4c00h			; закінчення роботи програми (стандартно)
        int	21h
@code_end:
Code	ends


END	@code_begin



