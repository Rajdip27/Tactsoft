using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModel;

public class RegistrarVm
{
    [Required]
    public string Name { get; set; }
    [Required]
    [DataType(dataType: DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Compare("Password", ErrorMessage = "Password dot not match.")]
    [Required]
    public string ConfirmPassword { get; set; }
    [Required]
    public string Address { get; set; }
}