using YashilBozor.Service.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace YashilBozor.Service.Services;

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