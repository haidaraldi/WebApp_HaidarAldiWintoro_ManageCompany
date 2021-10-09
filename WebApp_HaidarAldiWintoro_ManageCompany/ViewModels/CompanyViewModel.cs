using System.ComponentModel.DataAnnotations;

namespace WebApp_HaidarAldiWintoro_ManageCompany.ViewModels
{
    public class CompanyViewModel : EditImageViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Url)]
        public string Website { get; set; }
    }
}
