using Microsoft.AspNetCore.Mvc;
using YashilBozor.Api.Controllers.Common;
using YashilBozor.Domain.Configurations;
using YashilBozor.Service.DTOs.Categories.Assets.ProductAssets;
using YashilBozor.Service.Interfaces.Categories.Assets;

namespace YashilBozor.Api.Controllers;

public class ProductAssetsController(IProductAssetService productAssetService) : BaseController
{
    [HttpGet("{product-id:guid}")]
    public async ValueTask<IActionResult> Get([FromRoute(Name = "product-id")] Guid productId, [FromQuery] PaginationParams @params, CancellationToken cancellationToken)
    {
        var result = await productAssetService.GetAllAsync(productId, @params, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpGet("{product-id:guid}/{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute(Name = "product-id")] Guid productId, 
        [FromRoute] Guid id, 
        CancellationToken cancellationToken)
    {
        var result = await productAssetService.GetByProductIdAsync(productId, id, cancellationToken: cancellationToken);

        return Ok(result);
    }


    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await productAssetService.GetByIdAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromForm] ProductAssetForCreationDto productAssetForCreationDto, CancellationToken cancellationToken)
    {
        var result = await productAssetService.CreateAsync(productAssetForCreationDto, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await productAssetService.DeleteAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }
}
