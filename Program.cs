using System;

// Represents a type of yarn
public class Yarn
{
    public double yarn_used { get; set; } // Amount of yarn used

    public Yarn(double yarn_used_in)
    {
        yarn_used = yarn_used_in;
    }

    public double yarn_average = 1.10; // The average price of yarn per ounce
}

// Represents an employee
public class Employee
{
    public double HoursWorked { get; set; } // Number of hours worked
    public double HourlyRate { get; set; } // Hourly rate of the employee

    public Employee(double hoursWorked, double hourlyRate)
    {
        HoursWorked = hoursWorked;
        HourlyRate = hourlyRate;
    }

    // Calculates the employee's pay
    public double CalculatePay()
    {
        double tax = 0.2; // Tax rate (20%)
        double result = HoursWorked * HourlyRate;
        double result2 = HoursWorked * HourlyRate * tax;

        if (HoursWorked <= 40)
        {
            // Regular pay (up to 40 hours)
            return result - result2;
        }
        else
        {
            // Overtime pay (more than 40 hours)
            double overtimeHours = HoursWorked - 40;
            return 40 * HourlyRate + overtimeHours * 1.5 * HourlyRate;
        }
    }
}

class Program
{
    static void Main()
    {
        // Get input from the user
        Console.Write("Enter hours worked: ");
        double hours = double.Parse(Console.ReadLine());

        int business_expenses = 2; // Business expenses factor
        Console.Write("Enter yarn used: ");
        double yarn_used = double.Parse(Console.ReadLine()); // Cost of yarn
        double rate = 12; // Hourly rate

        // Create a Yarn instance
        Yarn yarn = new Yarn(yarn_used);

        // Calculate the yarn charge
        double yarn_charge = yarn.yarn_average * yarn_used;

        // Create an Employee instance
        Employee emp = new Employee(hours, rate);

        // Calculate the employee's pay
        double pay = emp.CalculatePay();

        // Calculate the wholesale cost
        double wholesaleCost = yarn_charge * pay * business_expenses / rate;

        // Display the result
        Console.WriteLine($"Wholesale cost: ${wholesaleCost:F2}");
    }
}
