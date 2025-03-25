using System;
using System.Collections.Generic;
class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Role { get; set; }
    public decimal Pay { get; set; }

    public Employee(string name, int id, string role, decimal pay)
    {
        Name = name;
        Id = id;
        Role = role;
        Pay = pay;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Role: {Role}, Pay: ${Pay}";
    }
}

class Program
{
    static List<Employee> employees = new List<Employee>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    RemoveEmployee();
                    break;
                case "3":
                    DisplayEmployees();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Employee Management System");
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Remove Employee");
        Console.WriteLine("3. Display Employees");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice (1-4): ");
    }

    static void AddEmployee()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        Console.Write("Enter employee role: ");
        string role = Console.ReadLine();

        Console.Write("Enter employee pay: $");
        if (decimal.TryParse(Console.ReadLine(), out decimal pay))
        {
            Employee newEmployee = new Employee(name, nextId, role, pay);
            employees.Add(newEmployee);
            Console.WriteLine($"Employee added successfully with ID: {nextId}");
            nextId++;
        }
        else
        {
            Console.WriteLine("Invalid pay amount. Employee not added.");
        }
    }

    static void RemoveEmployee()
    {
        Console.Write("Enter the ID of the employee to remove: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Employee employeeToRemove = employees.Find(e => e.Id == id);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                Console.WriteLine($"Employee with ID {id} has been removed.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID entered.");
        }
    }

    static void DisplayEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees in the system.");
        }
        else
        {
            Console.WriteLine("List of Employees:");
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
