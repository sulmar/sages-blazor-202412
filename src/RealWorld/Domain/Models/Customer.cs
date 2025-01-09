using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Customer : BaseEntity
{
    [Required]
    [MaxLength(10), MinLength(2)]
    public string FirstName { get; set; }

    [Required, MaxLength(10), MinLength(3)]
    public string LastName { get; set; }
    public string Note { get; set; }

    [Compare("ConfirmPassword")]
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    public string Pesel { get; set; }

    [RegularExpression(@"^[^\s@]+@([^\s@.,]+\.)+[^\s@.,]{2,}$")]
    public string Email { get; set; }
}
