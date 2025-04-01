#include "UserInterface.hpp"


CUserInterface::CUserInterface(CLogger &c_logger) : m_Logger(c_logger) {};

void CUserInterface::HandleUserInterface()
{
    std::cout << "Logging..." << std::endl;
    int nInputOperation;
    std::cout << "\n[0] Exit\n[1] View Logged Files" << std::endl;
    std::cout << "Enter the input operation : ";
    std::cin >> nInputOperation;

    while(nInputOperation != 0)
    {

        switch (nInputOperation)
        {
            case 1:
            {
                m_Logger.PrintListOfFiles("Logs");
                std::cout << "Total Directory Size : " + std::to_string(m_Logger.GetDirectorySize("Logs")) + " bytes" << std::endl;
                break;
            }
        }

        std::cout << "\nLogging....\n\n[0] Exit\n[1] View Logged Files" << std::endl;
        std::cout << "Enter the input operation : ";
        std::cin >> nInputOperation;

    }

    m_Logger.m_shouldStopLogging.store(true);
}