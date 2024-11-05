using DSO.EmailOTPModule.Models;
namespace DSO.EmailOTPModule.Services
{
    public interface IOtpService
    {
        Task<OtpResponse> GenerateOtpAsync(OtpRequest request);
        Task<OtpResponse> ValidateOtpAsync(OtpValidationRequest request);
    }
}
