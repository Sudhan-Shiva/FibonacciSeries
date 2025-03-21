#include "FunctionContainer.hpp"

void FunctionContainer::CallFunction(bool isReset = false)
{
    static int functionCalls;
    if(isReset == false)
        functionCalls++;
    else
        functionCalls = 0;
}