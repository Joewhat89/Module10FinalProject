using System;
using System.Collections.Generic;

class Contractor
{
    private string name;
    private string number;
    private string startDate;

    public Contractor(string name, string number, string startDate)
    {
        this.name = name;
        this.number = number;
        this.startDate = startDate;
    }

    public string GetName() { return name; }
    public string GetNumber() { return number; }
    public string GetStartDate() { return startDate; }

    public void SetName(string name) { this.name = name; }
    public void SetNumber(string number) { this.number = number; }
    public void SetStartDate(string startDate) { this.startDate = startDate; }
}

class Subcontractor : Contractor
{
    private int shift;
    private double hourlyRate;

    public Subcontractor(string name, string number, string startDate, int shift, double hourlyRate)
        : base(name, number, startDate)
    {
        this.shift = shift;
        this.hourlyRate = hourlyRate;
    }

    public int GetShift() { return shift; }
    public double GetHourlyRate() { return hourlyRate; }

    public float CalculatePay()
    {
        if (shift == 2)
            return (float)(hourlyRate * 1.03f);
        else
            return (float)hourlyRate;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Subcontractor> subcontractors = new List<Subcontractor>();
        string addAnother = "y";

        while (addAnother.ToLower() == "y")
        {
            Console.WriteLine("Enter subcontractor Name:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Contractor number: ");
            string number = Console.ReadLine();

            Console.Write("Start date (MM/DD/YYYY): ");
            string startDate = Console.ReadLine();

            int shift;
            while (true)
            {
                Console.Write("Shift (1 for Day, 2 for Night): ");
                if (int.TryParse(Console.ReadLine(), out shift) && (shift == 1 || shift == 2))
                    break;
                else
                    Console.WriteLine("Please enter either 1 or 2.");
            }

            double hourlyRate;
            while (true)
            {
                Console.Write("Hourly pay rate (numbers only): ");
                if (double.TryParse(Console.ReadLine(), out hourlyRate))
                    break;
                else
                    Console.WriteLine("Invalid input. Please enter numbers only, no symbols.");
            }

            Subcontractor sc = new Subcontractor(name, number, startDate, shift, hourlyRate);
            subcontractors.Add(sc);

            Console.Write("Would you like to enter another subcontractor? (y/n): ");
            addAnother = Console.ReadLine();
        }

        Console.WriteLine("\nSubcontractor Summary:\n");

        foreach (Subcontractor sc in subcontractors)
        {
            string shiftLabel = sc.GetShift() == 1 ? "Day" : "Night";
            Console.WriteLine($"Name: {sc.GetName()}, Number: {sc.GetNumber()}, Start Date: {sc.GetStartDate()}, Shift: {shiftLabel}, Adjusted Hourly Pay: ${sc.CalculatePay():0.00}");
        }

        Console.WriteLine("\nProgram complete.");
    }
}
