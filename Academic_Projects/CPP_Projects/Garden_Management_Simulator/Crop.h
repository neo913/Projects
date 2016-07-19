/*
017-747-148
Insu Yun
Crop.h
*/
#include<iostream>	//for std::ostream
class Crop{
private:
	int width;
	int length;
	Plant cPlant;
	int xPos;
	int yPos;
public:
        Crop();
        ~Crop();
        Crop(const Plant&, int, int, int, int); 	
        bool isEmpty()const;
        void display(std::ostream&)const;
        bool read(const Plant&);		
        bool place(char * map, int, int) const;	
		void out(std::ofstream&)const;//a3
};
std::ostream& operator<<(std::ostream& , const Crop&);
std::ofstream& operator<<(std::ofstream&, const Crop&);//a3
std::ifstream& operator>>(std::ifstream&, Crop&);//a3

