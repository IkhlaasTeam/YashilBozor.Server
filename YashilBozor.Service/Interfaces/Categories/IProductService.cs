using YashilBozor.Domain.Configurations;
using YashilBozor.Service.DTOs.Categories.Products;

namespace YashilBozor.Service.Interfaces.Categories;

public interface IProductService
{
    ValueTask<IEnumerable<ProductForResultDto>?> GetAllAsync(
       PaginationParams @params,
       bool asNoTracking = false,
       CancellationToken cancellationToken = default);

    ValueTask<ProductForResultDto?> GetByIdAsync(
        Guid productId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<ProductForResultDto> CreateAsync(
        ProductForCreationDto productForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<ProductForResultDto> UpdateAsync(
        ProductForUpdateDto productForUpdateDto,
        Guid productId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<ProductForResultDto?> DeleteAsync(
        Guid productId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
