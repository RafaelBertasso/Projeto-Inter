using Microsoft.AspNetCore.Mvc;

public abstract class AgendamentoController : Controller
{
    public ActionResult Read()
    {
        return View();
    }
}