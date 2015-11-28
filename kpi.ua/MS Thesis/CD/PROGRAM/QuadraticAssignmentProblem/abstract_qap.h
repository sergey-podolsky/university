#pragma once
#ifndef __ABSTRACT_QAP_GUARD
#define __ABSTRACT_QAP_GUARD

#include <vector>
#include <algorithm>
#include <time.h>
#include <string>

using namespace std;

#pragma warning( disable : 4996 )	// Disable ctime warning



//////////////////////////////////////////////////////////////////////////
// QAP Computation Result Structure
//////////////////////////////////////////////////////////////////////////
template <typename T>
struct Result
{
	T cost;					// Cost of solution
	vector<int> solution;	// Solution vector
	long iteration;			// Iteration number when solution was found
	clock_t	duration;		// Execution time taken to find solution above
	time_t timeStamp;			// Time stamp when solution above was found


	//////////////////////////////////////////////////////////////////////////
	// Write result to specified output stream
	//////////////////////////////////////////////////////////////////////////
	friend ostream & operator << (ostream & out, const Result<T> & result)
	{
		out << "Duration:\t" << result.duration << "\tmilliseconds" << endl;
		out << "Iteration:\t" << result.iteration << endl;
		out << "Cost:\t\t" << result.cost << endl;
		out << "Time:\t\t" << ctime(&result.timeStamp);
		out << "Solution:\t[ ";
		for_each(result.solution.cbegin(), result.solution.cend(), [](T x) { cout << x << " "; });
		return out << "]" << endl << string(80, '_');
	}



	//////////////////////////////////////////////////////////////////////////
	// Read QAP Result instance from specified input stream
	//////////////////////////////////////////////////////////////////////////
	friend istream & operator >> (istream & in, Result<T> & result)
	{
		// Read size
		size_t size;
		in >> size;

		// Read cost
		in >> result.cost;

		// Read solution vector
		for (size_t i = 0; i < size; i++)
		{
			T element;
			in >> element;
			result.solution.push_back(element);
		}

		// Set current time
		time(&result.timeStamp);
		result.duration = 0;

		return in;
	}



	//////////////////////////////////////////////////////////////////////////
	// Read QAP Result instance from specified file
	//////////////////////////////////////////////////////////////////////////
	static Result<T> fromFile(const string & path)
	{
		ifstream file(path);
		if(!file)
		{
			cout << "Error opening file " << path << endl;
			exit(1);
		}
		Result<T> result;
		file >> result;
		file.close();
		return result;
	}
};



//////////////////////////////////////////////////////////////////////////
// QAP Instance Structure
//////////////////////////////////////////////////////////////////////////
template <typename T>
struct Qap
{
	size_t size;							// Problem size
	vector<vector<T>> distances, flows;		// Distance and flow matrices


	//////////////////////////////////////////////////////////////////////////
	// Read QAP instance from specified input stream
	//////////////////////////////////////////////////////////////////////////
	friend istream & operator >> (istream & in, Qap<T> & qap)
	{
		// Read size
		in >> qap.size;

		// Allocate matrices
		qap.distances = vector<vector<T>>(qap.size, vector<T>(qap.size));
		qap.flows = vector<vector<T>>(qap.size, vector<T>(qap.size));

		// Read distances
		for (size_t i = 0; i < qap.size; i++)
			for (size_t j = 0; j < qap.size; j++)
				in >> qap.distances[i][j];

		// Read flows
		for (size_t i = 0; i < qap.size; i++)
			for (size_t j = 0; j < qap.size; j++)
				in >> qap.flows[i][j];

		return in;
	}



	//////////////////////////////////////////////////////////////////////////
	// Read QAP instance data from specified file
	//////////////////////////////////////////////////////////////////////////
	bool readFromFile(const string & path)
	{
		ifstream file(path);
		if(!file)
		{
			cout << "Error opening file " << path << endl;
			exit(1);
			return false;
		}
		file >> *this;
		file.close();
		return true;
	}



	//////////////////////////////////////////////////////////////////////////
	// Solve QAP
	//////////////////////////////////////////////////////////////////////////
	virtual
	Result<T> solve(const T costThreshold = 0,									// Min solution cost threshold as stop criterion 
					const long numberOfIterations = LONG_MAX,					// Max number of algorithm iterations as stop criterion
		            const clock_t timeLimit = numeric_limits<clock_t>::max())	// Max execution time limit (ms) after start as stop criterion
					= NULL; // Virtual method
};

#endif