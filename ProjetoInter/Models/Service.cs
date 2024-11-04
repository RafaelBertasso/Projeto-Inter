namespace ProjetoInter.Models;

public class Service
{
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PathFoto { get; set; }
    public string Duration { get; set; }

    // public ICollection<Client> Clients { get; set; } = new List<Client>();
}