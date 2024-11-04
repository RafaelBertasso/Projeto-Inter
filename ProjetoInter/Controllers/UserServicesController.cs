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
        var query = from client in db.Clients
            join userService in db.UserServices on client.ClientId equals userService.ClientId
            join service in db.Services on userService.ServiceId equals service.ServiceId
        where client.UserId == userService.ClientId
        where service.ServiceId == userService.ServiceId
            select new UserService
            {
                ClientId = client.ClientId,
                Client = new Client
                {
                    Name = client.Name,
                    Email = client.Email,
                    Phone = client.Phone,
                    DateOfBirth = client.DateOfBirth,
                    Password = client.Password,
                    Gender = client.Gender,
                    Street = client.Street,
                    City = client.City,
                    State = client.State,
                    District = client.District,
                    Number = client.Number,
                    Complement = client.Complement,
                    Cep = client.Cep    
                },

                Service = new Service
                {
                    Name = service.Name,
                    Description = service.Description,
                    PathFoto = service.PathFoto,
                    Duration = service.Duration
                },
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