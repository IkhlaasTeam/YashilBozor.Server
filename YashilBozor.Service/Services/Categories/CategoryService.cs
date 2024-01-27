using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using YashilBozor.DAL.IRepositories.Categories;
using YashilBozor.Domain.Configurations;
using YashilBozor.Domain.Entities.Categories;
using YashilBozor.Service.DTOs.Categories;
using YashilBozor.Service.Exceptions;
using YashilBozor.Service.Interfaces.Categories;
using YashilBozor.Service.Validators.Categories;

namespace YashilBozor.Service.Services.Categories;

public class CategoryService(
    ICategoryRepository categoryRepository,
    CategoryValidator categoryValidate,
    IMapper mapper
    ) : ICategoryService
{
    public async ValueTask<IEnumerable<CategoryForResultDto>> GetAllAsync(
    PaginationParams @params,
    bool asNoTracking = false,
    CancellationToken cancellationToken = default
)
    {
        var categories = await categoryRepository.SelectAll(
                category => category.DeletedAt == null, asNoTracking)
            .Skip((@params.PageIndex - 1) * @params.PageSize)
            .Take(@params.PageSize)
            .Include(category => category.Products)
            .ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<CategoryForResultDto>>(categories);
    }

    public async ValueTask<CategoryForResultDto> GetByIdAsync(
        Guid categoryId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var category = await categoryRepository.SelectByIdAsync(categoryId, asNoTracking, cancellationToken);

        if (category != null && category.DeletedAt == null)
        {
            return mapper.Map<CategoryForResultDto>(category);
        }

        throw new CustomException(400, "Category is not found"); 
    }


    public async ValueTask<CategoryForResultDto> CreateAsync
        (CategoryForCreationDto categoryForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var dto = categoryRepository.SelectAll(category => category.Name == categoryForCreationDto.Name && category.DeletedAt == null);
        if(dto is null)
            throw new CustomException(409, "Category is already exist");

        var category = mapper.Map<Category>(categoryForCreationDto);
        var validationResult = categoryValidate.Validate(category);


        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return mapper.Map<CategoryForResultDto>
            (await categoryRepository.InsertAsync
            (category, saveChanges, cancellationToken));

    }

    public async ValueTask<CategoryForResultDto> UpdateAsync
        (CategoryForUpdateDto categoryForUpdateDto,
        Guid categoryId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var dto = await categoryRepository.SelectByIdAsync(categoryId);

        if (dto.DeletedAt is not null)
            throw new CustomException(400, "Category is not found");

        var category = mapper.Map<Category>(categoryForUpdateDto);
        category.Id = categoryId;

        var validationResult = categoryValidate.Validate(category);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        category.UpdatedAt = DateTime.UtcNow;

        return mapper.Map<CategoryForResultDto>
            (await categoryRepository.UpdateAsync
            (category, saveChanges, cancellationToken));
    }

    public async ValueTask<CategoryForResultDto> DeleteAsync(
        Guid categoryId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var dto = await categoryRepository.SelectByIdAsync(categoryId);

        if (dto.DeletedAt is null)
            throw new CustomException(400, "Category is not found");

        return mapper.Map<CategoryForResultDto>
            (await categoryRepository.DeleteAsync
            (categoryId, saveChanges, cancellationToken));
    }
}
