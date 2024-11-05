using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DSO.EmailOTPModule.Controllers; // Adjust if necessary
using DSO.EmailOTPModule.Models; // Adjust if necessary
using DSO.EmailOTPModule.Services; // This should include IOtpService

namespace DSO.EmailOTPModule.Tests
{
    public class OtpControllerTests
    {
        private readonly OtpController _controller;
        private readonly Mock<IOtpService> _mockOtpService; // Change to use IOtpService

        public OtpControllerTests()
        {
            _mockOtpService = new Mock<IOtpService>(); // Change to use IOtpService
            _controller = new OtpController(_mockOtpService.Object);
        }

        [Fact]
        public async Task GenerateOtpAsync_ValidEmail_ReturnsOk()
        {
            // Arrange
            var request = new OtpRequest { Email = "test@example.com" };
            _mockOtpService.Setup(s => s.GenerateOtpAsync(request)).ReturnsAsync(new OtpResponse { Status = "Success", Message = "OTP sent successfully." });

            // Act
            var result = await _controller.GenerateOtpAsync(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<OtpResponse>(okResult.Value);
            Assert.Equal("Success", response.Status);
            Assert.Equal("OTP sent successfully.", response.Message);
        }
    }
}
