using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_HaidarAldiWintoro_ManageCompany.ViewModels
{
    public class EmployeesViewModel
    {
        public int Index { get; set; }
        [Required(ErrorMessage = "The First Name field is required.")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Phone field is required.")]
        [StringLength(20)]
        public string Phone { get; set; }  
        [Required(ErrorMessage = "The Email field is required.")]
        [StringLength(20)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Company Name field is required.")]
        public DateTime JoinDate { get; set; }
        public int IndexCompany { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWeb { get; set; }
    }
}
