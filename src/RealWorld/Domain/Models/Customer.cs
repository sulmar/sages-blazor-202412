using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Note { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
}
