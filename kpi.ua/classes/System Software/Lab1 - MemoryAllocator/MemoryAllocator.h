/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * General-purpose Memory Allocator
 * System software Lab ¹1 (1st semester 2009)
 *
 *		Author:
 * Podolsky Sergey
 * Group:	KV-64
 *
 * written:	15.10.2009
 *
 *		Project definition:
 * Main.cpp				Defines the entry point for the console application
 * MemoryAllocator.h	Defines Memory Allocator class
 * stdafx.h				Include file for standard system include files
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#pragma once

#include "stdafx.h"

/*---------------- Definitions -------------------------*/
#define BLOCK_T		void*
#define SIZE_T		unsigned int
#define SIZE_SZ		sizeof(SIZE_T)
#define HEADER_SZ	(2 * SIZE_SZ)
#define STATE_T		SIZE_T
#define FREE		0
#define USED		0x80000000
#define SIZE_MASK	(USED ^ 0xFFFFFFFF)

/*---------------- MEMORY ALLOCATOR CLASS --------------*/
class MemoryAllocator
{
private:
/*-----------------	Loacal variables -------------------*/
	BLOCK_T	table;
	SIZE_T	table_length;
	char*	lower_bound;

/*-----------------	Local methods ----------------------*/
	/*	Get block state	*/
	STATE_T	block_state(BLOCK_T block)
	{
		return block == NULL ? NULL : ((SIZE_T*)block)[0] & USED;
	}

	/*	Set block state	*/
	void	set_block_state(BLOCK_T block, STATE_T state)
	{
		if ( block != NULL )
			if (state == USED)
				((SIZE_T*)block)[0] |= USED;
			else
				((SIZE_T*)block)[0] &= SIZE_MASK;
	}

	/*	Get block that is situated in the same row of the table
		and in the same chain as given block	*/
	BLOCK_T	similar_block(BLOCK_T block)
	{
		return block == NULL ? NULL : ((BLOCK_T*)block)[2];
	}

	/*	Set to given reference to another block that is situated in the same row
		of the table and in the same chain as given block	*/
	void	set_similar_block(BLOCK_T block, BLOCK_T similar)
	{
		if ( block != NULL )
			((BLOCK_T*)block)[2] = similar;
	}

	/*	Get block size with header	*/
	SIZE_T	block_size(BLOCK_T block)
	{
		return block == NULL ? NULL : ((SIZE_T*)block)[0] & SIZE_MASK;
	}

	/*	Get size of previous block with header	*/
	SIZE_T	prev_size(BLOCK_T block)
	{
		return block == NULL ? NULL : ((SIZE_T*)block)[1];
	}

	/*	Set block size with header to given block	*/
	void	set_block_size(BLOCK_T block, SIZE_T size)
	{
		if ( block == NULL ) return;
		((SIZE_T*)block)[0] &= USED;
		((SIZE_T*)block)[0] |= SIZE_MASK & size;
	}

	/*	Set size of previous block with header to given block	*/
	void	set_prev_size(BLOCK_T block, SIZE_T size)
	{
		if ( block != NULL )
			((SIZE_T*)block)[1] = size;
	}

	/*	Get previus block	*/
	BLOCK_T prev_block(BLOCK_T block)
	{
		return block == NULL || prev_size(block) == NULL ? NULL : (BLOCK_T)((char*)block - prev_size(block));
	}

	/*	Get next block	*/
	BLOCK_T	next_block(BLOCK_T block)
	{
		return block == NULL || (char*)block + block_size(block) >= lower_bound ? NULL : (BLOCK_T*)((char*)block + block_size(block));
	}

	/*	Get max size of any block that can be represented by specified row of the table	*/
	SIZE_T	row_size(SIZE_T row)
	{
		return (HEADER_SZ + SIZE_SZ) << row;
	}

	/*	Add free block to the table and put it automatically
		to required row in order of block ascending by size	*/
	void	add_block_to_table(BLOCK_T block)
	{
		if ( block != NULL )
			// For each row in table
			for ( SIZE_T row = 0; row < table_length; row++ )
				// If row satisfies size
				if ( block_size(block) <= row_size(row) )
					// For each block in chain
					for ( BLOCK_T current = ((BLOCK_T*)table)[row], *prev = NULL; ; prev = current,  current = similar_block(current) )
						if ( current == NULL || block_size(block) <= block_size(current) )
						{
							set_similar_block(block, current);
							if ( prev == NULL )
								((BLOCK_T*)table)[row] = block;
							else
								set_similar_block(prev, block);
							return;
						}
	}

	/*	Remove specified block from the table for making it used	*/
	void remove_from_table(BLOCK_T block)
	{
		if ( block != NULL )
			// For each row in table
			for ( SIZE_T row = 0; row < table_length; row++ )
				// If row satisfies size
				if ( block_size(block) <= row_size(row) )
					// For each block in chain
					for ( BLOCK_T current = ((BLOCK_T*)table)[row], *prev = NULL; ; prev = current,  current = similar_block(current) )
						if ( current == block )
						{
							if ( prev == NULL )
								((BLOCK_T*)table)[row] = similar_block(current);
							else
								set_similar_block(prev, similar_block(current));
							return;
						}
						else if ( current == NULL )
							return;
	}

	/*	Copy specified count of chars from "source" to "dest"	*/
	void migrate_data(char* source, char* dest, SIZE_T offset, SIZE_T count)
	{
		for (; offset < count; offset++)
			*(dest + offset) = *(source + offset);
	}

/*-----------------	Public methods ---------------------*/
public:
	/* Constructor */
	MemoryAllocator(BLOCK_T memory_space, SIZE_T memory_size)
	{
		/* Assign lower bound*/
		lower_bound = (char*)memory_space + memory_size;
		/* Create table */
		table = memory_space;
		// Get table length
		table_length = 0;
		do	
			((BLOCK_T*)table)[table_length] = NULL;	// Initialize each table row with NULL
		while ( row_size(table_length++) < memory_size - table_length * sizeof(BLOCK_T*) );

		/* Create one block from all the memory given left */
		BLOCK_T block = ((BLOCK_T*)table + table_length);
		// Set to last table row value of  main block offset
		((BLOCK_T*)table)[table_length - 1] = block;
		// Initialize main block
		set_block_size(block, memory_size - table_length * sizeof(BLOCK_T*));
		set_prev_size(block, NULL);
		set_block_state(block, FREE);
		set_similar_block(block, NULL);
	}

	/* Allocate memory */
	BLOCK_T	mem_alloc(SIZE_T size)
	{
		/* Include header to size and increase to multiple of SIZE_SZ */
		size += size % SIZE_SZ == 0 ? HEADER_SZ : HEADER_SZ + SIZE_SZ - size % SIZE_SZ;
		/* For each table row */
		for ( SIZE_T row = 0; row < table_length; row++)
			/* If current row satisfies size */
			if ( size <= row_size(row) )
				/* For each block in chain */
				for ( BLOCK_T block = ((BLOCK_T*)table)[row], *prev_similar = NULL; block != NULL; prev_similar = block, block = similar_block(block) )
					/* If block has enough size */
					if ( block_size(block) >= size )
					{
						/* Set block state to used */
						set_block_state(block, USED);
						/* Remove block from chain */
						if (prev_similar == NULL)
							((BLOCK_T*)table)[row] = similar_block(block);	// Block is first in chain
						else
							set_similar_block(prev_similar, similar_block(block));	// Block not first in chain
						/* If block has enough free space to create new block header */
						if ( block_size(block) - size > HEADER_SZ )
						{
							/* Truncate current block */
							SIZE_T old_size = block_size(block);
							set_block_size(block, size);
							/* Insert and define additional new block */
							BLOCK_T inserted_block = next_block(block);
							set_block_size(inserted_block, old_size - block_size(block));
							set_prev_size(inserted_block, block_size(block));
							set_block_state(inserted_block, FREE);
							BLOCK_T next = next_block(inserted_block);
							/* If inserted block is not last */
							if ( next != NULL )
								/* Change property of next block that defines previous block's size */
								set_prev_size(next, block_size(inserted_block));
							/* Add inserted block to table */
							add_block_to_table(inserted_block);
						}
						return (BLOCK_T)((char*)block + HEADER_SZ);	/* Return block memory offset */
			}
		return NULL;	// Free block of requested size is not found
	}

	/* Free memory */
	void	mem_free(BLOCK_T addr)
	{
		if ( addr == NULL ) return;
		/* Get block offset */
		BLOCK_T block = (BLOCK_T)((char*)addr - HEADER_SZ);
		/* Get previous and next blocks */
		BLOCK_T prev = prev_block(block);
		BLOCK_T next = next_block(block);
		/* Merge current block with both next and previous */
		if ( (next != NULL && block_state(next) == FREE) && (prev != NULL && block_state(prev) == FREE) )
		{
			remove_from_table(prev);
			remove_from_table(next);
			set_block_size(prev, block_size(prev) + block_size(block) + block_size(next));
			next = next_block(prev);
			if (next != NULL)
				set_prev_size(next, block_size(prev));
			add_block_to_table(prev);
		}
		/* Merge current block with previous */
		else if ( prev != NULL && block_state(prev) == FREE )
		{
			remove_from_table(prev);
			set_block_size(prev, block_size(prev) + block_size(block));
			if ( next != NULL)
				set_prev_size(next, block_size(prev));
			add_block_to_table(prev);
		}
		/* Merge current block with next */
		else if ( next != NULL && block_state(next) == FREE )
		{
			remove_from_table(next);
			set_block_state(block, FREE);
			set_block_size(block, block_size(block) + block_size(next));
			next = next_block(block);
			if (next != NULL)
				set_prev_size(next, block_size(block));
			add_block_to_table(block);
		}
		/* Set current block as free without merging */
		else
		{
			set_block_state(block, FREE);
			add_block_to_table(block);
		}
	}

	/* Reallocate memory */
	BLOCK_T	mem_realloc(BLOCK_T addr, SIZE_T size)
	{
		if ( addr == NULL ) return mem_alloc(size);
		/* Get block pointer */
		BLOCK_T block = (BLOCK_T)((char*)addr - HEADER_SZ);
		/* The same size requested */
		if ( size + (size % SIZE_SZ == 0 ? HEADER_SZ : HEADER_SZ + SIZE_SZ - size % SIZE_SZ) == block_size(block) ) return addr;
		/* Try to allocate new memory with user-defined new size */
		BLOCK_T new_addr = mem_alloc(size);
		/* Allocated successfully */
		if ( new_addr != NULL )
		{
			migrate_data((char*)addr, (char*)new_addr, 0, size);
			mem_free(addr);
		}
		/* If coluld not allocate */
		else
		{
			/* Get current, previous and next blocks */
			BLOCK_T next = next_block(block), *prev = prev_block(block);
			/* Get posible size we can receive after free memory */
			SIZE_T posible_size =
				(next != NULL && block_state(next) == FREE) && (prev != NULL && block_state(prev) == FREE) ? block_size(prev) + block_size(block) + block_size(next) :
				(prev != NULL && block_state(prev) == FREE) ? block_size(prev) + block_size(block) :
				(next != NULL && block_state(next) == FREE) ? block_size(next) + block_size(block) :
				block_size(block);
			/* If possible free memory is too small then return NULL */
			if ( posible_size - HEADER_SZ < size ) return NULL;
			/* Possible free size would be enough */
			BLOCK_T data = similar_block(block); // Get first several bytes of data in block
			mem_free(addr);	/* Free current block */
			new_addr = mem_alloc(size); /* Allocate memory */
			set_similar_block((BLOCK_T)((char*)new_addr - HEADER_SZ), data);	// Get first several bytes of data in block
			if ( new_addr == addr ) return addr;	/* The same block returned */
			migrate_data((char*)addr, (char*)new_addr, sizeof(BLOCK_T), size - sizeof(BLOCK_T));
		}
		return new_addr;
	}

	/* Dump memory state to console */
	void	mem_dump()
	{
		SIZE_T count = 0;
		for ( BLOCK_T block = (BLOCK_T*)table + table_length; block != NULL; block = next_block(block), count++ )
			cout << block << ":"	/* Offset */
			<< "\tSize: " << HEADER_SZ << "+" << dec << block_size(block) - HEADER_SZ	/* Header + size*/
			<< "\tState: " << (block_state(block) == FREE ? "FREE" : "USED") << endl;	/* USED/FREE */
		//cout << "Total block count:\t" << count << endl;
		cout << "___________________________________________" << endl;
	}

	/* Dump table to console */
	void	table_dump()
	{
		for ( SIZE_T row = 0; row < table_length; row++)
		{
			SIZE_T count = 0;
			for ( BLOCK_T block = ((BLOCK_T*)table)[row]; block != NULL; block = similar_block(block) )
				count++;
			cout << dec << row << "\t(" << row_size(row) << "):\t" << count << endl;
		}
	}
};
