#include <stdio.h>
#include <io.h>
#include <string.h>
#include <stdlib.h>
#include "scanner.h"



int add_scan_info(scan_info *info, char *path)
{
	scan_info tmp;
	FILE *file = fopen(path, "r+b");
	int	i, count;

	if (!file)
	{
		fcloseall();
		return -1;
	}

	if (EOF == fread(&count, sizeof(int), 1, file))
	{
		count = 1;
		if (EOF == fwrite(&count, sizeof(int), 1, file) ||
			EOF == fwrite(info, sizeof(scan_info), 1, file))
				return -1;
		if (0 == fcloseall())	return -1;
		return 2;
	}

	for (i = 0; i < count; i++)
	{
		if (EOF == fread(&tmp, sizeof(scan_info), 1, file))
		{
			fcloseall();
			return -1;
		}
		if (!strcmp(info->model, tmp.model))
		{
			if (!fcloseall())	return -1;
			return 0;
		}
	}
	count++;
	if (EOF == fseek(file, sizeof(int)+(count-1)*sizeof(scan_info), 0)	||
		EOF == fwrite(info, sizeof(scan_info), 1, file)	||
		EOF == fseek(file, 0, 0)	||
		EOF == fwrite(&count, sizeof(int), 1, file))
	{
		fcloseall();
		return -1;
	}
	if (!fcloseall())	return -1;
	return 1;
}


scan_info *get_rec(char *string)
{
	scan_info *info;
	char *next;
	if (!(info = (scan_info*)malloc(sizeof(scan_info))))	return NULL;

	if (!(next = strstr(string, ";"))) {free(info); return NULL;}
	*next = '\0';
	strcpy(info->model, string);
	string = next + 1;
	
	if (!(next = strstr(string, ";"))) {free(info); return NULL;}
	*next = '\0';
	info->price = atof(string);
	string = next + 1;

	if (!(next = strstr(string, ";"))) {free(info); return NULL;}
	*next = '\0';
	info->x_size = atoi(string);
	string = next + 1;

	if (!(next = strstr(string, ";"))) {free(info); return NULL;}
	*next = '\0';
	info->y_size = atoi(string);
	string = next + 1;

	if (!(next = strstr(string, ";"))) {free(info); return NULL;}
	*next = '\0';
	info->optr = atoi(string);
	string = next + 1;

	if (!(next = strstr(string, ";"))) {free(info); return NULL;}
	*next = '\0';
	info->grey = (char)atoi(string);

	return info;
}

#define string_length	1000

int csv_to_dat(char *source, char *destination)
{
	int count = 0;
	char *string = (char*)malloc(string_length);
	FILE *csv = fopen(source, "rt");
	FILE *dat = fopen(destination, "wb");

	if (!(dat && csv && string))
	{
		fcloseall();
		return -1;
	}

	fwrite(&count, sizeof(int), 1, dat);

	while (!feof(csv))
	{
		scan_info *info;
		fgets(string, string_length, csv);
		info = get_rec(string);
		if (info)
		{
			fwrite(info, sizeof(scan_info), 1, dat);
			free(info);
			count++;
		}
	}

	fseek(dat, 0, 0);
	fwrite(&count, sizeof(int), 1, dat);
	fcloseall();
	return count;
}

scan_info *read_at(int number, char *path)
{
	int count;
	scan_info *info = (scan_info*)malloc(sizeof(scan_info));
	FILE *file = fopen(path, "rb");

	if (!file ||
		!info ||
		!fread(&count, sizeof(int), 1, file)	||
		(number >= count)	||
		EOF == fseek(file, sizeof(int)+number*sizeof(scan_info), 0)	|| 
		EOF == fread(info, sizeof(scan_info), 1, file))
	{
		free(info);
		info = NULL;
	}
	fcloseall();
	return info;
}


int delete_at(int number, char *path)
{
	int i, count;
	scan_info *info = (scan_info*)malloc(sizeof(scan_info));
	FILE *file = fopen(path, "r+b");

	if (!info ||
		!file ||
		EOF == fread(&count, sizeof(int), 1, file) ||
		number >= count)
	{
		fcloseall();
		return -1;
	}

	for (i = number + 1; i < count; i++)
	{
		if (EOF == fseek(file, sizeof(int)+i*sizeof(scan_info), 0) ||
			EOF == fread(info, sizeof(scan_info), 1, file) ||
			EOF == fseek(file, sizeof(int)+(i-1)*sizeof(scan_info), 0) ||
			EOF == fwrite(info, sizeof(scan_info), 1, file))
		{
			fcloseall();
			return -1;
		}
	}
	count--;
	if ((EOF == fseek(file, 0, 0)) ||
		EOF == fwrite(&count, sizeof(int), 1, file)||
		EOF == _chsize(file->_file, sizeof(long)+count*sizeof(scan_info)))
		{
			fcloseall();
			free(info);
			return -1;
		}
	free(info);
	return fcloseall();
}


int get_cheaper_than(double price, char *source, char *destination)
{
	int i, count, result = 0;
	FILE *log = fopen(destination, "w+t");
	FILE *dat = fopen(source, "rb");
	if (!dat	||
		!log	||
		EOF == fread(&count, sizeof(int), 1, dat))
	{
		fcloseall();
		return -1;
	}
	for (i = 0; i < count; i++)
	{
		scan_info info;
		if (EOF == fread(&info, sizeof(scan_info), 1, dat))
		{
			fcloseall();
			return -1;
		}
		if (info.price <= price)
		{
			if (EOF == fprint_info(&info, log))
			{
				fcloseall();
				return -1;
			}
			result++;
		}
	}
	fcloseall();
	return result;
}


void print_info(scan_info *info)
{
	if (!info) printf("NULL pointer!\n\n");
	else
	{
		printf("model = %s\n", info->model);
		printf("gray  = %i\n", info->grey);
		printf("optr  = %i\n", info->optr);
		printf("x_size= %i\n", info->x_size);
		printf("y_size= %i\n", info->y_size);
		printf("price = %f\n", info->price);
		printf("\n");
	}
}

int fprint_info(scan_info *info, FILE *file)
{
	if (!info ||
		EOF == fprintf(file, "model = %s\n", info->model)	||
		EOF == fprintf(file, "gray  = %i\n", info->grey)	||
		EOF == fprintf(file, "optr  = %i\n", info->optr)	||
		EOF == fprintf(file, "x_size= %i\n", info->x_size)	||
		EOF == fprintf(file, "y_size= %i\n", info->y_size)	||
		EOF == fprintf(file, "price = %f\n", info->price)	||
		EOF == fprintf(file, "\n"))
			return -1;
	return 1;
}