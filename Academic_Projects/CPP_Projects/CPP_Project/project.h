//////////////////////////
// Insu Yun 017-747-148 //
// OOP345 P R O J E C T //
// filename: project.h  //
//////////////////////////
//-** This file has lots of comments. If you feel it's annoying, delete all commentes **-//
#include "object.h"
#include <fstream>
#include <string>
#include <cstring>
#include <iostream>
namespace project{
template<typename T>
std::vector<T>* readFromJsonLike(std::string filename, T& t){
	std::vector<T>* all = new std::vector<T>;
	std::ifstream file(filename);
	std::string data;

	if(file.is_open()){
//TEST-------------Check which file it is
//std::cout<<"\n------File\""<<filename<<"\" opended---------"<<std::endl;

//-------------Get context of file to string
		getline(file, data, (char)file.eof());
//-----------------Count how many objects in this file
/*
		int objcount = 0;
		size_t obs = 0;
		size_t obe = 0;
		while(obe != data.find_last_of('}')){
			if(obs != 0){
				obs = obe + 1;
			}
			obs = data.find('{', obs);
			obe = data.find('}', obs+1);
			if(obe != std::string::npos){
				objcount++;
			}
		}
*/
//-----------------Now objcount means how many objects in this file.
//-----------------Count how many " in this file
		int count = 0;
		size_t tmp = 0;
		int lines = 0;
		while(tmp != data.find_last_of('\"')){
			tmp = data.find('\"', tmp+1);
			if(tmp != std::string::npos){
				count++;
				if(count % 4 == 0)
					lines++;
			}
		}
/*
//----------------Counting all
std::cout<<std::endl;
std::cout<<"Data is ............."<<data<<std::endl;
std::cout<<"\"count is..........."<<count<<std::endl;
std::cout<<"lines is..........."  <<lines<<std::endl;
std::cout<<"object is..........." <<objcount<<std::endl;
*/

//--------------Declare temp vector and pair
		std::vector<std::string> tmpvec;
		std::vector<std::pair<std::string, std::string>> t_pair;

		size_t get1 = 0, get2 = 0;
		for(int i=0; i < count/2; i++){
			get1 = get2+1;
			get1 = data.find('\"', get1);
			get2 = data.find('\"', get1+1);
			std::string chunk = data.substr(get1+1, get2-get1-1);
			tmpvec.push_back(chunk);
		}
//---------------Result of Parsing
/*
		std::cout<<std::endl;
		for(int i=0; i < (int)tmpvec.size(); i+=2){
			std::cout << "Result........."
			<<tmpvec[i]<<" + "<< tmpvec[i+1] << std::endl;
		}
*/
//std::cout<<std::endl;

//---------------Make pairs to set into course or cartoon
		for(int i=0; i < (int)tmpvec.size(); i+=2){
//std::cout << "Pair..........."<<tmpvec[i]<<" + "<< tmpvec[i+1] << std::endl;
			t_pair.push_back(std::make_pair(tmpvec[i], tmpvec[i+1]));
			t.set(t_pair);
//---------------If pairs become one object
			if((i+2) % 6 == 0 && i !=0){
//std::cout<<"t is......."<<std::endl<<t<<std::endl;
				(*all).push_back(t);
			}
		}
//---------------Check the (all)
/*
for(int i=0; i< (int)(*all).size(); i++){
	std::cout<<(*all)[i]<<std::endl;
}
*/
	file.close();
	}else{
		std::cout<<"File open error"<<std::endl;
	}
	return all;
}
template<typename T>
int writeToJsonLike(std::vector<T>* list, std::string filename){
	int no_objects_written = 0;
	std::ofstream of;
	of.open(filename.c_str());
	if(of.is_open()){
		of << "[";
		for(auto tmp: *list){
			of << "\n    {\n";
			of << tmp.to_json(8);

			if(no_objects_written >= 0 && no_objects_written != (int)list->size()-1)
				of << "    },";
			else
				of << "    }\n";
			no_objects_written++;
		}
		of << "]\n";
		of.close();
	}
	return no_objects_written;
}
}

