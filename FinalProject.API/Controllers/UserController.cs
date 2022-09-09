using FinalProject.Application.Services.Interfaces;
using FinalProject.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinalProject.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        //
        [HttpPost("create")]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.Create(user);
            return Ok();
        }

    }
}
