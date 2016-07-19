/*
017-747-148
Insu Yun
Crop.cpp
*/
#include<cstring>
#include<fstream>
#include "Plant.h"
#include "Crop.h"
//no argument constructor
Crop::Crop(){			
	width = 0;
	length = 0;
	xPos = 0;
	yPos = 0;
	cPlant = Plant();
}
//destructor
Crop::~Crop(){
}
//5 argument constructor
Crop::Crop(const Plant& p, int l, int w, int x, int y){
	if(p.isEmpty() == false &&  l > 0 && w > 0 && x > -1 && y > -1){
		cPlant = p;
		length = l;
		width = w;
		xPos = x;
		yPos = y;
	}
	else{
		* this = Crop();
	}
}
//is Empty function -> Check this Crop is empty or not
bool Crop::isEmpty()const{
	if(width == 0 ){
		return true;
	}
	else{
		return false;
	}
}
//Display function -> ostream is added
void Crop::display(std::ostream& os)const{
	int i, j;
	if(length*width > 0){
		os << std::endl;
		for(i=0; i<length; i++){
			for(j=0;j<width; j++){
				os<<cPlant.symbol();
			}
			os<<std::endl;
		}
		os << std::endl;
		cPlant.display(os);
		os << std::endl;
	}
}
//Read function -> Read information from user, if user quit this function, return false
bool Crop::read(const Plant& p){
	bool check = false;
	cPlant = p;
	while(!check){				
		std::cout << "Enter crop length: ";
		std::cin >> length;
		std::cout << "Enter crop width: ";
		std::cin >> width;
		std::cout << "Enter x: ";
		std::cin >> xPos;
		std::cout << "Enter y: ";
		std::cin >> yPos;
		std::cin.ignore();
		if(length > 0 && width > 0 && xPos > -1 && yPos > -1){
			check = true;
		}
		else{
			check = false;
		}
	}
	return check;
}
//Place function -> place crop to map
bool Crop::place(char * map, int l, int w)const{
	int i, j;
	if(isEmpty() == false && map != nullptr){
		for(i=yPos; i<yPos+length; i++){
			for(j=xPos; j<xPos+width; j++){
				map[(i*w)+j] = cPlant.symbol();
			}
		}
		return true;
	}
	else{
		return false;
	}
}
//Non-friend overload operator
std::ostream& operator<<(std::ostream& os, const Crop& c){
	c.display(os);
	return os;
}
//////////////////////////////////////////////////////////////////////////////////
//                                                                              //
//                              Assignment 3                                    //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////

//output function - This function outputs the current Crops information and passes on to the Plant's function
void Crop::out(std::ofstream& os)const{
	if (isEmpty() == false){
		os << length << " " << width << " " << xPos << " " << yPos << " ";
		cPlant.out(os);
	}
}
//<< operator - This function outputs the current object to the file reference provided in the same manners as outline for out function
std::ofstream& operator<<(std::ofstream& os, const Crop& c){
	if (c.isEmpty() == false){
		c.out(os);
	}
	return os;
}
//>> operator - This function parses the file and attempts to reconstructor the object as described in the file.
//Similar to the insertion operator, this function primarily focus on reading in the Crop information.
std::ifstream& operator>>(std::ifstream& is, Crop& c){
	if (is.is_open()){
		int width;
		int length;
		int xPos;
		int yPos;
		Plant cPlant;

		is >> length;
		is.clear();
		is.ignore();
		is >> width;
		is >> xPos;
		is >> yPos;
		is >> cPlant;
		Crop temp(cPlant, length, width, xPos, yPos);
		if (!temp.isEmpty()){
			c = temp;
		}
	}
	return is;
}
