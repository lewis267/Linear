// PolynomialTesting.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "polynomial.hpp"
#include <iostream>

using namespace math;

int main()
{
	polynomial<int> p();
	polynomial<int> * pp = &p;

	p << 2 << 12 << 0 << 4;

	char c;
	std::cin >> c;
    return 0;
}

