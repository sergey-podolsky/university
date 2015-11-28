#pragma once

#include "abstract_qap.h"


template <typename T>
struct MyTabuQap : Qap<T> 
{
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
	// Solve QAP
	//////////////////////////////////////////////////////////////////////////
	Result<T> solve(
		const T costThreshold = 0,									// Min solution cost threshold as stop criterion 
		const long numberOfIterations = LONG_MAX,					// Max number of algorithm iterations as stop criterion
		const clock_t timeLimit = numeric_limits<clock_t>::max())	// Max execution time limit (ms) after start as stop criterion
	{
		const long tabu_duration = size;
		const long aspiration = 2 * size * size;

		clock_t start_clock = clock();
		Result<T> best;
		best.cost = numeric_limits<T>::max();

		// Construct initial random solution
		vector<int> solution(size);
		for (size_t i = 0; i < size; i++)
			solution[i] = i;
		random_shuffle(solution.begin(), solution.end());
		best.solution = solution;

		// Compute cost
		T cost = 0;
		for (size_t i = 0; i < size; i++)
			for (size_t j = 0; j < size; j++)
				cost += distances[i][j] * flows[solution[i]][solution[j]];
		best.cost = cost;

		// Initialize deltas and tabu
		vector< vector<T> > deltas(size, vector<T>(size));
		vector< vector<long> > tabu(size, vector<long>(size));
		for (size_t i = 0; i < size - 1; i++)
			for (size_t j = i + 1; j < size; j++)
			{
				deltas[i][j] = computeDelta(solution, i, j);
				tabu[i][j] = -long(size * i + j);
			}

			/************************************************************************/
			/* Main loop															*/
			/************************************************************************/
			for (long iteration = 0; iteration < numberOfIterations && clock() - start_clock < timeLimit; iteration++)
			{
				size_t iMin, jMin;
				T minDelta = numeric_limits<T>::max();
				bool already_aspired = false;
				const auto iterationMinusAspiration = iteration - aspiration;
				const T bestCostMinusCost = best.cost - cost;

				for (size_t i = 0; i < size - 1; i++) 
					for (size_t j = i + 1; j < size; j++)
					{
						bool aspired =
							tabu[i][j] < iterationMinusAspiration ||
							deltas[i][j] < bestCostMinusCost;                

						if (aspired && (!already_aspired || already_aspired && deltas[i][j] < minDelta) ||
							!aspired && !already_aspired && tabu[i][j] < iteration && deltas[i][j] < minDelta)
						{
							minDelta = deltas[iMin = i][jMin = j];
							already_aspired |= aspired;
						}
					}

					// Perform swap
					swap(solution[iMin], solution[jMin]);

					// Update cost
					cost += minDelta;

#pragma region	Check if solution better than the best known
					/* best solution improved ?*/
					if (cost < best.cost)
					{
						best.cost = cost;
						best.solution = solution;
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
#pragma endregion

					// Forbid reverse move for a random number of iterations but at least 1
					tabu[iMin][jMin] = iteration + 1 + tabu_duration * rand() / RAND_MAX;


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
			return best;
	}
};