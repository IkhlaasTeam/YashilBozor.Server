using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using YashilBozor.DAL.IRepositories.Categories;
using YashilBozor.DAL.Repositories.Categories;
using YashilBozor.Domain.Configurations;
using YashilBozor.Domain.Entities.Categories;
using YashilBozor.Service.DTOs.Categories.Products;
using YashilBozor.Service.Interfaces.Categories;
using YashilBozor.Service.Validators.Categories;

namespace YashilBozor.Service.Services.Categories;

public class ProductService
    (IProductRepository productRepository,
    ProductValidator productValidate,
    IMapper mapper) : IProductService
{
    public async ValueTask<ProductForResultDto> CreateAsync
        (ProductForCreationDto productForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var product = mapper.Map<Product>(productForCreationDto);
        var validationResult = productValidate.Validate(product);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return mapper.Map<ProductForResultDto>(await productRepository
            .InsertAsync(product, saveChanges, cancellationToken));
    }

    public async ValueTask<ProductForResultDto?> DeleteAsync
        (Guid productId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return mapper.Map<ProductForResultDto>(await productRepository
            .DeleteAsync(productId, saveChanges, cancellationToken));
    }

    public async ValueTask<IEnumerable<ProductForResultDto>> GetAllAsync
        (PaginationParams @params,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        var products = await productRepository.SelectAll(
                product => product.DeletedAt == null, asNoTracking)
            .Skip((@params.PageIndex - 1) * @params.PageSize)
            .Take(@params.PageSize)
            .Include(p => p.Commentaries)
            .ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<ProductForResultDto>>(products);
    }

    public async ValueTask<ProductForResultDto?> GetByIdAsync
        (Guid productId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return mapper.Map<ProductForResultDto>
            (await productRepository.SelectByIdAsync
            (productId, asNoTracking, cancellationToken));
    }

    public async ValueTask<ProductForResultDto> UpdateAsync
        (ProductForUpdateDto productForUpdateDto,
        Guid productId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var product = mapper.Map<Product>(productForUpdateDto);
        product.Id = productId;

        var validationResult = productValidate.Validate(product);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        product.UpdatedAt = DateTime.UtcNow;

        return mapper.Map<ProductForResultDto>
            (await productRepository.UpdateAsync
            (product, saveChanges, cancellationToken));
    }
}
