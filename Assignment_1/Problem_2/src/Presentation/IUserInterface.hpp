#include <string>

class IUserInterface
{
    public:
        virtual void PrintWelcome() = 0;
        virtual std::string PerformFunctionOperation() = 0;
        virtual void Run() = 0;
};