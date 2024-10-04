using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

      
        [Required(ErrorMessage = "Please Enter NIP")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Enter 10 digits NIP Number")]
        public string NIP { get; set; }

        
        [Required(ErrorMessage = "Please Enter Id Of Business")]
        public int BusinessId { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Id Of User")]
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime CreationDate { get; set; }

        public int IsDeleted { get; set; }
    }
}
