using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TasksForUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<Entities.Task> tasks = new List<Entities.Task>
        {
            new Entities.Task
            {
                Id = 1,
                Title = "משימה ראשונה",
                Description = "תיאור המשימה",
                ProjectId = 1,
                Status = "Pending",
                Priority = "High",
                DueDate = DateTime.Now.AddDays(7),
                CreatedAt = DateTime.Now
            }
        };

        // GET: api/tasks
        [HttpGet]
        public ActionResult<List<Entities.Task>> GetAll()
        {
            return Ok(tasks);
        }

        // GET: api/tasks/1
        [HttpGet("{id}")]
        public ActionResult<Entities.Task> GetById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with ID {id} not found");

            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public ActionResult<Entities.Task> Create([FromBody] Entities.Task task)
        {
            task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            task.CreatedAt = DateTime.Now;

            tasks.Add(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        // PUT: api/tasks/1
        [HttpPut("{id}")]
        public ActionResult Update(int id,[FromBody] Entities.Task updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with ID {id} not found");

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.ProjectId = updatedTask.ProjectId;
            task.AssignedToUserId = updatedTask.AssignedToUserId;
            task.Status = updatedTask.Status;
            task.Priority = updatedTask.Priority;
            task.DueDate = updatedTask.DueDate;

            return NoContent();
        }

        // DELETE: api/tasks/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with ID {id} not found");

            tasks.Remove(task);
            return NoContent();
        }
        
        // PUT: api/tasks/1/status - פעולה נוספת
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with ID {id} not found");

            task.Status = status;
            return NoContent();
        }
    }
}
