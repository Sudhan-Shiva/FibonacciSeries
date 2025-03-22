#ifndef USER_INTERFACE_HPP
#define USER_INTERFACE_HPP

#include "IUserInterface.hpp"
#include "..\Application\LeapYearChecker.hpp"

class UserInterface : public IUserInterface
{
    private:
        LeapYearChecker& _leapYearChecker;

    public:
        UserInterface(LeapYearChecker& leapYearChecker);
        int GetInputYear () override;
        void Run() override;
        void PrintNameSize(char *name);
        void GetInputName(char *name, int maximumNameSize);
        void GetSortingOrderChoice(std::string &sortChoice);
        void PrintResults(int numberOfCorrectGuesses);
};

#endif