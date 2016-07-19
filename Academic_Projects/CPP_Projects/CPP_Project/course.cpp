//////////////////////////
// Insu Yun 017-747-148 //
// OOP345 P R O J E C T //
// filename: course.cpp //
//////////////////////////
#include "course.h"
#include <string>
#include <iostream>
course::course(){
	co = "";
	cpa = "";
	bsd = "";
}

course::~course(){
}
course::course(const course & c){
	*this = c;
}
course& course::operator=(const course & c){
	if(this != &c){
		co = c.co;
		cpa = c.cpa;
		bsd = c.bsd;
	}
	return *this;
}

course::course(course&& c){
	*this = std::move(c);
}
course&& course::operator=(course&& c){
	if(this != &c){
		co = c.co;
		cpa = c.cpa;
		bsd = c.bsd;
		c.co = "";
		c.cpa = "";
		c.bsd = "";
	}
	return std::move(*this);
}

void course::set(std::vector<std::pair<std::string, std::string>> vec){
	for(auto tmp: vec){
		if(tmp.first == "Name"){
			co = tmp.second;
		}else if(tmp.first == "CPA"){
			cpa = tmp.second;
		}else if(tmp.first == "BSD"){
			bsd = tmp.second;
		}
	}
}
const std::string course::get_name(){
	return co;
}
const std::string course::get_cpa(){
	return cpa;
}
const std::string course::get_bsd(){
	return bsd;
}
void course::display(std::ostream& os) const{
        os << "Line 1- Name: " << co << std::endl;
        os << "Line 2- CPA : " << cpa << std::endl;
        os << "Line 3- BSD : " << bsd << std::endl;
}
std::ostream& operator<<(std::ostream& os, const course& c){
        c.display(os);
        return os;
}
