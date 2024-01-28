using System.Text.Json.Serialization;
using YashilBozor.Domain.Entities.Commons;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Domain.Entities.Categories;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public bool IsFavourite { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }

    public Guid SellerId { get; set; }
    public User Seller { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    [JsonIgnore]
    public IEnumerable<Commentary> Commentaries { get; set; }
    public IEnumerable<Asset> Categories { get;}
}
