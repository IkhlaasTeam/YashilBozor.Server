using YashilBozor.Service.DTOs.Categories.Assets.ProductAssets;
using YashilBozor.Service.DTOs.Categories.Commentaries;

namespace YashilBozor.Service.DTOs.Categories.Products;

public class ProductForResultDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public bool IsFavourite { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SellerId { get; set; }

    public IEnumerable<CommentaryForResultDto> Commentaries { get; set; }
    public IEnumerable<ProductAssetForResultDto> ProductAssets { get; set; }
}
