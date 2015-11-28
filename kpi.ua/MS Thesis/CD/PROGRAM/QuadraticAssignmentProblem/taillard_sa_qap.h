#pragma  once

#include "abstract_qap.h"

#include <iostream>
#include <fstream>
#include <math.h>
#include <time.h>

using namespace std;


/****************************************************************/
/*
    This programme implement a simulated annealing for the
    quadratic assignment problem along the lines describes in
    the article D. T. Connoly, "An improved annealing scheme for 
    the QAP", European Journal of Operational Research 46, 1990,
    93-100.

    Compiler : g++ or CC should work. 

    Author : E. Taillard, 
             EIVD, Route de Cheseaux 1, CH-1400 Yverdon, Switzerland

    Date : 16. 3. 98

    Format of data file : Example for problem nug5 :

5

0 1 1 2 3
1 0 2 1 2
1 2 0 1 2
2 1 1 0 1
3 2 2 1 0

0 5 2 4 1
5 0 3 0 2
2 3 0 0 0
4 0 0 0 5
1 2 0 5 0

   Additionnal parameters : Number of iterations, number of runs

*/

/********************************************************************/

    
const long n_max = 851;
const long infini = 1399999999;
const long nb_iter_initialisation = 1000; // Connolly proposes nb_iterations/100

typedef long  type_vecteur[n_max];
typedef long type_matrice[n_max][n_max];


/************* random number generators ****************/

const long m = 2147483647; const long m2 = 2145483479; 
const long a12 = 63308; const long q12 = 33921; const long r12 = 12979; 
const long a13 = -183326; const long q13 = 11714; const long r13 = 2883; 
const long a21 = 86098; const long q21 = 24919; const long r21 = 7417; 
const long a23 = -539608; const long q23 = 3976; const long r23 = 2071;
const double invm = 4.656612873077393e-10;
long x10 = 12345, x11 = 67890, x12 = 13579, 
     x20 = 24680, x21 = 98765, x22 = 43210;

double mon_rand()
 {long h, p12, p13, p21, p23;
  h = x10/q13; p13 = -a13*(x10-h*q13)-h*r13;
  h = x11/q12; p12 = a12*(x11-h*q12)-h*r12;
  if (p13 < 0) p13 = p13 + m; if (p12 < 0) p12 = p12 + m;
  x10 = x11; x11 = x12; x12 = p12-p13; if (x12 < 0) x12 = x12 + m;
  h = x20/q23; p23 = -a23*(x20-h*q23)-h*r23;
  h = x22/q21; p21 = a21*(x22-h*q21)-h*r21;
  if (p23 < 0) p23 = p23 + m2; if (p21 < 0) p21 = p21 + m2;
  x20 = x21; x21 = x22; x22 = p21-p23; if(x22 < 0) x22 = x22 + m2;
  if (x12 < x22) h = x12 - x22 + m; else h = x12 - x22;
  if (h == 0) return(1.0); else return(h*invm);
 }

long unif(long low, long high)
 {return(low + long(double(high - low + 1) *  mon_rand() ));
 }

/************************** sa for qap ********************************/

long calc_delta_complet2(long n, type_matrice & a, type_matrice & b,
                         type_vecteur & p, long r, long s)
 {long d;
  d = (a[r][r]-a[s][s])*(b[p[s]][p[s]]-b[p[r]][p[r]]) +
      (a[r][s]-a[s][r])*(b[p[s]][p[r]]-b[p[r]][p[s]]);
  for (long k = 1; k <= n; k = k + 1) if (k!=r && k!=s)
    d = d + (a[k][r]-a[k][s])*(b[p[k]][p[s]]-b[p[k]][p[r]]) +
            (a[r][k]-a[s][k])*(b[p[s]][p[k]]-b[p[r]][p[k]]);
  return(d);
 }

long calcule_cout(long n, type_matrice & a, type_matrice & b, type_vecteur & p)
 {long i, j;
  long c = 0;
  for (i = 1; i <= n; i = i + 1) for (j = 1; j <= n; j = j + 1)
    c = c + a[i][j] * b[p[i]][p[j]];
  return(c);
 }



type_matrice a, b;


struct SaQap : Qap<long>
{
	//////////////////////////////////////////////////////////////////////////
	// Solve QAP
	//////////////////////////////////////////////////////////////////////////
	Result<long> solve(const long costThreshold = 0,								// Min solution cost threshold as stop criterion 
					   const long numberOfIterations = LONG_MAX,					// Max number of algorithm iterations as stop criterion
					   const clock_t timeLimit = numeric_limits<clock_t>::max())	// Max execution time limit (ms) after start as stop criterion

	{
		long n = size;
		for (size_t i = 0; i < size; i++)
			for (size_t j = 0; j < size; j++)
			{
				a[i + 1][j + 1] = distances[i][j];
				b[i + 1][j + 1] = flows[i][j];
			}


		clock_t start_clock = clock();
		Result<long> best;
		best.solution.resize(size);
		for (size_t i = 0; i < size; i++)
			best.solution[i] = i;
		random_shuffle(best.solution.begin(), best.solution.end());



		type_vecteur p;
		long i, r, s;
		long delta;
		long k = n*(n-1)/2, mxfail = k, nb_fail, iteration;
		long dmin = infini, dmax = 0;
		double t0, tf, beta, tfound, temperature;

		for (i = 1; i <= n; i = i + 1) p[i] = best.solution[i - 1] + 1;
		long current_cost = calcule_cout(n, a, b, p);
		best.cost = current_cost;

		for (iteration = 1; iteration <= nb_iter_initialisation;
			iteration = iteration+1)
		{r = unif(1, n);
		s = unif(1, n-1);
		if (s >= r) s = s+1;

		delta = calc_delta_complet2(n,a,b,p,r,s);
		if (delta > 0)
		{dmin = min(dmin, delta); dmax = max(dmax, delta);}; 
		current_cost += delta;
		swap(p[r], p[s]);
		};
		t0 = dmin + (dmax - dmin)/10.0;
		tf = dmin;
		beta = (t0 - tf)/(numberOfIterations*t0*tf);

		nb_fail = 0;
		tfound = t0;
		temperature = t0;
		r = 1; s = 2;
		for (iteration = 1; iteration <= numberOfIterations - nb_iter_initialisation && clock() - start_clock < timeLimit; iteration = iteration + 1)
		{ temperature = temperature / (1.0 + beta*temperature);

		s++;
		if (s > n)
		{r++; 
		if (r > n - 1) r = 1;
		s = r + 1;
		};

		delta = calc_delta_complet2(n,a,b,p,r,s);
		if ((delta < 0) || (mon_rand() < exp(-double(delta)/temperature)) ||
			mxfail == nb_fail)
		{current_cost = current_cost + delta; swap(p[r], p[s]); nb_fail = 0;}
		else nb_fail++;

		if (mxfail == nb_fail) {beta = 0; temperature = tfound;};

#pragma region	Check if solution better than the best known
		/* best solution improved ?*/
		if (current_cost < best.cost)
		{
			tfound = temperature;
			best.cost = current_cost;
			for (k = 0; k < n; k = k + 1)
				best.solution[k] = p[k + 1] - 1;
			best.iteration = iteration;
			best.duration = clock() - start_clock;
			time(&best.timeStamp);

			// Optimum reached
			if (current_cost <= costThreshold)
				break;

			// Print result if there is no stop criterion specified
			if (numberOfIterations == LONG_MAX && costThreshold == 0 && timeLimit == numeric_limits<clock_t>::max())
				cout << best << endl;
		}
#pragma endregion

		}

		return best;
	}
};
