#include "Fraction.hpp"

template <class Val>
void Fraction::Fraction(Val num, Val den) 
	: numerator(num), denomenator(den) {}

template <class Val>
private Fraction<Val> Fraction::addition(Fraction<Val> a, Fraction<Val> b) {
	return Fraction(
			a.numerator * b.denomenator + b.numerator * a.denomenator,
			a.denomenator * b.denomenator
			);
}


