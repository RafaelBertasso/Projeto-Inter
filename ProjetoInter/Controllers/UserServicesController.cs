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
        var query = from user in db.Users
            join userService in db.UserServices on user.UserId equals userService.UserId
            join service in db.Services on userService.ServiceId equals service.ServiceId
        where user.UserId == userService.UserId
        where service.ServiceId == userService.ServiceId
            select new UserService
            {
                UserId = user.UserId,
                User = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    DateOfBirth = user.DateOfBirth,
                    Password = user.Password,
                    Gender = user.Gender,
                    Street = user.Street,
                    City = user.City,
                    State = user.State,
                    District = user.District,
                    Number = user.Number,
                    Complement = user.Complement,
                    Cep = user.Cep    
                },

                Service = new Service
                {
                    Name = service.Name,
                    Description = service.Description,
                    PathFoto = service.PathFoto,
                    Duration = service.Duration
                },
                Budget = userService.Budget,
                DateTime = userService.DateTime,
                Status = userService.Status,
                Description = userService.Description
            };

        return View(query.ToList());
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