using System;

public class Employee
{
    public string Name { get; set; }
    public int EmployeeId { get; set; }

    public Employee(string name, int employeeId)
    {
        Name = name;
        EmployeeId = employeeId;
    }
}

public class Company
{
    public event Action<Employee> EmployeeAdded;

    public void AddEmployee(Employee employee)
    {
        Console.WriteLine($"Employee {employee.Name} with ID {employee.EmployeeId} has been added to the company.");
        OnEmployeeAdded(employee);
    }

    protected virtual void OnEmployeeAdded(Employee employee)
    {
        EmployeeAdded?.Invoke(employee);
    }
}

public class Club
{
    public void AddEmployeeToClub(Employee employee)
    {
        Console.WriteLine($"Employee {employee.Name} has been added to the club.");
    }
}

public class SocialInsurance
{
    public void EnrollEmployeeInInsurance(Employee employee)
    {
        Console.WriteLine($"Employee {employee.Name} has been enrolled in social insurance.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var company = new Company();
        var club = new Club();
        var socialInsurance = new SocialInsurance();

        company.EmployeeAdded += club.AddEmployeeToClub;
        company.EmployeeAdded += socialInsurance.EnrollEmployeeInInsurance;

        var newEmployee = new Employee("Ali Mohmmed", 123);
        company.AddEmployee(newEmployee);

        var anotherEmployee = new Employee("Hagar Ali", 456);
        company.AddEmployee(anotherEmployee);
    }
}
