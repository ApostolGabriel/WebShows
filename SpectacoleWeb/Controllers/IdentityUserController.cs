using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpectacoleWeb.Business_Logic;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Controllers
{
    public class IdentityUserController : Controller
    {
        private readonly IdentityUserService _identityUserService;

        public IdentityUserController(IdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        [Authorize(Roles = $"{Roles.Administrator}")]
        public IActionResult Index()
        {
            var users = _identityUserService.GetUsers();
            var roles = _identityUserService.GetUserRoles();
            return View(new MyViewModel(users, roles));
        }
    }
}
