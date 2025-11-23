using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksForUsers.Entities;

namespace TasksForUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private static List<Project> projects = new List<Project>
        {
            new Project { Id = 1, Name = "פרויקט דוגמא", Description = "תיאור", StartDate = DateTime.Now, Status = "Active" }
        };

        // GET: api/projects
        [HttpGet]
        public ActionResult<List<Project>> GetAll()
        {
            return Ok(projects);
        }

        // GET: api/projects/1
        [HttpGet("{id}")]
        public ActionResult<Project> GetById(int id)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return NotFound($"Project with ID {id} not found");

            return Ok(project);
        }

        // POST: api/projects
        [HttpPost]
        public ActionResult<Project> Create([FromBody] Project project)
        {
            project.Id = projects.Any() ? projects.Max(p => p.Id) + 1 : 1;
            projects.Add(project);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        // PUT: api/projects/1
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Project updatedProject)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return NotFound($"Project with ID {id} not found");

            project.Name = updatedProject.Name;
            project.Description = updatedProject.Description;
            project.StartDate = updatedProject.StartDate;
            project.EndDate = updatedProject.EndDate;
            project.Status = updatedProject.Status;

            return NoContent();
        }

        // DELETE: api/projects/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return NotFound($"Project with ID {id} not found");

            projects.Remove(project);
            return NoContent();
        }
    }
}
