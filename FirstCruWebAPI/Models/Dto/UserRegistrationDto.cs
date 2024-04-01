using System.ComponentModel.DataAnnotations;

namespace FirstCruWebAPI.Models.Dto
{
    public class UserRegistrationDto
    {
      
        public int UserId { get; set; }
      
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
      
        public string Email { get; set; } = string.Empty;
       
        public string MobileNumber { get; set; } = string.Empty;
    }
}
