#include <iostream>
#include "BinTree.h"

using std::cout;
using std::endl;


bool AskOverride(){
	string o;
	cout << "Overrite coincidences? ('y' - yes; else - do not)" << endl;
	cin >> o;
	return "y" == o;
}

void RequestFromFile(CBinTree *tree){
	cout << "Please, enter file path" << endl;
	string path;
	cin >> path;
	tree->FromFile(path, AskOverride());
}

void RequestAdd(CBinTree *tree){
	cout << "Please, enter values in CSV format" << endl;
	string csv;
	cin >> csv;
	tree->Add(csv, AskOverride());
}

void RequestDestination(CBinTree *tree){
	cout << "Please, enter destination" << endl;
	string destination;
	cin >> destination;
	tree->PrintByDestination(destination);
}

void RequetNumber(CBinTree *tree){
	cout << "Please, enter train number" << endl;
	int trainNumber;
	cin >> trainNumber;
	tree->PrintTrain(trainNumber);
}

void Request(CBinTree *tree){
	cout << "'1' - Load trains from file" << endl;
	cout << "'2' - Add new train" << endl;
	cout << "'3' - Get all trains' info" << endl;
	cout << "'4' - Get train's info by number" << endl;
	cout << "'5' - Get trains by destination" << endl;
	cout << "'0' - Exit program" << endl;
	
	string s;
	cin >> s;
	if ("1" == s) RequestFromFile(tree);
	else if ("2" == s) RequestAdd(tree);
	else if ("3" == s) tree->Print();
	else if ("4" == s) RequetNumber(tree);
	else if ("5" == s) RequestDestination(tree);
	else if ("0" == s) exit(1);
	Request(tree);
}

int main()
{
	Request(new CBinTree());
	return 0;
}