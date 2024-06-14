using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpecCrudPro.Models
{
    [Table("AppForm")]
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]

        [Display(Name="Enter Name")]
        public string Name { get; set; }

        [Display(Name="Enter Age")]
        [Required(ErrorMessage = "Please Enter Age")]
        [Range(18,100, ErrorMessage ="Age should be between 18 and 100")]
        public int Age { get; set; }
        [Display(Name="Enter Gender")]

        [Required(ErrorMessage = "Please Enter Gender")]

        public string gender { get; set; }
        [Display(Name="Enter Email")]

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage ="Enter Email in proper formate")]
        public string email { get; set; }
        [Display(Name="Enter Phone Number")]

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [StringLength(10)]
        public string phoneno { get; set; }

        [Display(Name="Select Country")]
        [Required(ErrorMessage = "Please select Country")]

        public string country { get; set; }
       [Required(ErrorMessage = "Please select state")]
        [Display(Name="Select State")]
        public string state { get; set; }
        public bool status { get; set; }
    }
}
