#include <iostream>
#include <limits>
#include "DivideByZeroException.hpp"

void GetInputInteger(int &nInputInteger,const std::string &strInputString)
{
    std::cout << strInputString ;
    while (!(std::cin >> nInputInteger)) 
    {
        std::cout << "Invalid input. Please enter a valid integer: ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

void GetOperator(char &chOperator)
{
    std::cout << "Enter the operation to be performed (+,-,*,/) [Press '~' to exit] : ";
    while (!(std::cin >> chOperator) || !( chOperator == '+' || chOperator == '-' || chOperator == '*' || chOperator == '/' || chOperator == '~') ) 
    {
        std::cout << "Invalid input. Please enter a valid operator (+,-,*,/) [Press '~' to exit] : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

void PerformOperation(int &nResult, const int &nFirstOperand, const int &nSecondOperand, const char &chOperator)
{
    switch(chOperator)
    {
        case('+'):
            nResult = nFirstOperand + nSecondOperand;
            break;
        case('-'):
            nResult = nFirstOperand - nSecondOperand;
            break;
        case('*'):
            nResult = nFirstOperand * nSecondOperand;
            break;
        case('/'):
            if(nSecondOperand == 0)
            {
                throw Cdivide_by_zero_exception(7, "Divide by zero exception !!!!");
            }
            nResult = nFirstOperand / nSecondOperand;
            break;
        case ('~'):
            break;
    }
}


int main()
{
    int nFirstInteger = 0, nSecondInteger = 0, nResult = 0; 
    GetInputInteger(nFirstInteger, "Enter the first integer : ");
    GetInputInteger(nSecondInteger, "Enter the second integer : ");
    char chOperator;
    GetOperator(chOperator);
    try
    {
        PerformOperation(nResult, nFirstInteger, nSecondInteger, chOperator);
        if(chOperator !=  '~')
            std::cout << "The result is : " << nResult << std::endl ;
        else
            std::cout << "Exited Successfully...." << std::endl;
    }
    catch(Cdivide_by_zero_exception &CaughtException)
    {
        std::cout << CaughtException.what() << std::endl;
        std::cout << "Error Code : " << CaughtException.GetErrorCode() << std::endl;
    }
}