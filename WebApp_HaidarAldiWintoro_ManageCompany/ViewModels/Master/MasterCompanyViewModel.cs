using System.Collections.Generic;
using WebApp_HaidarAldiWintoro_ManageCompany.Models;

namespace WebApp_HaidarAldiWintoro_ManageCompany.ViewModels.Master
{
    public class MasterCompanyViewModel
    {
        public Companies Companies { get; set; }
        public List<Companies> ListCompanies { get; set; }
        public CompanyViewModel CompaniesVM { get; set; }
    }
}
