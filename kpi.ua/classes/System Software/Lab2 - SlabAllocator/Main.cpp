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

#include "stdafx.h"
#include "SlabAllocator.h"

int _tmain(int argc, _TCHAR* argv[])
{
	SIZE_TYPE size = 5 * 4096 + 1000; // 5 pages and 1000 bytes for tables
	SlabAllocator* allocator = new SlabAllocator(malloc(size), size);

	void* block1 = allocator->mem_alloc(5000);
	
	for (int i = 0; i < 1024 + 1; i++)
		allocator->mem_alloc(4);

	allocator->mem_dump();
	allocator->table_dump();	

	return 0;
}

