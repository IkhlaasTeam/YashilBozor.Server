namespace YashilBozor.Service.Interfaces;

public interface IPasswordHasherService
{
    string HashPassword(string password);

    bool ValidatePassword(string password, string hashedPassword);
}