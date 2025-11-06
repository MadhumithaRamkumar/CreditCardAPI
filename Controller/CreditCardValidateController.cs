using CreditCardAPI.Models;
using CreditCardAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardValidateController : ControllerBase
    {

        private readonly ILuhnService _luhnService;

        private readonly ILogger<CreditCardValidateController> _logger;

        public CreditCardValidateController(ILuhnService luhnService,ILogger<CreditCardValidateController> logger)
        {
            _luhnService = luhnService;
            _logger = logger;
        }

        [HttpPost]

        public IActionResult CreditCardValidate([FromBody] CreditCardReq req)
        {
            _logger.LogInformation("Entered the CreditCardValidate Controller");

            if (req == null || string.IsNullOrWhiteSpace(req.CardNumber))
                return BadRequest(new { error = "Credit card number is Empty" });

            try
            {
                _logger.LogInformation("Entered the try block for CreditCardValidate Controller");

                CreditCardResp resp = _luhnService.IsValid(req.CardNumber);

                return Ok(resp);
                
            }

            catch (Exception ex) {

                _logger.LogError(ex, "Error validating card number");
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
    }
}
