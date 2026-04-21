using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace resting_dotnet
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Models.Client client)
        {
            
            return Ok(client);
        }
    }
}

