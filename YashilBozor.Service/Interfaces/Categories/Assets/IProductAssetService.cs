using YashilBozor.Domain.Configurations;
using YashilBozor.Service.DTOs.Categories.Assets.ProductAssets;

namespace YashilBozor.Service.Interfaces.Categories.Assets;

public interface IProductAssetService
{
    ValueTask<IEnumerable<ProductAssetForResultDto>> GetAllAsync(
       Guid productId,
       PaginationParams @params,
       bool asNoTracking = false,
       CancellationToken cancellationToken = default);

    ValueTask<ProductAssetForResultDto> GetByIdAsync(
        Guid productAssetId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<ProductAssetForResultDto> CreateAsync(
        ProductAssetForCreationDto productAssetForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<ProductAssetForResultDto> DeleteAsync(
        Guid productAssetId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);


    ValueTask<ProductAssetForResultDto> GetByProductIdAsync(
        Guid productId,
        Guid productAssetId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}
