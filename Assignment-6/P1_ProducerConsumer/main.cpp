#include <condition_variable>
#include <iostream>
#include <mutex>
#include <thread>
#include <sstream>
#include <queue>

#include "include/DivideByZeroexception.hpp"

std::mutex threadLocker;
std::queue<std::pair<int, char>> producerQueue;
std::condition_variable notifier;

/**
 * @brief Gets a valid operator from the user.
 * 
 * This function prompts the user to enter a valid arithmetic operator (+, -, *, /) or '~' to exit.
 * If an invalid operator is entered, the user is asked to re-enter a valid operator.
 * 
 * @param chOperator Reference to store the input operator.
 */
void GetOperator(char &chOperator)
{
    std::cout << "Enter the operation to be performed (+,-,*,/) [Press '~' to exit] : ";
    while (!(std::cin >> chOperator) || !(chOperator == '+' || chOperator == '-' || chOperator == '*' || chOperator == '/' || chOperator == '~')) 
    {
        std::cout << "Invalid input. Please enter a valid operator (+,-,*,/) [Press '~' to exit] : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

/**
 * @brief Performs the specified arithmetic operation.
 * 
 * This function takes two operands and an operator, then performs the corresponding arithmetic operation.
 * 
 * @param nResult Reference to store the result of the operation.
 * @param nFirstOperand First operand of the arithmetic operation.
 * @param nSecondOperand Second operand of the arithmetic operation.
 * @param chOperator The arithmetic operator.
 */
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
                throw Cdivide_by_zero_exception(-1, "Exception Thrown : Divide by zero exception !!");
            }
            nResult = nFirstOperand / nSecondOperand;
            break;
        case ('~'):
            break;
    }
}

/**
 * @brief Gets a valid operator from the user.
 * 
 * This function prompts the user to enter a valid arithmetic operator (+, -, *, /) or '~' to exit.
 * If an invalid operator is entered, the user is asked to re-enter a valid operator.
 * 
 * @param chOperator Reference to store the input operator.
 */
void GetOperator(char &chOperator)
{
    std::cout << "Enter the operation to be performed (+,-,*,/) [Press '~' to exit] : ";
    while (!(std::cin >> chOperator) || !(chOperator == '+' || chOperator == '-' || chOperator == '*' || chOperator == '/' || chOperator == '~')) 
    {
        std::cout << "Invalid input. Please enter a valid operator (+,-,*,/) [Press '~' to exit] : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

/** 
* @brief Gets a valid integer input from the user.
 * 
 * This function prompts the user to enter an integer and validates the input.
 * If invalid input is provided, the user is asked to re-enter a valid integer.
 * 
 * @param nInputInteger Reference to store the input integer.
 * @param strInputString The prompt message displayed to the user.
 */
void GetInputInteger(int &nInputInteger, const std::string &strInputString)
{
    std::cout << strInputString;
    while (!(std::cin >> nInputInteger)) 
    {
        std::cout << "Invalid input. Please enter a valid integer: ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

/**
 * @brief Gets user input and stores unique double numbers in a set.
 * 
 * This function recursively asks input to the user till a valid double or 'exit' is given.
 * If an unique double is given it is stored in the set, 
 * else if 'exit' is given the prompt stops.
 * 
 * @param strInput A string to store user input.
 * @param setUniqueDoubles A set to store unique double numbers.
 */
void ProducerLoop(std::string &strInput)
{
    threadLocker.lock();
    std::cout << "Enter an integer (type 'stop' to exit) : " << std::endl;

    while (true)
    {
        std::cout << "--> ";
        std::getline(std::cin, strInput);

        if (strInput == "stop")
        {
            break;
        }

        std::stringstream inputStream(strInput);
        double number;
        char chOperator;
        if (inputStream >> number)
        {
            GetOperator(chOperator);
            producerQueue.push({number,chOperator});
            notifier.notify_one();
            break;
        }
        else
        {
            std::cout << "Invalid input. Enter a valid integer (type 'stop' to exit)" << std::endl;
        }
    }

    threadLocker.unlock();
}

void PrintConsumerOutput()
{
    std::pair<int, char> newPair = producerQueue.front();
    producerQueue.pop();
    

}

void ConsumerLoop()
{
    threadLocker.lock();

    notifier.wait(threadLocker);
}