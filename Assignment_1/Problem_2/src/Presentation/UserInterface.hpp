# pragma once
#include "IUserInterface.hpp"

class UserInterface : public IUserInterface
{
    public:
        void PrintWelcome () override;
        std::string PerformFunctionOperation() override;
        void Run() override;
};