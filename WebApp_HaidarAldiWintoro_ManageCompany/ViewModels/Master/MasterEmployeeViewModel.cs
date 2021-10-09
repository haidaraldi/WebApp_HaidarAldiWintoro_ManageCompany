using System.Collections.Generic;
using WebApp_HaidarAldiWintoro_ManageCompany.Models;

namespace WebApp_HaidarAldiWintoro_ManageCompany.ViewModels.Master
{
    public class MasterEmployeeViewModel
    {
        public List<CompanyNameViewModel> CompanyNames { get; set; }
        public CompanyNameViewModel CompanyName { get; set; }

        public Employees Employees { get; set; }
        public EmployeesViewModel EmployeesVM { get; set; }
        public List<EmployeesViewModel> EmployeesVMs { get; set; }

    }
}
