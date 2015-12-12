org 100h

accept RQ: 0FFFEh \ -2
accept R4: 3
accept R14: 0FFFAh \ -6


{add R9, R14;}
{add R9, RQ;}
{sub sla, R9, R4, nz;}
{add sla, R9, 0;}

{add R9, R14;}
{add R9, RQ;}
{sub sla, R9, 7, nz;}

{add sla, R9, RQ;}
{add sla, R9, 0;}

{sub R9, 7, nz;}



{cjp nz, END;}

END{}
