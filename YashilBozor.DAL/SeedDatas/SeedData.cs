using YashilBozor.DAL.DbContexts;
using YashilBozor.Domain.Entities.Notification;

namespace YashilBozor.DAL.SeedDatas;

public static class SeedData
{
    public static async ValueTask InitializeSeedData(this AppDbContext dbContext)
    {
        if (!dbContext.Users.Any())
            await dbContext.AddUsers(10);

        if (!dbContext.EmailTemplates.Any())
            await dbContext.AddEmailTemplatesAsync();

    }

    public static async ValueTask<int> AddUsers(this AppDbContext dbContext, int count)
    {
        var faker = EntityFaker.GenerateUserFaker();
        var users = faker.Generate(count);
        await dbContext.Users.AddRangeAsync(users);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddEmailTemplatesAsync(this AppDbContext dbContext)
    {
        Console.WriteLine("template lar qo'shildi");
        var emailTemplates = new List<EmailTemplate>
        {
            new EmailTemplate("Welcome to our system", "Dear {{FullName}}, welcome to our system\n\nyour verification code is {{Code}}"),
            new EmailTemplate("New Message", "Hello {{FullName}}, you've got a new message."),
            new EmailTemplate("Truck Confirmation", "Dear {{FullName}}, your truck has been confirmed."),
            new EmailTemplate("Thank You", "Dear {{FullName}}, thank you for using our services."),
            new EmailTemplate("Your password has been changes", "Dear {{FullName}}, Your password has been changed."),
        };

        await dbContext.EmailTemplates.AddRangeAsync(emailTemplates);

        return await dbContext.SaveChangesAsync();
    }

}