namespace DSO.EmailOTPModule.Models
{
    public class OtpValidationRequest
    {
        public string OtpCode { get; set; }
        public string Email { get; set; }
        // Add other properties as needed
    }
}
