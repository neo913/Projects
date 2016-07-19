/*
This Project was developed for Kaprekar's constant.
Using pointers is required for this project.
This program was developed with basic C programming logics.
*/
#include <stdio.h>
int number, tnum;
int a, b, c, d;
int temp, i, j;
int big, small;

int check_number(int number);
void sort_increase(int *a, int *b, int *c, int *d);
void sort_decrease(int *a, int *b, int *c, int *d);
int main()
{
	int line=0, page=0;
	for(number = 1000; number < 10000; number++)
	{
		if(line % 20 == 0)
		{
			printf("\t\t\tKaprekar's constant\n");
			printf("%3c%8c%8c%8c%8c%8c%8c%8c\n",'N','1','2','3','4','5','6','7');
		}
		tnum = number;
		while(1)
		{
			temp = tnum;
			check_number(tnum);
			if(temp == 0)
				break;
			printf("%04d\t",tnum);
			sort_decrease(&a, &b, &c, &d);
			sort_increase(&a, &b, &c, &d);
			tnum = big - small;
			if(tnum == 6174)
			{
				printf("%04d\t\n",tnum);
					line++;
					break;
			}
		};
		if(line % 20 == 0 || number == 9999)
		{
			page++;
			printf("\t\t\t\tPage %d\n", page);
		}
	}
return 0;
}

int check_number(int number)
{
	d = number % 10;
	c = number / 10 % 10;
	b = number / 100 % 10;
	a = number / 1000 % 10;

	if(a == b && b == c && c == d)
		temp = 0;	
return number;
}
void sort_increase(int *a, int *b, int *c, int *d)
{
	int sort[4] = {*a, *b, *c, *d};
	for(j=0;j<4;j++)
		for(i=0;i<3;i++)
			if(sort[i] < sort[i+1])
			{
				temp     = sort[i];
				sort[i]   = sort[i+1];
				sort[i+1] = temp;
			}
	big = sort[0] * 1000 + sort[1] * 100 + sort[2] * 10 + sort[3];
}
void sort_decrease(int *a, int *b, int *c, int *d)
{
	int sort[4] = {*a, *b, *c, *d};
	for(j=0;j<4;j++)
		for(i=0;i<3;i++)
			if(sort[i] > sort[i+1])
			{
				temp     = sort[i];
				sort[i]   = sort[i+1];
				sort[i+1] = temp;
			}
	small = sort[0] * 1000 + sort[1] * 100 + sort[2] * 10 + sort[3];
}
