#pragma once
#ifdef NTHPRIMENUMBER_EXPORTS
#define NTHPRIMENUMBER_API __declspec(dllexport)
#else
#define NTHPRIMENUMBER_API __declspec(dllimport)
#endif

extern "C" NTHPRIMENUMBER_API unsigned int NthPrimeNumber(const unsigned int n);