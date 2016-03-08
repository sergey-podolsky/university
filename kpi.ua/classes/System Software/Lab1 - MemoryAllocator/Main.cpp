/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * General-purpose Memory Allocator
 * System software Lab ¹1 (1st semester 2009)
 *
 *		Author:
 * Podolsky Sergey
 * Group:	KV-64
 *
 * written:	14.10.2009
 *
 *		Project definition:
 * Main.cpp				Defines the entry point for the console application
 * MemoryAllocator.h	Defines Memory Allocator class
 * stdafx.h				Include file for standard system include files
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#include "stdafx.h"
#include "MemoryAllocator.h"

int _tmain(int argc, _TCHAR* argv[])
{
	unsigned size = 1024;
	MemoryAllocator *allocator = new MemoryAllocator(malloc(size), size);
	allocator->table_dump();
	allocator->mem_dump();

	void *addr1 = allocator->mem_alloc(100);
	void *addr2 = allocator->mem_alloc(100);
	void *addr3 = allocator->mem_alloc(100);
	allocator->table_dump();
	allocator->mem_dump();

	addr2 = allocator->mem_realloc(addr2, 120);
	allocator->table_dump();
	allocator->mem_dump();

	allocator->mem_free(addr3);
	allocator->table_dump();
	allocator->mem_dump();

	allocator->mem_free(addr2);
	allocator->table_dump();
	allocator->mem_dump();
}