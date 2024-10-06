using Microsoft.AspNetCore.Mvc;
using ProjetoInter.Models;

namespace Projeto_Inter.Controllers;
public class ServiceController : Controller
{
    private readonly ServiceDatabase db;

    public ServiceController(ServiceDatabase db)
    {
        this.db = db;
    }

    public ActionResult Read()
    {
        return View(db.Services.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Service model)
    {
        db.Services.Add(model);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Service service = db.Services.Single(e => e.ServiceId == id);
        return View(service);
    }

    [HttpPost]
    public ActionResult Update(int id, Service model)
    {
        Service service = db.Services.Single(e => e.ServiceId == id);
        
        service.Description = model.Description;
        service.Name = model.Name;
        service.PathFoto = model.PathFoto;

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id)
    {
        Service service = db.Services.Single(e => e.ServiceId == id);
        db.Remove(service);
        db.SaveChanges();
        return RedirectToAction("Read");
    }
}