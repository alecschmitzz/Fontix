using System.ComponentModel.DataAnnotations;

namespace Fontix.UI.Models.BindingModels;

public class CreateOrganisationBindingModel
{
    [Required] public string Name { get; set; }
}