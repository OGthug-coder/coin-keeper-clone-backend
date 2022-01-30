using Microsoft.AspNetCore.Mvc;

namespace coin_keeper_clone_backend.Home.Controllers;

[ApiController]
[Route("Home")]
public class HomeController : Controller
{
    [Route("index")]
    public JsonResult Index()
    {
        return Json(new { Name = "Guest", Output = true });
    }
}