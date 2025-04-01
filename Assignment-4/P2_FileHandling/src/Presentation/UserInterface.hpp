#ifndef USER_INTERFACE_HPP
#define USER_iNTERFACE_HPP

#include "../Application/Logger.hpp"

class CUserInterface
{
    public:
        void HandleUserInterface();
        CUserInterface(CLogger &c_logger);

    private:
        CLogger &m_Logger;
};

#endif