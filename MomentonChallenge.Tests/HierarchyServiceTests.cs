using System;
using MomentonChallenge.Services;
using Xunit;

namespace MomentonChallenge.Tests
{
    public class HierarchyServiceTests
    {
        [Fact]
        public static void EverythingWorks()
        {
            var jsonOutput = new HierarchyService(new ReportingService()).GetCompanyHierarchy();
            
            Assert.NotNull(jsonOutput);
        }
    }
}