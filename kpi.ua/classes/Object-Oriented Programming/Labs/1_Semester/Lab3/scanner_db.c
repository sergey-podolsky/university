#include <stdio.h>
#include <stdlib.h>
#include "scanner.h"

int main()
{
	scan_info *info;	

	printf("Converted CSV count = %i\n\n", csv_to_dat("Scanners.csv", "Scanners.dat"));
	info = read_at(100, "Scanners.dat");
	delete_at(100, "Scanners.dat");
	add_scan_info(info, "Scanners.dat");
	print_info(read_at(299, "Scanners.dat"));

	printf("cheaper = %i\n", get_cheaper_than(1000.99, "Scanners.dat", "Log.txt"));
	return 0;
}