using AutoMapper;
using System.Security.Authentication;
using System.Threading;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.Interfaces.Identity;
using YashilBozor.Service.Models;

namespace YashilBozor.Service.Services.Identity;

public class AuthAggregationService(
    IMapper mapper,
    IAccessTokenService accessTokenService,
    IAccessTokenGeneratorService accessTokenGeneratorService,
    IPasswordHasherService passwordHasherService,
    IAccountAggregatorService accountAggregatorService,
    IUserService userService,
    IUserCreadentialsService userCreadentialsService
) : IAuthAggregationService
{
    public async ValueTask<string> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        var foundUserId = await userService.GetIdByEmailAddressAsync(signUpDetails.EmailAddress, cancellationToken);

        if (foundUserId.HasValue)
            throw new InvalidOperationException("User already exists");

        
        var user = mapper.Map<User>(signUpDetails);

        var userCreadentials = new UserCreadentials 
        {
            Password = passwordHasherService.HashPassword(signUpDetails.Password),
        };

        return await accountAggregatorService.CreateUserAsync(user, userCreadentials, cancellationToken);
    }

    public async ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellation = default)
    {
        var foundUserId = await userService.GetIdByEmailAddressAsync(signInDetails.EmailAddress, cancellation) ?? throw new AuthenticationException("Email is invalid");

        var foundCreadentials = await userCreadentialsService.GetByUserIdAsync(foundUserId, cancellationToken: cancellation);

        var foundUser = await userService.GetByIdAsync(foundUserId, cancellationToken: cancellation);

        if (!passwordHasherService.ValidatePassword(signInDetails.Password, foundCreadentials.Password))
        {
            throw new AuthenticationException("Password is invalid");
        }

        var token = accessTokenGeneratorService.GetToken(foundUser);
        token.UserId = foundUser.Id;

        await accessTokenService.CreateAsync(token, cancellationToken: cancellation);

        return token.Token;
    }
}