using Microsoft.AspNetCore.Mvc;
using ProjetoInter.Models;

namespace ProjetoInter.Controllers;

public class EmployeeController : Controller
{
    private readonly ServiceDatabase db;

    public EmployeeController(ServiceDatabase db)
    {
        this.db = db;
    }


    public IActionResult Read()
    {
        return View(db.Employees.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        bool isLoggedIn = HttpContext.Session.GetInt32("UserId") != null;
        ViewBag.isLoggedIn = isLoggedIn;
        return View();
    }

    [HttpPost]
    public ActionResult Create(Employee model)
    {
        db.Employees.Add(model);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Employee employee = db.Employees.Single(e => e.UserId == id);
        return View(employee);
    }

    [HttpPost]
    public ActionResult Update(int id, Employee model)
    {
        Employee employee = db.Employees.Single(e => e.UserId == id);

        employee.Name = model.Name;
        employee.Email = model.Email;
        employee.Password = model.Password;

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id)
    {
        Employee employee = db.Employees.Single(e => e.UserId == id);
        db.Remove(employee);
        db.SaveChanges();

        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(EmployeeViewModel model)
    {
        var employee = db.Employees.SingleOrDefault(e => e.Email == model.Email && e.Password == model.Password);

        if (employee == null)
        {
            ViewBag.Autenticado = false;
            return View(model);
        }
        else
        {
            HttpContext.Session.SetInt32("userId", employee.UserId);
            HttpContext.Session.SetString("userName", employee.Name);
            return RedirectToAction("Read", "Menu");
        }
    }
}