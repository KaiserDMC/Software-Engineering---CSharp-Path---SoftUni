using System.Globalization;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        //01. - 02.
        SoftUniContext dbContext = new SoftUniContext();

        //03.
        //string output = GetEmployeesFullInformation(dbContext);
        //Console.WriteLine(output);

        //04.
        //string output = GetEmployeesWithSalaryOver50000(dbContext);
        //Console.WriteLine(output);

        //05.
        //string output = GetEmployeesFromResearchAndDevelopment(dbContext);
        //Console.WriteLine(output);

        //06.
        //string output = AddNewAddressToEmployee(dbContext);
        //Console.WriteLine(output);

        //07.
        //string output = GetEmployeesInPeriod(dbContext);
        //Console.WriteLine(output);

        //08.
        //string output = GetAddressesByTown(dbContext);
        //Console.WriteLine(output);

        //09.
        string output = GetEmployee147(dbContext);
        Console.WriteLine(output);
    }

    // 03. Employees Full Information

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 04. Employees with Salary Over 50000

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(e => e.Salary > 50000)
            .ToArray();

        foreach (var employee in employees)
        {
            stringBuilder.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 05. Employees from Research and Development

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department.Name,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            stringBuilder.AppendLine(
                $"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 06. Adding a New Address and Updating Employee

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address nakovAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        //context.Addresses.Add(nakovAddress);

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        employee.Address = nakovAddress;

        context.SaveChanges();

        StringBuilder stringBuilder = new StringBuilder();

        var employeesAddress = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToArray();

        foreach (var empAdr in employeesAddress)
        {
            stringBuilder.AppendLine($"{empAdr}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 07. Employees and Projects

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManFirst = e.Manager.FirstName,
                ManLast = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjName = ep.Project.Name,
                        ProjStartDate = ep.Project.StartDate,
                        ProjEndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    }).ToArray()

            }).ToArray();

        foreach (var emp in employees)
        {
            stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManFirst} {emp.ManLast}");

            foreach (var proj in emp.Projects)
            {
                stringBuilder.AppendLine(
                    $"--{proj.ProjName} - {proj.ProjStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {proj.ProjEndDate}");
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 08. Addresses by Town

    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count
            })
            .ToArray();

        foreach (var address in addresses)
        {
            stringBuilder.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 09. Employee 147

    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var employee = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .OrderBy(ep => ep.Project.Name)
                    .Select(ep => ep.Project.Name)
                    .ToArray()
            }).ToArray();

        foreach (var emp in employee)
        {
            stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

            foreach (var project in emp.Projects)
            {
                stringBuilder.AppendLine($"{project}");
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }

}