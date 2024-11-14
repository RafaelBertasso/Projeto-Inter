using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoInter.Models;

namespace ProjetoInter.Controllers;

public class ClientController : Controller
{
    private readonly ServiceDatabase db;
    private readonly HttpClient httpClient;

    public ClientController(ServiceDatabase db, IHttpClientFactory httpClientFactory)
    {
        this.db = db;
        httpClient = httpClientFactory.CreateClient();
    }

    public IActionResult Read()
    {
        return View(db.Clients.ToList());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Client model)
    {
        db.Clients.Add(model);
        db.SaveChanges();
        return RedirectToAction("Read", "Client");
    }


    [HttpGet]
    public ActionResult CreateLogin()
    {
        return View();
    }

    [HttpPost]
    public ActionResult CreateLogin(Client model)
    {
        db.Clients.Add(model);
        db.SaveChanges();
        return RedirectToAction("Login", "Client");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Client client = db.Clients.Single(e => e.UserId == id);
        return View(client);
    }

    [HttpPost]
    public ActionResult Update(int id, Client model)
    {
        Client client = db.Clients.Single(e => e.UserId == id);

        client.Name = model.Name;
        client.Email = model.Email;
        client.DateOfBirth = model.DateOfBirth;
        client.Phone = model.Phone;
        client.Password = model.Password;
        client.City = model.City;
        client.Street = model.Street;
        client.District = model.District;
        client.Number = model.Number;
        client.Complement = model.Complement;
        client.State = model.State;
        client.Cep = model.Cep;

        db.SaveChanges();
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id)
    {
        Client client = db.Clients.Single(e => e.UserId == id);
        db.Remove(client);
        db.SaveChanges();

        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(ClientViewModel model)
    {
        var client = db.Clients.Where(e => e.Email == model.Email && e.Password == model.Password)
        .FirstOrDefault();

        if (client == null)
        {
            ViewBag.Autenticado = false;
            return View(model);
        }
        else
        {
            HttpContext.Session.SetInt32("userId", client.UserId);
            HttpContext.Session.SetString("userName", client.Name);
            return RedirectToAction("Read", "Portifolio");
        }
    }

    [HttpGet]
    public async Task<IActionResult> BuscarCep(string cep)
    {
        if (string.IsNullOrEmpty(cep) || cep.Length != 8)
        {
            return BadRequest("CEP inválido.");
        }

        string apiUrl = $"https://example.api.findcep.com/v1/cep/{cep}.json";
        httpClient.DefaultRequestHeaders.Add("Referer", "http://localhost:5285");

        try
        {
            var response = await httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Erro na consulta do CEP");
            }

            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }
        catch
        {
            return BadRequest("Erro na consulta do CEP");
        }
    }

}