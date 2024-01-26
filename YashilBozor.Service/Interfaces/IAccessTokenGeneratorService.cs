using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Service.Interfaces;

public interface IAccessTokenGeneratorService
{
    AccessToken GetToken(User user);

    Guid GetTokenId(string accessToken);
}