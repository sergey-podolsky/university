#include <iostream>
#include "BinTree.h"
#include <fstream>

using std::cout;
using std::endl;

#define BUFSIZE 1024

CBinTree :: CBinTree(){
	top = NULL;
}

void CBinTree :: add(CTreeNode *node, CTreeNode **root, bool overrite){
	if (!*root)
		*root = node;
	else if (node->m_TrainNumber < (*root)->m_TrainNumber)
		add(node, &(*root)->left, overrite);
	else if (node->m_TrainNumber > (*root)->m_TrainNumber)
		add(node, &(*root)->right, overrite);
	else if (overrite){
		node->left = (*root)->left;
		node->right = (*root)->right;
		free(*root);
		*root = node;
	}
	else free(node);
}

void CBinTree :: Add(const string csv, bool overrite){
	add(new CTreeNode(csv), &top, overrite);
}

void CBinTree :: FromFile(const string path, bool overrite){
	FILE *f;
	char buf[BUFSIZE];
	if(!(f = fopen(path.data(), "r"))){
		cout << "Cannot open file" << endl;
		return;
	}
	while (!feof(f)){
		fgets(buf, BUFSIZE, f);
		Add(buf, overrite);
	}
	fclose(f);
}

void CBinTree :: print(CTreeNode *root){
	if (root){
		print(root->left);
		root->Print();
		print(root->right);
	}
}

void CBinTree :: Print(){
	if (top) print(top);
	else cout << "There is no trains in the CBinTree" << endl;
}

void CBinTree :: printByDestination(const string Destination, CTreeNode *root, int &foundCount){
	if (root){
		printByDestination(Destination, root->left, foundCount);
		if (root->m_Destination == Destination){
			root->Print();
			foundCount++;
		}
		printByDestination(Destination, root->right, foundCount);
	}
}

void CBinTree :: PrintByDestination(const string Destination){
	int foundCount = 0;
	printByDestination(Destination, top, foundCount);
	if (0 == foundCount)
		cout << "No results found" << endl;
}

bool CBinTree :: printTrain(int TrainNumber, CTreeNode *root){
	if (!root)	return false;
	else if (TrainNumber < root->m_TrainNumber)
		return printTrain(TrainNumber, root->left);
	else if (TrainNumber > root->m_TrainNumber)
		return printTrain(TrainNumber, root->right);
	else{
		root->Print();
		return true;
	}
}

void CBinTree :: PrintTrain(int TrainNumber){
	if (!printTrain(TrainNumber, top))
		cout << "No results found" << endl;
}