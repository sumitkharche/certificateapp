using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace sZTP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VouchersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVoucherDetails()
        {
            return Ok("Test Voucher Details");
        }
    }
}
