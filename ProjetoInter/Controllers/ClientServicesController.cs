using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                        ServiceId = service.ServiceId,
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

    public ActionResult ReadEmployee()
    {
        var query = from client in db.Clients
                    join clientService in db.ClientServices on client.UserId equals clientService.ClientId
                    join service in db.Services on clientService.ServiceId equals service.ServiceId
                    where client.UserId == clientService.ClientId
                    where service.ServiceId == clientService.ServiceId
                    select new ClientService
                    {

                        Client = new Client
                        {
                            UserId = client.UserId,
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

    private List<TimeSpan> AvaliableTimes(DateTime date)
    {
        var times = new List<TimeSpan>();
        TimeSpan startTime = TimeSpan.FromHours(8);
        TimeSpan endTime = TimeSpan.FromHours(17.5);

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            return times;
        }

        while (startTime <= endTime)
        {
            times.Add(startTime);
            startTime = startTime.Add(TimeSpan.FromMinutes(30));
        }
        return times;
    }


    [HttpGet]
    public ActionResult Create()
    {
        var model = new ClientServiceViewModel();
        ViewBag.Services = db.Services.ToList();
        ViewBag.AvaliableTimes = new List<TimeSpan>();

        return View(model);
    }

    [HttpPost]
    public ActionResult LoadTime(ClientServiceViewModel model)
    {
        ViewBag.Services = db.Services.ToList();

        if (model.DateTime != null)
        {

            var allTimes = AvaliableTimes(model.DateTime);

            var occupiedTimes = db.ClientServices
            .Where(cs => cs.DateTime.Date == model.DateTime.Date)
            .Select(cs => cs.DateTime.TimeOfDay)
            .ToList();

            ViewBag.AvaliableTimes = allTimes.Except(occupiedTimes).ToList();
        }
        else
        {
            ViewBag.AvaliableTimes = new List<TimeSpan>();
        }
        return View("Create",model);
    }

    [HttpPost]
    public ActionResult Create(ClientServiceViewModel model)
    {

        if (ModelState.IsValid)
        {
            return View(model);
        }

        if (model.DateTime.DayOfWeek == DayOfWeek.Saturday || model.DateTime.DayOfWeek == DayOfWeek.Sunday)
        {
            ModelState.AddModelError("", "Não é possível agendar nos finais de semana");
            return View(model);
        }

        var existsAppointment = db.ClientServices.Any(cs => cs.DateTime == model.DateTime);

        if (existsAppointment)
        {
            ModelState.AddModelError("", "O horário selecionado já está ocupado");
            return View(model);
        }
        var serviceId = model.ServiceId;

        var modelBase = (ClientService)model;

        modelBase.DateTime = model.DateTime + model.Time.TimeOfDay;
        db.ClientServices.Add(modelBase);
        Console.WriteLine(modelBase);
        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult GetServices()
    {
        return RedirectToAction("Create", "ClientService");
    }
    [HttpGet]
    public ActionResult CreateEmployee(DateTime? date)
    {
        var model = new ClientService();

        ViewBag.Services = db.Services.ToList();

        if (date.HasValue)
        {
            var allTimes = AvaliableTimes(date.Value);

            var occupiedTimes = db.ClientServices
            .Where(cs => cs.DateTime.Date == date.Value.Date)
            .Select(cs => cs.DateTime.TimeOfDay)
            .ToList();

            ViewBag.AvaliableTimes = allTimes.Except(occupiedTimes).ToList();
        }
        else
        {
            ViewBag.AvaliableTimes = new List<TimeSpan>();
        }

        ViewBag.SelectedDate = date;
        return View(model);
    }

    [HttpPost]
    public ActionResult CreateEmployee(ClientService model)
    {
        if (ModelState.IsValid)
        {
            if (model.DateTime.DayOfWeek == DayOfWeek.Saturday || model.DateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", "Não é possível agendar nos finais de semana");
                return CreateEmployee(model.DateTime);
            }

            var existsAppointment = db.ClientServices.Any(cs => cs.DateTime == model.DateTime);

            if (existsAppointment)
            {
                ModelState.AddModelError("", "O horário selecionado já está ocupado");
                return CreateEmployee(model.DateTime);
            }
        }
        else
        {
            db.ClientServices.Add(model);
            db.SaveChanges();
            return RedirectToAction("Read");
        }
        return CreateEmployee(model.DateTime);
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
        if (ModelState.IsValid)
        {
            if (model.DateTime.DayOfWeek == DayOfWeek.Saturday || model.DateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", "Não é possível agendar nos finais de semana");
                return View(model);
            }

            var existsAppointment = db.ClientServices.Any(cs => cs.DateTime == model.DateTime && cs.ClientServiceId != id);

            if (existsAppointment)
            {
                ModelState.AddModelError("", "O horário selecionado já está ocupado");
                return View(model);
            }

            ClientService clientService = db.ClientServices.Single(e => e.ClientServiceId == id);

            clientService.DateTime = model.DateTime;
            clientService.Status = model.Status;
            clientService.Description = model.Description;

            db.SaveChanges();
            return RedirectToAction("Read");
        }
        return View(model);
    }

    public ActionResult Delete(int id)
    {
        ClientService clientService = db.ClientServices.Single(e => e.ClientServiceId == id);
        db.Remove(clientService);
        db.SaveChanges();

        return RedirectToAction("Read");
    }

}