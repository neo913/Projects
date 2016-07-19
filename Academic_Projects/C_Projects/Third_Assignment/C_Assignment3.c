/*
This was the final project of my C programming class.
This program imports data from text files(locations.txt, passenger.txt), 
and then analyses the data.
And finally it exports the data of passengers and locations into detailed.txt file.
Current detailed.txt file is the result of this program.
*/
#include<stdio.h>
#include<string.h>
#include<stdlib.h>
struct Passenger{
	char name[60];
	int start;
	int end;
	int dayOfWeek;
	char day[10];
};
struct Location{
	int number;
	char name[60];
	double price;
};
struct Detail{
	char name[60];
	char start[60];
	char end[60];
	double price;
};
int getSize(FILE *fp);
int readPassenger(FILE *fp, struct Passenger data[]);
int readLocation(FILE *fp, struct Location data[]);
int getDays(struct Passenger *p, int n);
double priceDetail(struct Passenger *p, struct Location *s, int n, int size);
void finalOutput(struct Passenger *p, struct Location *s, struct Detail *d, int psize, int lsize);
double totalpriceCal(struct Detail *d, int size);
void getMost(struct Passenger *p, struct Location *s, int psize, int lsize);
int getTop(int *c, int n);
void stats(struct Passenger *p, int psize);
void writeDetail(FILE *file, struct Passenger *person,struct Location *station,struct Detail *detail, int psize,int lsize);
int main()
{
	int i=0,j=0;
	int state;

	FILE *file=fopen("passenger.txt","rt");
	if(file==NULL)								//if file has a problem
	{
		printf("file open error!\n");
		 return 1;
	}
	int psize = getSize(file);
	struct Passenger person[psize];
	
	psize = readPassenger(file, person);
//	for(i=0;i<10;i++)							//testing for person[]
//		printf("\n%s_%d_%d_%s", person[i].name, person[i].start, person[i].end, person[i].day);
	state=fclose(file);
	if(state!=0)								//if file has a problem
	{
		printf("file close error!\n");
		 return 1;
	}

	file=fopen("locations.txt", "rt");
	if(file==NULL)								//if file has a problem
	{
		printf("file open error!\n");
		 return 1;
	}
	int lsize = getSize(file);
	struct Location station[lsize];
	lsize = readLocation(file,station);
//	for(i=0;i<lsize;i++)							//testing for station[]
//		printf("\n%d_%s_%0.2lf\n", station[i].number, station[i].name, station[i].price);
	state=fclose(file);
	if(state!=0)								//if file has a problem
	{
		printf("file close error!\n");
		 return 1;
	}




	for(i=0;i<psize;i++)
		person[i].dayOfWeek = getDays(person,i);
//	for(i=0;i<10;i++)							//testing for person[].day
//		printf("%s - %d\n", person[i].day, person[i].dayOfWeek);




	file=fopen("detailed.txt", "wt");
	if(file==NULL)								//if file has a problem
	{
		printf("file open error!\n");
		 return 1;
	}
	struct Detail detail[psize];
	writeDetail(file,person,station,detail,psize,lsize);
	state=fclose(file);
	if(state!=0)								//if file has a problem
	{
		printf("file close error!\n");
		 return 1;
	}

//	for(i=0;i<10;i++)								//checke for detail
//		printf("%s : %s to %s - $%0.2lf",detail[i].name, detail[i].start, detail[i].end, detail[i].price);



///////////////////////////////////      Checking Station        ///////////////////////////////////////////
/*
	i = 7;
	printf("\n\n\n\n\n\n");
	printf("Start!!!!!!!!\n");
	printf("Passenger %s\t%d\t%d\t%d\t%s\n", person[i].name,person[i].start,person[i].end,person[i].dayOfWeek,person[i].day);
	printf("Location %d\t%s\t%0.2lf\n", station[i].number, station[i].name, station[i].price);
	printf("Detail %s\t%s\t%s\t%0.2lf\n", detail[i].name, detail[i].start, detail[i].end, detail[i].price);

	printf("\n\n\n\n\n\n");
*/

////////////////////////////////////////////////////////////////////////////////////////////////////////////

	finalOutput(person, station, detail, psize, lsize);

return 0;
}
void finalOutput(struct Passenger *p, struct Location *s, struct Detail *d, int psize, int lsize)
{
	double totalprice;
	double aveprice;
	int i;
	int pcount[7][10];
	double per[7][20];


	totalprice = totalpriceCal(d, psize);
	aveprice = totalprice / psize;
	
	printf("\n");
	printf("Summary Report\n");
	printf("==============\n");
	printf("Total number of Passengers: %d\n", psize);
	printf("Total Revenue:              %0.2lf\n",totalprice);		// $44578335.41
	printf("Average Fare:               %0.2lf\n",aveprice);		//$1902.94

	printf("\n\n");

	printf("The 5 most popular destinations\n");
	printf("-------------------------------\n");
	getMost(p, s, psize,lsize);

	printf("\n\n");

	printf("  Day of Week  |  Passenger Count  | Ridership Percentage\n");
	printf("-----------------------------------------------------------\n");
	stats(p,psize);


}
int getSize(FILE *fp)
{
	int size=0;
	while(feof(fp)==0)
	{
		if(fgetc(fp)=='\n')
			size++;
	}
	fseek(fp, 0, SEEK_SET);
return size;
}
int readPassenger(FILE *fp, struct Passenger data[])
{
	int i;
	int  size = getSize(fp);
	for(i=0;i<size;i++)
		fscanf(fp, "%[^:]:%d:%d:%[^\n]",data[i].name, &data[i].start, &data[i].end, data[i].day);

return size;
}
int readLocation(FILE *fp, struct Location data[])
{
	int i;
	int  size = getSize(fp);
	for(i=0;i<size;i++)
		fscanf(fp, "%d;%[^;];$%lf", &data[i].number, data[i].name, &data[i].price);

return size;
}
int getDays(struct Passenger *p, int i)
{
	if(strcmp(p[i].day,"Sunday") == 0)
		p[i].dayOfWeek = 0;
	else if(strcmp(p[i].day,"Monday") == 0)
		p[i].dayOfWeek = 1;
	else if(strcmp(p[i].day,"Tuesday") == 0)
		p[i].dayOfWeek = 2;
	else if(strcmp(p[i].day,"Wednesday") == 0)
		p[i].dayOfWeek = 3;
	else if(strcmp(p[i].day,"Thursday") == 0)
		p[i].dayOfWeek = 4;
	else if(strcmp(p[i].day,"Friday") == 0)
		p[i].dayOfWeek = 5;
	else if(strcmp(p[i].day,"Saturday") == 0)
		p[i].dayOfWeek = 6;
return p[i].dayOfWeek;
}
double priceDetail(struct Passenger *p, struct Location *s, int n, int size)
{
	double start, end;
	double result=0;
	int i;
	for(i=0;i<size;i++)
	{
		if(p[n].start == s[i].number)
			start = s[i].price;
		if(p[n].end == s[i].number)
			end = s[i].price;

	}
	result = end - start;
	if(result < 0)
		result = -1 * result;
return result;
}
double totalpriceCal(struct Detail *d, int size)
{
	int i;
	double result=0;
	for(i=0;i<size;i++)
		result = result + d[i].price;
return result;
}

	

void getMost(struct Passenger *p, struct Location *s, int psize, int lsize)
{
	int i=0, j=0;
	int t = s[lsize-1].number + 1;	
	int count[t];
	int cal[t];
	int temp;
	int top[5];

	for(i=0;i<t;i++)
		count[i]=0;
	for(i=0;i<5;i++)
		top[i]=0;

	for(i=0;i<psize;i++)		//get count of visit
		for(j=0;j<lsize;j++)
			if(p[i].end == s[j].number)
				count[s[j].number]++;
	for(i=0;i<t;i++)		//make a clone
		cal[i]=count[i];

	for(i=0;i<t;i++)		//ascending order for count[]
		for(j=0;j<t;j++)
			if(count[i] > count[j])
			{
				temp     = count[i];
				count[i] = count[j];
				count[j] = temp;
			}
				
	for(i=0;i<5;i++)		//get TOP 5's station numbers
		for(j=0;j<t+1;j++)
			if( count[i] == cal[j])
				top[i] = j;

	for(i=0;i<5;i++)		//print TOP 5 staion names
		for(j=0;j<lsize;j++)
			if(top[i] == s[j].number)
				printf("%s\n",s[j].name);

}
void writeDetail(FILE *file, struct Passenger *person,struct Location *station,struct Detail *detail, int psize,int lsize)
{
	int i, j;
	for(i=0;i<psize;i++)								//get detail.name
		strcpy(detail[i].name, person[i].name);
	for(i=0;i<psize;i++)								//get detail.start
		for(j=0;j<lsize;j++)
			if(person[i].start == station[j].number)
				strcpy(detail[i].start, station[j].name);
	for(i=0;i<psize;i++)								//get detail.end
		for(j=0;j<lsize;j++)
			if(person[i].end == station[j].number)
				strcpy(detail[i].end, station[j].name);
	for(i=0;i<psize;i++)								//get detail.price
		detail[i].price = priceDetail(person, station, i, lsize);

//	for(i=0;i<10;i++)								//checke for detail
//		printf("%s : %s to %s - $%0.2lf",detail[i].name, detail[i].start, detail[i].end, detail[i].price);

	for(i=0;i<psize;i++)
		fprintf(file, "%s : %s to %s - $%0.2lf", detail[i].name, detail[i].start, detail[i].end, detail[i].price);
}
void stats(struct Passenger *p, int psize)
{
	int i, j;
	int count[0];
	int day[7];	
	char days[7][10]={"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
	int result=0;
	double per[7];

	for(i=0;i<7;i++)
		day[i] = 0;
	for(i=0;i<7;i++)
		for(j=0;j<psize;j++)
			if(p[j].dayOfWeek == i)
				day[i]++;
	for(i=0;i<7;i++)
		result = result + day[i];
	
	for(i=0;i<7;i++)
		per[i]=(double)day[i] * 100 / result;

	for(i=0;i<7;i++)
		printf("  %11s  |  %15d  |  %0.2lf %%\n", days[i], day[i], per[i]);



}
