using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeplicaBack.Logic;
using TeplicaBack.Models;

namespace TeplicaBack.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext userDb;
        private ControllersService controllersService;
        public HomeController(ILogger<HomeController> logger,ApplicationContext applicationContext, ControllersService controllersService)
        {
            _logger = logger;
            userDb = applicationContext;
            this.controllersService = controllersService;
        }
        
        public async Task<IActionResult> Index()
        {
            System.Security.Claims.ClaimsPrincipal user = HttpContext.User;
            string login = user.Identity.Name;
            var buyableData = await userDb.Controllers.Where(x=>x.UserLogin == null).ToListAsync();
            var userData = controllersService.AddAndGetAllControllers(await userDb.Controllers.Where(x => x.UserLogin == login).ToListAsync());
            IndexModel indexModel = new IndexModel();
            indexModel.buyableModels = buyableData;
            indexModel.userControllers = userData;
            return View(indexModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buy(string type, Guid id, float price)
        {
            var tmp = userDb.Controllers.FirstOrDefault(x => x.Id == id);
            if (tmp == null)
                return Redirect("/");
            tmp.UserLogin = HttpContext.User.Identity.Name;
            userDb.Controllers.Update(tmp);
            userDb.SaveChanges();
            return Redirect("/");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}