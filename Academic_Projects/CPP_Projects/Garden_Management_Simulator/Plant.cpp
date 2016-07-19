/*
017-747-148
Insu Yun
Plant.cpp
*/
#include <cstring>
#include <fstream>
#include "Plant.h"

//Constructor with no argument
Plant::Plant(){
	pName[0] = '\0';
	pSymbol = ' ';
}
//Constructor with 2 arguments
Plant::Plant(const char* name , char symbol){
	if(name != nullptr && strlen(name) < 21 && strlen(name) > 0 && symbol != '\0') {
		strcpy(pName, name);
		pSymbol = symbol;
	}
	else{
		* this = Plant();
	}
}
//Destructor -> I don't need to use it
Plant::~Plant(){
}
//isEmpty function -> Check this plant is empty or not
bool Plant::isEmpty()const{
	if(pName[0] == '\0' ||  pSymbol == ' ')
		return true;
	else
		return false;
}
//Simply return current symbol
char Plant::symbol()const{
	return pSymbol;
}
//Simply return plant name
char Plant:: name()const{
	return *pName;
}
//Simply return plant name //Does it really needed? It's redundance
const char* Plant::plantName()const{
	return pName;
}
//Display function -> ostream is added
void Plant::display(std::ostream& os)const{
	if(strcmp(pName,"") != 0 && pSymbol != '\0'){
		os << ' ' << pSymbol << " = " << pName;
	}
}
//Read function -> Read information from user, if user quit this function, return false
bool Plant::read(){
	bool check = false;
	while(!check){
		std::cout << "Plant Symbol: ";
		std::cin >> pSymbol;
		std::cin.clear();
		std::cin.ignore();
		std::cout << "Plant Name: ";
		std::cin.getline(pName, 21);
		if(strcmp(pName,"") != 0 && pSymbol != '\0'){
			check = true ;
		}
		else {
			check = false;
		}
	}
	return check;
}
//Non-friend overloaded operator
std::ostream& operator<<(std::ostream& os, const Plant& p) {
	p.display(os);
	return os;
}
//Non-friend overloaded operator
bool operator==(const Plant& ap, const Plant& bp){
	return ap.symbol() == bp.symbol() && strcmp(ap.plantName(),bp.plantName()) == 0;
}

//////////////////////////////////////////////////////////////////////////////////
//										//
//				Assignment 3					//
//										//
//////////////////////////////////////////////////////////////////////////////////

//out function - This function outputs the current Plants information
void Plant::out(std::ofstream& os)const{
	if (isEmpty() == false){
		os << *this;
	}
}
//<< operator - This function outputs the current object to the file reference provided in the same manners as outline for out function
std::ofstream& operator<<(std::ofstream& os, const Plant& p){
	if (p.isEmpty() == false){
		char symbol = p.symbol();
		const char *name = p.plantName();
		os << symbol << " " << name<<std::endl;
	}
	return os;
}
//>> operator - This function parses the file and attempts to reconstructor the object as described in the file
//		This function replaces the right hand operand with the result.
std::ifstream& operator>>(std::ifstream& is, Plant& p){
	if (is.is_open()){
		char pSymbol;
		char pName[21];

		is >> pSymbol;
		is.getline(pName, 21);
		Plant temp(pName, pSymbol);
		if (!temp.isEmpty()){
			p = temp;
		}
	}
	return is;
}
