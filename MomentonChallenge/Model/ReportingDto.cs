using System.Collections.Generic;
using Newtonsoft.Json;

namespace MomentonChallenge.Model
{
    public class ReportingDto
    {

        public string Name { get; set; }
        public List<ReportingDto> Employees { get; set; }

        [JsonIgnore] 
        public int ManagerId { get; }

        [JsonIgnore] 
        public int Id { get; }

        public ReportingDto(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ManagerId = employee.ManagerId;
        }
    }
}