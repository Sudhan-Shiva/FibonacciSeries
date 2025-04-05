#include <iostream>
#include <limits>

/**
 * @brief Validates and gets a valid integer from the user.
 *
 *  @param nInputOperand The variable reference where the input operand will be stored.
 */
void GetValidInteger(int &nInputOperand)
{
    std::cout << "Enter the integer value : ";

    while (!(std::cin >> nInputOperand)) 
    {
        std::cout << "Invalid input. Please enter an integer value : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        std::cout.clear();
    }
}

/**
 * @brief Validates and gets a valid double from the user.
 * 
 * @param dInputOperand The variable reference where the input operand will be stored.
 */
void GetValidDouble(double &dInputOperand)
{
    std::cout << "Enter the double value : ";
    while (!(std::cin >> dInputOperand)) 
    {
        std::cout << "Invalid input. Please enter a double value : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

/**
 * @brief Validates and gets a valid float from the user.
 * 
 * @param fInputOperand The variable reference where the input operand will be stored.
 */
void GetValidFloat(float &fInputOperand)
{
    std::cout << "Enter the float value : ";
    while (!(std::cin >> fInputOperand)) 
    {
        std::cout << "Invalid input. Please enter a float value : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

void CallbackFunction(void* pFirstOperand, void* pSecondOperand, int nDataType)
{
    switch (nDataType) 
    {
        case 1:
            std::cout << "Result of adding integers " << *(int*)pFirstOperand << " and " << *(int*)pSecondOperand << " is "
            << *(int*)pFirstOperand + *(int*)pSecondOperand << "." << std::endl;
            break;
        case 2:
        std::cout << "Result of adding doubles " << *(double*)pFirstOperand << " and " << *(double*)pSecondOperand << " is "
        << *(double*)pFirstOperand + *(double*)pSecondOperand << "." << std::endl;
            break;
        case 3:
        std::cout << "Result of adding floats " << *(float*)pFirstOperand << " and " << *(float*)pSecondOperand << " is "
        << *(float*)pFirstOperand + *(float*)pSecondOperand << "." << std::endl;
            break;
        default:
            std::cout << "Unsupported data type in callback !!!" << std::endl;
    }
}

void PerformAddition(void* pFirstOperand, void* pSecondOperand,int nDataType, void (*pfnCallbackFunction)(void*, void* , int))
{
    pfnCallbackFunction(pFirstOperand, pSecondOperand, nDataType);
}

/**
 * @brief Main function to start the program.
 *  
 * @return Returns 0 on successful execution.
 */
int main()
{
    std::cout << "\n[1] Integer\n[2] Double\n[3] Float\nEnter the datatype : ";
    int nInputOperator;
    std::cin >> nInputOperator;

    switch(nInputOperator)
    {
        case 1 :
            int nFirstOperand;
            int nSecondOperand;

            GetValidInteger(nFirstOperand);
            GetValidInteger(nSecondOperand);

            PerformAddition(&nFirstOperand, &nSecondOperand, nInputOperator, CallbackFunction);
            break;
        
        case 2 :
            double dFirstOperand;
            double dSecondOperand;

            GetValidDouble(dFirstOperand);
            GetValidDouble(dSecondOperand);

            PerformAddition(&dFirstOperand, &dSecondOperand, nInputOperator, CallbackFunction);
            break;

        case 3 :
            float fFirstOperand;
            float fSecondOperand;

            GetValidFloat(fFirstOperand);
            GetValidFloat(fSecondOperand);

            PerformAddition(&fFirstOperand, &fSecondOperand, nInputOperator, CallbackFunction);
            break;
    }

    return 0;
}