#include "pch.h"
#include "NthPrimeNumber.h"

unsigned int NthPrimeNumber(const unsigned int n)
{
    if (n == 0)
    {
        return 0;
    }
    unsigned int i = 1;
    bool isPrime = true;
    unsigned int primeCount = 0;
    while (true)
    {
        isPrime = true;
        for (unsigned int factor = 3; factor < i; factor += 2)
        {
            if (i % factor == 0)
            {
                isPrime = false;
            }
        }
        if (isPrime)
        {
            if (primeCount == n - 1)
            {
                return i;
            }
            primeCount++;
        }
        i += 2;
    }
}