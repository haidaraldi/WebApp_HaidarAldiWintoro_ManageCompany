using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApp_HaidarAldiWintoro_ManageCompany.ViewModels
{
    public class UploadImageViewModel
    {
        [Required]
        [Display(Name = "Logo")]
        public IFormFile CompanyLogo { get; set; }
    }
}
