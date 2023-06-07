using Fontix.UI.Utils;
using Microsoft.Build.Framework;

namespace Fontix.UI.Models.BindingModels;

public class EditEventBindingModel
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Venue { get; set; }
    [Required] public string Description { get; set; }

    [Required]
    [DateTimeAfterNow(ErrorMessage = "DateTimeView must be after the current time")]
    public DateTime DateTimeView { get; set; }
}