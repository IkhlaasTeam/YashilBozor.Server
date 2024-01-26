using YashilBozor.Domain.Entities.Commons;

namespace YashilBozor.Domain.Entities.Categories;

public class Asset : Auditable
{
    public string MediaPath { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
