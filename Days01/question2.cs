using System;
using System.Collections.Generic;

class Program
{
    static double memory = 0;
    static List<string> history = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Calculator Console App - Advanced Features\n");

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
                    // Handle division by zero
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
                    int decimalPlaces = GetDecimalPlacesInput();
                    Console.WriteLine($"Result with {decimalPlaces} decimal places: {Math.Round(num1, decimalPlaces)}");
                    Console.WriteLine($"Result with {decimalPlaces} decimal places: {Math.Round(num2, decimalPlaces)}");
                    break;
                case 6:
                    // Unit Conversion
                    UnitConversion();
                    break;
                case 7:
                    // Memory Functions
                    MemoryFunctions();
                    break;
                case 8:
                    // Show Calculation History
                    ShowHistory();
                    break;
                case 9:
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
        Console.WriteLine("6. Unit Conversion");
        Console.WriteLine("7. Memory Functions");
        Console.WriteLine("8. Show Calculation History");
        Console.WriteLine("9. Exit");
        while (true)
        {
            Console.Write("Enter your choice (1-9): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 9)
                return choice;
            else
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
        }
    }

    static void PerformOperation(double num1, double num2, string operation, Func<double, double, double> op)
    {
        double result = op(num1, num2);
        Console.WriteLine($"{operation} Result: {result}");
        history.Add($"{num1} {operation} {num2} = {result}");
    }

    static void UnitConversion()
    {
        Console.WriteLine("\nChoose a unit conversion:");
        Console.WriteLine("1. Inches to Centimeters");
        Console.WriteLine("2. Pounds to Kilograms");
        int conversionChoice = GetConversionChoice();

        double inputValue = GetNumberInput("Enter the value to convert: ");
        double convertedValue = 0;

        switch (conversionChoice)
        {
            case 1:
                convertedValue = inputValue * 2.54;
                Console.WriteLine($"{inputValue} inches is equal to {convertedValue} centimeters.");
                history.Add($"{inputValue} inches to centimeters = {convertedValue} cm");
                break;
            case 2:
                convertedValue = inputValue * 0.45359237;
                Console.WriteLine($"{inputValue} pounds is equal to {convertedValue} kilograms.");
                history.Add($"{inputValue} pounds to kilograms = {convertedValue} kg");
                break;
        }
    }

    static int GetConversionChoice()
    {
        while (true)
        {
            Console.Write("Enter your choice (1-2): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
                return choice;
            else
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }

    static void MemoryFunctions()
    {
        Console.WriteLine("\nChoose a memory function:");
        Console.WriteLine("1. Store Result");
        Console.WriteLine("2. Retrieve Result");
        int memoryChoice = GetMemoryChoice();

        switch (memoryChoice)
        {
            case 1:
                memory = memoryChoice;
                Console.WriteLine("Result stored in memory.");
                break;
            case 2:
                Console.WriteLine($"Memory Value: {memory}");
                break;
        }
    }

    static int GetMemoryChoice()
    {
        while (true)
        {
            Console.Write("Enter your choice (1-2): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
                return choice;
            else
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }

    static void ShowHistory()
    {
        Console.WriteLine("\nCalculation History:");
        foreach (var calculation in history)
        {
            Console.WriteLine(calculation);
        }
    }
}
