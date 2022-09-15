using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> employeeIdsByCompany = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] companyAndEmployeeId = Console.ReadLine().Split(" -> ").ToArray();

                if (companyAndEmployeeId[0] == "End")
                {
                    break;
                }

                string company = companyAndEmployeeId[0];
                string employeeId = companyAndEmployeeId[1];

                if (!employeeIdsByCompany.ContainsKey(company))
                {
                    employeeIdsByCompany.Add(company, new List<string> { employeeId });
                }
                else
                {
                    if (!employeeIdsByCompany[company].Contains(employeeId))
                    {
                        employeeIdsByCompany[company].Add(employeeId);
                    }
                }
            }

            foreach (var VARIABLE in employeeIdsByCompany)
            {
                Console.WriteLine($"{VARIABLE.Key}");

                foreach (var id in VARIABLE.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
