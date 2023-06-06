using Data;
using Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proiect__EF___Web_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public SeedController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }
        /// <summary>
        /// Intilizeaza DB
        /// </summary>
        [HttpPost("seed")]
        public void Seed() =>
            dal.Seed();

    }
}
