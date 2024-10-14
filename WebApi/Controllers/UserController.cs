using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRouteResponses.Context;
using WebApiRouteResponses.Models;

namespace WebApiRouteResponses.Controllers
{
    // [Authorize]
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")] // Cambia el prefijo para evitar confusión
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _apiDbContext;

        public UserController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
            _apiDbContext.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("GetRoles")]
        public ActionResult<IEnumerable<object>> GetRoles()
        {
            var rolesWithUsers = _apiDbContext.UserRoles
                .Include(ur => ur.User)
                .Select(ur => new
                {
                    ur.Id,
                    ur.Role,
                    ur.Active,
                    User = new
                    {
                        ur.User!.Id,
                        ur.User.Name,
                        ur.User.LastName,
                        ur.User.Age,
                        ur.User.Active
                    }
                })
                .ToList();

            return Ok(rolesWithUsers); // Devuelve los roles junto con los detalles del usuario
        }

        [ResponseCache(Duration = 60)]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            // Obtiene los usuarios junto con sus roles
            var users = _apiDbContext.Users
                .Include(u => u.UserRoles) // Incluye los roles de usuario
                .ToList(); // Carga todos los usuarios en una lista

            return users; // Devuelve la lista de usuarios
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            _ = Guid.TryParse(id, out Guid userId);
            if (userId != Guid.Empty) // Si no es un GUID válido
            {
                var foundUser = _apiDbContext.Users
                    .Include(u => u.UserRoles) // Incluye los roles de usuario
                    .FirstOrDefault(u => u.Id == userId);
                if (foundUser != null)
                {
                    return Ok(foundUser);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            _apiDbContext.Users.Add(user);
            await _apiDbContext.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            _ = Guid.TryParse(id, out Guid userId);
            var foundUser = _apiDbContext.Users.FirstOrDefault(u => u.Id == userId);

            if (foundUser != null)
            {
                foundUser.Name = user.Name;
                foundUser.LastName = user.LastName;
                foundUser.Active = user.Active;
                foundUser.Age = user.Age;

                _apiDbContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            _ = Guid.TryParse(id, out Guid userId);
            if (userId != Guid.Empty)
            {
                var foundUser = _apiDbContext.Users.FirstOrDefault(u => u.Id == userId);
                _apiDbContext.Users.Remove(foundUser!);
                await _apiDbContext.SaveChangesAsync();
            }
        }
    }
}
