using Microsoft.AspNetCore.Mvc;
using ProjetoInter.Models;

namespace ProjetoInter.Controllers;

public class UserController : Controller
{
    private readonly ServiceDatabase db;

    public UserController(ServiceDatabase db)
    {
        this.db = db;
    }

    public ActionResult Read()
    {
        return View(db.Users.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(User model)
    {
        db.Users.Add(model);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        User user = db.Users.Single(e => e.UserId == id);
        return View(user);
    }

    [HttpPost]
    public ActionResult Update(int id, User model)
    {
        User user = db.Users.Single(e => e.UserId == id);

        user.Name = model.Name;
        user.Gender = model.Gender;
        user.Email = model.Email;
        user.DateOfBirth = model.DateOfBirth;
        user.Phone = model.Phone;
        user.Password = model.Password;

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id)
    {
        User user = db.Users.Single(e => e.UserId == id);
        db.Remove(user);
        db.SaveChanges();

        return RedirectToAction("Read");
    }
}

