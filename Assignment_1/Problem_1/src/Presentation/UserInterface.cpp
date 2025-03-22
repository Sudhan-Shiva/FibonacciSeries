#include <string>
#include <limits>
#include <iostream>
#include "UserInterface.hpp"

//Constructor
UserInterface::UserInterface(LeapYearChecker& leapYearChecker) : _leapYearChecker(leapYearChecker) {}

//Validates and gets the input year from the user
int UserInterface::GetInputYear()
{
    int inputYear;
    std::cout << "Enter the year : ";
    while (!(std::cin >> inputYear) || inputYear < 0) {
        std::cout << "Invalid input. Please enter an positive integer: ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }

    return inputYear;
}

//Perform the operations of the application
void UserInterface::Run()
{
    std::cout << "Welcome to the leap year game !!! \nYou have 3 tries." << std::endl;
    int numberOfTries = 0;
    int numberOfCorrectGuesses = 0;
    while(numberOfTries <= 2)
    {
        int year = GetInputYear();
        std::string  result = _leapYearChecker.CheckLeapYear(year);
        std::cout<< result << std::endl;
        if(result.find("not") == std::string::npos)
        {
            numberOfCorrectGuesses++;
        }
        std::cout << "Current Score : "+std::to_string(numberOfCorrectGuesses) << std::endl;
        numberOfTries++;
    }

    std::cout << "\nFinal Score : "+std::to_string(numberOfCorrectGuesses) << std::endl;

    PrintResults(numberOfCorrectGuesses);
}

//Prints the final evaluation of the user
void UserInterface::PrintResults(int numberOfCorrectGuesses)
{
    switch (numberOfCorrectGuesses)
    {
    case (0):
        std::cout << "Leap year occurs every four years, but years that are divisible by 100 must be divisible by 400 too." << std::endl;
        std::cout << "Better luck next time !!!" << std::endl;
        break;
    case (1):
        std::cout << "Good try player !!!" << std::endl;
        break;
    case (2):
        std::cout << "You are one of the best !!!" << std::endl;
        break;
    case (3):
        std::cout << "You are officially crowned as a master of finding leap years !!!" << std::endl;
        break;
    }
}
