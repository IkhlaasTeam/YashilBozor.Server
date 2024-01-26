using YashilBozor.DAL.DbContexts;

namespace YashilBozor.DAL.SeedDatas;

public static class SeedData
{
    public static async ValueTask InitializeSeedData(this AppDbContext dbContext)
    {
        if (!dbContext.Users.Any())
            await dbContext.AddUsers(10);

    }

    public static async ValueTask<int> AddUsers(this AppDbContext dbContext, int count)
    {
        var faker = EntityFaker.GenerateUserFaker();
        var users = faker.Generate(count);
        await dbContext.Users.AddRangeAsync(users);

        return await dbContext.SaveChangesAsync();
    }

}