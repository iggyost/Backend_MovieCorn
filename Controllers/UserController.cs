using Backend_MovieCorn.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MovieCorn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public static MovieCornDbContext context = new MovieCornDbContext();
        [HttpGet]
        [Route("get/{phone}")]
        public ActionResult<IEnumerable<User>> Get(string phone)
        {
            try
            {
                var user = context.Users.Where(x => x.Phone == phone).FirstOrDefault();
                if (user != null)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("enter/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> Enter(string phone, string password)
        {
            try
            {
                var user = context.Users.Where(x => x.Phone == phone && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Неверный пароль!");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("reg/{name}/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> RegUser(string name, string phone, string password)
        {
            try
            {
                var checkAvail = context.Users.Where(x => x.Phone == phone).FirstOrDefault();
                if (checkAvail == null)
                {
                    User user = new User()
                    {
                        Phone = phone,
                        Password = password,
                        Name = name,
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Пользователь с таким номером уже есть");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
