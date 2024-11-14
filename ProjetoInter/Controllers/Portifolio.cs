using Microsoft.AspNetCore.Mvc;

namespace ProjetoInter.Controllers;

public class PortifolioController : Controller
{
    private readonly ServiceDatabase db;

    public PortifolioController(ServiceDatabase db)
    {
        this.db = db;
    }

    public IActionResult Read()
    {
        var userId = HttpContext.Session.GetInt32("userId");

        ViewBag.Services = db.Services.ToList();
        ViewBag.UserId = userId;
        
        return View();
    }
}