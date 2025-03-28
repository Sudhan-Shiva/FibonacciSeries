#ifndef DIVIDE_BY_ZERO_EXCEPTION_HPP
#define DIVIDE_BY_ZERO_EXCEPTION_HPP

#include <exception>
#include <string> 
#include <cstring>

class Cdivide_by_zero_exception : public std::exception
{
    private:
        int m_ErrorCode;
        std::string m_ErrorMessage; 
    public:
        Cdivide_by_zero_exception(int nErrorCode, std::string strErrorMessage) : m_ErrorCode(nErrorCode), m_ErrorMessage(std::move(strErrorMessage)) {};
        const char* what() const noexcept override
        {
            return strcat(m_ErrorMessage.c_str(), std::to_string(m_ErrorCode).c_str());
        }
};

#endif