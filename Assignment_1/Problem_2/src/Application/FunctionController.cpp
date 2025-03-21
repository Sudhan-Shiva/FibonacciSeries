#include "FunctionController.hpp"
#include "..\Entity\FunctionContainer.hpp"
#include <string>

FunctionContainer functionContainer;

std::string FunctionController::GetFunctionCallsCount(int functionCalls)
{
    return "The function has been called " + std::to_string(functionCalls)+ " times.";
};

void FunctionController::HandleFunctions(std::string inputOperation)
{
    while(true)
    {
        if(inputOperation == "C")
            functionContainer.CallFunction();
        else if(inputOperation == "R")
            functionContainer.CallFunction(true);
        else
            break;
    }
};