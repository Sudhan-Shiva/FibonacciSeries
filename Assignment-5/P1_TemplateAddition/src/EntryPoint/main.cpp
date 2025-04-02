#include <iostream>
#include <string>

template <typename T> T AddInputs(T firstOperand, T secondOperand)
{
    return firstOperand + secondOperand;
}

int main()
{
    std::cout << "Adding 1 and 2 : " << AddInputs<int>(1, 2) << std::endl;
    std::cout << "Adding 7.65 and 2.455 : " << AddInputs<double>(7.65, 2.455) << std::endl;
    std::cout << "Adding 10.23 and 6.75 : " << AddInputs<float>(10.23, 6.75) << std::endl;
    std::cout << "Concatenating 'First' and 'Second' : " << AddInputs<std::string>("First", "Second") << std::endl;
}