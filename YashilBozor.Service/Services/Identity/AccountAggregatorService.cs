using Microsoft.Extensions.Options;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Domain.Enums;
using YashilBozor.Service.Commons.Settings;
using YashilBozor.Service.Interfaces.Identity;
using YashilBozor.Service.Interfaces.Notifications.Services;
using YashilBozor.Service.Interfaces.Verifications;

namespace YashilBozor.Service.Services.Identity;

public class AccountAggregatorService(
    IUserService userService,
    IUserCreadentialsService userCreadentialsService,
    IUserInfoVerificationCodeService userInfoVerificationCodeService,
    IVerificationProcessingService verificationProcessingService,
    IEmailManagementService emailManagementService,
    IOptions<SmtpSettings> options
) : IAccountAggregatorService
{
    public async ValueTask<string> CreateUserAsync(User user, UserCreadentials userCreadentials,CancellationToken cancellationToken = default)
    {
        var createdUser = await userService.CreateAsync(user, cancellationToken: cancellationToken);

        userCreadentials.UserId = createdUser.Id;
        await userCreadentialsService.CreateAsync(userCreadentials, cancellationToken: cancellationToken);

        var verificationCode = await userInfoVerificationCodeService.CreateAsync(
            VerificationCodeType.EmailAddressVerification,
            createdUser.Id,
            cancellationToken
        );

        await emailManagementService.SendEmailAsync(options.Value.EmailAddress, createdUser.EmailAddress, "Welcome to our system", verificationCode.Code);

        return verificationCode.Code;
    }

    public async ValueTask<bool> VerifyEmail(string code, Guid userId, CancellationToken cancellationToken)
    {
        var isaVerified = userInfoVerificationCodeService.GetAll(verification => verification.UserId == userId).FirstOrDefault()
            .Code.Equals(code) 
            && await verificationProcessingService.Verify(code, cancellationToken);

        if (!isaVerified)
            await userService.DeleteAsync(userId, cancellationToken: cancellationToken);
        return isaVerified;
    }
}
