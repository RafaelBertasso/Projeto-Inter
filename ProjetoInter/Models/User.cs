namespace ProjetoInter.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string DateOfBirth { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
     public string Street { get; set; }
     public string City { get; set; }
    public string District { get; set; }
    public int Number { get; set; }
    public string? Complement { get; set; }
    public string State { get; set; }
    public string Cep { get; set; }
}