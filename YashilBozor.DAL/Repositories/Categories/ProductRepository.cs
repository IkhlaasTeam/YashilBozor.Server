using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Categories;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Categories;

namespace YashilBozor.DAL.Repositories.Categories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
