using System.Linq.Expressions;
using System.Security.Cryptography;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Domain.Enums;
using YashilBozor.Service.Commons.Settings;
using YashilBozor.Service.Interfaces.Verifications;

namespace YashilBozor.Service.Services.Verifications;

public class UserInfoVerificationCodeService(
    IOptions<VerificationSettings> verificationSettings,
    IUserInfoVerificationCodeRepository userInfoVerificationCodeRepository
) : IUserInfoVerificationCodeService
{
    private readonly VerificationSettings _verificationSettings = verificationSettings.Value;

    public IQueryable<UserInfoVerificationCode> GetAll(Expression<Func<UserInfoVerificationCode, bool>> predicate) =>
        userInfoVerificationCodeRepository.SelectAll(predicate);
    public IList<string> Generate()
    {
        var codes = new List<string>();

        for (var index = 0; index < 10; index++)
            codes.Add(string.Join("", RandomNumberGenerator.GetBytes(_verificationSettings.VerificationCodeLength).Select(@char => @char % 10)));

        return codes;
    }

    public async ValueTask<(UserInfoVerificationCode Code, bool IsValid)> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var verificationCode = await userInfoVerificationCodeRepository.SelectAll(verificationCode => verificationCode.Code == code, true)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException();

        return (verificationCode, verificationCode.IsActive && verificationCode.ExpiryTime > DateTimeOffset.UtcNow);
    }

    public async ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default)
    {
        var verificationCode = await userInfoVerificationCodeRepository.SelectAll(verificationCode => verificationCode.Code == code, true)
            .Select(
                verificationCode => new
                {
                    verificationCode.Id,
                    verificationCode.Type
                }
            )
            .FirstOrDefaultAsync(cancellationToken);

        return verificationCode?.Type;
    }

    public async ValueTask<UserInfoVerificationCode> CreateAsync(
        VerificationCodeType codeType,
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        var verificationCodeValue = default(string);

        do
        {
            var verificationCodes = Generate();
            var existingCodes = await userInfoVerificationCodeRepository.SelectAll(code => verificationCodes.Contains(code.Code))
                .ToListAsync(cancellationToken);

            verificationCodeValue = verificationCodes.Except(existingCodes.Select(code => code.Code)).FirstOrDefault() ??
                                    throw new InvalidOperationException("Verification code generation failed.");
        } while (string.IsNullOrEmpty(verificationCodeValue));

        var verificationCode = new UserInfoVerificationCode
        {
            Code = verificationCodeValue,
            CodeType = codeType,
            UserId = userId,
            IsActive = true,
            VerificationLink = $"{_verificationSettings.VerificationLink}/{verificationCodeValue}",
            ExpiryTime = DateTimeOffset.UtcNow.AddSeconds(_verificationSettings.VerificationCodeExpiryTimeInSeconds)
        };

        await userInfoVerificationCodeRepository.InsertAsync(verificationCode, cancellationToken: cancellationToken);

        return verificationCode;
    }

    public async ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await userInfoVerificationCodeRepository.DeactivateAsync(codeId, cancellationToken: cancellationToken);
    }

}