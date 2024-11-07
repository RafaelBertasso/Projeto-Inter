using Microsoft.AspNetCore.Mvc;

namespace ProjetoInter.Controllers;

public class IndexController : Controller
{

    public IActionResult Read()
    {
        return View();
    }
}