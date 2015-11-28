#pragma once

#define NOMINMAX

#include <iostream>
#include <string>
#include <hash_set>
#include "abstract_qap.h"



template <typename T>
struct LocalOptimaQap : Qap<T>
{
	//////////////////////////////////////////////////////////////////////////
	// Compute solution hash
	//////////////////////////////////////////////////////////////////////////
	unsigned long long computeHash(const vector<int> & array)
	{
		unsigned long long a = 63689L;
		unsigned long long hashCode = 0L;
	
		for (auto i = array.cbegin(); i != array.end(); i++)
		{
			hashCode = hashCode * a + *i;
			a = a * 378551L;
		}
	
		return hashCode;
	}
	
	
	
	//////////////////////////////////////////////////////////////////////////
	// Compute solution cost
	//////////////////////////////////////////////////////////////////////////
	inline T computeCost(const vector<int> & solution)
	{
		T cost = 0;
		for (size_t i = 0; i < size; i++)
			for (size_t j = 0; j < size; j++)
				cost += distances[i][j] * flows[solution[i]][solution[j]];
		return cost;
	}
	
	
	
	//////////////////////////////////////////////////////////////////////////
	// Compute cost delta caused by two elements swap
	//////////////////////////////////////////////////////////////////////////
	inline T computeDelta(const vector<int> & solution, const int i, const int j)
	{
		const auto
			si = solution[i],
			sj = solution[j];

		T delta =
			(distances[i][i] - distances[j][j]) * (flows[sj][sj] - flows[si][si]) +	// Loopback
			(distances[i][j] - distances[j][i]) * (flows[sj][si] - flows[si][sj]);	// Reverse flows directions

		for (size_t k = 0; k < size; k++)
			if (k != i && k != j)
			{
				const register auto sk = solution[k];
				delta +=
					(distances[k][i] - distances[k][j]) * (flows[sk][sj] - flows[sk][si]) +
					(distances[i][k] - distances[j][k]) * (flows[sj][sk] - flows[si][sk]);
			}
			return delta;
	}



	//////////////////////////////////////////////////////////////////////////
	// ij-swap corrective after pq-swap performed, or
	// pq-swap corrective after ij-swap performed,
	// i, j, p, q  are distinct indices
	//////////////////////////////////////////////////////////////////////////
	inline T computeDeltaCorrective(vector<int> & solution, const int i, const int j, const int p, const int q)
	{
		const auto
			si = solution[i],
			sj = solution[j],
			sp = solution[p],
			sq = solution[q];

		return
			(distances[p][i] - distances[p][j] + distances[q][j] - distances[q][i]) *
			(flows[sp][sj] - flows[sp][si] + flows[sq][si] - flows[sq][sj])
			+
			(distances[i][p] - distances[j][p] + distances[j][q] - distances[i][q]) *
			(flows[sj][sp] - flows[si][sp] + flows[si][sq] - flows[sj][sq]);
	}



	//////////////////////////////////////////////////////////////////////////
	// Update deltas of ik-swap and jk-swap after some ij swap is performed
	// Assuming delta of ij-swap is not updated yet
	//////////////////////////////////////////////////////////////////////////
	inline void updateJointDeltas(
		const vector<int> & solution,					// Solution vector
		const int i, const int j, const int k,			// Three distinct indices
		const T delta_ij, T & delta_ik, T & delta_jk)	// References to delta matrix elements to be updated
	{
		const auto
			si = solution[i],
			sj = solution[j],
			sk = solution[k];

		const T new_delta_ik = computeDelta(solution, i, k);

		delta_jk +=
			delta_ik - delta_ij - new_delta_ik -
			(distances[i][j] - distances[i][k] - distances[j][i] + distances[j][k] + distances[k][i] - distances[k][j]) *
			(flows[si][sj] - flows[si][sk] - flows[sj][si] + flows[sj][sk] + flows[sk][si] - flows[sk][sj]);

		delta_ik = new_delta_ik;
	}


	
	//////////////////////////////////////////////////////////////////////////
	// Construct solution using roulette wheel
	//////////////////////////////////////////////////////////////////////////
	inline void constructSolutionLinear(vector<int> & solution, const vector<vector<double>> & matrix)
	{
		// All facilities and locations
		vector<int> locations(size), facilities(size);
		for (size_t i = 0; i < size; i++)
			locations[i] = facilities[i] = i;
	
		// Assign all facilities to all unassigned locations
		while (!locations.empty())
		{
			// Choose random location iterator
			auto location = locations.cbegin() + rand() % locations.size();
	
			// Choose random facility iterator using roulette based on intensity matrix
			double roulette = 0.0;
			for (auto facility = facilities.cbegin(); facility != facilities.cend(); facility++)
				roulette += matrix[*location][*facility];
			double ball = roulette * rand() / (RAND_MAX + 1.0);
			double accumulator = 0.0;
			for (auto facility = facilities.cbegin(); facility != facilities.cend(); facility++)
				if ((accumulator += matrix[*location][*facility]) >= ball)
				{
					solution[*location] = *facility;
					locations.erase(location);
					facilities.erase(facility);
					break;
				}
		}
	}



	//////////////////////////////////////////////////////////////////////////
	// Force solution to local optimum in the neighbor of two elements swap
	//////////////////////////////////////////////////////////////////////////
	inline void toLocalOptimum(vector<int> & solution, T & cost)
	{
		vector< vector<T> > deltas(size, vector<T>(size, numeric_limits<T>::max()));
		for (size_t i = 0; i < size - 1; i++)
			for (size_t j = i + 1; j < size; j++)
				deltas[i][j] = computeDelta(solution, i, j);

		for (;;)
		{
			T minDelta = 0;
			size_t iMin, jMin;
			for (size_t i = 0; i < size - 1; i++)
				for (size_t j = i + 1; j < size; j++)
					if (deltas[i][j] < minDelta)
						minDelta = deltas[iMin = i][jMin = j];

			if (minDelta >= 0)
				return;
			else
			{
				swap(solution[iMin], solution[jMin]);
				cost += minDelta;

				// Update deltas
				for (size_t i = 0; i < size - 1; i++)
					if (i != iMin && i != jMin)
						for (size_t j = i + 1; j < size; j++)
							if (j != iMin && j != jMin)
								deltas[i][j] += computeDeltaCorrective(solution, i, j, iMin, jMin);

				for (size_t k = 0; k < iMin; k++)
					updateJointDeltas(solution, iMin, jMin, k, minDelta, deltas[k][iMin], deltas[k][jMin]);
				for (size_t k = iMin + 1; k < jMin; k++)
					updateJointDeltas(solution, iMin, jMin, k, minDelta, deltas[iMin][k], deltas[k][jMin]);
				for (size_t k = jMin + 1; k < size; k++)
					updateJointDeltas(solution, iMin, jMin, k, minDelta, deltas[iMin][k], deltas[jMin][k]);

				deltas[iMin][jMin] *= -1;
			}
		}
	}
	
	
	
	inline void diversificationResetSolution(vector<vector<double>> & matrix, const vector<int> & solution) 
	{
		for (size_t location = 0; location < size; location++)
			matrix[location][solution[location]] = 1.0;
	}
	
	
	
	inline void diversificationResetMatrix(vector<vector<double>> & matrix) 
	{
		for (size_t location = 0; location < size; location++)
			for (size_t facility = 0; facility < size; facility++)
				matrix[location][facility] = 1.0;
	}
	
	
	
	inline void diversificationResetToAverage(vector<vector<double>> & matrix, const vector<int> & solution) 
	{
		double average = 0.0;
		for (size_t location = 0; location < size; location++)
		{
			for (size_t facility = 0; facility < size; facility++)
				average += matrix[location][facility];
			average -= matrix[location][solution[location]];
		}
			
		average /= size * size;
	
		for (size_t location = 0; location < size; location++)
			matrix[location][solution[location]]  = average;
	}
	
	
	
//#define DUMPING
	
	//////////////////////////////////////////////////////////////////////////
	// Solve QAP
	//////////////////////////////////////////////////////////////////////////
	Result<T> solve(const T costThreshold = 0,									// Min solution cost threshold as stop criterion 
					const long numberOfIterations = LONG_MAX,					// Max number of algorithm iterations as stop criterion
		            const clock_t timeLimit = numeric_limits<clock_t>::max())	// Max execution time limit (ms) after start as stop criterion
	{
		clock_t start_clock = clock();
		Result<T> best;
		best.cost = numeric_limits<T>::max();
		hash_set<unsigned long long> hashCodes;
	
		// Allocate intensity matrix
		vector<vector<double>> matrix(size, vector<double>(size, 1.0));
	
		double costSum = 0.0;
	
		// Main iterations
		for (long iteration = 0; iteration < numberOfIterations && clock() - start_clock < timeLimit; iteration++)
		{
			// Construct new solution using intensity matrix
			vector<int> solution(size);
			//constructSolutionQuadratic(solution, matrix);
			constructSolutionLinear(solution, matrix);
	
			// If already known local optimum suddenly constructed then omit solution
			if (hashCodes.find(computeHash(solution)) != hashCodes.end())
			{
#ifdef DUMPING
				cout << "collision after construction" << endl;
#endif
				// Diversification
				diversificationResetMatrix(matrix);
				continue;
			}
	
			// Compute cost of constructed solution
			T cost = computeCost(solution);
	
			// Force solution to local optimum
			toLocalOptimum(solution, cost);
	
			// Try to add obtained local optimum hash code to hash set
			// If local optimum is already known then omit it
			if (!hashCodes.insert(computeHash(solution)).second)
			{
#ifdef DUMPING
				cout << "collision after optimization\thash count: " << hashCodes.size() << endl;
#endif
				// Diversification
				diversificationResetToAverage(matrix, solution);
				continue;
			}
	
			// Check if obtained solution better than best known
			if (cost < best.cost)
			{
				best.solution = solution;
				best.cost = cost;
				best.iteration = iteration;
				best.duration = clock() - start_clock;
				time(&best.timeStamp);
	
				// Optimum reached
				if (cost <= costThreshold)
					break;
	
				// Print result if there is no stop criterion specified
				if (numberOfIterations == LONG_MAX && costThreshold == 0 && timeLimit == numeric_limits<clock_t>::max())
					cout << best << endl;
			}
	
			// Compute average cost of distinct local optima
			costSum += cost;
			double ralativeCost = costSum / hashCodes.size() / cost;
	
			// Update intensity matrix
			for (size_t location = 0; location < size; location++)
				matrix[location][solution[location]] *= ralativeCost;
		}
		return best;
	}
};