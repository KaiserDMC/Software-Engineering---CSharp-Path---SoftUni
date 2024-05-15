using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Department> departments = new List<Department>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] employeeStrings = Console.ReadLine().Split(" ").ToArray();

                Employee employee = new Employee(employeeStrings[0], decimal.Parse(employeeStrings[1]));

                if (!departments.Any(dep => dep.Name == employeeStrings[2]))
                {
                    departments.Add((new Department(employeeStrings[2])));
                }

                departments.Find(d => d.Name == employeeStrings[2]).AddEmployee(decimal.Parse(employeeStrings[1]), employeeStrings[0]);
            }

            Department bestDepartment =
                departments.OrderByDescending(best => best.TotalSalaries / best.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.Name}");

            foreach (Employee employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }

    class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Department
    {
        public Department(string departmeName)
        {
            this.Name = departmeName;
        }

        public string Name { get; set; }

        public List<Employee> Employees = new List<Employee>();
        public decimal TotalSalaries { get; set; }

        public void AddEmployee(decimal salary, string name)
        {
            TotalSalaries += salary;
            Employees.Add(new Employee(name, salary));
        }
    }

}
