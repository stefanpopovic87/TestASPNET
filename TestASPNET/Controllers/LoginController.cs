using System.Linq;
using System.Web.Http;
using TestASPNET.Models;

namespace TestASPNET.Controllers
{
    public class LoginController : ApiController
    {
        private readonly AppDbContext _db = new AppDbContext();

        // Handles POST requests to api/login to authenticate a user
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(User login)
        {
            // Retrieve the user from the database based on the provided username and password
            var user = _db.Users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
            {
                // Return Unauthorized status if the user is not found
                return Unauthorized();
            }
            // Return a success message if the user is authenticated
            return Ok("Login successful");
        }
    }
}
