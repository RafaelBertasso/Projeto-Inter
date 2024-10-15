namespace ProjetoInter.Models;

public class UserService
{
    public int UserServiceId { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public float Budget { get; set; }
    public DateTime DateTime { get; set; }
    public int Status { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public Service Service { get; set; }
}