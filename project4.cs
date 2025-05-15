using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Temperature Converter");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Celsius to Fahrenheit");
            Console.WriteLine("2. Celsius to Kelvin");
            Console.WriteLine("3. Fahrenheit to Celsius");
            Console.WriteLine("4. Fahrenheit to Kelvin");
            Console.WriteLine("5. Kelvin to Celsius");
            Console.WriteLine("6. Kelvin to Fahrenheit");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice (1-7): ");
            string choice = Console.ReadLine();

            if (choice == "7")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (choice != "1" && choice != "2" && choice != "3" &&
                choice != "4" && choice != "5" && choice != "6")
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                continue;
            }

            double temp = GetValidDoubleInput("Enter the temperature: ");

            double result = 0;
            string fromUnit = "";
            string toUnit = "";

            switch (choice)
            {
                case "1":
                    result = CelsiusToFahrenheit(temp);
                    fromUnit = "°C";
                    toUnit = "°F";
                    break;
                case "2":
                    result = CelsiusToKelvin(temp);
                    fromUnit = "°C";
                    toUnit = "K";
                    break;
                case "3":
                    result = FahrenheitToCelsius(temp);
                    fromUnit = "°F";
                    toUnit = "°C";
                    break;
                case "4":
                    result = FahrenheitToKelvin(temp);
                    fromUnit = "°F";
                    toUnit = "K";
                    break;
                case "5":
                    result = KelvinToCelsius(temp);
                    fromUnit = "K";
                    toUnit = "°C";
                    break;
                case "6":
                    result = KelvinToFahrenheit(temp);
                    fromUnit = "K";
                    toUnit = "°F";
                    break;
            }

            Console.WriteLine($"\n{temp}{fromUnit} = {result:F2}{toUnit}");
        }
    }

    static double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }

    static double CelsiusToKelvin(double c)
    {
        return c + 273.15;
    }

    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }

    static double FahrenheitToKelvin(double f)
    {
        return FahrenheitToCelsius(f) + 273.15;
    }

    static double KelvinToCelsius(double k)
    {
        return k - 273.15;
    }

    static double KelvinToFahrenheit(double k)
    {
        return CelsiusToFahrenheit(KelvinToCelsius(k));
    }

    static double GetValidDoubleInput(string prompt)
    {
        double value = 0;
        bool isValid = false;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out value))
            {
                if (value >= -1000 && value <= 1000)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Out of range. Please enter a number between -1000 and 1000.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (!isValid);

        return value;
    }
}
