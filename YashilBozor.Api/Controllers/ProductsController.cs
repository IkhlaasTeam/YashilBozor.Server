using Microsoft.AspNetCore.Mvc;
using YashilBozor.Api.Controllers.Common;
using YashilBozor.Domain.Configurations;
using YashilBozor.Service.DTOs.Categories.Products;
using YashilBozor.Service.Interfaces.Categories;

namespace YashilBozor.Api.Controllers;

public class ProductsController(IProductService productService) : BaseController
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params,
        CancellationToken cancellationToken)
    {
        var result = await productService.GetAllAsync(@params, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetByIdAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var result = await productService.GetByIdAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] ProductForCreationDto productForCreationDto,
        CancellationToken cancellationToken)
    {
        var result = await productService.CreateAsync(productForCreationDto,
            cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async ValueTask<IActionResult> UpdateAsync([FromRoute] Guid id,
        [FromBody] ProductForUpdateDto productForUpdateDto,
        CancellationToken cancellationToken)
    {
        var result = await productService.UpdateAsync(productForUpdateDto,
            id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var result = await productService.DeleteAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }
}
