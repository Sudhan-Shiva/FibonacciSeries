#include "..\Presentation\UserInterface.hpp"
#include <string>

//Main method of the program
int main()
{
    LeapYearChecker leapYearChecker;
    UserInterface userInterface(leapYearChecker);
    userInterface.Run();
}