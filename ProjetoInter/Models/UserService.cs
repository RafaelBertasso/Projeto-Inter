namespace ProjetoInter.Models;

public class UserService
{
    public int UserServiceId { get; set; }
    public int ClientId { get; set; }
    public int ServiceId { get; set; }
    public DateTime DateTime { get; set; }
    public string ServiceName { get; set; }
    public int Status { get; set; }
    public string Description { get; set; }
    public Client Client { get; set; }
    public Service Service { get; set; }
}