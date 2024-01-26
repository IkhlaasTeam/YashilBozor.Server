using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Categories;
using HHD.Domain.Entities.Categories;
using YashilBozor.DAL.Repositories.Common;

namespace YashilBozor.DAL.Repositories.Categories;

public class CommentaryRepository : Repository<Commentary>, ICommentaryRepository
{
    public CommentaryRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
