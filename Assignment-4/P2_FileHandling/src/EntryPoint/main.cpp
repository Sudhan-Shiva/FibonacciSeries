#include "../Presentation/UserInterface.hpp"

int main() 
{
    CLogger cLogger;
    CUserInterface cUserInterface(cLogger);
    std::thread thread1 (&CLogger::LogDateTime, &cLogger);
    std::thread thread2 (&CUserInterface::HandleUserInterface, &cUserInterface);

    thread1.join();
    thread2.join();
}
