//////////////////////////
// Insu Yun 017-747-148 //
// OOP345 P R O J E C T //
// filename: cartoon.cpp//
//////////////////////////
#include "cartoon.h"
#include <string>
#include <iostream>
cartoon::cartoon(){
	type = "";
	name = "";
	likes = "";
}
cartoon::~cartoon(){
}
cartoon::cartoon(const cartoon & c){
	*this = c;
}
cartoon& cartoon::operator=(const cartoon & c){
	if(this != &c){
		type = c.type;
		name = c.name;
		likes = c.likes;
	}
	return *this;
}
cartoon::cartoon(cartoon&& c){
	*this = std::move(c);
}
cartoon&& cartoon::operator=(cartoon&& c){
	if(this != &c){
		type = c.type;
		name = c.name;
		likes = c.likes;
		c.type = "";
		c.name = "";
		c.likes = "";
	}
	return std::move(*this);
}
void cartoon::set(std::vector<std::pair<std::string, std::string>> vec){
	for(auto tmp: vec){
		if(tmp.first == "type"){
			type = tmp.second;
		}else if(tmp.first == "name"){
			name = tmp.second;
		}else if(tmp.first == "likes"){
			likes = tmp.second;
		}
	}
}
const std::string cartoon::get_type(){
	return type;
}
const std::string cartoon::get_name(){
	return name;
}
const std::string cartoon::get_likes(){
	return likes;
}
void cartoon::display(std::ostream& os) const{
	os << "Line 1- Type: " << type << std::endl;
	os << "Line 2- Name: " << name << std::endl;
	os << "Line 3- Like: " << likes<< std::endl;
}
std::ostream& operator<<(std::ostream& os, const cartoon& c){
	c.display(os);
	return os;
}
