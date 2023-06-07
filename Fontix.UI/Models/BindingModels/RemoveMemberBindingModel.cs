using System.ComponentModel.DataAnnotations;

namespace Fontix.UI.Models.BindingModels;

public class RemoveMemberBindingModel
{
    [Required] public int OrganisationId { get; set; }
    [Required] public int UserId { get; set; }

}