#include <stdio.h>
int main()
{
	int premeter;		//previous meter
	int curmeter;		//current meter
	int con;			//conservation district
	int last;			//last year
	float basic=35.00;		//basic fee
	float unpaid;		//unpaid balance
	float used;			//used water
	float total;		//total balance


	printf("This program calculates a water bill based on the demand charge ($35.00) and a $1.10 per cubic meter use charge.\n\n");
	
	printf("A $2.00 surcharge is added to accounts with an unpaid balance.\n\n");

	printf("If you live in a conservation district, a conservation area rate will apply.\n\n");

	printf("Not meeting the conservations guidelines will result in an overuse charge of 2.0 times the regular rate.\n\n");
	
	printf("Enter unpaid balance, previous, current meter readings and whether you live in a conservation district on separate lines after the prompts.\n\n");

	printf("\nEnter unpaid balance ($): ");
	scanf("%f", &unpaid);
	
	printf("\nEnter previous meter reading: ");
	scanf("%d", &premeter);

	printf("\nEnter current meter reading: ");
	scanf("%d", &curmeter);
	
	used=curmeter-premeter;			//get used meter
	
	printf("\nDo you live in a conservation district? (Enter 0 for no and 1 for yes): ");
	scanf("%d", &con);

	if(con==1)			//if he/she lives in a conservation district ONLY.
	{
		printf("\nSince you live in a conservation district, you are required to use no more than 95.0%% of the amount of water you used in the same quarter last year in order to qualify for the rate of $1.10 per cubic meter.\n\n");
		
		printf("Enter amount of water used in the same quarter last year: ");
		scanf("%d", &last);
	
		printf("\nUse charge is at 2.00 times normal rate since use of %.0f units exceeds 95.0%% of last year's %d-unit use.\n", used, last);
		
		if(last*0.95<used)		//for 2.00 times charge(If he/she used over 95% ONLY)
			used=used*2;
	}
	
	if(unpaid>0)
	{
		printf("\nBill includes $2.00 late charge on unpaid balance of $%.2f\n", unpaid);		//Because I've already added 2.00
		unpaid=unpaid+2.00; //surcharge for unpaid
	}



	total=basic+unpaid+(used)*1.1;
	
	printf("\nTotal due = $ %.2f\n\n", total);

	return 0;
}
