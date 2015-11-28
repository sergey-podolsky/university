#!/bin/bash

set -e

while read var method f low high eps norun; do
  echo $var
  if [ -n "$var" ] && [ -z "$norun" ]; then
    echo > config.h
    echo "#define FUNCTION $f" >> config.h
    echo "#define METHOD $method" >> config.h

    echo "$low $high $eps" > input.txt

    mpicc -W -Wall -O2 -std=c99 integrate.c
    echo "" | time mpiexec -np 4 ./a.out

    cat output.txt
  fi
done < table.txt

