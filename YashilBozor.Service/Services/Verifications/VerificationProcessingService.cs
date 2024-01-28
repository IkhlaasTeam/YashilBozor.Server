using YashilBozor.Domain.Enums;
using YashilBozor.Service.Interfaces.Identity;
using YashilBozor.Service.Interfaces.Verifications;

namespace YashilBozor.Service.Services.Verifications;

public class VerificationProcessingService(
    IUserInfoVerificationCodeService userInfoVerificationCodeService, 
    IUserService userService)
    : IVerificationProcessingService
{
    public async ValueTask<bool> Verify(string code, CancellationToken cancellationToken)
    {
        var codeType = await userInfoVerificationCodeService.GetVerificationTypeAsync(code, cancellationToken) ??
                       throw new InvalidOperationException("Verification code is not found.");

        //var result = codeType switch
        //{
        //    VerificationType.UserInfoVerificationCode => VerifyUserInfoAsync(code, cancellationToken) ,
        //   // _ => throw new NotSupportedException("Verification type is not supported.")
        //};
        var result = VerifyUserInfoAsync(code, cancellationToken);

        return await result;
    }

    private async ValueTask<bool> VerifyUserInfoAsync(string code, CancellationToken cancellationToken = default)
    {
        var userInfoVerificationCode = await userInfoVerificationCodeService.GetByCodeAsync(code, cancellationToken);

        if (!userInfoVerificationCode.IsValid) return false;

        var user = await userService.GetByIdAsync(userInfoVerificationCode.Code.UserId, cancellationToken: cancellationToken) ??
                   throw new InvalidOperationException();

        //switch (userInfoVerificationCode.Code.CodeType)
        //{
        //    case VerificationCodeType.EmailAddressVerification:
               
        //        break;
        //    default: throw new NotSupportedException();
        //}

        await userInfoVerificationCodeService.DeactivateAsync(userInfoVerificationCode.Code.Id, cancellationToken: cancellationToken);

        return true;
    }
}