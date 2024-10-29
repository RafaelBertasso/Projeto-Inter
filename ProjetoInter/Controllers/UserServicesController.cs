using Microsoft.AspNetCore.Mvc;
using ProjetoInter.Models;

namespace ProjetoInter.Controllers;

public class UserServicesController : Controller
{
    private readonly ServiceDatabase db;

    public UserServicesController(ServiceDatabase db)
    {
        this.db = db;
    }

    public IActionResult Read()
    {
        return View(db.UserServices.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(UserService model)
    {
        db.UserServices.Add(model);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        UserService userService = db.UserServices.Single(e => e.UserServiceId == id);
        return View(userService);
    }

    [HttpPost]
    public ActionResult Update(int id, UserService model)
    {
        UserService userService = db.UserServices.Single(e => e.UserServiceId == id);

        userService.Budget = model.Budget;
        userService.DateTime = model.DateTime;
        userService.Status = model.Status;
        userService.Description = model.Description;

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id)
    {
        UserService userService = db.UserServices.Single(e => e.UserServiceId == id);
        db.Remove(userService);
        db.SaveChanges();

        return RedirectToAction("Read");
    }
}