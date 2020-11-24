namespace MomentonChallenge.Services
{
    public class HierarchyService
    {
        private readonly ReportingService _service;

        public HierarchyService(ReportingService service)
        {
            _service = service;
        }

        public string GetCompanyHierarchy()
        {
            var ceo = _service.FindCeo();
            var managers = _service.GetReportingEmployees(ceo);

            foreach (var manager in managers.Employees)
            {
                _service.GetReportingEmployees(manager);
            }

            var jsonOutput = _service.WriteOutputToJson(ceo);
            return jsonOutput;
        }
    }
}