using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksForUsers.Entities;

namespace TasksForUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "יוסי כהן", Email = "yossi@example.com", Role = "Admin", CreatedAt = DateTime.Now },
            new User { Id = 2, Name = "שרה לוי", Email = "sara@example.com", Role = "Member", CreatedAt = DateTime.Now }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(users);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound($"User with ID {id} not found");

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            // יצירת ID חדש
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            user.CreatedAt = DateTime.Now;

            users.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound($"User with ID {id} not found");

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound($"User with ID {id} not found");

            users.Remove(user);
            return NoContent();
        }
    }
}
