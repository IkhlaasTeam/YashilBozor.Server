using Microsoft.AspNetCore.Http;

namespace YashilBozor.Service.DTOs.Categories.Assets.ProductAssets;

public class ProductAssetForCreationDto
{
    public IFormFile FormFile { get; set; }
    public Guid ProductId { get; set; }
}
