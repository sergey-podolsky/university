#include <tchar.h>
#include <fstream>
#include <iostream>

#include "local_optima_qap.h"
#include "my_tabu_qap.h"
#include "taillard_fant_qap.h"
#include "taillard_tabu_qap.h"
#include "taillard_sa_qap.h"



//////////////////////////////////////////////////////////////////////////
// Measure average result metrics after specified invocation attempts count 
//////////////////////////////////////////////////////////////////////////
template <typename T>
void measureAverageResult(const unsigned attempts,					// Count of attempts to calculate average stats
						  Qap<T> & qap,								// QAP instance
						  const T costThreshold,					// Min solution cost threshold as stop criterion 
						  const long numberOfIterations = LONG_MAX,	// Max number of algorithm iterations as stop criterion
						  const clock_t timeLimit = INT_MAX)		// Max execution time limit (ms) after start as stop criterion
{
	Result<T> average;
	average.cost = 0;
	average.duration = 0;
	average.iteration = 0;

	for (unsigned i = 0; i < attempts; i++)
	{
		cout << "Attempt:\t" << i << endl;

		// Solve QAP
		auto result = qap.solve(costThreshold, numberOfIterations, timeLimit);

		// Dump result
		cout << result << endl;

		// Compute average metrics
		average.cost += result.cost;
		average.iteration += result.iteration;
		average.duration += result.duration;
		average.solution = result.solution;
	}

	// Compute average metrics
	average.cost /= attempts;
	average.iteration /= attempts;
	average.duration /= attempts;
	time(&average.timeStamp);

	// Dump average result and title
	cout << string(35, '-') << "[AVERAGE]" << string(36, '-') << average;
}



//////////////////////////////////////////////////////////////////////////
// Main
//////////////////////////////////////////////////////////////////////////
int _tmain(int argc, _TCHAR* argv[])
{
	typedef double T;
	//const string name = "tai150b";

	// Initialize pseudorandom generator
	//srand((unsigned)time(NULL));
	
	//SaQap qap;
	//FantQap qap;
	//LocalOptimaQap<T> qap;
	//TaillardTabuQap qap;
	MyTabuQap<T> qap;

	cout.precision(32);

	cin >> qap;

	//qap.readFromFile("QAPLIB/QAP Instances/" + name + ".dat");
	//auto optimal = Result<T>::fromFile("QAPLIB/QAP Solutions/" + name + ".sln");

	qap.solve();
	//measureAverageResult(1000, qap, optimal.cost);

	return 0;
}