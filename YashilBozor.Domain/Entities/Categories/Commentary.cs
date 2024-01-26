using YashilBozor.Domain.Entities.Commons;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Domain.Entities.Categories;

public class Commentary : Auditable
{
    public string Comment { get; set; }
    public bool IsLiked { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
