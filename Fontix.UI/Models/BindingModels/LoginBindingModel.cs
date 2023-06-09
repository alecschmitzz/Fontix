using System.ComponentModel.DataAnnotations;

namespace Fontix.UI.Models.BindingModels;

public class LoginBindingModel
{
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
}