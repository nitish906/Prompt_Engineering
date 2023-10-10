using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Calculator Console App - Basic Arithmetic Operations\n");

            // Get user inputs for two numbers
            double num1 = GetNumberInput("Enter the first number: ");
            double num2 = GetNumberInput("Enter the second number: ");

            // Display menu and get user choice
            int choice = DisplayMenu();

            switch (choice)
            {
                case 1:
                    PerformOperation(num1, num2, "Addition", (a, b) => a + b);
                    break;
                case 2:
                    PerformOperation(num1, num2, "Subtraction", (a, b) => a - b);
                    break;
                case 3:
                    PerformOperation(num1, num2, "Multiplication", (a, b) => a * b);
                    break;
                case 4:
                    PerformOperation(num1, num2, "Division", (a, b) =>
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Error: Division by zero is not allowed.");
                            return double.NaN;
                        }
                        return a / b;
                    });
                    break;
                case 5:
                    // Additional feature: Decimal precision
                    int decimalPlaces = GetDecimalPlacesInput();
                    Console.WriteLine($"Result with {decimalPlaces} decimal places: {Math.Round(num1, decimalPlaces)}");
                    Console.WriteLine($"Result with {decimalPlaces} decimal places: {Math.Round(num2, decimalPlaces)}");
                    break;
                case 6:
                    // Exit the program
                    Console.WriteLine("Exiting the program. Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static double GetNumberInput(string message)
    {
        double number;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out number))
                return number;
            else
                Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static int GetDecimalPlacesInput()
    {
        int decimalPlaces;
        while (true)
        {
            Console.Write("Enter the number of decimal places: ");
            if (int.TryParse(Console.ReadLine(), out decimalPlaces) && decimalPlaces >= 0)
                return decimalPlaces;
            else
                Console.WriteLine("Invalid input. Please enter a non-negative integer.");
        }
    }

    static int DisplayMenu()
    {
        Console.WriteLine("\nChoose an operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Set Decimal Precision");
        Console.WriteLine("6. Exit");
        while (true)
        {
            Console.Write("Enter your choice (1-6): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 6)
                return choice;
            else
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
        }
    }

    static void PerformOperation(double num1, double num2, string operation, Func<double, double, double> op)
    {
        double result = op(num1, num2);
        Console.WriteLine($"{operation} Result: {result}");
    }
}
