#include "LeapYearChecker.hpp"
#include <string>

// Returns a string denoting whether the input year is a leap year
std::string LeapYearChecker::CheckLeapYear(int inputYear)
{
    return (IsLeapYear(inputYear) ? ("Year : " + std::to_string(inputYear) + " is a leap year.") : "Year : " + std::to_string(inputYear) + " is not a leap year.");
}
