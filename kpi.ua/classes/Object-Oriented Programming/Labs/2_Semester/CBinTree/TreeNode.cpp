#include <iostream>
#include <stdlib.h>
#include "TreeNode.h"


using std::cout;
using std::endl;


CTreeNode :: CTreeNode(){
	m_TrainNumber = 0;
	m_Destination = "<none>";
	m_DepertureTime = "00:00";
	left = right = NULL;
}

CTreeNode :: CTreeNode(int TrainNumber, const string Destination, const string DepartureTime){
	m_TrainNumber = TrainNumber;
	m_Destination = Destination;
	m_DepertureTime = DepartureTime;
	left = right = NULL;
}

CTreeNode :: CTreeNode(const std::string csv){
	int i1 = csv.find_first_of(";");
	int i2 = csv.find_last_of(";");
	if ((i1 < 0) || (i2 < 0) || (i1 == i2))
		cout << "Error in input CSV format" << endl;
	else{
		m_TrainNumber = atoi(csv.substr(0, i1).data());
		m_DepertureTime = csv.data() + i2 + 1;
		m_Destination = csv.substr(i1 + 1, i2 - i1 - 1);
		left = right = NULL;
	}
}

void CTreeNode :: Print(){
	cout << "Train No: " << m_TrainNumber << endl;
	cout << "Destination: " << m_Destination << endl;
	cout << "Departure Time: " << m_DepertureTime << endl;
	cout << endl;
}