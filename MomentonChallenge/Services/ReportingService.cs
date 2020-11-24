using System.Collections.Generic;
using System.Linq;
using MomentonChallenge.DataSource;
using MomentonChallenge.Model;
using Newtonsoft.Json;

namespace MomentonChallenge.Services
{
    public class ReportingService
    {
        public ReportingDto FindCeo()
        {
            return new ReportingDto(InMemoryDatabase.Employees().First(e => e.ManagerId == 0));
        }
        
        public ReportingDto GetReportingEmployees(ReportingDto manager)
        {
            manager.Employees = new List<ReportingDto>();
            var employeesReporting = InMemoryDatabase.Employees().Where(a => a.ManagerId == manager.Id).ToList();

            if (employeesReporting.Count == 0)
            {
                manager.Employees = null;
                return manager;
            } 
            
            foreach (var employee in employeesReporting)
            { 
                manager.Employees.Add(new ReportingDto(employee));
            }

            return manager;
        }

        public string WriteOutputToJson(ReportingDto ceo)
        {
            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(ceo, options);
        }
    }
}