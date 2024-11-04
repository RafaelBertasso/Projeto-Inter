using Microsoft.AspNetCore.Mvc;

namespace ProjetoInter.Controllers;

public class IndexController : Controller
{
    private readonly ServiceDatabase db;

    public IndexController(ServiceDatabase db)
    {
        this.db = db;
    }

    public IActionResult Read()
    {
        return View();
    }
}