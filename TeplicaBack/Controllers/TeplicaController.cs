using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeplicaBack.Logic;

namespace TeplicaBack.Controllers
{
    [Authorize]
    public class TeplicaController : Controller
    {
        private readonly ILogger<TeplicaController> _logger;

        private ControllersService controllersService;

        public TeplicaController(ILogger<TeplicaController> logger, ControllersService controllersService)
        {
            _logger = logger;
            this.controllersService = controllersService;
        }

        [HttpPost]
        public int Regroup(int group, Guid id)
        {
            controllersService.Regroup(id, group);
            return 0;
        }
        [HttpGet]
        public IActionResult ChangeProperties(Guid id)
        {
            var tmp = controllersService.FindControllerById(id);
            if (tmp == null) 
                return null;
            return View("Properties", tmp);
        }
        [HttpPost]
        public IActionResult ChangeProperties(params string[] properties)
        {
            controllersService.ChangeProperties(properties);
            return Redirect("/");
        }
        [HttpGet]
        public string Ping(Guid id, string value)
        {
            return controllersService.Ping(id,value);
        }
    }
}