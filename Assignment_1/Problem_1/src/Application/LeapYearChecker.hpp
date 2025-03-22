#ifndef LEAP_YEAR_CHECKER_HPP
#define LEAP_YEARCHECKER_HPP

#include "..\Entity\LeapYear.hpp"
#include <string>

class LeapYearChecker
{
    public:
        std::string CheckLeapYear(int inputYear);
};

#endif