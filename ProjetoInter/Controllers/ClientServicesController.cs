using Microsoft.AspNetCore.Mvc;
using ProjetoInter.Models;

namespace ProjetoInter.Controllers;

public class ClientServicesController : Controller
{
    private readonly ServiceDatabase db;

    public ClientServicesController(ServiceDatabase db)
    {
        this.db = db;
    }

    public IActionResult Read()
    {
        var query = from client in db.Clients
            join clientService in db.ClientServices on client.UserId equals clientService.ClientId
            join service in db.Services on clientService.ServiceId equals service.ServiceId
        where client.UserId == clientService.ClientId
        where service.ServiceId == clientService.ServiceId
            select new ClientService
            {
                ClientId = client.UserId,
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
                DateTime = clientService.DateTime,
                Status = clientService.Status,
                Description = clientService.Description
            };

        return View(query.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(ClientService model)
    {
        db.ClientServices.Add(model);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        ClientService clientService = db.ClientServices.Single(e => e.ClientServiceId == id);
        return View(clientService);
    }

    [HttpPost]
    public ActionResult Update(int id, ClientService model)
    {
        ClientService clientService = db.ClientServices.Single(e => e.ClientServiceId == id);

        clientService.DateTime = model.DateTime;
        clientService.Status = model.Status;
        clientService.Description = model.Description;

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id)
    {
        ClientService clientService = db.ClientServices.Single(e => e.ClientServiceId == id);
        db.Remove(clientService);
        db.SaveChanges();

        return RedirectToAction("Read");
    }
}