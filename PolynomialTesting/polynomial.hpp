// Polynomial representation
// 2017 Patrick Lewis


#if !defined(POLYNOMIAL_HPP)
#define POLYNOMIAL_HPP

#if defined(_MSC_VER)
	#pragma once
#endif

#include <vector>

namespace math {

template <class Value_T>
class polynomial
{
public:
// Types

	//! The type of this <code>polynomial</code>.
	typedef polynomial<Value_T> this_type;

	//! The type of a value.
	typedef Value_T value;

private:
// Member variables

	//! The polynomial representation
	std::vector<value> poly;

public:
// Element access

	//! Get the value of the element at the given exponent
	value * operator [] (size_t index) {
		_ASSERT(index < poly.size());
		return poly.at(index);
	}

	//! Get the value of the element at the given exponent
	const value * operator [] (size_t index) const {
		_ASSERT(index < poly.size());
		return poly.at(index);
	}

	//! Get the value of the element at the given exponent
	value * at(size_t index) {
		_ASSERT(index < poly.size());
		return poly.at(index);
	}

	//! Get the value of the element at the given exponent
	const value * at(size_t index) const {
		_ASSERT(index < poly.size());
		return poly.at(index);
	}

	//! Return the degree of the polynomial.
	size_t size() const { return poly.size(); }


// Construction/Destruction

	//! Create an empty <code>polynomial</code>.
	explicit polynomial()
		: poly() {}

	//! Create a <code>polynomial</code> of the specified degree and filled with the
	//! given value.
	explicit polynomial(size_t degree, value v)
		: poly() {
		for (int i = 0; i < degree; ++i)
			poly.push_back(v);
	}

	
	//! Stream constructor
	friend this_type& operator << (this_type &p, value v) {
		p->poly.push_back(v);
		return p;
	}


	//! The copy constructor.





};
}


#endif
