using System.Text.Json.Serialization;
using YashilBozor.Domain.Entities.Commons;

namespace YashilBozor.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; }

    [JsonIgnore]
    public IEnumerable<Product> Products { get; set; }
}
