using DSO.EmailOTPModule.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace DSO.EmailOTPModule.Services
{
    public class OtpService
    {
        private readonly IConfiguration _configuration;
        private static readonly Dictionary<string, (string Otp, DateTime ExpiryTime)> _otpStore = new();

        public OtpService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public OtpResponse GenerateOtp(OtpRequest request)
        {
            string otp = new Random().Next(100000, 999999).ToString();
            var expiryTime = DateTime.Now.AddMinutes(5); // OTP expires in 5 minutes

            // Store OTP and expiry time in the dictionary
            _otpStore[request.Email] = (otp, expiryTime);

            bool isSent = SendEmailWithOtp(request.Email, otp);

            return new OtpResponse
            {
                Status = isSent ? "Success" : "Failed",
                Message = isSent ? $"OTP sent to {request.Email}" : "Failed to send OTP"
            };
        }

        public bool ValidateOtp(string email, string inputOtp)
        {
            // Check if the email exists in the store
            if (_otpStore.ContainsKey(email))
            {
                var (storedOtp, expiryTime) = _otpStore[email];

                // Validate if the OTP matches and is not expired
                if (storedOtp == inputOtp && DateTime.Now <= expiryTime)
                {
                    _otpStore.Remove(email); // Remove OTP after successful validation
                    return true;
                }
            }

            return false;
        }
        public async Task<OtpResponse> GenerateOtpAsync(OtpRequest request)
        {
            string otp = new Random().Next(100000, 999999).ToString();
            var expiryTime = DateTime.Now.AddMinutes(5); // OTP expires in 5 minutes

            // Store OTP and expiry time in the dictionary
            _otpStore[request.Email] = (otp, expiryTime);

            bool isSent = await SendEmailWithOtpAsync(request.Email, otp);

            return new OtpResponse
            {
                Status = isSent ? "Success" : "Failed",
                Message = isSent ? $"OTP sent to {request.Email}" : "Failed to send OTP"
            };
        }
         private async Task<bool> SendEmailWithOtpAsync(string email, string otp)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");
                string host = smtpSettings["Host"];
                int port = int.Parse(smtpSettings["Port"]);
                bool enableSsl = bool.Parse(smtpSettings["EnableSsl"]);
                string username = smtpSettings["Username"];
                string password = smtpSettings["Password"];

                using (var client = new SmtpClient(host, port))
                {
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = enableSsl;

                    var mail = new MailMessage
                    {
                        From = new MailAddress(username),
                        Subject = "Your OTP Code",
                        Body = $"Your OTP is: {otp}",
                        IsBodyHtml = false
                    };
                    mail.To.Add(email);

                    await Task.Run(() => client.Send(mail)); // Simulate asynchronous behavior
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }

        private bool SendEmailWithOtp(string email, string otp)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");
                string host = smtpSettings["Host"];
                int port = int.Parse(smtpSettings["Port"]);
                bool enableSsl = bool.Parse(smtpSettings["EnableSsl"]);
                string username = smtpSettings["Username"];
                string password = smtpSettings["Password"];

                using (var client = new SmtpClient(host, port))
                {
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = enableSsl;

                    var mail = new MailMessage
                    {
                        From = new MailAddress(username),
                        Subject = "Your OTP Code",
                        Body = $"Your OTP is: {otp}",
                        IsBodyHtml = false
                    };
                    mail.To.Add(email);

                    client.Send(mail);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
    }
}
