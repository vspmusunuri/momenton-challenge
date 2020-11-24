using System.Collections.Generic;
using MomentonChallenge.Model;

namespace MomentonChallenge.DataSource
{
    public static class InMemoryDatabase
    {
        public static IEnumerable<Employee> Employees()
        {
            return new List<Employee>
            {
                new Employee {Id = 100, Name = "Alan", ManagerId = 150},
                new Employee {Id = 220, Name = "Martin", ManagerId = 100},
                new Employee {Id = 150, Name = "Jamie"},
                new Employee {Id = 275, Name = "Alex", ManagerId = 100},
                new Employee {Id = 400, Name = "Steve", ManagerId = 150},
                new Employee {Id = 190, Name = "David", ManagerId = 400},
            };
        }
    }
}