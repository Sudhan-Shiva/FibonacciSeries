// The below program demonstrate the use of void function to
// pass void pointer as parameter in callback function.

#include <iostream>
using namespace std;

// Callback function definition
void CallbackFunction(void* data1, void* data2, char dataType)
{
    switch (dataType) {
    case 'i':
        cout << "Callback for integer: " << *(int*)data1 + *(int*)data2
             << endl;
        break;
    case 'd':
        cout << "Callback for double: " << *(double*)data1 + *(double*)data2
             << endl;
        break;
    default:
        cout << "Unsupported data type in callback!"
             << endl;
    }
}

// Function that takes a callback
void PerformOperation(void* data1, void* data2, char dataType,
                      void (*callback)(void*, void* , char))
{
    callback(data1, data2, dataType);
}

int main()
{
    int intValue = 7;
    int secondOperand = 8;
    double doubleValue = 8.12;
    double secondDouble = 7.89;

    // Perform operation with integer and callback
    PerformOperation(&intValue, &secondOperand, 'i', CallbackFunction);

    // Perform operation with double and callback
    PerformOperation(&doubleValue, &secondDouble, 'd', CallbackFunction);

    return 0;
}
