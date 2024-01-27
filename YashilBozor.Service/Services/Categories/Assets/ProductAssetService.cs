using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YashilBozor.DAL.IRepositories.Categories;
using YashilBozor.DAL.IRepositories.Categories.Assets;
using YashilBozor.Domain.Configurations;
using YashilBozor.Domain.Entities.Categories;
using YashilBozor.Service.DTOs.Categories.Assets.ProductAssets;
using YashilBozor.Service.Exceptions;
using YashilBozor.Service.Helpers;
using YashilBozor.Service.Interfaces.Categories.Assets;

namespace YashilBozor.Service.Services.Categories.Assets;

public class ProductAssetService
    (IProductAssetRepository productAssetRepository,
    IProductRepository productRepository,
    IMapper mapper)
    : IProductAssetService
{
    public async ValueTask<ProductAssetForResultDto> CreateAsync
        (ProductAssetForCreationDto productAssetForCreationDto, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default)
    {
        var productImgPath = FileUploadHelper.UploadFile("Products", productAssetForCreationDto.FormFile).Result;

        var asset = new Asset();
        asset.CreatedAt = DateTime.Now;
        asset.MediaPath = productImgPath;
        asset.ProductId = productAssetForCreationDto.ProductId;

        var productAsset = await productAssetRepository.InsertAsync(asset);

        return mapper.Map<ProductAssetForResultDto>(productAsset);
    }

    public async ValueTask<ProductAssetForResultDto> DeleteAsync
        (Guid productAssetId, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default)
    {
        var asset = await productAssetRepository.SelectByIdAsync(productAssetId);
        if (asset != null && asset.DeletedAt == null)
        {
            var productAsset = productAssetRepository.DeleteAsync(productAssetId);
            return mapper.Map<ProductAssetForResultDto>(productAsset);
        }

        throw new CustomException(400, "Product Asset is not found");
    }

    public async  ValueTask<IEnumerable<ProductAssetForResultDto>> GetAllAsync
        (Guid productId, 
        PaginationParams @params,
    bool asNoTracking = false, 
        CancellationToken cancellationToken = default)
    {
        var product = await productRepository.SelectByIdAsync(productId, asNoTracking, cancellationToken);

        if (product != null && product.DeletedAt == null)
        {
            var assets = await productAssetRepository.SelectAll(
             a => a.DeletedAt == null, asNoTracking)
            .Skip((@params.PageIndex - 1) * @params.PageSize)
            .Take(@params.PageSize)
            .ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<ProductAssetForResultDto>>(assets);
        }

        throw new CustomException(400, "Product is not found");
    }

    public async ValueTask<ProductAssetForResultDto> GetByIdAsync
        (Guid productAssetId, 
        bool asNoTracking = false, 
        CancellationToken cancellationToken = default)
    {
        var asset = await productAssetRepository.SelectByIdAsync(productAssetId, asNoTracking, cancellationToken);

        if (asset != null && asset.DeletedAt == null)
        {
            return mapper.Map<ProductAssetForResultDto>(asset);
        }

        throw new CustomException(400, "Product Asset is not found");
    }

    public async ValueTask<ProductAssetForResultDto> GetByProductIdAsync
        (Guid productId, 
        Guid productAssetId, 
        bool asNoTracking = false, 
        CancellationToken cancellationToken = default)
    {
        var product = await productRepository.SelectByIdAsync(productId, asNoTracking, cancellationToken);
        var asset = await productAssetRepository.SelectByIdAsync(productAssetId, asNoTracking, cancellationToken);
        if ((product != null && product.DeletedAt == null) && (asset != null && asset.DeletedAt == null))
        {
            return mapper.Map<ProductAssetForResultDto>(asset);
        }

        throw new CustomException(400, "Product Asset is not found");
    }
}
