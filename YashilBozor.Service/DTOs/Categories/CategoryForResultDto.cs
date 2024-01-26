using YashilBozor.Service.DTOs.Categories.Products;

namespace YashilBozor.Service.DTOs.Categories;

public class CategoryForResultDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ProductForResultDto> Products { get; set; }
}
