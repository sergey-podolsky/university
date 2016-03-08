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

#pragma once
#include "stdafx.h"

class SlabAllocator
{
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *			Definitions												 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#define	BLOCK_TYPE		void*
#define	SIZE_TYPE		unsigned int
#define SIZE_LENGTH		sizeof(SIZE_TYPE)
#define MIN_SIZE_DEGREE	2
#define	MIN_BLOCK_SIZE	(1 << MIN_SIZE_DEGREE)
#define	PAGE_SIZE		4096
static const SIZE_TYPE	PAGE_HALF = PAGE_SIZE / 2;


/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *			Descriptor structure									 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#define	DESCRIPTOR	struct Descriptor
struct	Descriptor
{
	DESCRIPTOR*	next;
	DESCRIPTOR*	prev;
	SIZE_TYPE	total_count;
	SIZE_TYPE	free_count;
	SIZE_TYPE*	first_free_block;
	SIZE_TYPE*	page;
};


/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *			Page states												 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#define	FREE_PAGE		3
#define	LAST_BLOCK_PART	2
#define	NOT_LAST_PART	1
#define	MULTIBLOCK		0
#define	STATE_MASK		3
static const SIZE_TYPE	POINTER_MASK = STATE_MASK ^ 0xFFFFFFFF;


/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *			Local variables											 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
SIZE_TYPE*	block_class_table;
SIZE_TYPE*	descriptor_pointer_table;
SIZE_TYPE	page_count;
#define	CLASS_COUNT		(descriptor_pointer_table - block_class_table)
#define	PAGES_OFFSET	(descriptor_pointer_table + page_count)


/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *			Local functions											 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

static inline double log2(double x)
{
	static const double l2 = 1.0 / log(2.0);
	return log(x) * l2;
}

static inline SIZE_TYPE round_size(SIZE_TYPE size)
{
	return size <= MIN_BLOCK_SIZE ? MIN_BLOCK_SIZE : 1 << (SIZE_TYPE)ceil(log2(size));
}

static inline SIZE_TYPE	get_page_state(SIZE_TYPE* descriptor_pointer)
{
	return *descriptor_pointer & STATE_MASK;
}

static void set_page_state(SIZE_TYPE* descriptor_pointer, SIZE_TYPE new_state)
{
	*descriptor_pointer &= POINTER_MASK;
	*descriptor_pointer |= new_state;
}

inline SIZE_TYPE* get_class_by_size(SIZE_TYPE size)
{
	return block_class_table + (size <= MIN_BLOCK_SIZE ? 0 : (SIZE_TYPE)ceil(log2(size)) - MIN_SIZE_DEGREE);
}

inline DESCRIPTOR* get_page_by_descriptor_pointer(SIZE_TYPE* descriptor_pointer)
{
	return (DESCRIPTOR*)((SIZE_TYPE)PAGES_OFFSET + PAGE_SIZE * (descriptor_pointer - descriptor_pointer_table));
}

inline SIZE_TYPE* get_descriptor_pointer_by_page(SIZE_TYPE* page)
{
	return descriptor_pointer_table + ((SIZE_TYPE)page - (SIZE_TYPE)PAGES_OFFSET) / PAGE_SIZE;
}

DESCRIPTOR* search_free_page_sequence(SIZE_TYPE required_count)
{
	for ( SIZE_TYPE* block_class = get_class_by_size(required_count * PAGE_SIZE); block_class < descriptor_pointer_table; block_class++)
		for ( DESCRIPTOR* page_sequence = ((DESCRIPTOR*)block_class)->next; page_sequence != NULL; page_sequence = page_sequence->next )
			if ( page_sequence->total_count >= required_count )
				return page_sequence;
	return NULL;
}

void add_free_page_sequence_to_size_class(DESCRIPTOR* page_sequence, SIZE_TYPE page_count)
{
	// Set count of free pages
	page_sequence->total_count = page_count;
	// Get size class
	SIZE_TYPE* size_class = get_class_by_size(page_count * PAGE_SIZE);
	// Insert sequence into chain in order of ascending sequences
	for ( DESCRIPTOR* enumerator = (DESCRIPTOR*)size_class; ; enumerator = enumerator->next )
		if ( enumerator->next == NULL || enumerator->next->total_count >= page_count )
		{
			page_sequence->next = enumerator->next;
			page_sequence->prev = enumerator;
			enumerator->next = page_sequence;
			if ( page_sequence->next != NULL )
				page_sequence->next->prev = page_sequence;
			break;
		}
}

void remove_node_from_chain(DESCRIPTOR* descriptor)
{
	DESCRIPTOR *next = descriptor->next, *prev = descriptor->prev;
	prev->next = next;
	if ( next != NULL ) next->prev = prev;
}

SIZE_TYPE* allocate_multipage_block(SIZE_TYPE size)
{
	// Required page count
	SIZE_TYPE required_count = (SIZE_TYPE)ceil((double)size / PAGE_SIZE);
	// Get page sequence of required count
	DESCRIPTOR* page_sequence = search_free_page_sequence(required_count);
	if ( page_sequence == NULL ) return NULL;
	// Break chain
	remove_node_from_chain(page_sequence);
	// Set each page state to used
	SIZE_TYPE* descriptor_pointer = get_descriptor_pointer_by_page((SIZE_TYPE*)page_sequence);
	for ( SIZE_TYPE i = 0; i < required_count - 1; i++ )
		set_page_state(descriptor_pointer++, NOT_LAST_PART);
	set_page_state(descriptor_pointer++, LAST_BLOCK_PART);
	// Count of free pages left
	SIZE_TYPE left_count = ((DESCRIPTOR*)page_sequence)->total_count - required_count;
	// If free pages left
	if ( left_count > 0 )
		add_free_page_sequence_to_size_class(get_page_by_descriptor_pointer(descriptor_pointer), left_count);
	// return address
	return (SIZE_TYPE*)page_sequence;
}

void free_multipage_block(SIZE_TYPE* descriptor_pointer)
{
	// Set each page state to free
	SIZE_TYPE* enumerator = descriptor_pointer;
	while ( get_page_state(enumerator) == NOT_LAST_PART )
		set_page_state(enumerator++, FREE_PAGE);
	set_page_state(enumerator++, FREE_PAGE);
	// Get free pages before current block
	SIZE_TYPE* before = descriptor_pointer;
	while ( before - 1 >= descriptor_pointer_table && get_page_state(before - 1) == FREE_PAGE )
		before--;
	// If there are free pages before then remove them from size class
	if ( descriptor_pointer - before > 0 )
		remove_node_from_chain(get_page_by_descriptor_pointer(before));
	// Get free pages after current block
	SIZE_TYPE* after = enumerator;
	while ( after < PAGES_OFFSET && get_page_state(after) == FREE_PAGE )
		after++;
	// If there are free pages after then remove them from size class
	if ( after - enumerator > 0 )
		remove_node_from_chain(get_page_by_descriptor_pointer(enumerator));
	// Merge all free pages and add them to size class
	add_free_page_sequence_to_size_class(get_page_by_descriptor_pointer(before), after - before);
}

SIZE_TYPE* allocate_little_block(SIZE_TYPE size)
{
		// Get block size class
		SIZE_TYPE* size_class = get_class_by_size(size);
		// If class contains free blocks
		if ( *size_class != NULL )
		{
			// Get descriptor
			DESCRIPTOR* descriptor = (DESCRIPTOR*)*size_class;
			// Remove first block from free block list
			SIZE_TYPE* first_free_block = descriptor->first_free_block;
			descriptor->first_free_block = (SIZE_TYPE*)*first_free_block;
			// If page is full then remove it from size class
			if ( --descriptor->free_count == 0 )
				remove_node_from_chain(descriptor);
			// return address
			return first_free_block;
		}
		else
		{
			// Allocate single page
			SIZE_TYPE* page = (SIZE_TYPE*)mem_alloc(PAGE_SIZE);
			if ( page == NULL ) return NULL;
			// Result
			SIZE_TYPE* address;
			// Descriptor
			DESCRIPTOR* descriptor;
			// Round size as degree of 2
			size = round_size(size);
			// If block size fits to descriptor size then create descriptor inside page
			if ( round_size(sizeof(DESCRIPTOR)) == size )
			{
				descriptor = (DESCRIPTOR*)page;
				// Set total block count
				descriptor->total_count = PAGE_SIZE / size - 1;
				// Set free block count
				descriptor->free_count = descriptor->total_count - 1;
				// Set first free block inside page
				descriptor->first_free_block = (SIZE_TYPE*)((SIZE_TYPE)page + 2 * size);
				// Set address
				address = (SIZE_TYPE*)((SIZE_TYPE)page + size);
			}
			else
			{
				// Allocate memory for descriptor
				descriptor = (DESCRIPTOR*)mem_alloc(sizeof(DESCRIPTOR));
				// If returned NULL then return NULL
				if ( descriptor == NULL )
				{
					mem_free(page);
					return NULL;
				}
				// Set total block count
				descriptor->total_count = PAGE_SIZE / size;
				// Set first free block inside page
				descriptor->first_free_block = (SIZE_TYPE*)((SIZE_TYPE)page + size);
				// Set free block count
				descriptor->free_count = descriptor->total_count - 1;
				// Set address
				address = page;
			}
			// Set descriptor page
			descriptor->page = page;
			// Set descriptor pointer in descriptor table to descriptor address
			*get_descriptor_pointer_by_page(page) = (SIZE_TYPE)(descriptor);
			// Initialize free block list references
			SIZE_TYPE* free_block = descriptor->first_free_block;
			for ( SIZE_TYPE i = 0; i < descriptor->free_count - 1; i++ )
				free_block = (SIZE_TYPE*)(*free_block = (SIZE_TYPE)free_block + size);
			// Add page to block size class of one page that was found earlier
			descriptor->next = (DESCRIPTOR*)*size_class;
			descriptor->prev = (DESCRIPTOR*)size_class;
			*size_class = (SIZE_TYPE)descriptor;
			if ( descriptor->next != NULL )
				descriptor->next->prev = descriptor;
			// Return address
			return address;
		}
}

void free_little_block(SIZE_TYPE* block)
{
	// Get descriptor pointer
	SIZE_TYPE* descriptor_pointer = get_descriptor_pointer_by_page((SIZE_TYPE*)block);
	// Get page address
	DESCRIPTOR* page = get_page_by_descriptor_pointer(descriptor_pointer);
	// Get page descriptor
	DESCRIPTOR* descriptor = (DESCRIPTOR*)*descriptor_pointer;
	// If page is free
	if ( ++descriptor->free_count == descriptor->total_count )
	{
		// Remove descriptor
		if ( descriptor != page )
			mem_free(descriptor);
		// Remove page from multiblock page list
		remove_node_from_chain(descriptor);
		// Free page
		set_page_state(descriptor_pointer, LAST_BLOCK_PART);
		mem_free(page);
	}
	// If page was full before
	else if ( descriptor->free_count == 1 )
	{
		// Get block size class
		SIZE_TYPE* size_class = get_class_by_size(PAGE_SIZE / (descriptor == page ? descriptor->total_count + 1 : descriptor->total_count));
		// Add page to block size class of one page that was found earlier
		descriptor->next = (DESCRIPTOR*)*size_class;
		descriptor->prev = (DESCRIPTOR*)size_class;
		*size_class = (SIZE_TYPE)descriptor;
		if ( descriptor->next != NULL )
			descriptor->next->prev = descriptor;
	}
}


/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *			Public methods											 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
public:

/*====================== Constructor ================================*/
SlabAllocator(BLOCK_TYPE memory_space, SIZE_TYPE memory_size)
{
	// Create table of block classes
	descriptor_pointer_table = block_class_table = (SIZE_TYPE*)memory_space;
	for ( SIZE_TYPE class_size = MIN_BLOCK_SIZE / 2; class_size < ((memory_size - CLASS_COUNT * SIZE_LENGTH) / (PAGE_SIZE + SIZE_LENGTH)) * PAGE_SIZE; class_size *= 2 )
		*(descriptor_pointer_table++) = NULL;
	// Create table of descriptor pointers
	page_count = (memory_size - CLASS_COUNT * SIZE_LENGTH) / (PAGE_SIZE + SIZE_LENGTH);
	for (SIZE_TYPE i = 0; i < page_count; i++)
		set_page_state(descriptor_pointer_table + i, FREE_PAGE);
	// Add all pages to last (the biggest) class
	block_class_table[CLASS_COUNT - 1] = (SIZE_TYPE)PAGES_OFFSET;
	DESCRIPTOR* free_sequence = (DESCRIPTOR*)PAGES_OFFSET;
	free_sequence->total_count = page_count;
	free_sequence->next = NULL;
	free_sequence->prev = (DESCRIPTOR*)(block_class_table + CLASS_COUNT - 1);
}

/*====================== Allocate memory ============================*/
BLOCK_TYPE	mem_alloc(SIZE_TYPE size)
{
	if ( size > PAGE_HALF )
		return allocate_multipage_block(size);
	else
		return allocate_little_block(size);
}

/*====================== Free memory ================================*/
void	mem_free(BLOCK_TYPE block)
{
	// Get page descriptor pointer
	SIZE_TYPE* descriptor_pointer = get_descriptor_pointer_by_page((SIZE_TYPE*)block);
	// If page state is block part then
	if ( get_page_state(descriptor_pointer) != MULTIBLOCK )
		free_multipage_block(descriptor_pointer);
	else
		free_little_block((SIZE_TYPE*)block);
}

/*====================== Reallocate memory ==========================*/
BLOCK_TYPE	mem_realloc(BLOCK_TYPE addr, SIZE_TYPE new_size)
{
	if ( addr == NULL ) return mem_alloc(new_size);
	SIZE_TYPE* old_block = (SIZE_TYPE*)addr;
	// Get page descriptor pointer
	SIZE_TYPE* descriptor_pointer = get_descriptor_pointer_by_page(old_block);
	// Get old size
	SIZE_TYPE old_size = 1;
	if ( get_page_state(descriptor_pointer) == MULTIBLOCK )
	{
		DESCRIPTOR* descriptor = (DESCRIPTOR*)*descriptor_pointer;
		old_size = PAGE_SIZE / ((SIZE_TYPE*)descriptor == descriptor->page ? descriptor->total_count + 1 : descriptor->total_count);
	}
	else
	{
		while ( get_page_state(descriptor_pointer++) == NOT_LAST_PART )
			old_size++;
		old_size *= PAGE_SIZE;
	}
	// If size is the same then return current block
	if ( old_size == (new_size <= PAGE_HALF ? round_size(new_size) : PAGE_SIZE * (SIZE_TYPE)ceil((double)new_size / PAGE_SIZE)) ) return old_block;
	// Allocate block of new size
	SIZE_TYPE* new_block = (SIZE_TYPE*)mem_alloc(new_size);
	// If could not allocate then return NULL
	if ( new_block == NULL ) return NULL;
	// Copy info from old block to new one
	memcpy(new_block, old_block, min(old_size, new_size));
	// Free old block
	mem_free(old_block);
	// Return new block
	return new_block;
}

/*====================== Dump each page state =======================*/
void mem_dump()
{
	for ( SIZE_TYPE i = 0; i < page_count; i++ )
	{
		SIZE_TYPE state = get_page_state(descriptor_pointer_table + i);
		cout << get_page_by_descriptor_pointer(descriptor_pointer_table + i) << ":\t" <<
			(state == FREE_PAGE ? "Free page" : state == MULTIBLOCK ? "Used multiblock page" : state == LAST_BLOCK_PART ? "Used block part (last page)" : "Used block part (not last page)") << endl;
	}
	cout << "___________________________________________" << endl;
}

/*====================== Dump table with all free blocks ============*/
void table_dump()
{
	SIZE_TYPE* block_class = block_class_table;
	for ( SIZE_TYPE size = MIN_BLOCK_SIZE; block_class < descriptor_pointer_table; size *= 2, block_class++ )
	{
		cout << size << " bytes:" << endl;
		if ( size > PAGE_HALF )
			for ( DESCRIPTOR* page_sequence = ((DESCRIPTOR*)block_class)->next; page_sequence != NULL; page_sequence = page_sequence->next )
				cout << "\t" << page_sequence << ":\t" << page_sequence->total_count << " free pages in free block\n";
		else
			for ( DESCRIPTOR* descriptor = (DESCRIPTOR*)*block_class; descriptor != NULL; descriptor = descriptor->next )
				cout << "\t" << descriptor->page << ":\t" << descriptor->free_count << "/" << descriptor->total_count << " free blocks in page\n";
	}
	cout << "___________________________________________" << endl;
}

};