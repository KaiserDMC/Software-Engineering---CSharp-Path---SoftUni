namespace SoftUni.Models;

public partial class Employee
{
    public Employee()
    {
        Departments = new HashSet<Department>();
        InverseManager = new HashSet<Employee>();
        EmployeesProjects = new HashSet<EmployeeProject>();
    }

    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string JobTitle { get; set; } = null!;
    public int DepartmentId { get; set; }
    public int? ManagerId { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public int? AddressId { get; set; }

    public virtual Department Department { get; set; } = null!;
    public virtual Address? Address { get; set; }
    public virtual Employee? Manager { get; set; }

    public virtual ICollection<Department> Departments { get; set; }
    public virtual ICollection<Employee> InverseManager { get; set; }
    public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
}