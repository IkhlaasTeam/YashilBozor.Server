using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Categories;
using HHD.Domain.Entities.Categories;
using YashilBozor.DAL.Repositories.Common;

namespace YashilBozor.DAL.Repositories.Categories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
