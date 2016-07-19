/*
017-747-148
Insu Yun
Plant.h
*/

#include <iostream>	//for std::ostream
class Plant{
private:
	char pSymbol;
	char pName[21];
public:
        Plant();
        Plant(const char* , char);
        ~Plant();
        bool isEmpty()const;
        char symbol()const;
		char name()const;
		void display(std::ostream&)const;	
		bool read();
		const char* plantName()const;
		void out(std::ofstream&)const;//a3 
};
bool operator==(const Plant&, const Plant&);
std::ostream& operator<<(std::ostream& , const Plant& );
std::ifstream& operator>>(std::ifstream&, Plant&);//a3 
std::ofstream& operator<<(std::ofstream&, const Plant&);//a3
