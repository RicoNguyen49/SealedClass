using System;

interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}

class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee()
    {
        Id = 0;
        FirstName = string.Empty;
        LastName = string.Empty;
    }
    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public string Fullname()
    {
        return FirstName + " " + LastName;
    }
    public virtual double Pay()
    {
        double salary;
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        salary = double.Parse(Console.ReadLine());
        return salary;
    }

}

//sealed execitive class
sealed class Executive : Employee
{
    public string Title { get; set; }
    public double Salary { get; set; }

    //default constructor
    public Executive()
    {
        Title = "";
        Salary = 0;
    }

    //Parameterized constructor 
    public Executive(int id, string firstName, string lastName, string title, double salary)
        : base(id, firstName, lastName)
    {
        Title = title;
        Salary = salary;
    }

    public override double Pay()
    {
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        Salary = double.Parse(Console.ReadLine());
        return Salary;
    }

    public double overpay()
    {
        return Salary * 0.1; //10% overpay
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Creating an employee object
        Employee employee1 = new Employee(1, "steven", "universe");

        //Displaying employee information
        Console.WriteLine("Employee Information:");
        Console.WriteLine($"ID: {employee1.Id}");
        Console.WriteLine($"Name: {employee1.Fullname()}");
        Console.WriteLine($"Weekly Salary: {employee1.Pay()}");

        Console.WriteLine();

        //Creating an executive object
        Executive executive1 = new Executive(2, "bob", "ross", "CEO",1000);

        //Displaying executive information
        Console.WriteLine("Executive Information:");
        Console.WriteLine($"ID: {executive1.Id}");
        Console.WriteLine($"Name: {executive1.Fullname()}");
        Console.WriteLine($"Title: {executive1.Title}");
        Console.WriteLine($"Weekly Salary: {executive1.Pay()}");
        Console.WriteLine($"OverPay: {executive1.overpay()}");

        Console.WriteLine();
    }
}
