using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoInter.Models;

[Table("User")]
public abstract class User
{
    [Key]
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}