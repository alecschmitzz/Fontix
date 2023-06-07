using System.ComponentModel.DataAnnotations;

namespace Fontix.UI.Models.BindingModels;

public class EditOrganisationBindingModel
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
}