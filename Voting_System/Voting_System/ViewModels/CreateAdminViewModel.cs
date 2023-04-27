using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Voting_System.ViewModels
{
	public class CreateAdminViewModel
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
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Required]
		[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
		public string Password { get; set; }
		[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
		[Compare("Password")]
		[Display(Name = "Re-enter Password")]
		public string ConfirmPassword { get; set; }
	}
}
