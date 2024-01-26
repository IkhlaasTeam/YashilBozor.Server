using YashilBozor.Service.Interfaces.Identity;
using BC = BCrypt.Net.BCrypt;

namespace YashilBozor.Service.Services.Identity;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool ValidatePassword(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}