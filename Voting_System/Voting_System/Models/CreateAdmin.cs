using System.ComponentModel.DataAnnotations;
using VotingSystem.Models.Base;

namespace Voting_System.Models
{
    public class CreateAdmin:BaseEntity
    {
		[Required]
        [Display(Name = "User Name")]
		public string UserName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
		[Required]
		[Display(Name = "Password")]
		public string Password { get; set; }
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
        public string User_type { get;set; }
    }
}
