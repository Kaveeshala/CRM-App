using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CRM.Models
{

    public class User
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Please Enter Surname")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
       
        [Required(ErrorMessage = "Please Enter Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter Login")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Range(1,3)]
        [Required(ErrorMessage = "Please Enter Id Of Role")]
        public int RoleId { get; set; }

        public int IsDeleted { get; set; }

    }


}