using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IAccessTokenGeneratorService
{
    AccessToken GetToken(User user);

    Guid GetTokenId(string accessToken);
}