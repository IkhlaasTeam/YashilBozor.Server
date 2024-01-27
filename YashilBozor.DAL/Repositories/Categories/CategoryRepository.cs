using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Categories;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Categories;

namespace YashilBozor.DAL.Repositories.Categories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{

    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
