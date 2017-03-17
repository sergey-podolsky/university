#ifndef __TreeNode
#define __treeNode

#include <string>
using namespace std;

class CTreeNode{
public:
	int m_TrainNumber;
	string m_Destination;
	string m_DepertureTime;
	CTreeNode *left;
	CTreeNode *right;

	CTreeNode();
	CTreeNode(int TrainNumber, const string Destination, const string DepartureTime);
	CTreeNode(const string csv);
	void Print();
};

#endif