/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * General-purpose Memory Allocator	(part 2)						 *
 * System software Lab ¹2 (1st semester 2009)						 *
 *																	 *
 *		Author:														 *
 * Podolsky Sergey													 *
 * Group:	KV-64													 *
 *																	 *
 * written:	13.11.2009												 *
 *																	 *
 *		Project definition:											 *
 * Main.cpp			The entry point for the console application		 *
 * SlabAllocator.h	Defines Memory Allocator class					 *	
 * stdafx.h			Include file for standard system include files	 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#include <stdio.h>
#include <tchar.h>
#include <stdlib.h>
#include <iostream>
#include <math.h>

using namespace std;
using std::cout;
using std::cin;
using std::endl;



// TODO: reference additional headers your program requires here
