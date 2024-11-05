using Xunit;
using Moq;
using DSO.EmailOTPModule.Services;
using DSO.EmailOTPModule.Models;

namespace DSO.EmailOTPModule.Tests
{
    public class OtpServiceTests
    {
        [Fact]
        public async Task GenerateOtpAsync_ShouldReturnOtpResponse()
        {
            var service = new OtpService();
            var request = new OtpRequest { Email = "test@example.com" };

            var response = await service.GenerateOtpAsync(request);

            Assert.NotNull(response);
            Assert.Equal("Success", response.Status);
        }

        [Fact]
        public void ValidateOtp_ShouldReturnTrue_WhenValid()
        {
            var service = new OtpService();
            var request = new OtpRequest { Email = "test@example.com" };
            var otpResponse = service.GenerateOtpAsync(request).Result;

            var result = service.ValidateOtp(request.Email, otpResponse.Otp);

            Assert.True(result);
        }
    }
}
