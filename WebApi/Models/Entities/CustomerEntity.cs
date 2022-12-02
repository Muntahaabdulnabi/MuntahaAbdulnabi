using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string Address { get; set; } = null!;
    public string CustomerName => $"{FirstName} {LastName}";
}


// Jag kunde ha lagt Data Annotation som t.ex. [Key], [Required] och[StringLength(max)] [Column(DataType)],
// men det inte så viktigt eftersom vissa är redan finns genom att sätta "Id" och " =nul!".
// MaxLength är inte så viktig i detta projekt.