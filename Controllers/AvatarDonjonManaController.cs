using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using tfou.Models;

namespace tfou.Controllers;

public class AvatarDonjonManaController : Controller
{
    private readonly ILogger<AvatarDonjonManaController> _logger;


    public AvatarDonjonManaController(ILogger<AvatarDonjonManaController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Game()
    {
        var path = "/swf/avatar-donjon-mana/avatar-donjon-mana-game-10605328nmevw.swf";
        return File(path, "application/x-shockwave-flash");
    }

    [Route("AvatarDonjonMana/Niveaux/{niveau}")]
    public IActionResult Niveaux(string niveau)
    {
        var path = "/swf/avatar-donjon-mana/niveaux/" + niveau;
        return File(path, "application/x-shockwave-flash");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
