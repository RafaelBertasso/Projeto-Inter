namespace ProjetoInter.Models;

public class UserService
{
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public float Budget { get; set; }
    public DateTime DateTime { get; set; }
    public int Status { get; set; }
    public string Description { get; set; }
}