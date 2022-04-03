using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Billet.Server.Models.Clients;

namespace Billet.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public Task<IEnumerable<Server.Models.Clients.Client>> List()
        {
            throw new NotImplementedException();
        }
    }
}
