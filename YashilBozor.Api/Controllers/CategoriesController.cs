using Microsoft.AspNetCore.Mvc;
using YashilBozor.Api.Controllers.Common;
using YashilBozor.Domain.Configurations;
using YashilBozor.Service.DTOs.Categories;
using YashilBozor.Service.Interfaces.Categories;

namespace YashilBozor.Api.Controllers;

public class CategoriesController(ICategoryService categoryService) : BaseController
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] PaginationParams @params, CancellationToken cancellationToken)
    {
        var result = await categoryService.GetAllAsync(@params, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await categoryService.GetByIdAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] CategoryForCreationDto categoryForCreationDto, CancellationToken cancellationToken)
    {
        var result = await categoryService.CreateAsync(categoryForCreationDto, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async ValueTask<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] CategoryForUpdateDto categoryForUpdateDto, CancellationToken cancellationToken)
    {
        var result = await categoryService.UpdateAsync(categoryForUpdateDto, id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await categoryService.DeleteAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }
}
