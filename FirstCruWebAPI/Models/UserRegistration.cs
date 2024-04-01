using System.ComponentModel.DataAnnotations;

namespace FirstCruWebAPI.Models
{
    public class UserRegistration
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string MobileNumber { get; set; } = string.Empty;
    }
}
