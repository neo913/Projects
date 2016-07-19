/*
017-747-148
Insu Yun
Garden.h
*/
#include<iostream>	//for std::ostream
const int MAX_CROPS = 20;
class Garden{
private:
	int width;
	int length;
	Crop gCrop[MAX_CROPS];
	char *map;
	int NoCrop;
public:
	Garden();
	Garden(const char*); //a3
	Garden(int, int);
	Garden(const Garden&);
	~Garden();
	virtual bool isEmpty()const;			//virtual function
	virtual void display(std::ostream&)const;	//virtual function
	Garden& operator=(const Garden&);
	Garden& operator+=(const Crop& );
	void out(std::ofstream&)const;//a3
};
std::ostream & operator<<(std::ostream& , const Garden& );
std::ofstream& operator<<(std::ofstream&, const Garden&);//a3
std::ifstream& operator>>(std::ifstream&, Garden&);//a3

class DetailedGarden: public Garden{ //a3 DetailedGarden class which is inherited from Garden class
private:
	char * desc;
	int desclen;
public:
	DetailedGarden();
	DetailedGarden(const char*, int, int);
	bool isEmpty() const;
	void display(std::ostream&)const;
};
