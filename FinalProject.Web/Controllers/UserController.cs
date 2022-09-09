using FinalProject.Application.Services.Interfaces;
using FinalProject.Data;
using FinalProject.Domain.Users;
using Microsoft.AspNetCore.Mvc;


namespace FinalProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserService userService,IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult List()
        {
            var users = _userService.List();
            return View(users);
        }
        
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Create(user);
                TempData["Create"] = "User created successfully...";
                return RedirectToAction("List");
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _userService.Get(id);
            return View(user);

        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            
            if (ModelState.IsValid)
            {
                _userService.Edit(user);
               
                //User editedUser = _unitOfWork.Users.Find(user.Id);
                //editedUser.Username = user.Username;
                //editedUser.Email = user.Email;
                //editedUser.Password = user.Password;
                return RedirectToAction("List");

            }
            return BadRequest("eksik bilgi girdiniz");
        }

        public IActionResult Delete(int id)
        {

            _userService.Delete(id);
            TempData["Delete"] = "User deleted successfully...";
            return RedirectToAction("List");
        }

        public IActionResult ChangeStatus(int id)
        {
            _userService.ChangeStatus(id);
            return RedirectToAction("List");
        }
        
        

    }
}
