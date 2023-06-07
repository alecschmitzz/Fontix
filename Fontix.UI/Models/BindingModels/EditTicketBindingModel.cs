using System.ComponentModel.DataAnnotations;
using Fontix.UI.Utils;

namespace Fontix.UI.Models.BindingModels;

public class EditTicketBindingModel
{
    [Required] public int Id { get; set; }

    public int EventId { get; set; }

    [Required] public string Name { get; set; }

    [Required]
    [Range(0.00, double.MaxValue, ErrorMessage = "Price must greater than or equal to 0")]
    public decimal Price { get; set; }

    [Required]
    [DateTimeAfterNow(ErrorMessage = "DateTimeStart must be after the current time")]
    public DateTime DateTimeStart { get; set; }

    [Required]
    [DateTimeAfterNow(ErrorMessage = "DateTimeEnd must be after the current time")]
    public DateTime DateTimeEnd { get; set; }

    [Required]
    [DateTimeAfterNow(ErrorMessage = "DateTimeView must be after the current time")]
    public DateTime DateTimeView { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Amount must be greater than or equal to 0")]
    public int Amount { get; set; }
}