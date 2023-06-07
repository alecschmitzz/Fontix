using System.ComponentModel.DataAnnotations;

namespace Fontix.UI.Models.BindingModels;

public class AddMemberBindingModel
{
    [Required] public int OrganisationId { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
}