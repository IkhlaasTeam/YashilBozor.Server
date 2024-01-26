namespace YashilBozor.Service.Interfaces.Identity;

public interface IPasswordHasherService
{
    string HashPassword(string password);

    bool ValidatePassword(string password, string hashedPassword);
}