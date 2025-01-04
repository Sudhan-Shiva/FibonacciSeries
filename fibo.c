#include <stdio.h>

// Function to generate the Fibonacci series
void generateFibonacciSeries(int n, int fibonacci_series[]) {
    // Handle the case where n is less than or equal to 0
    if (n <= 0) {
        printf("The number of Fibonacci elements must be greater than 0.\n");
        return;
    }

    // Handle the first Fibonacci numbers
    fibonacci_series[0] = 0;
    if (n > 1) {
        fibonacci_series[1] = 1;
    }

    // Generate the remaining Fibonacci numbers
    for (int i = 2; i < n; i++) {
        fibonacci_series[i] = fibonacci_series[i - 1] + fibonacci_series[i - 2];
    }
}

// Function to get only the odd numbers from the Fibonacci series
void getOddNumbers(int n, int fibonacci_series[]) {
    printf("Odd Fibonacci Numbers: ");
    for (int i = 0; i < n; i++) {
        if (fibonacci_series[i] % 2 != 0) {  // Check if the number is odd
            printf("%d ", fibonacci_series[i]);
        }
    }
    printf("\n");
}

void ODDD(int n, int fibonacci_series[]) {
    printf("Odd Fibonacci Numbers: ");
    
    }




int main() {
    int n;
    printf("Enter the number of Fibonacci elements to generate: ");
    scanf("%d", &n);

    // Declare an array to store the Fibonacci series
    int fibonacci_series[n];

    // Generate the Fibonacci series
    generateFibonacciSeries(n, fibonacci_series);

    // Print the entire Fibonacci series
    printf("Fibonacci Series: ");
    for (int i = 0; i < n; i++) {
        printf("%d ", fibonacci_series[i]);
    }
    printf("\n");

    // Call the function to print only the odd Fibonacci numbers
    getOddNumbers(n, fibonacci_series);

    return 0;
}