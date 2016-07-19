/*
017-747-148
Insu Yun
Garden.cpp
*/
#include <fstream>
#include <cstring>
#include "Plant.h"
#include "Crop.h"
#include "Garden.h"

//No argument constructor
Garden::Garden(){
	width = 0;
	length = 0;
	NoCrop = 0;
	for(int i=0;i<MAX_CROPS;i++){
		gCrop[i] = Crop();
	}
	map = nullptr;
}
//2 argument constructor
Garden::Garden(int l, int w){
	if(w >0 && l >0 ){
		*this = Garden();
		length = l;
		width = w;
		NoCrop = 0;
		for(int i=0;i<MAX_CROPS;i++){
			gCrop[i] = Crop();
		}
		map = nullptr;
		map = new char[length*width];
		for(int i=0;i<width*length;i++){
				map[i] = ' ';
			}
	}
	else{
		map = nullptr;
		*this = Garden();
	}
}
//Copy constructor
Garden::Garden(const Garden& g){
	if (g.isEmpty() == false){
		map = nullptr;
		*this = g;
	}
}
//Assignment operator
Garden& Garden::operator=(const Garden& g){
	if(this != &g && g.isEmpty() == false && g.map != nullptr){
		map = nullptr;
		*this = Garden();
		width = g.width;
		length = g.length;
		delete [] map;
		map = new char[length*width+1];
		for(int i=0;i<length;i++){
			for(int j=0;j<width;j++){
				map[(width*i)+j] = g.map[(width*i)+j];
			}
		}
	}
	return *this;
}

//Destructor
Garden::~Garden(){
	if(isEmpty() == false){
	delete [] map;
	}
}
//isEmpty function -> Check Garden is empty or not
bool Garden::isEmpty()const{
	if(map == nullptr){
		return true;
	}
	else{
		return false;
	}
}
//Append operator
Garden& Garden::operator+=(const Crop& c){
	if(c.isEmpty() == false && NoCrop < 20){
		gCrop[NoCrop] = c;
		gCrop[NoCrop].place(map, length, width);
		NoCrop++;
	}
	return * this;
}
//Display function
void Garden::display(std::ostream& os)const{
	if(isEmpty() == false){
		os << '+';
		for(int i=0; i<width;i++){
			os<<'-';
		}
		os << '+' << std::endl;		// +-----+
		for(int i=0;i<length;i++){
			os<<'|';
			for(int j=0;j<width;j++){
				os<<map[(width*i)+j];
			}
			os << '|' << std::endl;
		}
		os << '+';
		for (int i = 0; i < width; i++){
			os << '-';
		}
		os << '+' << std::endl;		// +-----+
	}
}
std::ostream& operator<<(std::ostream& os, const Garden& g){
	if (g.isEmpty() == false){
		g.display(os);
	}
	return os;
}

//////////////////////////////////////////////////////////////////////////////////
//                                                                              //
//                              Assignment 3                                    //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////

//out function - This function outputs the current object to the file reference provided using the above format.
void Garden::out(std::ofstream& os)const{
	if (isEmpty() == false){
		os << NoCrop << " " << length << " " << width << std::endl;
		for (int i = 0; i < NoCrop; i++){
			gCrop[i].out(os);
		}
	}
}
//<< operator - This function outputs the current object to the file reference provided in the same manners as outline for out function
std::ofstream& operator<<(std::ofstream& os, const Garden& g){
	if (g.isEmpty() == false){
		g.out(os);
	}
	return os;
}
// >> operator - This function parses the file and attempts to reconstructor the object as described in the file.
//This function primarily focus on reading the first line and controlling how many additional lines are read.
std::ifstream& operator>>(std::ifstream& is, Garden& g){
	if (is.is_open()) {
		int NoCrop;
		int len;
		int wid;

		is >> NoCrop >> len >> wid;
		Garden temp(len, wid);

		for (int i = 0; i < NoCrop; i++){
			Crop tempCrop;
			is >> tempCrop;
			temp += tempCrop;
		}
		if (!temp.isEmpty()){
			g = temp;
		}
	}
	return is;
}
//A one argument constructor that receives a c-style string representing the name of a file
Garden::Garden(const char* filename){
	if (filename != nullptr){
		std::ifstream in(filename);
		if (in.fail()) {
			std::cerr << "Read error";
			in.clear();
		}
		else{
			in >> *this;
		}
	}
	else{
		map = nullptr;
		*this = Garden();
	}
}
//////////////////////////////////////////////////////////////////////////////////
//                                                                              //
//                              Detailed Garden                                 //
//                                                                              //
//////////////////////////////////////////////////////////////////////////////////

//A no argument Constructor - SES
DetailedGarden::DetailedGarden(){
	desc = nullptr;
	desclen = 0;
}
// Three argument constructor that receives a c-style null terminated string, as well as two integers represents the length and width of the Garden.
DetailedGarden::DetailedGarden(const char* d, int l, int w) : Garden(l, w){	//Automatically call Garden::Garden(int, int)
	if (d != nullptr){
		desc = nullptr;
		delete [] desc;
		desc = new char[strlen(d)+1];
		strcpy(desc, d);
		desclen = strlen(desc);
	}
	else{
		desc = nullptr;
		*this = DetailedGarden();
	}
}
//Check this is Empty
bool DetailedGarden::isEmpty() const{
	if (desc == nullptr){
		return true;
	}
	else{
		return false;
	}
}
//A display function
void DetailedGarden::display(std::ostream& os)const {
	Garden::display(os);
	os << desc << std::endl;
}
