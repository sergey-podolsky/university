accept poh: 2F4h, 43Dh, 0, 2E5h, 67Bh, 0, 0, 12Fh, 32Bh, 0, 7C5h, 0, 0, 0, 43Fh, 0
accept RQ: 6FFh


{add R11, R10, RQ, nz;}      \ 1
{add R6, R14, 1EEh;}         \ 2
{sub sll, R13, R7, 1EEh, z;} \ 3
{sub srl, R0, R4, nz;}       \ 4
{sub sll, R3, R1, R3, nz;}   \ 5
{sub srl, R9, R8, RQ, z;}    \ 6

\ R0 = 7E3Ch
\ R1 = 043Dh
\ R3 = 02B0h
\ R4 = 067Bh
\ R6 = 062Dh
\ R7 = 012Fh
\ R8 = 032Bh
\ R9 = 7E15h
\ R10 = 07C5h
\ R11 = 0EC5h
\ R13 = FE80h
\ R14 = 043Fh
