using Microsoft.AspNetCore.Mvc;
using DSO.EmailOTPModule.Services;
using DSO.EmailOTPModule.Models;
using System.Threading.Tasks;

namespace DSO.EmailOTPModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpController : ControllerBase
    {

        private readonly OtpService _otpService;

    public OtpController(OtpService otpService)
    {
        _otpService = otpService;
    }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateOtpAsync([FromBody] OtpRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                return BadRequest("Email is required.");
            }

            var response = await _otpService.GenerateOtpAsync(request);
            return Ok(response);
        }

        [HttpPost("verify")]
        public ActionResult<OtpResponse> VerifyOtp([FromBody] OtpRequest request, [FromQuery] string otp)
        {
            var result = _otpService.ValidateOtp(request.Email, otp);
            return Ok(new OtpResponse { Status =Convert.ToString(result) });
        }
    }
}
