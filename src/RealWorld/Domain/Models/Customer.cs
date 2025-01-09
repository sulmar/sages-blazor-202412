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
}
