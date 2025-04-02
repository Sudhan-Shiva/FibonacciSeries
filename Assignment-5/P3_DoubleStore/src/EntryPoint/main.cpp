#include <iostream>
#include <limits>

/**
 * @brief Gets a valid double input from the user.
 * 
 * This function prompts the user to enter an double and validates the input.
 * If invalid input is provided, the user is asked to re-enter a valid double.
 * 
 * @param dInputDouble Reference to store the input double.
 */
void GetValidDouble(double &dInputDouble)
{
    while (!(std::cin >> dInputDouble))
    {
        std::cout << "Invalid input. Please enter a valid decimal : ";
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

int main()
{
    std::string strUserChoice;
    double dUserOption;
    while(std::cin >> dUserOption | std::cin >>)
}