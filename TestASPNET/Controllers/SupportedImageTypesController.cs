using System.Linq;
using System.Web.Http;
using TestASPNET.Models;

namespace TestASPNET.Controllers
{
    public class SupportedImageTypesController : ApiController
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        [Route("api/supportedImageTypes")]
        public IHttpActionResult GetSupportedImageTypes()
        {
            var supportedImageTypes = _db.SupportedImageTypes.ToList();
            return Ok(supportedImageTypes);
        }
    }
}
