using System.Web.Mvc;
using TestASPNET.Models;
using System.Linq;
using System.Data.Entity;

namespace TestASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db = new AppDbContext();

        // Returns the login.html file as the response
        public ActionResult Login()
        {
            return File(Server.MapPath("~/Views/Home/login.html"), "text/html");
        }

        // Returns the main.html file as the response
        public ActionResult Main()
        {
            return File(Server.MapPath("~/Views/Home/main.html"), "text/html");
        }

        // Returns the projects.html file as the response
        public ActionResult ListProjects()
        {
            return File(Server.MapPath("~/Views/Home/projects.html"), "text/html");
        }

        // Retrieves a project by its ID and returns it as JSON
        public ActionResult GetProject(int id)
        {
            var project = _db.Projects.Include(p => p.SupportedImageType).SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return Json(project, JsonRequestBehavior.AllowGet);
        }
    }
}
