#ifndef __BinTree
#define __BinTree
#include "TreeNode.h"

class CBinTree{
private:
	CTreeNode *top;
	void add(CTreeNode *node, CTreeNode **root, bool overrite);
	void print(CTreeNode *root);
	void printByDestination(const string Destination, CTreeNode *root,  int &foundCount);
	bool printTrain(int TrainNumber, CTreeNode *root);
public:
	CBinTree();
	void Add(const string csv, bool overrite);
	void FromFile(const string path, bool overrite);
	void Print();
	void PrintByDestination(const string Destination);
	void PrintTrain(int TrainNumber);
};

#endif