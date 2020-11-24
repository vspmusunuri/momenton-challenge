using System;
using System.Collections.Generic;
using System.Linq;
using MomentonChallenge.Model;
using MomentonChallenge.Services;
using Xunit;


namespace MomentonChallenge.Tests
{
    public class ReportingServiceTests
    {
        [Fact]
        public void FindsCeoTest()
        {
            var service = new ReportingService();
            var ceo = service.FindCeo();
            
            Assert.Equal("Jamie", ceo.Name);
            Assert.Equal(0, ceo.ManagerId);
        }

        [Fact]
        public void WritesOutputToJsonTest()
        {
            var manager = new Employee { Id = 100, Name = "Jamie", ManagerId = 0};
            var employee = new Employee {Id = 100, Name = "Alex", ManagerId = 150};

            var dto = new ReportingDto(manager)
            {
                Name = "Jamie",
                Employees = new List<ReportingDto> {new ReportingDto(employee)}
            };
            
            var service = new ReportingService();
            var jsonOutput = service.WriteOutputToJson(dto);
            
            Assert.NotNull(jsonOutput);
        }

        [Fact]
        public void GetsAnyReportingEmployees()
        {
            var service = new ReportingService();
            var manager = new Employee {Id = 100, Name = "Alan", ManagerId = 150};
            
            var reportingManager = new ReportingDto(manager);
            service.GetReportingEmployees(reportingManager);
            
            Assert.Equal(2, reportingManager.Employees.Count);
            Assert.Equal("Martin", reportingManager.Employees.First().Name);
            Assert.Equal("Alex", reportingManager.Employees.Last().Name);
        }
    }
}