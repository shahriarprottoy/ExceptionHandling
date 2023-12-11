using System;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");

            try
            {
                // Convert the input to an integer using int.Parse().
                int number = int.Parse(Console.ReadLine());
                // Output the input if correct
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Use a try-catch block to handle FormatException if the user enters a non-numeric value.
                // Display an error message in case of an exception.
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");

            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            catch (OverflowException)
            {
                // Display appropriate error messages for different exceptions.
                Console.WriteLine("Error: The entered number is too large or too small for an integer.");
            }
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");

            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            finally
            {
                // Add a finally block to the program.
                Console.WriteLine("Finally block executed, whether an exception was caught or not.");
            }
        }

        // Class for custom exception type
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");

            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    // Modify your number input program to throw NegativeNumberException if the user enters a negative number.
                    throw new NegativeNumberException("Error: Negative numbers are not allowed.");
                }
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            catch (NegativeNumberException ex)
            {
                // Handle this exception in a separate catch block and display an appropriate message.
                Console.WriteLine(ex.Message);
            }
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");

            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());
                CheckNumber(number);
                Console.WriteLine($"You entered: {number}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // In this function, call CheckNumber inside a try block and handle the exception.
                Console.WriteLine(ex.Message);
            }
        }

        // NOTE: You can implement the CheckNumber here
        static void CheckNumber(int number)
        {
            if (number > 100)
            {
                // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
                throw new ArgumentOutOfRangeException(nameof(number), "Error: Number cannot be greater than 100.");
            }
        }

        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");

            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());
                CheckNumberWithLogging(number);
                Console.WriteLine($"You entered: {number}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // In this function, catch the exception in the main program and display the logged message.
                Console.WriteLine($"Logged Exception: {ex.Message}");
            }
        }

        // NOTE: You can implement the CheckNumberWithLogging here
        static void CheckNumberWithLogging(int number)
        {
            try
            {
                if (number > 100)
                {
                    // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
                    throw new ArgumentOutOfRangeException(nameof(number), "Error: Number cannot be greater than 100.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging Exception: {ex.Message}");
                // Re-throw the exception after logging
                throw;
            }
        }
    }
}
