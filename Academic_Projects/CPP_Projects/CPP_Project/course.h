//////////////////////////
// Insu Yun 017-747-148 //
// OOP345 P R O J E C T //
// filename: course.h   //
//////////////////////////
#pragma once
#include "object.h"
#include <string>
#include <iostream>
#include <vector>
class course: public object{
private:
	std::string co;
	std::string cpa;
	std::string bsd;
public:
	course();
	~course();
	course(const course&);
	course& operator=(const course &);
	course(course&&);
	course&& operator=(course&&);
	void set(std::vector<std::pair<std::string, std::string>>);
	const std::string to_DSV(const char c=','){
		return co+c+cpa+c+bsd;
	};
	const std::string to_json(int leading_space=0){
		std::string space(leading_space, ' ');
		return  space+"\"Name\": \""+co +"\""+",\n"+
			space+"\"CPA\": \""+cpa+"\""+",\n"+
			space+"\"BSD\": \""+bsd+"\""+"\n";
	};
	const std::string get_name();
	const std::string get_cpa();
	const std::string get_bsd();
	void display(std::ostream& os) const;
};
	std::ostream& operator<<(std::ostream& os, const course& co);
