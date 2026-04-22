using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace resting_dotnet
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Context.ClientDbContext _context;

        public ClientController(Context.ClientDbContext context)
        {
            _context = context;
        }
    }
}

