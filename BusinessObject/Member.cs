using System.ComponentModel.DataAnnotations;

namespace BusinessObject;

public class Member
{
    [Key]
    public int MemberId { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Password { get; set; }
}