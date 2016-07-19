//////////////////////////
// Insu Yun 017-747-148 //
// OOP345 P R O J E C T //
// filename: cartoon.h  //
//////////////////////////
#pragma once
#include "object.h"
#include <string>
#include <iostream> 
class cartoon: public object{
private:
	std::string type;
	std::string name;
	std::string likes;
public:
	cartoon();
	~cartoon();
	cartoon(const cartoon&);
	cartoon& operator=(const cartoon & );
	cartoon(cartoon&&);
	cartoon&& operator=(cartoon&&);
	void set(std::vector<std::pair<std::string, std::string>>);
	const std::string to_DSV(const char c=','){
		return type+c+name+c+likes;
	};
	const std::string to_json(int leading_spaces=0){
		std::string space(leading_spaces, ' ');
		return  space+"\"type\":  \""+type+"\",\n"+
			space+"\"name\":  \""+name+"\",\n"+
			space+"\"likes\": \""+likes+"\",\n";
	};
	const std::string get_type();
	const std::string get_name();
	const std::string get_likes();
	void display(std::ostream& os) const;
};
	std::ostream& operator<<(std::ostream& os, const cartoon& c);
