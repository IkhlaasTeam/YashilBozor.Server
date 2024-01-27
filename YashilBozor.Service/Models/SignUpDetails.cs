namespace YashilBozor.Service.Models;

public class SignUpDetails
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string PhoneNumber { get; set; }

    public string Password { get; set; }
}