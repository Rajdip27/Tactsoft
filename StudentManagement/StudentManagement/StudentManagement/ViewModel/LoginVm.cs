using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModel;

public class LoginVm
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}