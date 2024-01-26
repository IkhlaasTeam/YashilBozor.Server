using YashilBozor.Domain.Configurations;
using YashilBozor.Service.DTOs.Categories;

namespace YashilBozor.Service.Interfaces.Categories;

public interface ICategoryService
{
    ValueTask<IEnumerable<CategoryForResultDto>> GetAllAsync(
        PaginationParams @params,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<CategoryForResultDto?> GetByIdAsync(
        Guid categoryId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<CategoryForResultDto> CreateAsync(
        CategoryForCreationDto userForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<CategoryForResultDto> UpdateAsync(
        CategoryForUpdateDto userForUpdateDto,
        Guid categoryId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<CategoryForResultDto?> DeleteAsync(
        Guid categoryId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
