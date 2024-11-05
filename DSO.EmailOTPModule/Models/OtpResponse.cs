using DSO.EmailOTPModule.Models;
namespace DSO.EmailOTPModule.Models
{
    public class OtpResponse
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public string? Otp { get; set; }
    }
}
