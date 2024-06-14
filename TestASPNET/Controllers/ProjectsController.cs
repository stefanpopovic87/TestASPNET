using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using TestASPNET.Models;

namespace TestASPNET.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private readonly AppDbContext _db = new AppDbContext();

        // Handles GET requests to api/projects to retrieve all projects
        [HttpGet]
        public IHttpActionResult GetProjects()
        {
            // Retrieve all projects including their SupportedImageType and order by Id
            var projects = _db.Projects
                .Include(p => p.SupportedImageType)
                .OrderBy(x => x.Id)
                .ToList();
            return Ok(projects);
        }

        // Handles GET requests to api/projects/{id} to retrieve a specific project by Id
        [HttpGet]
        [Route("{id:int}", Name = "GetProjectById")]
        public IHttpActionResult GetProject(int id)
        {
            // Find the project by Id
            var project = _db.Projects.Find(id);
            if (project == null)
            {
                // Return 404 Not Found if the project does not exist
                return NotFound();
            }
            return Ok(project);
        }

        // Handles POST requests to api/projects to create a new project
        [HttpPost]
        public IHttpActionResult CreateProject(Project project)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate ProjectName
            if (string.IsNullOrWhiteSpace(project.ProjectName))
            {
                ModelState.AddModelError("ProjectName", "Project name is required.");
                return BadRequest(ModelState);
            }

            // Validate ProjectEnabled
            if (!project.ProjectEnabled)
            {
                ModelState.AddModelError("ProjectEnabled", "Project enabled is required and must be true by default.");
                return BadRequest(ModelState);
            }

            // Validate SupportedImageTypeId if AcceptingNewVisits is true
            if (project.AcceptingNewVisits && !project.SupportedImageTypeId.HasValue)
            {
                ModelState.AddModelError("SupportedImageTypeId", "Supported image type is required if accepting new visits is true.");
                return BadRequest(ModelState);
            }

            // Validate SupportedImageTypeId if provided
            if (project.SupportedImageTypeId.HasValue)
            {
                var supportedImageType = _db.SupportedImageTypes.Find(project.SupportedImageTypeId.Value);
                if (supportedImageType == null)
                {
                    ModelState.AddModelError("SupportedImageTypeId", "Invalid supported image type.");
                    return BadRequest(ModelState);
                }
            }

            // Add the new project to the database and save changes
            _db.Projects.Add(project);
            _db.SaveChanges();

            // Return the created project with a 201 status code
            return CreatedAtRoute("GetProjectById", new { id = project.Id }, project);
        }
    }
}
