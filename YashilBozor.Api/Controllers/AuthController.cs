using Microsoft.AspNetCore.Mvc;
using YashilBozor.Api.Controllers.Common;
using YashilBozor.Domain.Configurations;
using YashilBozor.Service.DTOs.Users;
using YashilBozor.Service.Interfaces.Identity;
using YashilBozor.Service.Models;
using YashilBozor.Service.Services.Identity;

namespace YashilBozor.Api.Controllers;

public class AuthController(IAuthAggregationService authAggregationService, IUserService userService) : BaseController
{
    [HttpPost("sign-up")]
    public async ValueTask<IActionResult> SignUp([FromBody] SignUpDetails signUpDetails, [FromQuery]string code, CancellationToken cancellationToken)
    {
        var result = await authAggregationService.SignUpAsync(signUpDetails, code, cancellationToken);
        return result ? Ok() : BadRequest();
    }

    [HttpPost("sign-in")]
    public async ValueTask<IActionResult> SignIn([FromBody] SignInDetails signInDetails, CancellationToken cancellationToken)
    {
        var result = await authAggregationService.SignInAsync(signInDetails, cancellationToken);
        return result is not null ? Ok() : BadRequest();
    }


    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] PaginationParams @params, CancellationToken cancellationToken)
    {
        var result = await userService.GetAllAsync(@params, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await userService.GetByIdAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async ValueTask<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken)
    {
        var result = await userService.UpdateAsync(userForUpdateDto, id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }
}
