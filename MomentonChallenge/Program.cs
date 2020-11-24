using System;
using MomentonChallenge.Services;

namespace MomentonChallenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            var jsonOutput = new HierarchyService(new ReportingService()).GetCompanyHierarchy();
            Console.WriteLine(jsonOutput);
        }
    }
}