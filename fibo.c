#include <stdio.h>

void generateFibonacciSeries(int n) {
    // Handle the case where n is less than or equal to 0
    if (n <= 0) {
        printf("The number of Fibonacci elements must be greater than 0.\n");
        return;
    }
    
    // Declare an array to store the Fibonacci series
    int fibonacci_series[n];

    // Handle the first Fibonacci numbers
    fibonacci_series[0] = 0;
    if (n > 1) {
        fibonacci_series[1] = 1;
    }

    // Generate the remaining Fibonacci numbers
    for (int i = 2; i < n; i++) {
        fibonacci_series[i] = fibonacci_series[i - 1] + fibonacci_series[i - 2];
    }

    // Print the Fibonacci series
    printf("Fibonacci Series: ");
    for (int i = 0; i < n; i++) {
        printf("%d ", fibonacci_series[i]);
    }
    printf("\n");
}

int main() {
    int n;
    printf("Enter the number of Fibonacci elements to generate: ");
    scanf("%d", &n);

    generateFibonacciSeries(n);

    return 0;
}
