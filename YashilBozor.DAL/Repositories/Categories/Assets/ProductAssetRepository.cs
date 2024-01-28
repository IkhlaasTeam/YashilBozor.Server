using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Categories.Assets;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Categories;

namespace YashilBozor.DAL.Repositories.Categories.Assets;

public class ProductAssetRepository : Repository<Asset>, IProductAssetRepository
{
    public ProductAssetRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
