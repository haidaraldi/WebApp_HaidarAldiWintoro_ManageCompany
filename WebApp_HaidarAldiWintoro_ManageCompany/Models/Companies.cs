using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Models
{
    public class Companies
    {
        [Key]
        public int Index { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        [StringLength(100)]
        public string Website { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
