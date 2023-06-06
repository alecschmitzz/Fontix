using System.ComponentModel.DataAnnotations;

namespace Fontix.UI.Models.BindingModels;

public class RegisterBindingModel
{
    [Required] public string NameFirst { get; set; }

    [Required] public string NameLast { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }
}