using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Voting_System.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Enter Uesrname")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Enter Password")]
        [Required]
        public string Password { get; set; }
    }
}
