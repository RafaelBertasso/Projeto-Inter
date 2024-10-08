using Microsoft.AspNetCore.Mvc;

namespace ProjetoInter.Controllers;
public class MenuController : Controller
{
    public ActionResult Read()
    {
        return View();
    }
}