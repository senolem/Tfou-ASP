using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using tfou.Models;

namespace tfou.Controllers;

public class AvatarXtremSurfeurController : Controller
{
    private readonly ILogger<AvatarXtremSurfeurController> _logger;


    public AvatarXtremSurfeurController(ILogger<AvatarXtremSurfeurController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Game()
    {
        var path = "/swf/avatar-xtrem/avatar-x-trem-surfeur-game-4-10627521tkycj.swf";
        return File(path, "application/x-shockwave-flash");
    }

    [Route("AvatarXtremSurfeur/Niveaux/{niveau}")]
    public IActionResult Niveaux(string niveau)
    {
        var path = "/swf/avatar-xtrem/niveaux/" + niveau;
        return File(path, "application/x-shockwave-flash");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
