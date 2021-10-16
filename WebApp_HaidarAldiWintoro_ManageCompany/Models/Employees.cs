using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Models
{
    public class Employees
    {
        [Key]
        public int Index { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }


        public int CompaniesIndex { get; set; }
        public Companies Companies { get; set; }
    }
}
