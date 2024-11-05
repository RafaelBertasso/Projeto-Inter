using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoInter.Models;

[Table("Employee")]
public class Employee : User
{
    //public ICollection<User> Users { get; set; } = new List<User>();
}