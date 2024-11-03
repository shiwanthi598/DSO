using System.Threading.Tasks;

namespace DSO.EmailOTPModule.Utilities
{
    public static class EmailSender
    {
        public static async Task<bool> SendEmailAsync(string emailAddress, string emailBody)
        {
            // Simulate email sending. Replace with actual email sending logic.
            // In a real app, use an SMTP client or email service API (e.g., SendGrid).
            await Task.Delay(500);
            return true; // Return false to simulate email sending failure.
        }
    }
}
